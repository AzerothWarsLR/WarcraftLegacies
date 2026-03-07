namespace MacroTools.ControlPoints;

/// <summary>
/// Settings determining the behaviour of the <see cref="ControlPointDefenderManager"/>.
/// </summary>
public sealed class ControlPointDefenderSettings
{
  /// <summary>
  /// The base damage for <see cref="ControlPoint.Defender"/>s.
  /// </summary>
  public required int DamageBase { get; init; }

  /// <summary>
  /// The amount of damage <see cref="ControlPoint.Defender"/>s get per <see cref="ControlPoint.ControlLevel"/> they have.
  /// </summary>
  public required int DamagePerControlLevel { get; init; }
}
