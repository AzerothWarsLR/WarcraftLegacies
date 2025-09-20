using MacroTools.FactionSystem;

namespace TestMap.Source.Setup;

public static class TeamSetup
{
  public static Team TeamLegion { get; private set; }
  public static Team TeamAlliance { get; private set; }
  public static Team TeamHorde { get; private set; }

  public static void Setup()
  {
    TeamAlliance = new Team("Alliance")
    {
      VictoryMusic = "HeroicVictory"
    };
    FactionManager.Register(TeamAlliance);

    TeamLegion = new Team("Burning Legion")
    {
      VictoryMusic = "DarkVictory"
    };
    FactionManager.Register(TeamLegion);

    TeamHorde = new Team("Horde")
    {
      VictoryMusic = "DarkVictory"
    };
    FactionManager.Register(TeamHorde);
  }

}
