using System.Collections.Generic;
using MacroTools.Extensions;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.GameLogic.AssistedFollow;

/// <summary>
/// Replaces expensive moving-target follow orders with event-driven stable destinations.
/// </summary>
public static class AssistedFollowSystem
{
  private const int MaximumOrdersPerTick = 12;

  private static readonly Dictionary<unit, FollowGroup> _groupsByLeader = new();
  private static readonly Dictionary<unit, FollowerState> _statesByFollower = new();
  private static readonly Dictionary<unit, LeaderMovementOrder> _lastHeroMovementOrders = new();
  private static readonly Dictionary<unit, PendingBinding> _pendingBindingsByFollower = new();
  private static readonly List<PendingBinding> _pendingBindings = new();
  private static List<FollowerState> _pendingFollowerStates = new();
  private static readonly HashSet<unit> _internallyOrderedUnits = new();

  private static FollowOrderMode _mode = FollowOrderMode.StableDestination;
  private static bool _isSetup;
  private static int _activeFollowerCount;
  private static int _pendingFollowerStateIndex;

  /// <summary>The active implementation, exposed so the test harness can perform an A/B comparison.</summary>
  public static FollowOrderMode Mode
  {
    get => _mode;
    set
    {
      if (_mode == value)
      {
        return;
      }

      ResetTracking();
      _mode = value;
    }
  }

  /// <summary>The number of units currently bound to a friendly hero.</summary>
  public static int ActiveFollowerCount => _activeFollowerCount;

  /// <summary>Registers the order and lifecycle events used by the system.</summary>
  public static void Setup()
  {
    if (_isSetup)
    {
      return;
    }

    _isSetup = true;
    PlayerUnitEvents.Register(UnitTypeEvent.ReceivesTargetOrder, OnTargetOrder);
    PlayerUnitEvents.Register(UnitTypeEvent.ReceivesPointOrder, OnPointOrder);
    PlayerUnitEvents.Register(UnitTypeEvent.ReceivesOrder, OnImmediateOrder);
    PlayerUnitEvents.Register(UnitTypeEvent.Dies, OnUnitInvalidated);
    PlayerUnitEvents.Register(UnitTypeEvent.ChangesOwner, OnUnitInvalidated);
    PlayerUnitEvents.Register(UnitTypeEvent.IsRemoved, OnUnitInvalidated);
    PlayerUnitEvents.Register(UnitTypeEvent.IsLoaded, OnUnitLoaded);
    PeriodicEvents.AddPeriodicEvent(OnPeriodic, PeriodicEvents.SYSTEM_INTERVAL);
  }

  private static void OnTargetOrder()
  {
    var orderedUnit = @event.Unit;
    var issuedOrderId = @event.IssuedOrderId;
    var targetUnit = @event.OrderTargetUnit;

    if (_internallyOrderedUnits.Contains(orderedUnit))
    {
      return;
    }

    CancelPendingBinding(orderedUnit);
    DetachFollower(orderedUnit);
    _lastHeroMovementOrders.Remove(orderedUnit);

    if (_mode != FollowOrderMode.StableDestination || issuedOrderId != ORDER_SMART ||
        !IsFollowCandidate(orderedUnit, targetUnit))
    {
      return;
    }

    var pendingBinding = new PendingBinding(orderedUnit, targetUnit!);
    _pendingBindingsByFollower[orderedUnit] = pendingBinding;
    _pendingBindings.Add(pendingBinding);
  }

  private static void OnPointOrder()
  {
    var orderedUnit = @event.Unit;
    var issuedOrderId = @event.IssuedOrderId;
    var orderPointX = @event.OrderPointX;
    var orderPointY = @event.OrderPointY;

    if (_internallyOrderedUnits.Contains(orderedUnit))
    {
      return;
    }

    CancelPendingBinding(orderedUnit);
    DetachFollower(orderedUnit);

    if (_mode != FollowOrderMode.StableDestination)
    {
      _lastHeroMovementOrders.Remove(orderedUnit);
      return;
    }

    if (!orderedUnit.IsUnitType(unittype.Hero))
    {
      return;
    }

    // Shift-queued waypoints cannot be associated reliably with the active leg. Keep the
    // current stable destination instead of shortcutting the army to a later queued point.
    if (HasOrderQueuedBehindCurrent(orderedUnit))
    {
      _lastHeroMovementOrders.Remove(orderedUnit);
      return;
    }

    if (!FollowOrderClassifier.TryGetMirroredPointOrder(issuedOrderId, out var mirroredOrderId))
    {
      _lastHeroMovementOrders.Remove(orderedUnit);
      return;
    }

    var movementOrder = new LeaderMovementOrder(issuedOrderId, mirroredOrderId, orderPointX, orderPointY);
    _lastHeroMovementOrders[orderedUnit] = movementOrder;

    if (_groupsByLeader.TryGetValue(orderedUnit, out var group))
    {
      QueuePointOrder(group, movementOrder);
    }
  }

  private static void OnImmediateOrder()
  {
    var orderedUnit = @event.Unit;
    var issuedOrderId = @event.IssuedOrderId;

    if (_internallyOrderedUnits.Contains(orderedUnit))
    {
      return;
    }

    CancelPendingBinding(orderedUnit);
    DetachFollower(orderedUnit);
    _lastHeroMovementOrders.Remove(orderedUnit);

    if (orderedUnit.IsUnitType(unittype.Hero) && HasOrderQueuedBehindCurrent(orderedUnit))
    {
      return;
    }

    if (_mode == FollowOrderMode.StableDestination &&
        FollowOrderClassifier.IsMirroredImmediateOrder(issuedOrderId) &&
        _groupsByLeader.TryGetValue(orderedUnit, out var group))
    {
      QueueImmediateOrder(group, issuedOrderId);
    }
  }

  private static void OnUnitInvalidated()
  {
    InvalidateUnit(@event.Unit);
  }

  private static void OnUnitLoaded()
  {
    InvalidateUnit(@event.LoadedUnit);
  }

  private static void InvalidateUnit(unit invalidatedUnit)
  {
    CancelPendingBinding(invalidatedUnit);
    DetachFollower(invalidatedUnit);
    RemoveFollowGroup(invalidatedUnit);
    _lastHeroMovementOrders.Remove(invalidatedUnit);
  }

  private static bool OnPeriodic()
  {
    ProcessPendingBindings();
    ProcessPendingFollowerOrders();
    return true;
  }

  private static void ProcessPendingBindings()
  {
    foreach (var pendingBinding in _pendingBindings)
    {
      if (!_pendingBindingsByFollower.TryGetValue(pendingBinding.Follower, out var currentBinding) ||
          currentBinding != pendingBinding)
      {
        continue;
      }

      _pendingBindingsByFollower.Remove(pendingBinding.Follower);
      if (_mode != FollowOrderMode.StableDestination ||
          !IsFollowCandidate(pendingBinding.Follower, pendingBinding.Leader))
      {
        continue;
      }

      if (pendingBinding.Follower.IsLoaded)
      {
        continue;
      }

      var orderCount = pendingBinding.Follower.OrderCount;
      if (FollowOrderClassifier.HasOrderQueuedBehindCurrent(orderCount))
      {
        continue;
      }

      var currentOrder = pendingBinding.Follower.CurrentOrder;
      if (currentOrder != 0 && currentOrder != ORDER_SMART && currentOrder != ORDER_MOVE)
      {
        continue;
      }

      AttachFollower(pendingBinding.Follower, pendingBinding.Leader);
    }

    _pendingBindings.Clear();
  }

  private static void ProcessPendingFollowerOrders()
  {
    var processedOrders = 0;
    var examinedStates = 0;
    while (processedOrders < MaximumOrdersPerTick &&
           examinedStates < MaximumOrdersPerTick * 4 &&
           _pendingFollowerStateIndex < _pendingFollowerStates.Count)
    {
      var state = _pendingFollowerStates[_pendingFollowerStateIndex++];
      examinedStates++;
      state.IsOrderQueued = false;
      var pendingOrder = state.PendingOrder;
      state.PendingOrder = null;
      if (!state.Active || pendingOrder == null)
      {
        continue;
      }

      processedOrders++;
      var follower = state.Follower;
      var leader = state.Group.Leader;
      if (!IsActiveFollowerValid(follower, leader))
      {
        DetachFollower(follower);
        continue;
      }

      _internallyOrderedUnits.Add(follower);
      var orderAccepted = false;
      try
      {
        if (pendingOrder.HasPoint)
        {
          GetPointOrderDestination(state, pendingOrder, out var destinationX, out var destinationY);
          orderAccepted = follower.IssueOrder(pendingOrder.OrderId, destinationX, destinationY);
        }
        else
        {
          orderAccepted = follower.IssueOrder(pendingOrder.OrderId);
        }
      }
      finally
      {
        _internallyOrderedUnits.Remove(follower);
      }

      if (!orderAccepted)
      {
        DetachFollower(follower);
      }
    }

    if (_pendingFollowerStateIndex == _pendingFollowerStates.Count)
    {
      _pendingFollowerStates.Clear();
      _pendingFollowerStateIndex = 0;
    }
    else if (_pendingFollowerStateIndex >= 512)
    {
      var compactedStates = new List<FollowerState>();
      for (var i = _pendingFollowerStateIndex; i < _pendingFollowerStates.Count; i++)
      {
        compactedStates.Add(_pendingFollowerStates[i]);
      }

      _pendingFollowerStates = compactedStates;
      _pendingFollowerStateIndex = 0;
    }
  }

  private static void AttachFollower(unit follower, unit leader)
  {
    if (HasOrderQueuedBehindCurrent(leader))
    {
      // A queued leader route cannot be mirrored safely when later legs activate without
      // another issued-order event. Keep this follower on Warcraft's native target order.
      return;
    }

    LeaderMovementOrder? movementOrder = null;
    if (_lastHeroMovementOrders.TryGetValue(leader, out var lastOrder) &&
        FollowOrderClassifier.IsMatchingLeaderOrder(
          lastOrder.IssuedOrderId, lastOrder.FollowerOrderId, leader.CurrentOrder))
    {
      movementOrder = lastOrder;
    }
    else if (!FollowOrderClassifier.IsStationaryLeaderOrder(leader.CurrentOrder))
    {
      // The hero is moving under an unsupported or unobserved order. Leave Warcraft's
      // native follow untouched rather than replacing it with a stale position snapshot.
      return;
    }

    if (!_groupsByLeader.TryGetValue(leader, out var group))
    {
      group = new FollowGroup(leader);
      _groupsByLeader.Add(leader, group);
    }

    var state = new FollowerState(follower, group, group.NextFormationSlot++);
    group.Followers.Add(state);
    group.ActiveFollowerCount++;
    _statesByFollower.Add(follower, state);
    _activeFollowerCount++;

    if (movementOrder != null)
    {
      QueuePointOrder(state, movementOrder);
    }
    else
    {
      QueuePointOrder(state, new LeaderMovementOrder(ORDER_MOVE, ORDER_MOVE, leader.X, leader.Y, false));
    }
  }

  private static void QueuePointOrder(FollowGroup group, LeaderMovementOrder movementOrder)
  {
    foreach (var state in group.Followers)
    {
      if (state.Active)
      {
        QueuePointOrder(state, movementOrder);
      }
    }
  }

  private static void QueuePointOrder(FollowerState state, LeaderMovementOrder movementOrder)
  {
    var leader = state.Group.Leader;
    var follower = state.Follower;
    var followerX = movementOrder.PreserveFormation ? follower.X : leader.X;
    var followerY = movementOrder.PreserveFormation ? follower.Y : leader.Y;
    QueueFollowerOrder(state, new PendingFollowerOrder(movementOrder.FollowerOrderId,
      leader.X, leader.Y, followerX, followerY, movementOrder.X, movementOrder.Y));
  }

  private static void GetPointOrderDestination(FollowerState state, PendingFollowerOrder pendingOrder,
    out float destinationX, out float destinationY)
  {
    var worldBounds = Rectangle.WorldBounds;
    var leaderDestinationX = System.Math.Clamp(pendingOrder.LeaderDestinationX,
      worldBounds.Left + 32, worldBounds.Right - 32);
    var leaderDestinationY = System.Math.Clamp(pendingOrder.LeaderDestinationY,
      worldBounds.Bottom + 32, worldBounds.Top - 32);
    FollowDestinationPlanner.GetDestination(pendingOrder.LeaderX, pendingOrder.LeaderY,
      pendingOrder.FollowerX, pendingOrder.FollowerY,
      leaderDestinationX, leaderDestinationY, state.FormationSlot, out var desiredDestinationX,
      out var desiredDestinationY);

    desiredDestinationX = System.Math.Clamp(desiredDestinationX, worldBounds.Left + 32, worldBounds.Right - 32);
    desiredDestinationY = System.Math.Clamp(desiredDestinationY, worldBounds.Bottom + 32, worldBounds.Top - 32);
    FollowDestinationPlanner.GetPathingSafeDestination(leaderDestinationX, leaderDestinationY,
      desiredDestinationX, desiredDestinationY, IsTerrainUnwalkable, out destinationX, out destinationY);
  }

  private static bool IsTerrainUnwalkable(float x, float y) =>
    pathingtype.Walkability.GetPathable(x, y);

  private static void QueueImmediateOrder(FollowGroup group, int orderId)
  {
    foreach (var state in group.Followers)
    {
      if (state.Active)
      {
        QueueFollowerOrder(state, new PendingFollowerOrder(orderId));
      }
    }
  }

  private static void QueueFollowerOrder(FollowerState state, PendingFollowerOrder pendingOrder)
  {
    state.PendingOrder = pendingOrder;
    if (state.IsOrderQueued)
    {
      return;
    }

    state.IsOrderQueued = true;
    _pendingFollowerStates.Add(state);
  }

  private static bool IsFollowCandidate(unit follower, unit? leader) =>
    leader != null && follower != leader && follower.Alive && leader.Alive && follower.Owner == leader.Owner &&
    leader.IsUnitType(unittype.Hero) && !follower.IsUnitType(unittype.Hero) && !follower.IsUnitBoat() &&
    !follower.IsUnitType(unittype.Structure) &&
    !follower.IsUnitType(unittype.Peon) && !follower.IsUnitType(unittype.Flying);

  private static bool IsActiveFollowerValid(unit follower, unit leader) =>
    follower.Alive && leader.Alive && follower.Owner == leader.Owner && !follower.IsLoaded;

  // Reforged includes the active order in BlzGetUnitOrderCount. A value above one
  // means another order is queued behind it and must remain under native queue control.
  private static bool HasOrderQueuedBehindCurrent(unit orderedUnit) =>
    FollowOrderClassifier.HasOrderQueuedBehindCurrent(orderedUnit.OrderCount);

  private static void CancelPendingBinding(unit follower) =>
    _pendingBindingsByFollower.Remove(follower);

  private static void DetachFollower(unit follower)
  {
    if (!_statesByFollower.TryGetValue(follower, out var state))
    {
      return;
    }

    _statesByFollower.Remove(follower);
    state.Active = false;
    state.Group.ActiveFollowerCount--;
    state.Group.InactiveFollowerCount++;
    _activeFollowerCount--;
    if (state.Group.ActiveFollowerCount == 0)
    {
      _groupsByLeader.Remove(state.Group.Leader);
      state.Group.Followers.Clear();
      state.Group.InactiveFollowerCount = 0;
    }
    else if (state.Group.InactiveFollowerCount >= state.Group.ActiveFollowerCount &&
             state.Group.Followers.Count >= 64)
    {
      CompactFollowGroup(state.Group);
    }
  }

  private static void CompactFollowGroup(FollowGroup group)
  {
    var activeStates = new List<FollowerState>(group.ActiveFollowerCount);
    foreach (var state in group.Followers)
    {
      if (state.Active)
      {
        activeStates.Add(state);
      }
    }

    group.Followers = activeStates;
    group.InactiveFollowerCount = 0;
  }

  private static void RemoveFollowGroup(unit leader)
  {
    if (!_groupsByLeader.TryGetValue(leader, out var group))
    {
      return;
    }

    _groupsByLeader.Remove(leader);
    foreach (var state in group.Followers)
    {
      if (!state.Active)
      {
        continue;
      }

      state.Active = false;
      _statesByFollower.Remove(state.Follower);
      _activeFollowerCount--;
    }

    group.Followers.Clear();
    group.ActiveFollowerCount = 0;
    group.InactiveFollowerCount = 0;
  }

  private static void ResetTracking()
  {
    foreach (var group in _groupsByLeader.Values)
    {
      foreach (var state in group.Followers)
      {
        state.Active = false;
      }
    }

    _groupsByLeader.Clear();
    _statesByFollower.Clear();
    _lastHeroMovementOrders.Clear();
    _pendingBindingsByFollower.Clear();
    _pendingBindings.Clear();
    _pendingFollowerStates.Clear();
    _pendingFollowerStateIndex = 0;
    _internallyOrderedUnits.Clear();
    _activeFollowerCount = 0;
  }

  private sealed class FollowGroup
  {
    public unit Leader { get; }
    public List<FollowerState> Followers { get; set; } = new();
    public int ActiveFollowerCount { get; set; }
    public int InactiveFollowerCount { get; set; }
    public int NextFormationSlot { get; set; }

    public FollowGroup(unit leader)
    {
      Leader = leader;
    }
  }

  private sealed class FollowerState
  {
    public unit Follower { get; }
    public FollowGroup Group { get; }
    public int FormationSlot { get; }
    public bool Active { get; set; } = true;
    public bool IsOrderQueued { get; set; }
    public PendingFollowerOrder? PendingOrder { get; set; }

    public FollowerState(unit follower, FollowGroup group, int formationSlot)
    {
      Follower = follower;
      Group = group;
      FormationSlot = formationSlot;
    }
  }

  private sealed class LeaderMovementOrder
  {
    public int IssuedOrderId { get; }
    public int FollowerOrderId { get; }
    public float X { get; }
    public float Y { get; }
    public bool PreserveFormation { get; }

    public LeaderMovementOrder(int issuedOrderId, int followerOrderId, float x, float y,
      bool preserveFormation = true)
    {
      IssuedOrderId = issuedOrderId;
      FollowerOrderId = followerOrderId;
      X = x;
      Y = y;
      PreserveFormation = preserveFormation;
    }
  }

  private sealed class PendingBinding
  {
    public unit Follower { get; }
    public unit Leader { get; }

    public PendingBinding(unit follower, unit leader)
    {
      Follower = follower;
      Leader = leader;
    }
  }

  private sealed class PendingFollowerOrder
  {
    public int OrderId { get; }
    public bool HasPoint { get; }
    public float LeaderX { get; }
    public float LeaderY { get; }
    public float FollowerX { get; }
    public float FollowerY { get; }
    public float LeaderDestinationX { get; }
    public float LeaderDestinationY { get; }

    public PendingFollowerOrder(int orderId)
    {
      OrderId = orderId;
    }

    public PendingFollowerOrder(int orderId, float leaderX, float leaderY, float followerX, float followerY,
      float leaderDestinationX, float leaderDestinationY) : this(orderId)
    {
      HasPoint = true;
      LeaderX = leaderX;
      LeaderY = leaderY;
      FollowerX = followerX;
      FollowerY = followerY;
      LeaderDestinationX = leaderDestinationX;
      LeaderDestinationY = leaderDestinationY;
    }
  }
}
