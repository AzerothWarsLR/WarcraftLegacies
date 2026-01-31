using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendSunfury
{
  public LegendaryHero Solarian { get; }
  public LegendaryHero Kael { get; }
  public LegendaryHero Kiljaeden { get; }
  public LegendaryHero Pathaleon { get; }
  public Capital WellOfEternity { get; }

  public LegendSunfury()
  {
    WellOfEternity = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_N0DZ_THE_WELL_OF_ETERNITY_SUNFURY_OTHER),
      Essential = true,
      DeathMessage = "The destruction of the original Well of Eternity tore apart the Azerothean supercontinent. The rupturing of its second successor reaches no such heights, but its absence is felt by Elves and arcanists the world over."
    };

    Solarian = new LegendaryHero("Solarian")
    {
      UnitType = UNIT_U02V_HIGH_ASTROMANCER_SUNFURY,
      StartingXp = 2800
    };

    Pathaleon = new LegendaryHero("Pathaleon")
    {
      UnitType = UNIT_H098_SUNFURY_MASTERMIND_QUELTHALAS,
      StartingXp = 1800
    };

    Kael = new LegendaryHero("Kael'thas Sunstrider")
    {
      PlayerColor = playercolor.Red,
      UnitType = UNIT_HKAL_PRINCE_OF_QUEL_THALAS_QUELTHALAS
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
