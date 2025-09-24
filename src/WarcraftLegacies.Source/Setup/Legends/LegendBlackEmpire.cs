using MacroTools.LegendSystem;
using MacroTools.Systems;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendBlackEmpire
{
  public LegendaryHero Nzoth { get; }
  public LegendaryHero Zonozz { get; }
  public LegendaryHero Zaqul { get; }
  public LegendaryHero Yorsahj { get; }

  public LegendBlackEmpire(PreplacedUnitSystem preplacedUnitSystem)
  {
    Nzoth = new LegendaryHero("N'zoth")
    {
      Unit = preplacedUnitSystem.GetUnit(UNIT_U01Z_OLD_GOD_NZOTH),
      PermaDies = true,
      StartingXp = 41800,
    };

    Zonozz = new LegendaryHero("Warlord Zon'ozz")
    {
      UnitType = UNIT_U00P_LIEUTENANT_OF_N_ZOTH_BLACK_EMPIRE,
      StartingXp = 2800,
    };

    Zaqul = new LegendaryHero("Za'qul")
    {
      UnitType = UNIT_E01D_HARBINGER_OF_NY_ALOTHA_YOGG,
      StartingXp = 1000,
    };

    Yorsahj = new LegendaryHero("Yor'sahj")
    {
      UnitType = UNIT_U02B_N_RAQI_ABERRATION_BLACK_EMPIRE,
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
