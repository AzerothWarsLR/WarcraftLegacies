using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Dialogues;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.TaurenTribes.Quests;
using WarcraftLegacies.Source.Objectives;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Mechanics;

/// <summary>
/// Drives the pack kodos and Tauren guards from the starting camp to Thunder Bluff, marching through
/// Thousand Needles, Stonemaul Keep, and Mulgore along the way.
/// </summary>
public sealed class LongMarchCaravan
{
  private enum Stage
  {
    ThousandNeedles,
    StonemaulKeep,
    Mulgore,
    ThunderBluff
  }

  private static readonly int[] AmbushUnitTypes =
  {
    UNIT_OTCO_CENTAUR_OUTRUNNER_TAUREN_TRIBES_AMBUSH,
    UNIT_OTCD_CENTAUR_DRUDGE_TAUREN_TRIBES_AMBUSH,
    UNIT_OTCA_CENTAUR_ARCHER_TAUREN_TRIBES_AMBUSH,
    UNIT_OTCI_CENTAUR_IMPALER_TAUREN_TRIBES_AMBUSH
  };

  private static readonly Dialogue FirstAmbushDialogue = new(
    @"Sound\Dialogue\OrcCampaign\Orc02\O02Cairne11.flac",
    "Hold your formations, the Kodo's must be protected.",
    "Cairne Bloodhoof");

  private static readonly Dialogue SecondAmbushDialogue = new(
    @"Sound\Dialogue\OrcCampaign\Orc02\O02Cairne15.flac",
    "The centaur have returned, we're under attack!",
    "Cairne Bloodhoof");

  private static readonly Dialogue ThirdAmbushDialogue = new(
    @"Sound\Dialogue\OrcCampaign\Orc02\O02Cairne17.flac",
    "The marauders attack again! Stand and fight, my brethren!",
    "Cairne Bloodhoof");

  private static readonly Dialogue FirstAmbushDefeatedDialogue = new(
    @"Sound\Dialogue\OrcCampaign\Orc02\O02Cairne05.flac",
    "They shall not catch the Tauren unprepared.",
    "Cairne Bloodhoof");

  private static readonly Dialogue SecondAmbushDefeatedDialogue = new(
    @"Sound\Dialogue\OrcCampaign\Orc02\O02Cairne25.flac",
    "Let the fury of the earth mother deal with these wretches as they deserve!",
    "Cairne Bloodhoof");

  private static readonly Dialogue MulgorePassDialogue = new(
    @"Sound\Dialogue\OrcCampaign\Orc02\O02Cairne23.flac",
    "This pass leads straight to Mulgore, but I fear the caravan will be overrun before it reaches the other side.",
    "Cairne Bloodhoof");

  private const int AmbushWaveSize = 3;
  private const float OrderPulseInterval = 3.00f;
  private const float ArrivalRadius = 500f;
  private const float ArrivalPauseSeconds = 15.00f;
  private const float ThunderBluffPauseSeconds = 3.00f;
  private const float FormationSpacing = 200f;
  private const float EscortMoveSpeed = 90f;
  private const float GuardFormationSlotRadius = 600f;
  private const float GuardCatchUpSpeed = 150f;
  private const float GuardFlankOffset = 250f;
  private const float GuardVanguardOffset = 150f;
  private const float GuardEngagementRange = 350f;
  private const float AmbushCheckInterval = 7.00f;
  private const float MinAmbushChance = 0.10f;
  private const float MaxAmbushChance = 0.65f;
  private const float InitialFormUpGraceSeconds = 8.00f;
  private const float MaxPlayerDistance = 2500f;
  private const float RestCircleRadius = 350f;
  private const float RestCircleArrivalRadius = 60f;
  private const float RestCircleSettleSeconds = 6.00f;
  private const float RestCircleTurnSeconds = 1.00f;

  private readonly Faction _taurenTribes;
  private readonly QuestTheLongMarch _quest;
  private readonly List<unit> _kodos;
  private readonly List<unit> _guards;
  private readonly List<(unit Unit, bool PrefersPlayer)> _ambushers = new();
  private readonly List<List<unit>> _pendingAmbushWaves = new();
  private int _ambushWavesSpawned;
  private int _ambushWavesDefeatedReported;
  private readonly List<unit> _stonemaulRescueUnits;
  private readonly List<unit> _thunderBluffRescueUnits;
  private readonly unit _thousandNeedlesControlPoint;
  private readonly unit _mulgoreControlPoint;
  private readonly Point _thousandNeedlesTarget;
  private readonly Point _stonemaulTarget;
  private readonly Point _mulgoreTarget;
  private readonly Point _thunderBluffTarget;
  private readonly Rectangle _stonemaulKeep;
  private readonly Rectangle _thunderBluff;

  private Stage _stage;
  private Point _currentTarget = null!;
  private Point _legStart = null!;
  private float _legLength = 1f;
  private timer? _orderTimer;
  private timer? _ambushTimer;
  private bool _awaitingArrival;
  private bool _concluded;

  /// <summary>
  /// Initializes a new instance of the <see cref="LongMarchCaravan"/> class.
  /// </summary>
  public LongMarchCaravan(Faction taurenTribes, QuestTheLongMarch quest, List<unit> kodos, List<unit> guards,
    unit thousandNeedlesControlPoint, Point stonemaulTarget, unit mulgoreControlPoint, Rectangle stonemaulKeep,
    Rectangle thunderBluff)
  {
    _taurenTribes = taurenTribes;
    _quest = quest;
    _kodos = kodos;
    _guards = guards;
    _stonemaulKeep = stonemaulKeep;
    _thunderBluff = thunderBluff;
    _thousandNeedlesControlPoint = thousandNeedlesControlPoint;
    _mulgoreControlPoint = mulgoreControlPoint;
    _thousandNeedlesTarget = thousandNeedlesControlPoint.GetPosition();
    _stonemaulTarget = stonemaulTarget;
    _mulgoreTarget = mulgoreControlPoint.GetPosition();
    _thunderBluffTarget = thunderBluff.Center;

    _stage = Stage.ThousandNeedles;

    _stonemaulRescueUnits = stonemaulKeep.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    _thunderBluffRescueUnits = thunderBluff.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);

    foreach (var kodo in kodos)
    {
      SetUnitMoveSpeed(kodo, EscortMoveSpeed);
      PlayerUnitEventsHelper.RegisterDiesOrChangesOwnerOnce(OnKodoLost, kodo);
    }

    foreach (var guard in guards)
    {
      SetUnitMoveSpeed(guard, EscortMoveSpeed);
    }

    SetCurrentTarget(_thousandNeedlesTarget);

    var formingKodos = _kodos.Where(kodo => kodo.Alive).ToList();
    FormUpKodoLine(formingKodos);
    FormUpGuards(formingKodos);

    var formUpTimer = timer.Create();
    formUpTimer.Start(InitialFormUpGraceSeconds, false, () =>
    {
      formUpTimer.Dispose();
      if (_concluded)
      {
        return;
      }

      Tick();
      _orderTimer = timer.Create();
      _orderTimer.Start(OrderPulseInterval, true, Tick);
      _ambushTimer = timer.Create();
      _ambushTimer.Start(AmbushCheckInterval, true, TryAmbush);
    });
  }

  private void SetCurrentTarget(Point target)
  {
    var living = _kodos.Where(kodo => kodo.Alive).ToList();
    _legStart = living.Count > 0
      ? new Point(living.Average(kodo => kodo.X), living.Average(kodo => kodo.Y))
      : target;
    _currentTarget = target;
    _legLength = Math.Max(MathEx.GetDistanceBetweenPoints(_legStart, _currentTarget), 1f);
  }

  private void FormUpKodoLine(List<unit> living)
  {
    if (living.Count == 0)
    {
      return;
    }

    var anchor = new Point(living.Average(kodo => kodo.X), living.Average(kodo => kodo.Y));
    var directionX = _currentTarget.X - anchor.X;
    var directionY = _currentTarget.Y - anchor.Y;
    var directionLength = Math.Sqrt(directionX * directionX + directionY * directionY);
    if (directionLength < 1)
    {
      directionLength = 1;
    }

    var forwardX = directionX / directionLength;
    var forwardY = directionY / directionLength;

    for (var i = 0; i < living.Count; i++)
    {
      var trailDistance = i * FormationSpacing;
      var offsetX = (float)(-forwardX * trailDistance);
      var offsetY = (float)(-forwardY * trailDistance);
      living[i].IssueOrder(ORDER_MOVE, anchor.X + offsetX, anchor.Y + offsetY);
    }
  }

  private float GetLegProgress()
  {
    var living = _kodos.Where(kodo => kodo.Alive).ToList();
    if (living.Count == 0)
    {
      return 0f;
    }

    var centroid = new Point(living.Average(kodo => kodo.X), living.Average(kodo => kodo.Y));
    var traveled = MathEx.GetDistanceBetweenPoints(_legStart, centroid);
    var progress = traveled / _legLength;
    if (progress < 0f)
    {
      return 0f;
    }

    return progress > 1f ? 1f : progress;
  }

  private bool IsPlayerTooFarBehind(List<unit> livingKodos)
  {
    var player = _taurenTribes.Player;
    if (player == null)
    {
      return false;
    }

    var centroid = new Point(livingKodos.Average(kodo => kodo.X), livingKodos.Average(kodo => kodo.Y));
    var nearestDistance = float.MaxValue;
    foreach (var playerUnit in GlobalGroup.EnumUnitsOfPlayer(player).Where(unitToCheck => unitToCheck.Alive))
    {
      var distance = MathEx.GetDistanceBetweenPoints(playerUnit.GetPosition(), centroid);
      if (distance < nearestDistance)
      {
        nearestDistance = distance;
      }
    }

    return nearestDistance > MaxPlayerDistance;
  }

  private void Tick()
  {
    if (_concluded)
    {
      return;
    }

    var living = _kodos.Where(kodo => kodo.Alive).ToList();
    RefreshAmbusherOrders(living);
    CheckAmbushWavesDefeated();

    if (_awaitingArrival)
    {
      if (_stage != Stage.ThunderBluff)
      {
        ArrangeInCircle(_currentTarget);
      }

      return;
    }

    RefreshGuardOrders(living);

    if (living.Count == 0)
    {
      return;
    }

    var leadDistance = MathEx.GetDistanceBetweenPoints(living[0].GetPosition(), _currentTarget);

    if (leadDistance < ArrivalRadius)
    {
      BeginArrivalPause();
      return;
    }

    if (IsPlayerTooFarBehind(living))
    {
      return;
    }

    if (_ambushers.Count > 0)
    {
      foreach (var kodo in living)
      {
        kodo.IssueOrder(ORDER_STOP);
      }

      return;
    }

    IssueMoveOrders(living);
  }

  private void IssueMoveOrders(List<unit> living)
  {
    var averageX = living.Average(kodo => kodo.X);
    var averageY = living.Average(kodo => kodo.Y);
    var directionX = _currentTarget.X - averageX;
    var directionY = _currentTarget.Y - averageY;
    var directionLength = Math.Sqrt(directionX * directionX + directionY * directionY);
    if (directionLength < 1)
    {
      directionLength = 1;
    }

    var forwardX = directionX / directionLength;
    var forwardY = directionY / directionLength;

    for (var i = 0; i < living.Count; i++)
    {
      var trailDistance = i * FormationSpacing;
      var offsetX = (float)(-forwardX * trailDistance);
      var offsetY = (float)(-forwardY * trailDistance);
      living[i].IssueOrder(ORDER_MOVE, _currentTarget.X + offsetX, _currentTarget.Y + offsetY);
    }
  }

  private (Point Anchor, double ForwardX, double ForwardY, double PerpendicularX, double PerpendicularY, float
    KodoColumnHalfLength) GetGuardFormationAxes(List<unit> livingKodos)
  {
    var anchor = livingKodos.Count > 0
      ? new Point(livingKodos.Average(kodo => kodo.X), livingKodos.Average(kodo => kodo.Y))
      : new Point(_guards.Average(guard => guard.X), _guards.Average(guard => guard.Y));

    var directionX = _currentTarget.X - anchor.X;
    var directionY = _currentTarget.Y - anchor.Y;
    var directionLength = Math.Sqrt(directionX * directionX + directionY * directionY);
    if (directionLength < 1)
    {
      directionLength = 1;
    }

    var forwardX = directionX / directionLength;
    var forwardY = directionY / directionLength;
    var perpendicularX = -directionY / directionLength;
    var perpendicularY = directionX / directionLength;
    var kodoColumnHalfLength = livingKodos.Count > 1 ? (livingKodos.Count - 1) * FormationSpacing / 2f : 0f;

    return (anchor, forwardX, forwardY, perpendicularX, perpendicularY, kodoColumnHalfLength);
  }

  private static Point GetGuardSlot(int guardIndex, Point anchor, double forwardX, double forwardY,
    double perpendicularX, double perpendicularY, float kodoColumnHalfLength)
  {
    var side = guardIndex % 2 == 0 ? -1 : 1;
    var isFrontPair = guardIndex < 2;
    var forwardOffset = isFrontPair ? kodoColumnHalfLength + GuardVanguardOffset : -kodoColumnHalfLength;
    var lateralOffset = side * GuardFlankOffset;
    var slotX = anchor.X + (float)(perpendicularX * lateralOffset) + (float)(forwardX * forwardOffset);
    var slotY = anchor.Y + (float)(perpendicularY * lateralOffset) + (float)(forwardY * forwardOffset);
    return new Point(slotX, slotY);
  }

  private void FormUpGuards(List<unit> formingKodos)
  {
    if (_guards.Count == 0)
    {
      return;
    }

    var (anchor, forwardX, forwardY, perpendicularX, perpendicularY, kodoColumnHalfLength) =
      GetGuardFormationAxes(formingKodos);

    for (var i = 0; i < _guards.Count; i++)
    {
      var guard = _guards[i];
      var slot = GetGuardSlot(i, anchor, forwardX, forwardY, perpendicularX, perpendicularY, kodoColumnHalfLength);
      SetUnitMoveSpeed(guard, GetUnitDefaultMoveSpeed(guard));
      guard.IssueOrder(ORDER_MOVE, slot.X, slot.Y);
    }
  }

  private void RefreshGuardOrders(List<unit> livingKodos)
  {
    _guards.RemoveAll(guard => !guard.Alive);
    if (_guards.Count == 0)
    {
      return;
    }

    var (anchor, forwardX, forwardY, perpendicularX, perpendicularY, kodoColumnHalfLength) =
      GetGuardFormationAxes(livingKodos);

    for (var i = 0; i < _guards.Count; i++)
    {
      var guard = _guards[i];
      if (IsGuardEngaged(guard))
      {
        continue;
      }

      var slot = GetGuardSlot(i, anchor, forwardX, forwardY, perpendicularX, perpendicularY, kodoColumnHalfLength);
      var distanceToSlot = MathEx.GetDistanceBetweenPoints(guard.GetPosition(), slot);
      if (distanceToSlot <= GuardFormationSlotRadius)
      {
        SetUnitMoveSpeed(guard, EscortMoveSpeed);
        guard.IssueOrder(ORDER_ATTACK, slot.X, slot.Y);
      }
      else
      {
        SetUnitMoveSpeed(guard, GuardCatchUpSpeed);
        guard.IssueOrder(ORDER_MOVE, slot.X, slot.Y);
      }
    }
  }

  private bool IsGuardEngaged(unit guard) =>
    _ambushers.Any(ambusher => ambusher.Unit.Alive &&
      MathEx.GetDistanceBetweenPoints(ambusher.Unit.GetPosition(), guard.GetPosition()) <= GuardEngagementRange);

  private void BeginArrivalPause()
  {
    _awaitingArrival = true;
    var arrivedStage = _stage;

    if (arrivedStage != Stage.ThunderBluff)
    {
      ArrangeInCircle(_currentTarget);

      var settleTimer = timer.Create();
      settleTimer.Start(RestCircleSettleSeconds, false, () =>
      {
        settleTimer.Dispose();
        FaceCircleCenter(_currentTarget);
      });
    }

    var pauseSeconds = arrivedStage == Stage.ThunderBluff ? ThunderBluffPauseSeconds : ArrivalPauseSeconds;
    var pauseTimer = timer.Create();
    pauseTimer.Start(pauseSeconds, false, () =>
    {
      _awaitingArrival = false;
      AdvanceFromStage(arrivedStage);
      pauseTimer.Dispose();
    });
  }

  private void ArrangeInCircle(Point center)
  {
    var units = _kodos.Where(kodo => kodo.Alive).Concat(_guards.Where(guard => guard.Alive)).ToList();
    if (units.Count == 0)
    {
      return;
    }

    var angleStep = 360.0 / units.Count;
    for (var i = 0; i < units.Count; i++)
    {
      var unitToPlace = units[i];
      if (_guards.Contains(unitToPlace) && IsGuardEngaged(unitToPlace))
      {
        continue;
      }

      var angleRadians = i * angleStep * Math.PI / 180.0;
      var slotX = center.X + (float)Math.Cos(angleRadians) * RestCircleRadius;
      var slotY = center.Y + (float)Math.Sin(angleRadians) * RestCircleRadius;

      if (MathEx.GetDistanceBetweenPoints(unitToPlace.GetPosition(), new Point(slotX, slotY)) <= RestCircleArrivalRadius)
      {
        continue;
      }

      unitToPlace.IssueOrder(ORDER_MOVE, slotX, slotY);
    }
  }

  private void FaceCircleCenter(Point center)
  {
    foreach (var unitToFace in _kodos.Where(kodo => kodo.Alive).Concat(_guards.Where(guard => guard.Alive)))
    {
      var faceAngle = (float)(Math.Atan2(center.Y - unitToFace.Y, center.X - unitToFace.X) * 180.0 / Math.PI);
      SetUnitFacingTimed(unitToFace, faceAngle, RestCircleTurnSeconds);
    }
  }

  private void AdvanceFromStage(Stage arrivedStage)
  {
    switch (arrivedStage)
    {
      case Stage.ThousandNeedles:
        OnReachThousandNeedles();
        break;
      case Stage.StonemaulKeep:
        OnReachStonemaulKeep();
        break;
      case Stage.Mulgore:
        OnReachMulgore();
        break;
      case Stage.ThunderBluff:
        OnReachThunderBluff();
        break;
    }
  }

  private void OnReachThousandNeedles()
  {
    if (_stage != Stage.ThousandNeedles || _concluded)
    {
      return;
    }

    AwardControlPoint(_thousandNeedlesControlPoint);
    _quest.MarkThousandNeedlesReached();
    _stage = Stage.StonemaulKeep;
    SetCurrentTarget(_stonemaulTarget);
  }

  private void OnReachStonemaulKeep()
  {
    if (_stage != Stage.StonemaulKeep || _concluded)
    {
      return;
    }

    _taurenTribes.Player?.RescueGroup(_stonemaulRescueUnits);
    _quest.MarkStonemaulReached();
    _stage = Stage.Mulgore;
    SetCurrentTarget(_mulgoreTarget);
    _taurenTribes.Player?.QueueDialogue(MulgorePassDialogue);
  }

  private void OnReachMulgore()
  {
    if (_stage != Stage.Mulgore || _concluded)
    {
      return;
    }

    AwardControlPoint(_mulgoreControlPoint);
    _quest.MarkMulgoreReached();
    _stage = Stage.ThunderBluff;
    SetCurrentTarget(_thunderBluffTarget);
  }

  private void AwardControlPoint(unit controlPoint)
  {
    var player = _taurenTribes.Player;
    if (player != null)
    {
      controlPoint.Rescue(player);
    }
  }

  private void OnReachThunderBluff()
  {
    if (_concluded)
    {
      return;
    }

    _taurenTribes.Player?.RescueGroup(_thunderBluffRescueUnits);
    _quest.MarkThunderBluffReached();
    Conclude();
  }

  private void OnKodoLost()
  {
    if (_concluded || _kodos.Any(kodo => kodo.Alive))
    {
      return;
    }

    if (_stage == Stage.ThousandNeedles)
    {
      AwardControlPoint(_thousandNeedlesControlPoint);
      _quest.MarkThousandNeedlesReached();
      _stage = Stage.StonemaulKeep;
    }

    if (_stage == Stage.StonemaulKeep)
    {
      InjureRescuedUnits(_stonemaulRescueUnits);
      _taurenTribes.Player?.RescueGroup(_stonemaulRescueUnits);
      _quest.MarkStonemaulReached();
      _stage = Stage.Mulgore;
    }

    if (_stage == Stage.Mulgore)
    {
      AwardControlPoint(_mulgoreControlPoint);
      _quest.MarkMulgoreReached();
      _stage = Stage.ThunderBluff;
    }

    InjureRescuedUnits(_thunderBluffRescueUnits);
    _taurenTribes.Player?.RescueGroup(_thunderBluffRescueUnits);
    _quest.MarkThunderBluffReached();
    Conclude();
  }

  private static void InjureRescuedUnits(IEnumerable<unit> units)
  {
    foreach (var rescuedUnit in units)
    {
      rescuedUnit.SetLifePercent(60);
    }
  }

  private void Conclude()
  {
    _concluded = true;
    _orderTimer?.Dispose();
    _orderTimer = null;
    _ambushTimer?.Dispose();
    _ambushTimer = null;

    foreach (var kodo in _kodos.Where(kodo => kodo.Alive))
    {
      kodo.Dispose();
    }

    var player = _taurenTribes.Player;
    if (player != null)
    {
      foreach (var guard in _guards.Where(guard => guard.Alive))
      {
        guard.Rescue(player);
      }
    }
  }

  private void TryAmbush()
  {
    if (_concluded || _ambushers.Count > 0)
    {
      return;
    }

    var legProgress = GetLegProgress();
    var ambushChance = MinAmbushChance + (MaxAmbushChance - MinAmbushChance) * (float)Math.Sin(Math.PI * legProgress);
    if (GetRandomReal(0, 1) > ambushChance)
    {
      return;
    }

    SpawnAmbush();
  }

  private void SpawnAmbush()
  {
    var living = _kodos.Where(kodo => kodo.Alive).ToList();
    if (living.Count == 0)
    {
      return;
    }

    var origin = living[GetRandomInt(0, living.Count - 1)];
    var angle = GetRandomReal(0, 360) * Math.PI / 180.0;
    var spawnX = origin.X + (float)Math.Cos(angle) * 800;
    var spawnY = origin.Y + (float)Math.Sin(angle) * 800;

    if (IsInsideRect(spawnX, spawnY, _stonemaulKeep) || IsInsideRect(spawnX, spawnY, _thunderBluff))
    {
      return;
    }

    var waveMembers = new List<unit>();
    for (var i = 0; i < AmbushWaveSize; i++)
    {
      var unitType = AmbushUnitTypes[GetRandomInt(0, AmbushUnitTypes.Length - 1)];
      var attacker = unit.Create(player.NeutralAggressive, unitType, spawnX, spawnY, GetRandomReal(0, 360));
      var prefersPlayer = GetRandomInt(0, 1) == 0;
      _ambushers.Add((attacker, prefersPlayer));
      waveMembers.Add(attacker);
      IssueAmbusherOrder(attacker, prefersPlayer, living);
    }

    _pendingAmbushWaves.Add(waveMembers);
    _ambushWavesSpawned++;
    PlayAmbushEscalationDialogue();
  }

  private void PlayAmbushEscalationDialogue()
  {
    var dialogue = _ambushWavesSpawned switch
    {
      1 => FirstAmbushDialogue,
      2 => SecondAmbushDialogue,
      3 => ThirdAmbushDialogue,
      _ => null
    };
    if (dialogue != null)
    {
      _taurenTribes.Player?.QueueDialogue(dialogue);
    }
  }

  private void CheckAmbushWavesDefeated()
  {
    for (var i = _pendingAmbushWaves.Count - 1; i >= 0; i--)
    {
      if (_pendingAmbushWaves[i].Any(waveUnit => waveUnit.Alive))
      {
        continue;
      }

      _pendingAmbushWaves.RemoveAt(i);
      _ambushWavesDefeatedReported++;
      var dialogue = _ambushWavesDefeatedReported switch
      {
        1 => FirstAmbushDefeatedDialogue,
        2 => SecondAmbushDefeatedDialogue,
        _ => null
      };
      if (dialogue != null)
      {
        _taurenTribes.Player?.QueueDialogue(dialogue);
      }
    }
  }

  private void RefreshAmbusherOrders(List<unit> livingKodos)
  {
    _ambushers.RemoveAll(ambusher => !ambusher.Unit.Alive);
    foreach (var (ambusherUnit, prefersPlayer) in _ambushers)
    {
      IssueAmbusherOrder(ambusherUnit, prefersPlayer, livingKodos);
    }
  }

  private void IssueAmbusherOrder(unit ambusher, bool prefersPlayer, List<unit> livingKodos)
  {
    var target = prefersPlayer ? GetNearestPlayerUnit(ambusher.X, ambusher.Y) : null;
    target ??= livingKodos
      .OrderBy(kodo => MathEx.GetDistanceBetweenPoints(kodo.GetPosition(), ambusher.GetPosition()))
      .FirstOrDefault();
    if (target == null)
    {
      return;
    }

    ambusher.IssueOrder(ORDER_ATTACK, target.X, target.Y);
  }

  private static bool IsInsideRect(float x, float y, Rectangle rect) =>
    x >= rect.Rect.MinX && x <= rect.Rect.MaxX && y >= rect.Rect.MinY && y <= rect.Rect.MaxY;

  private unit? GetNearestPlayerUnit(float x, float y)
  {
    var player = _taurenTribes.Player;
    if (player == null)
    {
      return null;
    }

    var origin = new Point(x, y);
    return GlobalGroup.EnumUnitsOfPlayer(player)
      .Where(playerUnit => playerUnit.Alive && !playerUnit.IsUnitType(unittype.Structure))
      .OrderBy(playerUnit => MathEx.GetDistanceBetweenPoints(playerUnit.GetPosition(), origin))
      .FirstOrDefault();
  }
}
