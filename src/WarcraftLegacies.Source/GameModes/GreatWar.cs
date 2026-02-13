using MacroTools.Commands;
using MacroTools.GameModes;
using WarcraftLegacies.Source.Commands;

namespace WarcraftLegacies.Source.GameModes;

public sealed class GreatWar : IGameMode
{
  /// <inheritdoc />
  public string Name => "Great War (8v8)";

  /// <inheritdoc />
  public void OnChoose()
  {
    CommandManager.Register(new Forfeit());
    this.SetupGreatWarTeams()
      .SetupAllianceCommands();
  }
}
