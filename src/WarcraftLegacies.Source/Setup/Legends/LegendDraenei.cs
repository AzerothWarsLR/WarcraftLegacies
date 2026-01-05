using MacroTools.LegendSystem;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendDraenei
{
  public LegendaryHero Velen { get; }
  public LegendaryHero Maraad { get; }
  public LegendaryHero Adal { get; }
  public LegendaryHero LegendNobundo { get; }
  public Capital LegendExodar { get; }
  public Capital LegendExodarGenerator { get; }
  public Capital Shattrah { get; }
  public Capital Halaar { get; }

  public LegendDraenei()
  {
    LegendNobundo = new LegendaryHero("Nobundo")
    {
      UnitType = UNIT_E01J_HIGH_SHAMAN_DRUIDS,
      StartingXp = 1800
    };

    LegendExodar = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_E01X_EXODAR_REGALIS_DRAENEI_SPACESHIP),
      Essential = true
    };

    LegendExodarGenerator = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_N00E_DIMENSIONAL_GENERATOR_DRAENEI)
    };

    Maraad = new LegendaryHero("Maraad")
    {
      UnitType = UNIT_H09S_HAMMER_OF_THE_LIGHT_DRAENEI,
      StartingXp = 1800
    };

    Adal = new LegendaryHero("A'dal")
    {
      UnitType = UNIT_H09M_THE_NAARU_DRAENEI,
      PlayerColor = playercolor.Blue,
      StartingXp = 10800
    };

    Velen = new LegendaryHero("Velen")
    {
      UnitType = UNIT_E01I_AGELESS_ONE_DRUIDS
    };

    Shattrah = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H0AH_SHATTRAH_DRAENEI_OTHER)
    };

    Halaar = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_H0AE_HALAAR_DRAENEI_OTHER)
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Velen);
    LegendaryHeroManager.Register(Maraad);
    LegendaryHeroManager.Register(Adal);
    LegendaryHeroManager.Register(LegendNobundo);
    CapitalManager.Register(LegendExodar);
    CapitalManager.Register(LegendExodarGenerator);
    CapitalManager.Register(Shattrah);
    CapitalManager.Register(Halaar);
  }
}
