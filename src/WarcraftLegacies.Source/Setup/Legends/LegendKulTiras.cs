using MacroTools;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendKultiras
  {
    public static LegendaryHero LegendAdmiral { get; private set; }
    public static LegendaryHero LegendLucille { get; private set; }
    public static LegendaryHero LegendKatherine { get; private set; }
    public static Capital LegendBoralus { get; private set; }
    public static LegendaryHero Flagship { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendAdmiral = new LegendaryHero
      {
        UnitType = FourCC("Hapm")
      };
      LegendaryHeroManager.Register(LegendAdmiral);

      LegendLucille = new LegendaryHero
      {
        UnitType = FourCC("E016"),
        StartingXp = 2800
      };
      LegendaryHeroManager.Register(LegendLucille);

      LegendKatherine = new LegendaryHero
      {
        UnitType = FourCC("H05L"),
        StartingXp = 1200
      };
      LegendaryHeroManager.Register(LegendKatherine);

      LegendBoralus = new Capital()
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H046_BORALUS_KEEP_KUL_TIRAS),
        DeathMessage = "Boralus Keep has fallen" //Todo: pointless flavour
      };
      CapitalManager.Register(LegendBoralus);

      Flagship = new LegendaryHero
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H05V_PROUDMOORE_FLAGSHIP_KUL_TIRAS)
      };
      Flagship.Unit.SetInvulnerable(true);
      Flagship.Unit.Pause(true);
    }
  }
}