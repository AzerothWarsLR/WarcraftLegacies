using MacroTools.LegendSystem;
using MacroTools.Systems;

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Responsible for setting up all Gilneas <see cref="Legend"/>s.
  /// </summary>
  public sealed class LegendGilneas
  {
    public LegendaryHero Tess { get; }

    public LegendaryHero Genn { get; }

    public LegendaryHero Darius { get; }

    public LegendaryHero Goldrinn { get; }

    public Capital GilneasCastle { get; }
    /// <summary>
    /// Sets up <see cref="LegendGilneas"/>.
    /// </summary>
    /// 
    public LegendGilneas(PreplacedUnitSystem preplacedUnitSystem)
    {
      Tess = new LegendaryHero("Tess Greymane")
      {
        UnitType = UNIT_TGGN_PRINCESS_OF_GILNEAS_GILNEAS,
        StartingArtifacts = new()
        { 
          new(CreateItem(ITEM_I00R_SCYTHE_OF_ELUNE, Regions.ArtifactDummyInstance.Center.X,Regions.ArtifactDummyInstance.Center.Y))
        }
      };

      Goldrinn = new LegendaryHero("Goldrinn")
      {
        UnitType = UNIT_E01E_ANCIENT_GUARDIAN_GILNEAS,
        StartingXp = 8800,
      };

      Genn = new LegendaryHero("Genn Greymane")
      {
        UnitType = UNIT_HHKL_KING_OF_GILNEAS_GILNEAS,
        StartingXp = 2800
      };

      Darius = new LegendaryHero("Darius Crowley")
      {
        UnitType = UNIT_HPB2_GILNEAN_LORD_GILNEAS,
        StartingXp = 5400
      };

      GilneasCastle = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(UNIT_H04I_GILNEAS_CASTLE_GILNEAS_OTHER),
        Essential = true
      };
    }

    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Genn);
      LegendaryHeroManager.Register(Darius);
      LegendaryHeroManager.Register(Tess);
      LegendaryHeroManager.Register(Goldrinn);
      CapitalManager.Register(GilneasCastle);
    }
  }
}