using MacroTools.LegendSystem;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendIllidan
  {
    public LegendaryHero Illidan { get; }
    public LegendaryHero Vashj { get; }
    public LegendaryHero Najentus { get; }
    public LegendaryHero Azshara { get; }
    public LegendaryHero Altruis { get; }
    public LegendaryHero Akama { get; }

    public LegendIllidan()
    {
      Illidan = new LegendaryHero("Illidan")
      {
        UnitType = UNIT_EEVI_DEMON_HUNTER_HYBRID_ILLIDARI,
        StartingArtifacts = new()
        {
          new(CreateItem(ITEM_I007_SKULL_OF_GUL_DAN, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
        }
      };

      Vashj = new LegendaryHero("Lady Vashj")
      {
        UnitType = FourCC("Hvsh"),
        StartingXp = 1000
      };

      Azshara = new LegendaryHero("Azshara")
      {
        UnitType = FourCC("H08U")
      };

      Najentus = new LegendaryHero("Warlord Najentus")
      {
        UnitType = FourCC("U00S"),
        StartingXp = 5400
      };

      Altruis = new LegendaryHero("Altruis")
      {
        UnitType = FourCC("E015")
      };

      Akama = new LegendaryHero("Akama")
      {
        UnitType = FourCC("Naka"),
        StartingXp = 4000
      };
    }
    
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Illidan);
      LegendaryHeroManager.Register(Vashj);
      LegendaryHeroManager.Register(Najentus);
      LegendaryHeroManager.Register(Azshara);
      LegendaryHeroManager.Register(Altruis);
      LegendaryHeroManager.Register(Akama);
    }
  }
}