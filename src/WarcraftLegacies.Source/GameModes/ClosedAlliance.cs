using MacroTools.GameModes;

namespace WarcraftLegacies.Source.GameModes;

public sealed class ClosedAlliance : IGameMode
{
  /// <inheritdoc />
  public string Name => "Closed Alliance";

  /// <inheritdoc />
  public void OnChoose()
  {
    this
      .SetupControlPointVictory()
      .SetupUnallyCommand();
  }
}
