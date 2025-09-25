using System;
using MacroTools.Extensions;
using WCSharp.Events;

namespace MacroTools.LegendSystem;

/// <summary>
///   A Legend is a wrapper for unique heroes. A Legend can continue to exist even if the unit it describes does not.
///   A Legend might have other units it relies on to survive. If so, when it dies, it gets removed if those units are not
///   under control.
///   There is a dummy ability to represent this.
/// </summary>
public abstract class Legend
{
  private unit? _unit;
  private int _unitType;

  /// <summary>
  /// A flavourful message that pops up when this <see cref="Legend"/> dies permanently.
  /// </summary>
  public string? DeathMessage { protected get; set; }

  /// <summary>
  /// The unit representing this <see cref="Legend"/>.
  /// <para>The system will assign this on its own if a <see cref="UnitType"/> has been set for the <see cref="Legend"/>,
  /// and a hero with that <see cref="UnitType"/> is trained from an Altar.</para>
  /// </summary>
  public unit? Unit
  {
    get => _unit.Owner == null ? null : _unit;
    set
    {
      var previousUnit = Unit;
      if (Unit != null)
      {
        Unit.DropAllItems();
        _unit.Dispose();
      }

      _unit = value;

      if (_unit == null)
      {
        return;
      }

      _unitType = _unit.UnitType;
      OnChangeUnit();
      UnitChanged?.Invoke(this, new LegendChangeUnitEventArgs(this, previousUnit));
    }
  }

  /// <summary>
  ///   If true, this <see cref="Legend"/> is essential for parent faction to avoid elimination
  /// </summary>
  public bool Essential { get; set; }

  /// <summary>
  /// Invoked when the <see cref="Unit"/> value changes.
  /// </summary>
  public event EventHandler<LegendChangeUnitEventArgs>? UnitChanged;

  /// <summary>
  /// Initializes a new instance of the <see cref="Legend"/> class.
  /// </summary>
  protected Legend()
  {
    PlayerUnitEvents.Register(UnitTypeEvent.FinishesTraining, () =>
    {
      var trainedUnit = @event.TrainedUnit;
      if (UnitType != trainedUnit.UnitType)
      {
        return;
      }

      Unit = trainedUnit;
      ChangedOwner?.Invoke(this, new LegendChangeOwnerEventArgs(this));
    });
    Essential = false;
  }

  /// <summary>
  /// Fired when the <see cref="Legend"/> changes unit.
  /// </summary>
  protected virtual void OnChangeUnit() { }

  /// <summary>
  ///   If true, when the Legend dies, its parent faction is defeated.
  /// </summary>
  public bool Hivemind { get; set; }

  /// <summary>
  ///   The current unit type of the Legend. Can be changed at any time, even if the Legend is already in the game world.
  ///   This will be automatically updated if unit is changed.
  /// </summary>
  public int UnitType
  {
    get => _unitType;
    set
    {
      if (_unit != null)
      {
        var newUnit = unit.Create(OwningPlayer, value, _unit.X, _unit.Y, _unit.Facing);
        newUnit.Life = _unit.Life;
        newUnit.Mana = _unit.Mana;
        newUnit.SetExperience(_unit.Experience);
        _unit.TransferItems(newUnit);
        var oldX = _unit.X;
        var oldY = _unit.Y;
        _unit.Dispose();
        Unit = newUnit;
        _unit.SetPosition(oldX, oldY);
      }

      _unitType = value;
    }
  }

  /// <summary>
  /// The player that owns the unit representing this <see cref="Legend"/>. Returns null if the <see cref="Legend"/>
  /// doesn't exist on the map yet.
  /// </summary>
  public player? OwningPlayer => _unit.Owner;

  /// <summary>
  ///   Fired when the <see cref="Legend" /> changes owner.
  /// </summary>
  public event EventHandler<LegendChangeOwnerEventArgs>? ChangedOwner;

  /// <summary>
  /// Invokes the <see cref="ChangedOwner"/> event.
  /// </summary>
  protected void OnChangeOwner(LegendChangeOwnerEventArgs args)
  {
    ChangedOwner?.Invoke(this, args);
  }
}
