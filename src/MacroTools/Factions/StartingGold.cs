namespace MacroTools.Factions;

/// <summary>
/// Gold a player receives for free at the start of the game.
/// </summary>
public sealed class StartingGold
{
  /// <summary>
  /// Gold received instantly on Turn 1.
  /// </summary>
  public required int Instant { get; init; }

  /// <summary>
  /// Gold received each turn from Turn 1 to <see cref="Turns"/>.
  /// </summary>
  public required int Income { get; init; }

  /// <summary>
  /// Turn at which free gold <see cref="Income"/> ends.
  /// </summary>
  public required int Turns { get; init; }
}
