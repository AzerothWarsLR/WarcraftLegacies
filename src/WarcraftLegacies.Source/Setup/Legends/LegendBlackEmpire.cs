using MacroTools;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendBlackEmpire
  {
    public LegendaryHero Nzoth { get; }
    public LegendaryHero Vezax { get; }
    public LegendaryHero Volazj { get; }
    public LegendaryHero Yorsahj { get; }
    public Capital ObeliskCaptain { get; }
    public Capital ObeliskFootman { get; }

    public LegendBlackEmpire(PreplacedUnitSystem preplacedUnitSystem)
    {
      Nzoth = new LegendaryHero("N'zoth")
      {
        UnitType = Constants.UNIT_U01Z_OLD_GOD_NZOTH,
        PermaDies = true,
        StartingXp = 10000,
      };

      Vezax = new LegendaryHero("General Vezax")
      {
        UnitType = Constants.UNIT_U02B_YOGG_SARON_CHAMPION,
        StartingXp = 7000,
      };

      Volazj = new LegendaryHero("Herald Volazj")
      {
        UnitType = Constants.UNIT_E01D_N_RAQI_ARCANIST_YOGG,
        StartingXp = 7000,
      };

      Yorsahj = new LegendaryHero("Yor'sahj")
      {
        UnitType = Constants.UNIT_U02A_N_RAQI_ABERRATION_YOGG,
        StartingXp = 7000,
      };

      ObeliskCaptain = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_N0BA_NY_ALOTHA_OBELISK_NZOTH_OTHER, new Point(12313, -29094)),
        Essential = true
      };

      ObeliskFootman = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_N0BA_NY_ALOTHA_OBELISK_NZOTH_OTHER, new Point(13184, -29094)),
        Essential = true
      };

    }
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Nzoth);
      LegendaryHeroManager.Register(Vezax);
      LegendaryHeroManager.Register(Volazj);
      LegendaryHeroManager.Register(Yorsahj);
      CapitalManager.Register(ObeliskFootman);
      CapitalManager.Register(ObeliskCaptain);
    }
  }
}