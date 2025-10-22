using System;
using MacroTools.Extensions;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Opens a two-way Waygate for as long as the caster keeps channeling.
/// </summary>
public sealed class WaygateOpen : Spell
{
  /// <summary>
  /// The unit type ID for the entrance Waygate to create.
  /// </summary>
  public int InteriorWaygateUnitTypeId { get; init; }

  /// <summary>
  /// The unit type ID for the exit Waygate to create.
  /// </summary>
  public int ExteriorWaygateUnitTypeId { get; init; }

  /// <summary>
  /// A function that returns where the exit waygate should be created.
  /// </summary>
  public Func<Point>? GetInteriorWaygatePosition { get; init; }

  /// <summary>
  /// A function that returns where the entrance Waygate should be created.
  /// </summary>
  public Func<Point>? GetExteriorWaygatePosition { get; init; }

  private unit? _exteriorWaygate;
  private unit? _interiorWaygate;

  /// <summary>
  /// Initializes a new instance of the <see cref="WaygateOpen"/> class.
  /// </summary>
  /// <param name="id"></param>
  public WaygateOpen(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (GetExteriorWaygatePosition == null)
    {
      throw new InvalidOperationException(
        $"{nameof(WaygateOpen)} must declare both {nameof(GetExteriorWaygatePosition)}");
    }

    if (GetInteriorWaygatePosition == null)
    {
      throw new InvalidOperationException(
        $"{nameof(WaygateOpen)} must declare both {nameof(GetInteriorWaygatePosition)}");
    }

    var exteriorWaygatePosition = GetExteriorWaygatePosition();
    var interiorWaygatePosition = GetInteriorWaygatePosition();

    _exteriorWaygate = unit.Create(player.NeutralPassive, ExteriorWaygateUnitTypeId, exteriorWaygatePosition.X, exteriorWaygatePosition.Y, 0);
    _exteriorWaygate.SetWaygateDestination(interiorWaygatePosition);

    _interiorWaygate = unit.Create(player.NeutralPassive, InteriorWaygateUnitTypeId, interiorWaygatePosition.X, interiorWaygatePosition.Y, 0);
    _exteriorWaygate.SetWaygateDestination(exteriorWaygatePosition);
  }

  /// <inheritdoc />
  public override void OnStop(unit caster)
  {
    _exteriorWaygate.Dispose();
    _interiorWaygate.Dispose();
    _exteriorWaygate = null;
    _interiorWaygate = null;
  }
}
