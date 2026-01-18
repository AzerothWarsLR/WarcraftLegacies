using System;

namespace MacroTools.Legends;

/// <summary>
/// Event arguments for when a <see cref="Legend"/> dies.
/// </summary>
public sealed class LegendDiedEventArgs : EventArgs
{
  /// <summary>
  /// The <see cref="LegendaryHero"/> that died.
  /// </summary>
  public required LegendaryHero LegendaryHero { get; init; }

  /// <summary>
  /// True if the <see cref="Legend"/> was killed permanently.
  /// </summary>
  public required bool Permanent { get; init; }
}
