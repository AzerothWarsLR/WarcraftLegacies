namespace MacroTools.Extensions;

/// <summary>
/// Determines what happens to units as they are prepared for <see cref="UnitExtensions.Rescue"/>.
/// </summary>
public enum RescuePreparationMode
{
  /// <summary>
  /// Render all prepared units invulnerable.
  /// </summary>
  Invulnerable,

  /// <summary>
  /// Render all prepared units invulnerable, and hide non-structures.
  /// </summary>
  HideNonStructures,

  /// <summary>
  /// Render all prepared units invulnerable, and hide all units and structures.
  /// </summary>
  HideAll
}
