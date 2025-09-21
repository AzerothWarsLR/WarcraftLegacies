using MacroTools.LegendSystem;
using MacroTools.Systems;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendKultiras
{
  public LegendaryHero LegendAdmiral { get; }
  public LegendaryHero LegendLucille { get; }
  public LegendaryHero LegendMeredith { get; }
  public LegendaryHero LegendKatherine { get; }
  public Capital LegendBoralus { get; }
  public LegendaryHero Flagship { get; }

  public LegendKultiras(PreplacedUnitSystem preplacedUnitSystem)
  {
    LegendAdmiral = new LegendaryHero("Daelin Proudmoore")
    {
      UnitType = UNIT_HAPM_LORD_ADMIRAL_OF_KUL_TIRAS_KUL_TIRAS
    };

    LegendLucille = new LegendaryHero("Lucille Waycrest")
    {
      UnitType = UNIT_E016_RULER_OF_HOUSE_WAYCREST_KULTIRAS,
      StartingXp = 2800
    };

    LegendMeredith = new LegendaryHero("Meredith Waycrest")
    {
      UnitType = UNIT_U026_MATRIARCH_OF_HOUSE_WAYCREST_KULTIRAS,
      StartingXp = 2800
    };

    LegendKatherine = new LegendaryHero("Katherine Proudmoore")
    {
      UnitType = UNIT_H05L_LADY_OF_HOUSE_PROUDMOORE_KUL_TIRAS,
      StartingXp = 1200
    };

    LegendBoralus = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(UNIT_H046_BORALUS_KEEP_KUL_TIRAS),
      DeathMessage = "Boralus Keep has fallen", //Todo: pointless flavour
      Essential = true
    };

    Flagship = new LegendaryHero("Flagship")
    {
      Unit = preplacedUnitSystem.GetUnit(UNIT_H05V_PROUDMOORE_FLAGSHIP_KUL_TIRAS)
    };
    Flagship.Unit.IsInvulnerable = true;
    Flagship.Unit.SetPausedEx(true);
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(LegendAdmiral);
    LegendaryHeroManager.Register(LegendLucille);
    LegendaryHeroManager.Register(LegendMeredith);
    LegendaryHeroManager.Register(LegendKatherine);
    LegendaryHeroManager.Register(Flagship);
    CapitalManager.Register(LegendBoralus);
  }
}
