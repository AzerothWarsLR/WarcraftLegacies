using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendAhnqiraj
{
  public LegendaryHero Cthun { get; }
  public LegendaryHero Ouro { get; }
  public LegendaryHero Skeram { get; }
  public LegendaryHero Moam { get; }

  public LegendAhnqiraj()
  {
    Cthun = new LegendaryHero("C'thun")
    {
      Unit = PreplacedWidgets.Units.Get(UNIT_U00R_OLD_GOD_CTHUN),
      PermaDies = true,
      StartingXp = 41800,
      Essential = true
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
    Cthun.Unit.AddSkillPoints(-7);
    LegendaryHeroManager.Register(Moam);
    LegendaryHeroManager.Register(Ouro);
    LegendaryHeroManager.Register(Skeram);
  }
}
