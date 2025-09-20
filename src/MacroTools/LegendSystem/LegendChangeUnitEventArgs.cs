using System;

namespace MacroTools.LegendSystem;

/// <summary>
/// Event arguments for when a <see cref="Legend"/> changes unit.
/// </summary>
public sealed class LegendChangeUnitEventArgs : EventArgs
{
  /// <summary>
  /// The <see cref="Legend"/> triggering the event.
  /// </summary>
  public Legend Legend { get; }

  /// <summary>
  /// The <see cref="unit"/> that used to represent the <see cref="Legend"/>.
  /// </summary>
  public unit? PreviousUnit { get; }

  /// <summary>
  /// Initializes a new instance of the <see cref="LegendChangeUnitEventArgs"/> class.
  /// </summary>
  public LegendChangeUnitEventArgs(Legend legend, unit? previousUnit)
  {
    Legend = legend;
    PreviousUnit = previousUnit;
  }
}
