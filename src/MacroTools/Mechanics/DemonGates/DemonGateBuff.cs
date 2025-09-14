using System.Collections.Generic;
using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Mechanics.DemonGates
{
  /// <summary>
  /// Units with this buff will periodically spawn units from themselves.
  /// </summary>
  public sealed class DemonGateBuff : TickingBuff
  {
    /// <summary>
    /// The special effect that appears on created demons for a brief period.
    /// </summary>
    public string SpawnEffectPath { get; init; } = "";

    /// <summary>
    /// The number of demons from this portal that can exist simultaneously.
    /// </summary>
    public int SpawnLimit { get; init; } = 12;

    /// <summary>
    /// The progress towards spawning a new demon.
    /// </summary>
    private float Progress
    {
      get => _progress;
      set
      {
        _progress = value;
        int value1 = (int)value;
        SetUnitState(Target, UNIT_STATE_MANA, value1);
      }
    }

    private Point SpawnPoint
    {
      get
      {
        if (FocalDemonGateBuff.Instance != null && UnitAlive(FocalDemonGateBuff.Instance.Target))
          return FocalDemonGateBuff.Instance.SpawnPoint;

        var targetPosition = Target.GetPosition();
        var offsetPosition =
          WCSharp.Shared.Util.PositionWithPolarOffset(targetPosition.X, targetPosition.Y, SpawnDistance,
            Target.GetFacing() + FacingOffset);
        return new Point(offsetPosition.x, offsetPosition.y);
      }
    }

    private Point RallyPoint =>
      FocalDemonGateBuff.Instance != null && UnitAlive(FocalDemonGateBuff.Instance.Target)
        ? FocalDemonGateBuff.Instance.RallyPoint
        : Target.GetRallyPoint();

    private int _demonUnitTypeId;
    private readonly float _spawnInterval;
    private readonly int _spawnCount;
    private float _progress;
    private readonly List<unit> _spawnedDemons = new();
    private static int _toggleBuffTypeId;
    private static int _toggleAbilityTypeId;

    private const float FacingOffset = -45f; //Demon gate model is spun around weirdly so this reverses that for code
    private const float SpawnDistance = 300f; //How far away from the gate to spawn units

    /// <summary>
    /// Initializes a new instance of the <see cref="DemonGateBuff"/> class.
    /// </summary>
    /// <param name="caster"><inheritdoc /></param>
    /// <param name="demonUnitTypeId">The unit to spawn.</param>
    /// <param name="spawnInterval">How frequently to spawn the unit.</param>
    /// <param name="spawnCount">How many units to spawn.</param>
    public DemonGateBuff(unit caster, int demonUnitTypeId, float spawnInterval, int spawnCount) :
      base(caster, caster)
    {
      _demonUnitTypeId = demonUnitTypeId;
      _spawnInterval = spawnInterval;
      _spawnCount = spawnCount;
      Interval = 1;
    }

    /// <inheritdoc />
    public override void OnApply()
    {
      Target.IssueOrder(OrderId("setrally"), Target.GetPosition());
      BlzSetUnitMaxMana(Target, (int)_spawnInterval);
      Target.AddAbility(_toggleAbilityTypeId);
      Target.IssueOrder("immolation");
      Progress = _spawnInterval / 2;
    }

    /// <inheritdoc />
    public override void OnTick()
    {
      if (Progress < _spawnInterval)
        Progress += Interval;
      if (Progress >= _spawnInterval
          && Caster.OwningPlayer().GetFoodUsed() < Caster.OwningPlayer().GetFoodCap()
          && Caster.OwningPlayer().GetFoodUsed() < Caster.OwningPlayer().GetFoodCapCeiling()
          && GetUnitAbilityLevel(Caster, _toggleBuffTypeId) > 0
          && _spawnedDemons.Count <= SpawnLimit - _spawnCount)
      {
        SpawnDemon();
      }
    }

    /// <inheritdoc />
    public override StackResult OnStack(Buff newStack)
    {
      if (newStack is DemonGateBuff newDemonGateBuff) 
        _demonUnitTypeId = newDemonGateBuff._demonUnitTypeId;
      int maximumMana = (int)_spawnInterval;
      BlzSetUnitMaxMana(Target, maximumMana);
      return StackResult.Consume;
    }

    /// <summary>
    /// Sets up the <see cref="DemonGateBuff"/> system.
    /// </summary>
    /// <param name="toggleAbilityTypeId">An ability to add to all Demon Gates.</param>
    /// <param name="toggleBuffTypeId">Demon Gates only function while this buff is active.</param>
    public static void Setup(int toggleAbilityTypeId, int toggleBuffTypeId)
    {
      _toggleAbilityTypeId = toggleAbilityTypeId;
      _toggleBuffTypeId = toggleBuffTypeId;
    }

    private void SpawnDemon()
    {
      for (var i = 0; i < _spawnCount; i++)
      {
        var spawnedDemon = CreateUnit(Target.OwningPlayer(), _demonUnitTypeId, SpawnPoint.X, SpawnPoint.Y,
          Target.GetFacing() + FacingOffset);
        spawnedDemon.IssueOrder(OrderId("attack"), RallyPoint);
        
        _spawnedDemons.Add(spawnedDemon);

        var deathTrigger = CreateTrigger();
        TriggerRegisterUnitEvent(deathTrigger, spawnedDemon, EVENT_UNIT_DEATH);
        TriggerAddAction(deathTrigger, () =>
        {
          _spawnedDemons.Remove(spawnedDemon);
          DestroyTrigger(GetTriggeringTrigger());
        });
      }

      AddSpecialEffect(SpawnEffectPath, SpawnPoint.X, SpawnPoint.Y).SetLifespan();
      Progress = 0;
    }
  }
}