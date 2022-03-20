using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup
{
  public class TeamSetup{

  
    public static Team TEAM_LEGION { get; private set; }
    public static Team TEAM_ALLIANCE { get; private set; }
    public static Team TEAM_HORDE { get; private set; }
    public static Team TEAM_NIGHT_ELVES { get; private set; }
    public static Team TEAM_NAGA { get; private set; }
    public static Team TEAM_GILNEAS { get; private set; }
    public static Team TEAM_SCARLET { get; private set; }
    public static Team TEAM_FORSAKEN { get; private set; }
    public static Team TEAM_OLDGOD { get; private set; }
    public static Team TEAM_SCOURGE { get; private set; }
  

    public static void Setup( ){
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
