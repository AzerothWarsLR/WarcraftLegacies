using System;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;
using static War3Api.Blizzard;

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
    private player _owner;

    public ControlPoint(unit u, float value)
    {
      Unit = u;
      _owner = GetOwningPlayer(u);
      Value = value;
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeChangesOwner, ChangeOwner, UnitType);
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeIsDamaged, OnDamaged, UnitType);
    }

    /// <summary>
    ///   How much gold this <see cref="ControlPoint" /> grants per minute.
    /// </summary>
    public float Value { get; }

    public int UnitType => GetUnitTypeId(Unit);

    public string Name => GetUnitName(Unit);

    public unit Unit { get; }

    public Person OwningPerson => Person.ByHandle(_owner);

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
          SetUnitLifePercentBJ(Unit, 85);
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
        var p = GetTriggerPlayer();

        Person person = Person.ByHandle(_owner);

        person.ControlPointValue -= Value;
        person.ControlPointCount -= 1;
        
        var formerOwner = _owner;
        _owner = p;
        person = Person.ByHandle(_owner);

        person.ControlPointValue += Value;
        person.ControlPointCount += 1;

        UnitAddAbility(Unit, RegenerationAbility);

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