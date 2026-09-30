using MacroTools.Commands;
using MacroTools.GameModes;
using MacroTools.Localization;
using WarcraftLegacies.Source.Commands;

namespace WarcraftLegacies.Source.GameModes;

public sealed class GreatWar : IGameMode
{
  /// <inheritdoc />
  public string Name => Loc.Get("Great War (7v7)");

  /// <inheritdoc />
  public void OnChoose()
  {
    CommandManager.Register(new Forfeit());
    this.SetupGreatWarTeams()
      .SetupAllianceCommands();
  }

  /// <inheritdoc />
  public int VoteOffset => -4;
}
