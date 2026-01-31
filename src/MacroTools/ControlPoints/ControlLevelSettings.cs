namespace MacroTools.ControlPoints;

/// <summary>
/// Determines the settings for the <see cref="ControlPoint.Defender"/> units that defend <see cref="ControlPoint"/>s.
/// </summary>
public sealed class ControlLevelSettings
{
  /// <summary>
  /// The maximum <see cref="ControlPoint.ControlLevel"/> a <see cref="ControlPoint"/> can have.
  /// </summary>
  public int ControlLevelMaximum { get; init; }

  /// <summary>
  /// The default unit type ID to be used for <see cref="ControlPoint"/> <see cref="ControlPoint.Defender"/>s.
  /// </summary>
  public int DefaultDefenderUnitTypeId { get; init; }

  /// <summary>
  /// The base damage for <see cref="ControlPoint.Defender"/>s.
  /// </summary>
  public int DamageBase { get; init; }

  /// <summary>
  /// The amount of damage <see cref="ControlPoint.Defender"/>s get per <see cref="ControlPoint.ControlLevel"/> they have.
  /// </summary>
  public int DamagePerControlLevel { get; init; }

  /// <summary>
  /// The amount of armor given to <see cref="ControlPoint"/>s per <see cref="ControlPoint.ControlLevel"/>.
  /// </summary>
  public int ArmorPerControlLevel { get; init; }

  /// <summary>
  /// The amount of hit points given to <see cref="ControlPoint"/>s per <see cref="ControlPoint.ControlLevel"/>.
  /// </summary>
  public int HitPointsPerControlLevel { get; init; }
}
