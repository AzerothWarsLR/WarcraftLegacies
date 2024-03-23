using MacroTools.GameModes;

namespace WarcraftLegacies.Source.GameModes
{
  public sealed class OpenAlliance : IGameMode
  {
    /// <inheritdoc />
    public string Name => "Open Alliance";

    /// <inheritdoc />
    public void OnChoose()
    {
      this
        .SetupAllianceCommands()
        .SetupControlPointVictory();
    }
  }
}