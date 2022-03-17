using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Setup
{
  public class TeamSetup{

  
    Team TEAM_LEGION
    Team TEAM_ALLIANCE
    Team TEAM_HORDE
    Team TEAM_NIGHT_ELVES
    Team TEAM_NAGA
    Team TEAM_GILNEAS
    Team TEAM_SCARLET
    Team TEAM_FORSAKEN
    Team TEAM_OLDGOD
    Team TEAM_SCOURGE
  

    public static void OnInit( ){
      //Starting teams
      Team t = 0;

      TEAM_ALLIANCE = Team.create("Alliance");
      TEAM_ALLIANCE.VictoryMusic = "HeroicVictory";

      TEAM_LEGION = Team.create("Burning Legion");
      TEAM_LEGION.VictoryMusic = "DarkVictory";

      TEAM_HORDE = Team.create("Horde");
      TEAM_HORDE.VictoryMusic = "DarkVictory";

      TEAM_NIGHT_ELVES = Team.create("Night Elves");
      TEAM_NIGHT_ELVES.VictoryMusic = "HeroicVictory";

      TEAM_OLDGOD = Team.create("Old Gods");
      TEAM_OLDGOD.VictoryMusic = "DarkVictory";

      TEAM_NAGA = Team.create("Illidari");
      TEAM_NAGA.VictoryMusic = "DarkVictory";

      TEAM_GILNEAS = Team.create("Gilneas");
      TEAM_GILNEAS.VictoryMusic = "HeroicVictory";

      TEAM_SCARLET = Team.create("Scarlet Crusade");
      TEAM_SCARLET.VictoryMusic = "DarkVictory";

      TEAM_FORSAKEN = Team.create("Forsaken");
      TEAM_FORSAKEN.VictoryMusic = "DarkVictory";

      TEAM_SCOURGE = Team.create("Northrend");
      TEAM_SCOURGE.VictoryMusic = "DarkVictory";
    }

  }
}
