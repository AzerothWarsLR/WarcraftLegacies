using MacroTools.LegendSystem;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendIllidan
{
  public LegendaryHero Illidan { get; } = new("Illidan")
  {
    UnitType = UNIT_EEVI_DEMON_HUNTER_HYBRID_ILLIDARI,
    StartingArtifacts = new()
    {
      new(CreateItem(ITEM_I007_SKULL_OF_GUL_DAN, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
    }
  };

  public LegendaryHero Vashj { get; } = new("Lady Vashj")
  {
    UnitType = FourCC("Hvsh"),
    StartingXp = 1000
  };

  public LegendaryHero Najentus { get; } = new("Warlord Najentus")
  {
    UnitType = FourCC("U00S"),
    StartingXp = 5400
  };

  public LegendaryHero Azshara { get; } = new("Azshara")
  {
    UnitType = FourCC("H08U")
  };

  public LegendaryHero Akama { get; } = new("Akama")
  {
    UnitType = FourCC("Naka"),
    StartingXp = 4000
  };

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Illidan);
    LegendaryHeroManager.Register(Vashj);
    LegendaryHeroManager.Register(Najentus);
    LegendaryHeroManager.Register(Azshara);
    LegendaryHeroManager.Register(Akama);
  }
}
