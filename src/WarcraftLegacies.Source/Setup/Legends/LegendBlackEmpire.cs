using MacroTools.LegendSystem;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendBlackEmpire
{
  public LegendaryHero Nzoth { get; }
  public LegendaryHero Zonozz { get; }
  public LegendaryHero Zaqul { get; }
  public LegendaryHero Yorsahj { get; }

  public LegendBlackEmpire()
  {
    Nzoth = new LegendaryHero("N'zoth")
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_U01Z_OLD_GOD_NZOTH),
      PermaDies = true,
      StartingXp = 41800,
      Essential = true
    };

    Zonozz = new LegendaryHero("Warlord Zon'ozz")
    {
      UnitType = UNIT_U00P_LIEUTENANT_OF_N_ZOTH_NZOTH,
      StartingXp = 2800,
    };

    Zaqul = new LegendaryHero("Za'qul")
    {
      UnitType = UNIT_E01D_HARBINGER_OF_NY_ALOTHA_NZOTH,
      StartingXp = 1000,
    };

    Yorsahj = new LegendaryHero("Yor'sahj")
    {
      UnitType = UNIT_U02B_N_RAQI_ABERRATION_NZOTH,
      StartingXp = 0,
    };
  }
  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Nzoth);
    Nzoth.Unit.AddSkillPoints(-7);
    LegendaryHeroManager.Register(Zonozz);
    LegendaryHeroManager.Register(Zaqul);
    LegendaryHeroManager.Register(Yorsahj);
  }
}
