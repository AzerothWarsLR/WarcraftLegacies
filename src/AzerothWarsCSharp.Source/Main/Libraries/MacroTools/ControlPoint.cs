using System;
using System.Collections.Generic;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Main.Libraries.MacroTools
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

    private static readonly Dictionary<int, ControlPoint> _byUnitType = new();
    private static readonly Dictionary<unit, ControlPoint> _byUnit = new();
    private player owner;

    private readonly float value;

    public ControlPoint(unit u, float value)
    {
      Position = new Point(GetUnitX(u), GetUnitY(u));
      Unit = u;
      owner = GetOwningPlayer(u);
      this.value = value;
    }

    public int UnitType => GetUnitTypeId(Unit);

    public string Name => GetUnitName(Unit);

    public Point Position { get; set; }

    public unit Unit { get; }

    public Person OwningPerson => Person.ByHandle(owner);
    public static event EventHandler<ControlPoint>? OnControlPointLoss;
    public static event EventHandler<ControlPointOwnerChangeEventArgs>? OnControlPointOwnerChange;

    private void ChangeOwner(player p)
    {
      Person person = Person.ByHandle(owner);

      person.ControlPointValue -= value;
      person.ControlPointCount -= 1;

      OnControlPointLoss?.Invoke(this, this);

      var formerOwner = owner;
      owner = p;
      person = Person.ByHandle(owner);

      person.ControlPointValue += value;
      person.ControlPointCount += 1;

      OnControlPointOwnerChange?.Invoke(this, new ControlPointOwnerChangeEventArgs(this, formerOwner));
    }

    public static ControlPoint GetFromUnit(unit whichUnit)
    {
      return _byUnit[whichUnit];
    }

    public static ControlPoint GetFromUnitType(int unitType)
    {
      return _byUnitType[unitType];
    }

    /// <summary>
    ///   Registers a <see cref="ControlPoint" /> to the Control Point system.
    /// </summary>
    public static void Register(ControlPoint controlPoint)
    {
      AllControlPoints.Add(controlPoint);
      _byUnit[controlPoint.Unit] = controlPoint;
      _byUnitType[controlPoint.UnitType] = controlPoint;
      BlzSetUnitMaxHP(controlPoint.Unit, MAX_HITPOINTS);
      SetUnitLifePercentBJ(controlPoint.Unit, 80);

      controlPoint.OwningPerson.ControlPointValue += controlPoint.value;
      controlPoint.OwningPerson.ControlPointCount += 1;
    }

    private static void UnitChangesOwner()
    {
      if (_byUnit.ContainsKey(GetTriggerUnit())) _byUnit[GetTriggerUnit()].ChangeOwner(GetTriggerPlayer());
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeChangesOwner, UnitChangesOwner);
    }
  }
}