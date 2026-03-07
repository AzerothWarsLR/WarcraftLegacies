namespace MacroTools.GoldMines;

/// <summary>
/// Settings dictating the behaviour of the <see cref="GoldMineManager"/>.
/// </summary>
public sealed class GoldMineSettings
{
  /// <summary>
  /// The default model assigned to Gold Mines.
  /// </summary>
  public required string GoldMineModelDefault { get; init; }
}
