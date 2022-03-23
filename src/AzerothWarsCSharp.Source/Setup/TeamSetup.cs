using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Setup
{
  public class TeamSetup{

  
    public static Team TeamLegion { get; private set; }
    public static Team TeamAlliance { get; private set; }
    public static Team TeamHorde { get; private set; }
    public static Team TeamNightElves { get; private set; }
    public static Team TeamNaga { get; private set; }
    public static Team TeamGilneas { get; private set; }
    public static Team TeamScarlet { get; private set; }
    public static Team TeamForsaken { get; private set; }
    public static Team TeamOldgod { get; private set; }
    public static Team TeamScourge { get; private set; }
  

    public static void Setup( ){
      //Starting teams
      Team t = 0;

      TeamAlliance = Team.create("Alliance");
      TeamAlliance.VictoryMusic = "HeroicVictory";

      TeamLegion = Team.create("Burning Legion");
      TeamLegion.VictoryMusic = "DarkVictory";

      TeamHorde = Team.create("Horde");
      TeamHorde.VictoryMusic = "DarkVictory";

      TeamNightElves = Team.create("Night Elves");
      TeamNightElves.VictoryMusic = "HeroicVictory";

      TeamOldgod = Team.create("Old Gods");
      TeamOldgod.VictoryMusic = "DarkVictory";

      TeamNaga = Team.create("Illidari");
      TeamNaga.VictoryMusic = "DarkVictory";

      TeamGilneas = Team.create("Gilneas");
      TeamGilneas.VictoryMusic = "HeroicVictory";

      TeamScarlet = Team.create("Scarlet Crusade");
      TeamScarlet.VictoryMusic = "DarkVictory";

      TeamForsaken = Team.create("Forsaken");
      TeamForsaken.VictoryMusic = "DarkVictory";

      TeamScourge = Team.create("Northrend");
      TeamScourge.VictoryMusic = "DarkVictory";
    }

  }
}
