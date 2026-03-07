namespace MacroTools.ControlPoints;

/// <summary>
/// Settings determining the behaviour of the <see cref="ControlPointManager"/>.
/// </summary>
public sealed class ControlPointSettings
{
  /// <summary>
  /// The maximum <see cref="ControlPoint.ControlLevel"/> a <see cref="ControlPoint"/> can have.
  /// </summary>
  public required int ControlLevelMaximum { get; init; }

  /// <summary>
  /// The amount of armor given to <see cref="ControlPoint"/>s per <see cref="ControlPoint.ControlLevel"/>.
  /// </summary>
  public required int ArmorPerControlLevel { get; init; }

  /// <summary>
  /// The amount of hit points given to <see cref="ControlPoint"/>s per <see cref="ControlPoint.ControlLevel"/>.
  /// </summary>
  public required int HitPointsPerControlLevel { get; init; }
}
