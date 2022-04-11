using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class TeamSetup{
    public static Team TeamLegion { get; private set; }
    public static Team TeamAlliance { get; private set; }
    public static Team TeamHorde { get; private set; }
    
    public static void Setup( ){
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
    }

  }
}
