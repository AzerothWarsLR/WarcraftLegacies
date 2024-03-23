using MacroTools;
using MacroTools.LegendSystem;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendBlackEmpire
  {
    public LegendaryHero Nzoth { get; }
    public LegendaryHero Vezax { get; }
    public LegendaryHero Volazj { get; }
    public LegendaryHero Yorsahj { get; }

    public LegendBlackEmpire(PreplacedUnitSystem preplacedUnitSystem)
    {
      Nzoth = new LegendaryHero("N'zoth")
      {
        UnitType = UNIT_U01Z_OLD_GOD_NZOTH,
        PermaDies = true,
        StartingXp = 10000,
      };

      Vezax = new LegendaryHero("General Vezax")
      {
        UnitType = UNIT_U02B_YOGG_SARON_CHAMPION,
        StartingXp = 7000,
      };

      Volazj = new LegendaryHero("Herald Volazj")
      {
        UnitType = UNIT_E01D_N_RAQI_ARCANIST_YOGG,
        StartingXp = 7000,
      };

      Yorsahj = new LegendaryHero("Yor'sahj")
      {
        UnitType = UNIT_U02A_N_RAQI_ABERRATION_YOGG,
        StartingXp = 7000,
      };
    }
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Nzoth);
      LegendaryHeroManager.Register(Vezax);
      LegendaryHeroManager.Register(Volazj);
      LegendaryHeroManager.Register(Yorsahj);
    }
  }
}