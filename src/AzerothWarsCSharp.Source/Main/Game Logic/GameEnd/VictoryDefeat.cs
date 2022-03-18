using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Game_Logic.GameEnd
{
  public class VictoryDefeat{

  
    string VICTORY_COLOR = "|cff911499";
    string DEFEAT_COLOR = "|cff911499";
    boolean GameWon = false;
  

    static void TeamVictory(Team whichTeam ){
      var i = 0;
      Team loopTeam;

      ClearTextMessages();
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, VICTORY_COLOR + "\nTEAM VICTORY!|r\nThe " + whichTeam.Name + " has won the game! Surviving players may continue playing, but scores have already been recorded.");
      //Give victory to ALL teams which are still standing at this point
      while(true){
        if ( i == Team.Count){ break; }
        loopTeam = Team.ByIndex(i);
        i = i + 1;
      }
      PlayThematicMusic(loopTeam.VictoryMusic);
      GameWon = true;
    }

    static void DefeatTeam(Team whichTeam ){
      if (GetGameTime() >= 60){
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, VICTORY_COLOR + "\nTEAM DEFEAT!|r\nThe " + whichTeam.Name + " has been defeated.");
        StartSound(gg_snd_GameFound);
      }
    }

  }
}
