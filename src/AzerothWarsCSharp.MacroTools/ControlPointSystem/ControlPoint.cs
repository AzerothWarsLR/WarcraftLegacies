using System;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using static War3Api.Common;


namespace AzerothWarsCSharp.MacroTools.ControlPointSystem
{
  /// <summary>
  ///   An immobile and permanent unit on the map.
  ///   Increases the income of the controlling <see cref="Faction" />.
  ///   When a <see cref="ControlPoint" /> is reduced below a certain health threshold, it changes ownership to the attacker.
  /// </summary>
  public sealed class ControlPoint
  {
    private const float CAPTURE_THRESHOLD = 0.8f; //Percentage of maximum HP; below this, the CP will go to the damager
    private static readonly int RegenerationAbility = FourCC("A0UT");

    private readonly TriggerWrapper _damageTrigger = new();
    private readonly TriggerWrapper _changeOwnerTrigger = new();

    public ControlPoint(unit u, float value)
    {
      Unit = u;
      Value = value;

      TriggerRegisterUnitEvent(_damageTrigger.Trigger, Unit, EVENT_UNIT_DAMAGED);
      TriggerRegisterUnitEvent(_changeOwnerTrigger.Trigger, Unit, EVENT_UNIT_CHANGE_OWNER);

      TriggerAddAction(_damageTrigger.Trigger, OnDamaged);
      TriggerAddAction(_changeOwnerTrigger.Trigger, ChangeOwner);
    }

    public player Owner => GetOwningPlayer(Unit);
    
    /// <summary>
    ///   How much gold this <see cref="ControlPoint" /> grants per minute.
    /// </summary>
    public float Value { get; }

    public int UnitType => GetUnitTypeId(Unit);

    public string Name => GetUnitName(Unit);

    public unit Unit { get; }
    
    /// <summary>
    ///   Fires when the <see cref="ControlPoint" /> changes its owner.
    /// </summary>
    public event EventHandler<ControlPointOwnerChangeEventArgs>? ChangedOwner;
    
    public static event EventHandler<ControlPointOwnerChangeEventArgs>? OnControlPointOwnerChange;

    private void OnDamaged()
    {
      try
      {
        unit attacker = GetEventDamageSource();

        var hp = (GetUnitState(Unit, UNIT_STATE_LIFE) - GetEventDamage()) /
                 GetUnitState(Unit, UNIT_STATE_MAX_LIFE);
        if (hp < CAPTURE_THRESHOLD)
        {
          BlzSetEventDamage(0);
          SetUnitOwner(Unit, GetOwningPlayer(attacker), true);
          Unit.SetLifePercent(85);
        }
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
        var newOwner = GetTriggerPlayer();

        PlayerData playerData = PlayerData.ByHandle(formerOwner);
        
        playerData.ControlPointValue -= Value;
        playerData.ControlPointCount -= 1;
        
        playerData = PlayerData.ByHandle(newOwner);

        playerData.ControlPointValue += Value;
        playerData.ControlPointCount += 1;
        
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