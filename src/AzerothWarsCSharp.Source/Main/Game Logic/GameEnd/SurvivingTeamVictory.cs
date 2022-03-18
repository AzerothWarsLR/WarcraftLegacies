//When there is only one team left in the game that hasn)t been defeated, that team wins.

using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Game_Logic.GameEnd
{
  public class SurvivingTeamVictory{

    private static void OnTeamScoreStatusChanged( ){
      Team loopTeam;
      var i = 0;
      Team victoriousTeam = 0;
      var total = 0;
      if (!GameWon && GetTriggerTeam().ScoreStatus == SCORESTATUS_DEFEATED){
        while(true){
          if ( i == Team.Count || total > 1){ break; }
          loopTeam = Team.ByIndex(i);
          if (loopTeam.ScoreStatus == SCORESTATUS_NORMAL){
            total = total + 1;
            victoriousTeam = loopTeam;
          }
          i = i + 1;
        }
      }
      if (total == 1){
        TeamVictory(victoriousTeam);
      }
    }

    public static void Setup( ){
      trigger trig = CreateTrigger();
      TeamScoreStatusChanged.register(trig);
      TriggerAddAction(trig,  OnTeamScoreStatusChanged);
    }

  }
}
