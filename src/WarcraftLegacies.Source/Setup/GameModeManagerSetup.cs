using MacroTools.GameModes;
using WarcraftLegacies.Source.GameModes;

namespace WarcraftLegacies.Source.Setup;

public static class GameModeManagerSetup
{
  public static void PostSetup()
  {
    var gameModeManager = new GameModeManager(new IGameMode[]
    {
      new ClosedAlliance(),
      new OpenAlliance(),
      new GreatWar()
    })
    {
      TimeToDisplay = 49,
      VoteLength = 10
    };
    gameModeManager.Setup();
  }
}
