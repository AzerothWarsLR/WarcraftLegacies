using MacroTools;
using MacroTools.LegendSystem;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendBlackEmpire
  {
    public LegendaryHero Nzoth { get; }
    public LegendaryHero Zonozz { get; }
    public LegendaryHero Xkorr { get; }
    public LegendaryHero Yorsahj { get; }

    public LegendBlackEmpire(PreplacedUnitSystem preplacedUnitSystem)
    {
      Nzoth = new LegendaryHero("N'zoth")
      {
        UnitType = UNIT_U01Z_OLD_GOD_NZOTH,
        PermaDies = true,
        StartingXp = 10000,
      };

      Zonozz = new LegendaryHero("General Vezax")
      {
        UnitType = UNIT_U00P_LIEUTENANT_OF_N_ZOTH,
        StartingXp = 7000,
      };

      Xkorr = new LegendaryHero("X'korr the Compelling")
      {
        UnitType = UNIT_E01D_MOUTH_OF_N_ZOTH_YOGG,
        StartingXp = 7000,
      };

      Yorsahj = new LegendaryHero("Yor'sahj")
      {
        UnitType = UNIT_U02B_N_RAQI_ABERRATION,
        StartingXp = 7000,
      };
    }
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Nzoth);
      LegendaryHeroManager.Register(Zonozz);
      LegendaryHeroManager.Register(Xkorr);
      LegendaryHeroManager.Register(Yorsahj);
    }
  }
}