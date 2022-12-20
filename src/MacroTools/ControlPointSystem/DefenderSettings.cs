namespace MacroTools.ControlPointSystem
{
  /// <summary>
  /// Determines the settings for the <see cref="ControlPoint.Defender"/> units that defend <see cref="ControlPoint"/>s.
  /// </summary>
  public sealed class DefenderSettings
  {
    /// <summary>
    /// When <see cref="ControlPoint"/>s have a <see cref="ControlPoint.ControlLevel"/> greater than 0, they spawn a
    /// unit with this ID to defend them.
    /// </summary>
    public int DefenderUnitTypeId { get; init; }
    
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
  }
}