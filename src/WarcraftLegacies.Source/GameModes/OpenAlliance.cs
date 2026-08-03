using MacroTools.GameModes;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.GameModes;

public sealed class OpenAlliance : IGameMode
{
  /// <inheritdoc />
  public string Name => Loc.Get("Open Alliance");

  /// <inheritdoc />
  public void OnChoose()
  {
    this
      .SetupAllianceCommands()
      .SetupControlPointVictory();
  }

  /// <inheritdoc />
  public int VoteOffset => 0;
}
