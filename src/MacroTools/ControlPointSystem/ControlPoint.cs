using System;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Wrappers;
using static War3Api.Common;


namespace MacroTools.ControlPointSystem
{
  /// <summary>
  ///   An immobile and permanent unit on the map.
  ///   Increases the income of the controlling <see cref="Faction" />.
  ///   When a <see cref="ControlPoint" /> is reduced below a certain health threshold, it changes ownership to the attacker.
  /// </summary>
  public sealed class ControlPoint
  {
    /// <summary>
    /// The percentage of maximum hitpoints below which the <see cref="ControlPoint"/> will be transferred to the attacker.
    /// </summary>
    private const float CaptureThreshold = 0.8f;
    private static readonly int RegenerationAbility = FourCC("A0UT");

    private readonly TriggerWrapper _damageTrigger = new();
    private readonly TriggerWrapper _changeOwnerTrigger = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="ControlPoint"/> class.
    /// </summary>
    /// <param name="representingUnit">The unit representing the <see cref="ControlPoint"/>.</param>
    /// <param name="value">The gold income granted by the <see cref="ControlPoint"/>.</param>
    public ControlPoint(unit representingUnit, float value)
    {
      Unit = representingUnit;
      Value = value;

      TriggerRegisterUnitEvent(_damageTrigger.Trigger, Unit, EVENT_UNIT_DAMAGED);
      TriggerRegisterUnitEvent(_changeOwnerTrigger.Trigger, Unit, EVENT_UNIT_CHANGE_OWNER);

      TriggerAddAction(_damageTrigger.Trigger, OnDamaged);
      TriggerAddAction(_changeOwnerTrigger.Trigger, ChangeOwner);
    }

    /// <summary>
    /// The owner of the <see cref="ControlPoint"/>.
    /// </summary>
    public player Owner => GetOwningPlayer(Unit);
    
    /// <summary>
    ///   How much gold this <see cref="ControlPoint" /> grants per minute.
    /// </summary>
    public float Value { get; }

    /// <summary>
    /// The unit type ID of the <see cref="ControlPoint"/>.
    /// </summary>
    public int UnitType => GetUnitTypeId(Unit);

    /// <summary>
    /// A user-friendly name for the <see cref="ControlPoint"/>.
    /// </summary>
    public string Name => GetUnitName(Unit);

    /// <summary>
    /// The unit representing the <see cref="ControlPoint"/>.
    /// </summary>
    public unit Unit { get; }
    
    /// <summary>
    ///   Fires when the <see cref="ControlPoint" /> changes its owner.
    /// </summary>
    public event EventHandler<ControlPointOwnerChangeEventArgs>? ChangedOwner;
    
    /// <summary>
    /// Invoked when the <see cref="ControlPoint"/> changes owner.
    /// </summary>
    public static event EventHandler<ControlPointOwnerChangeEventArgs>? OnControlPointOwnerChange;

    private void OnDamaged()
    {
      try
      {
        var attacker = GetEventDamageSource();

        var hitPoints = (GetUnitState(Unit, UNIT_STATE_LIFE) - GetEventDamage()) /
                 GetUnitState(Unit, UNIT_STATE_MAX_LIFE);
        if (!(hitPoints < CaptureThreshold)) return;
        BlzSetEventDamage(0);
        SetUnitOwner(Unit, GetOwningPlayer(attacker), true);
        Unit.SetLifePercent(85);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }

    private void ChangeOwner()
    {
      try
      {
        var formerOwner = GetChangingUnitPrevOwner();
        var newOwner = GetTriggerUnit().OwningPlayer();

        var playerData = PlayerData.ByHandle(formerOwner);
        
        playerData.ControlPointCount -= 1;
        playerData.BaseIncome -= Value;

        playerData = PlayerData.ByHandle(newOwner);
        
        playerData.ControlPointCount += 1;
        playerData.BaseIncome += Value;

        UnitAddAbility(Unit, RegenerationAbility);
        SetUnitState(Unit, UNIT_STATE_LIFE, GetUnitState(Unit, UNIT_STATE_MAX_LIFE));

        OnControlPointOwnerChange?.Invoke(this, new ControlPointOwnerChangeEventArgs(this, formerOwner));
        ChangedOwner?.Invoke(this, new ControlPointOwnerChangeEventArgs(this, formerOwner));
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
      }
    }
  }
}