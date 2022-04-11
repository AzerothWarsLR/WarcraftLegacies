using AzerothWarsCSharp.MacroTools.Factions;

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
      TeamAlliance = new Team("Alliance")
      {
        VictoryMusic = "HeroicVictory"
      };

      TeamLegion = new Team("Burning Legion")
      {
        VictoryMusic = "DarkVictory"
      };

      TeamHorde = new Team("Horde")
      {
        VictoryMusic = "DarkVictory"
      };

      TeamNightElves = new Team("Night Elves")
      {
        VictoryMusic = "HeroicVictory"
      };

      TeamOldgod = new Team("Old Gods")
      {
        VictoryMusic = "DarkVictory"
      };

      TeamNaga = new Team("Illidari")
      {
        VictoryMusic = "DarkVictory"
      };

      TeamGilneas = new Team("Gilneas")
      {
        VictoryMusic = "HeroicVictory"
      };

      TeamScarlet = new Team("Scarlet Crusade")
      {
        VictoryMusic = "DarkVictory"
      };

      TeamForsaken = new Team("Forsaken")
      {
        VictoryMusic = "DarkVictory"
      };

      TeamScourge = new Team("Northrend")
      {
        VictoryMusic = "DarkVictory"
      };
    }

  }
}
