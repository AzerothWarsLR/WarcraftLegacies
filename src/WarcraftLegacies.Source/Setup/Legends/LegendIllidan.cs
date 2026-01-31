using MacroTools.Legends;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendIllidan
{
  public LegendaryHero Illidan { get; } = new("Illidan")
  {
    UnitType = UNIT_EEVI_DEMON_HUNTER_ILLIDARI_HYBRID_ILLIDAN,
    StartingArtifacts = new()
    {
      new(item.Create(ITEM_I007_SKULL_OF_GUL_DAN, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y)),
      new(item.Create(ITEM_I0WG_WARGLAIVES_OF_AZZINOTH, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y)),
    }
  };

  public LegendaryHero Vashj { get; } = new("Lady Vashj")
  {
    UnitType = UNIT_HVSH_SEA_WITCH_ILLIDARI,
    StartingXp = 1000
  };

  public LegendaryHero Najentus { get; } = new("Warlord Najentus")
  {
    UnitType = UNIT_U00S_HIGH_WARLORD_ILLIDARI,
    StartingXp = 5400
  };

  public LegendaryHero Akama { get; } = new("Akama")
  {
    UnitType = UNIT_NAKA_ELDER_SAGE_ILLIDARI,
    StartingXp = 4000
  };

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Illidan);
    LegendaryHeroManager.Register(Vashj);
    LegendaryHeroManager.Register(Najentus);
    LegendaryHeroManager.Register(Akama);
  }
}
