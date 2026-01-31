using MacroTools.Factions;

namespace WarcraftLegacies.Source.Setup;

public static class TeamSetup
{
  public static Team Legion { get; private set; }
  public static Team Alliance { get; private set; }
  public static Team NorthAlliance { get; private set; }
  public static Team SouthAlliance { get; private set; }
  public static Team Horde { get; private set; }
  public static Team NightElves { get; private set; }
  public static Team Outland { get; private set; }
  public static Team OldGods { get; private set; }
  public static Team Kalimdor { get; private set; }
  public static void Setup()
  {
    Alliance = new Team("Alliance")
    {
      VictoryMusic = "HeroicVictory"
    };
    FactionManager.Register(Alliance);

    NorthAlliance = new Team("North Alliance")
    {
      VictoryMusic = "HeroicVictory"
    };
    FactionManager.Register(NorthAlliance);

    SouthAlliance = new Team("South Alliance")
    {
      VictoryMusic = "HeroicVictory"
    };
    FactionManager.Register(SouthAlliance);

    Legion = new Team("Burning Legion")
    {
      VictoryMusic = "DarkVictory"
    };
    FactionManager.Register(Legion);

    Horde = new Team("Horde")
    {
      VictoryMusic = "DarkVictory"
    };
    FactionManager.Register(Horde);

    NightElves = new Team("Night Elves")
    {
      VictoryMusic = "HeroicVictory"
    };
    FactionManager.Register(NightElves);

    Outland = new Team("Outland")
    {
      VictoryMusic = "DarkVictory"
    };
    FactionManager.Register(Outland);

    OldGods = new Team("Old Gods")
    {
      VictoryMusic = "DarkVictory"
    };
    FactionManager.Register(OldGods);

    Kalimdor = new Team("Kalimdor")
    {
      VictoryMusic = "HeroicVictory"
    };
    FactionManager.Register(Kalimdor);
  }

}
