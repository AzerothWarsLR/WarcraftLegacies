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
        Unit = preplacedUnitSystem.GetUnit(UNIT_U01Z_OLD_GOD_NZOTH),
        PermaDies = true,
        StartingXp = 41800,
      };

      Zonozz = new LegendaryHero("General Vezax")
      {
        UnitType = UNIT_U00P_LIEUTENANT_OF_N_ZOTH,
        StartingXp = 5000,
      };

      Xkorr = new LegendaryHero("X'korr the Compelling")
      {
        UnitType = UNIT_E01D_HARBINGER_OF_NY_ALOTHA_YOGG,
        StartingXp = 2800,
      };

      Yorsahj = new LegendaryHero("Yor'sahj")
      {
        UnitType = UNIT_U02B_N_RAQI_ABERRATION,
        StartingXp = 0,
      };
    }
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Nzoth);
      UnitModifySkillPoints(Nzoth.Unit, -7);
      LegendaryHeroManager.Register(Zonozz);
      LegendaryHeroManager.Register(Xkorr);
      LegendaryHeroManager.Register(Yorsahj);
    }
  }
}