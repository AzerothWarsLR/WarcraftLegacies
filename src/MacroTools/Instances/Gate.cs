using System;
using WCSharp.Shared.Data;

namespace MacroTools.Instances;

/// <summary>
/// Describes an entryway into an <see cref="Instance"/>.
/// </summary>
public sealed class Gate
{
  private readonly Func<Point> _exteriorPosition;
  private readonly Func<Point> _interiorPosition;

  /// <summary>
  /// Initializes a new instance of the <see cref="Gate"/> class.
  /// </summary>
  /// <param name="interiorPosition">A function describing the interior position of the <see cref="Gate"/>.</param>
  /// <param name="exteriorPosition">A function describing the exterior position of the <see cref="Gate"/>.</param>
  public Gate(Func<Point> interiorPosition, Func<Point> exteriorPosition)
  {
    _interiorPosition = interiorPosition;
    _exteriorPosition = exteriorPosition;
  }

  /// <summary>
  /// A function describing the interior position of the <see cref="Gate"/>.
  /// </summary>
  public Point InteriorPosition => _interiorPosition();

  /// <summary>
  /// A function describing the exterior position of the <see cref="Gate"/>.
  /// </summary>
  public Point ExteriorPosition => _exteriorPosition();
}
