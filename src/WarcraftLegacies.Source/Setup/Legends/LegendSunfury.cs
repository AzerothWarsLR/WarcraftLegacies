using MacroTools;
using MacroTools.LegendSystem;



namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendSunfury
  {
    public LegendaryHero Solarian { get; private set; }
    public LegendaryHero Kael { get; private set; }
    public LegendaryHero Kiljaeden { get; private set; }
    public LegendaryHero Pathaleon { get; private set; }
    public Capital WellOfEternity { get; private set; }

    public LegendSunfury(PreplacedUnitSystem preplacedUnitSystem)
    {
      WellOfEternity = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(UNIT_N0DZ_THE_WELL_OF_ETERNITY_SUNFURY_OTHER),
        Essential = true,
        DeathMessage = "The Well of Eternity, once a beacon of immense power, has been destroyed. Its demise marks the end of an era, and the world breathes a sigh of relief."
      };

      Solarian = new LegendaryHero("Solarian")
      {
        UnitType = UNIT_U02V_HIGH_ASTROMANCER_SUNFURY,
        StartingXp = 2800
      };

      Pathaleon = new LegendaryHero("Pathaleon")
      {
        UnitType = UNIT_H098_SUNFURY_MASTERMIND_HIGH_ELVES,
        StartingXp = 1800
      };

      Kael = new LegendaryHero("Kael'thas Sunstrider")
      {
        PlayerColor = PLAYER_COLOR_RED,
        UnitType = UNIT_HKAL_PRINCE_OF_QUEL_THALAS_QUEL_THALAS
      };

      Kiljaeden = new LegendaryHero("Kil'jaeden")
      {
        UnitType = UNIT_U004_THE_DECEIVER_LEGION,
        PermaDies = true,
        StartingXp = 10800,
        DeathMessage = "Kil'jaeden the Deceiver has been annihilated, but it is too late for the Sunfury, who will continue to live and die with demonic taint coursing through their veins."
      };
    }

    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Solarian);
      LegendaryHeroManager.Register(Pathaleon);
      LegendaryHeroManager.Register(Kiljaeden);
      LegendaryHeroManager.Register(Kael);
      CapitalManager.Register(WellOfEternity);
    }
  }
}
