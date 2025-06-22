using MacroTools.GameModes;

namespace WarcraftLegacies.Source.GameModes
{
  public sealed class GreatWar : IGameMode
  {
    /// <inheritdoc />
    public string Name => "Great War (8v8)";

    /// <inheritdoc />
    public void OnChoose()
    {
      this.SetupGreatWarTeams()
        .SetupAllianceCommands();
    }
  }
}