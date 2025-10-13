using System;
using MacroTools.FactionSystem;

namespace MacroTools.ControlPointSystem;

/// <summary>
///   An immobile and permanent unit on the map.
///   Increases the income of the controlling <see cref="Faction" />.
///   When a <see cref="ControlPoint" /> is reduced below a certain health threshold, it changes ownership to the attacker.
/// </summary>
public sealed class ControlPoint
{
  private float _controlLevel;

  /// <summary>
  /// Fired when the <see cref="ControlLevel"/> of this <see cref="ControlPoint"/> changes.
  /// </summary>
  public event EventHandler? ControlLevelChanged;

  /// <summary>
  /// The owner of this <see cref="ControlPoint"/> changed their alliances, or the <see cref="ControlPoint"/> itself
  /// changed ownership.
  /// </summary>
  public event EventHandler<ControlPoint>? OwnerAllianceChanged;

  /// <summary>
  /// A tower that appears on the <see cref="ControlPoint"/> when its <see cref="ControlLevel"/> exceeds 0.
  /// </summary>
  public unit? Defender { get; internal set; }

  /// <summary>
  /// The owner of the <see cref="ControlPoint"/>.
  /// </summary>
  public player Owner => Unit.Owner;

  /// <summary>
  /// Whether or not this <see cref="ControlPoint"/> can gain levels.
  /// </summary>
  public bool UseControlLevels { get; }

  /// <summary>
  ///   How much gold this <see cref="ControlPoint" /> grants per minute.
  /// </summary>
  public int Value { get; }

  /// <summary>
  /// The unit type ID of the <see cref="ControlPoint"/>.
  /// </summary>
  public int UnitType => Unit.UnitType;

  /// <summary>
  /// A user-friendly name for the <see cref="ControlPoint"/>.
  /// </summary>
  public string Name { get; }

  /// <summary>
  /// The unit representing the <see cref="ControlPoint"/>.
  /// </summary>
  public unit Unit { get; }

  /// <summary>
  /// When <see cref="ControlLevel"/> is higher than 0, the <see cref="ControlPoint"/> becomes a tower with
  /// attack damage and hit points based on its <see cref="ControlLevel"/>.
  /// </summary>
  public float ControlLevel
  {
    get => _controlLevel;
    set
    {
      _controlLevel = value;
      ControlLevelChanged?.Invoke(this, EventArgs.Empty);
    }
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="ControlPoint"/> class.
  /// </summary>
  /// <param name="representingUnit">The unit representing the <see cref="ControlPoint"/>.</param>
  /// <param name="value">The gold income granted by the <see cref="ControlPoint"/>.</param>
  /// <param name="useControlLevels">Whether or not this <see cref="ControlPoint"/> can gain levels.</param>
  public ControlPoint(unit representingUnit, int value, bool useControlLevels)
  {
    Unit = representingUnit;
    Value = value;
    Name = representingUnit.Name;
    UseControlLevels = useControlLevels;
  }

  /// <summary>
  /// Fired when the <see cref="ControlPoint"/> is registered.
  /// </summary>
  internal void OnRegister()
  {
    trigger trigger = trigger.Create();
    trigger.RegisterUnitEvent(Unit, unitevent.ChangeOwner);
    trigger.AddAction(SignalOwnerAllianceChange);
  }

  /// <summary>
  /// Signals that the <see cref="ControlPoint"/>'s <see cref="ControlPoint.Owner"/> has changed its alliances.
  /// </summary>
  internal void SignalOwnerAllianceChange() => OwnerAllianceChanged?.Invoke(this, this);
}
