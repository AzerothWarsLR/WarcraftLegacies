using MacroTools;
using MacroTools.Extensions;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendKultiras : IRegistersLegends
  {
    public LegendaryHero LegendAdmiral { get; }
    public LegendaryHero LegendLucille { get; }
    public LegendaryHero LegendKatherine { get; }
    public Capital LegendBoralus { get; }
    public LegendaryHero Flagship { get; }

    public LegendKultiras(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendAdmiral = new LegendaryHero("Daelin Proudmoore")
      {
        UnitType = FourCC("Hapm")
      };
      LegendaryHeroManager.Register(LegendAdmiral);

      LegendLucille = new LegendaryHero("Lucille Waycrest")
      {
        UnitType = FourCC("E016"),
        StartingXp = 2800
      };
      LegendaryHeroManager.Register(LegendLucille);

      LegendKatherine = new LegendaryHero("Katherine Proudmoore")
      {
        UnitType = FourCC("H05L"),
        StartingXp = 1200
      };
      LegendaryHeroManager.Register(LegendKatherine);

      LegendBoralus = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H046_BORALUS_KEEP_KUL_TIRAS),
        DeathMessage = "Boralus Keep has fallen" //Todo: pointless flavour
      };
      CapitalManager.Register(LegendBoralus);

      Flagship = new LegendaryHero("Flagship")
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_H05V_PROUDMOORE_FLAGSHIP_KUL_TIRAS)
      };
      Flagship.Unit.SetInvulnerable(true);
      Flagship.Unit.Pause(true);
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register();
      CapitalManager.Register();
    }
  }
}