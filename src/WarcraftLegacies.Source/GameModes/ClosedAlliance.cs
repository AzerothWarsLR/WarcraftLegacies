using MacroTools.GameModes;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.GameModes;

public sealed class ClosedAlliance : IGameMode
{
  /// <inheritdoc />
  public string Name => Loc.Get("Closed Alliance");

  /// <inheritdoc />
  public void OnChoose()
  {
    this
      .SetupControlPointVictory()
      .SetupUnallyCommand();
  }

  /// <inheritdoc />
  public int VoteOffset => 0;
}
