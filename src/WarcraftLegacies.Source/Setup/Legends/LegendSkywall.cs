using MacroTools.LegendSystem;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendSkywall
{
  public LegendaryHero Ertan { get; }
  public LegendaryHero Aqir { get; }
  public LegendaryHero Ragnaros { get; }
  public LegendaryHero Neptulon { get; }
  public Capital Vortex { get; }

  public LegendSkywall()
  {
    Ertan = new LegendaryHero("Ertan")
    {
      UnitType = UNIT_E023_GRAND_VIZIER_SKYWALL,
      StartingXp = 0,
    };

    Aqir = new LegendaryHero("Al'Aqir")
    {
      UnitType = UNIT_U01S_WINDLORD_SKYWALL,
      StartingXp = 1000,
    };

    Ragnaros = new LegendaryHero("Ragnaros")
    {
      UnitType = UNIT_U02K_LORD_OF_THE_FIRELANDS_SKYWALL,
      StartingXp = 2800,
    };

    Neptulon = new LegendaryHero("Neptulon")
    {
      UnitType = UNIT_UELN_THE_TIDEHUNTER_SKYWALL,
      StartingXp = 4000,
    };

    Vortex = new Capital
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_NELC_VORTEX_PINNACLE_SKYWALL_T3),
      Capturable = true,
      Essential = true
    };
  }
  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Ertan);
    LegendaryHeroManager.Register(Aqir);
    LegendaryHeroManager.Register(Ragnaros);
    LegendaryHeroManager.Register(Neptulon);
    CapitalManager.Register(Vortex);
  }
}
