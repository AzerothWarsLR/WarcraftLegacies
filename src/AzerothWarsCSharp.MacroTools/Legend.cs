using System;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  /// <summary>
  ///   Represents a character from the Warcraft universe. A Legend always has a unit type.
  ///   A Legend can be represented by 0 or 1 units, and each unit can be either 0 or 1 Legends.
  /// </summary>
  public sealed class Legend
  {
    private trigger? _changeOwnerTrigger;
    private trigger? _damagedTrigger;

    private trigger? _deathTrigger;

    private unit? _unit;

    public Legend(unit unit)
    {
      Unit = unit;
      UnitTypeId = GetUnitTypeId(unit);
    }

    public Legend(int unitTypeId)
    {
      UnitTypeId = unitTypeId;
    }

    private static int DummyAbilityDiesWithout { get; } = FourCC("LEgn");
    private static int DummyAbilityPermaDies { get; } = FourCC("LEgo");
    private static int DummyAbilityCapital { get; } = FourCC("LEca");

    public int UnitTypeId { get; set; }

    public string Name { get; init; } = "DefaultName";

    public unit? Unit
    {
      get => _unit;
      set
      {
        _unit = value;
        DestroyTrigger(_deathTrigger);
        DestroyTrigger(_damagedTrigger);
        DestroyTrigger(_changeOwnerTrigger);
        _deathTrigger = CreateTrigger();
        _damagedTrigger = CreateTrigger();
        _changeOwnerTrigger = CreateTrigger();
        TriggerRegisterUnitEvent(_deathTrigger, value, EVENT_UNIT_DEATH);
        TriggerRegisterUnitEvent(_damagedTrigger, value, EVENT_UNIT_DAMAGED);
        TriggerRegisterUnitEvent(_changeOwnerTrigger, value, EVENT_UNIT_CHANGE_OWNER);
        TriggerAddAction(_deathTrigger, OnDeathTrigger);
        TriggerAddAction(_damagedTrigger, OnDamagedTrigger);
        TriggerAddAction(_changeOwnerTrigger, OnChangeOwnerTrigger);
      }
    }

    /// <summary>
    ///   The Warcraft 3 player that controls this <see cref="Legend" />.
    ///   <see langword="null" /> if the <see cref="Legend" /> doesn't have a unit on the map.
    /// </summary>
    public player? OwningPlayer
    {
      get => GetOwningPlayer(_unit);
      set
      {
        if (GetOwningPlayer(_unit) != value) SetUnitOwner(_unit, value, true);
      }
    }

    public event EventHandler<LegendChangedOwnerEventArgs>? ChangedOwner;

    private void OnDeathTrigger()
    {
    }

    private void OnDamagedTrigger()
    {
    }

    private void OnChangeOwnerTrigger()
    {
      ChangedOwner?.Invoke(this, new LegendChangedOwnerEventArgs(this, GetChangingUnitPrevOwner()));
    }

    /// <summary>
    ///   Creates a unit representing this Legend.
    /// </summary>
    public void CreateOnMap(Point point, float facing = 270)
    {
      if (Unit != null)
        throw new Exception($"Legend {Name} already has a unit representing it named {GetUnitName(Unit)}.");
      Unit = CreateUnit(Player(0), UnitTypeId, point.X, point.Y, facing);
      ChangedOwner?.Invoke(this, new LegendChangedOwnerEventArgs(this, null));
    }

    ~Legend()
    {
      DestroyTrigger(_deathTrigger);
      DestroyTrigger(_damagedTrigger);
      DestroyTrigger(_changeOwnerTrigger);
    }
  }
}