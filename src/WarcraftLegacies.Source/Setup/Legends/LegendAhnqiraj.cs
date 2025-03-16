using MacroTools.LegendSystem;
using MacroTools.Systems;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendAhnqiraj
  {
    public LegendaryHero Cthun { get; }
    public LegendaryHero Ouro { get; }
    public LegendaryHero Skeram { get; }
    public LegendaryHero Moam { get; }

    public LegendAhnqiraj(PreplacedUnitSystem preplacedUnitSystem)
    {
      Cthun = new LegendaryHero("C'thun")
      {
        Unit = preplacedUnitSystem.GetUnit(UNIT_U00R_OLD_GOD_AHN_QIRAJ),
        PermaDies = true,
        StartingXp = 41800,
      };

      Moam = new LegendaryHero("Moam")
      {
        UnitType = UNIT_U00Z_OBSIDIAN_DESTROYER,
        StartingXp = 1000,
      };

      Skeram = new LegendaryHero("Prophet Skeram")
      {
        UnitType = UNIT_E005_THE_PROPHET,
        StartingXp = 0,
      };

      Ouro = new LegendaryHero("Ouro")
      {
        UnitType = UNIT_U02S_ANCIENT_SAND_WORM,
        StartingXp = 2800,
      };
    }
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Cthun);
      UnitModifySkillPoints(Cthun.Unit, -7);
      LegendaryHeroManager.Register(Moam);
      LegendaryHeroManager.Register(Ouro);
      LegendaryHeroManager.Register(Skeram);
    }
  }
}