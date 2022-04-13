using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.Libraries;
using WCSharp.Events;
using WCSharp.Shared.Data;
using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  /// <summary>
  ///   An immobile and permanent unit on the map.
  ///   Increases the income of the controlling <see cref="Faction" />.
  /// </summary>
  public sealed class ControlPoint
  {
    private const int MAX_HITPOINTS = 10000; //All Control Points get given this many hitpoints
    private static readonly List<ControlPoint> AllControlPoints = new();

    private static readonly int RegenerationAbility = FourCC("A0UT");

    private static readonly Dictionary<int, ControlPoint> ByUnitType = new();
    private static readonly Dictionary<unit, ControlPoint> ByUnit = new();

    private readonly float _value;
    private player _owner;

    public ControlPoint(unit u, float value)
    {
      Position = new Point(GetUnitX(u), GetUnitY(u));
      Unit = u;
      _owner = GetOwningPlayer(u);
      _value = value;
    }

    public int UnitType => GetUnitTypeId(Unit);

    public string Name => GetUnitName(Unit);

    public Point Position { get; set; }

    public unit Unit { get; }

    public Person OwningPerson => Person.ByHandle(_owner);

    /// <summary>
    /// Fires when the <see cref="ControlPoint"/> changes its owner.
    /// </summary>
    public event EventHandler<ControlPointOwnerChangeEventArgs>? ChangedOwner;

    /// <summary>
    ///   Whether or not the given unit is a <see cref="ControlPoint" />.
    /// </summary>
    /// <param name="unit"></param>
    /// <returns></returns>
    public static bool UnitIsControlPoint(unit unit)
    {
      return ByUnit.ContainsKey(unit);
    }

    public static event EventHandler<ControlPoint>? OnControlPointLoss;
    public static event EventHandler<ControlPointOwnerChangeEventArgs>? OnControlPointOwnerChange;

    private void ChangeOwner()
    {
      var p = GetTriggerPlayer();
      
      Person person = Person.ByHandle(_owner);

      person.ControlPointValue -= _value;
      person.ControlPointCount -= 1;

      OnControlPointLoss?.Invoke(this, this);

      var formerOwner = _owner;
      _owner = p;
      person = Person.ByHandle(_owner);

      person.ControlPointValue += _value;
      person.ControlPointCount += 1;

      UnitAddAbility(Unit, RegenerationAbility);
      
      OnControlPointOwnerChange?.Invoke(this, new ControlPointOwnerChangeEventArgs(this, formerOwner));
      ChangedOwner?.Invoke(this, new ControlPointOwnerChangeEventArgs(this, formerOwner));
    }

    public static ControlPoint GetFromUnit(unit whichUnit)
    {
      return ByUnit[whichUnit];
    }

    public static ControlPoint GetFromUnitType(int unitType)
    {
      if (ByUnitType.TryGetValue(unitType, out var controlPoint))
      {
        return controlPoint;
      }

      throw new KeyNotFoundException($"There is no {nameof(ControlPoint)} with unit type ID {GeneralHelpers.DebugIdInteger2IdString(unitType)}");
    }

    /// <summary>
    ///   Registers a <see cref="ControlPoint" /> to the Control Point system.
    /// </summary>
    public static void Register(ControlPoint controlPoint)
    {
      AllControlPoints.Add(controlPoint);
      ByUnit.Add(controlPoint.Unit, controlPoint);
      ByUnitType.Add(controlPoint.UnitType, controlPoint);
      BlzSetUnitMaxHP(controlPoint.Unit, MAX_HITPOINTS);
      SetUnitLifePercentBJ(controlPoint.Unit, 80);

      controlPoint.OwningPerson.ControlPointValue += controlPoint._value;
      controlPoint.OwningPerson.ControlPointCount += 1;
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeChangesOwner, controlPoint.ChangeOwner, controlPoint.UnitType);
    }
  }
}