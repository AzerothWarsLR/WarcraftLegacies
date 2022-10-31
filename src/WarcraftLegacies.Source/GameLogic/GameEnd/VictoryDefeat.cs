using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.GameLogic.GameEnd
{
  public static class VictoryDefeat
  {
    public static bool GameWon;
    private static readonly string VictoryColor = "|cff911499";
    
    public static void TeamVictory(Team whichTeam)
    {
      ClearTextMessages();
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0,
        VictoryColor + "\nTEAM VICTORY!|r\nThe " + whichTeam.Name +
        " has won the game! Surviving players may continue playing, but scores have already been recorded.");
      PlayThematicMusic(whichTeam.VictoryMusic);
      GameWon = true;
    }
  }
}