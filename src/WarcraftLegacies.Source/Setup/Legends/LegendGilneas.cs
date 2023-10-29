using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Responsible for setting up all Gilneas <see cref="Legend"/>s.
  /// </summary>
  public sealed class LegendGilneas
  {
    public LegendaryHero Tess { get; private set; }
    public LegendaryHero Genn { get; private set; }
    public LegendaryHero Darius { get; private set; }
    public LegendaryHero Goldrinn { get; private set; }
    public Capital GilneasCastle { get; private set; }

    /// <summary>
    /// Sets up <see cref="LegendGilneas"/>.
    /// </summary>
    public LegendGilneas()
    {
      Tess = new LegendaryHero("Tess Greymane")
      {
        UnitType = Constants.UNIT_EWAR_PRINCESS_OF_GILNEAS_GILNEAS,
      };

      Goldrinn = new LegendaryHero("Goldrinn")
      {
        UnitType = Constants.UNIT_E01E_ANCIENT_GUARDIAN_GILNEAS,
        StartingXp = 8800,
      };

      Genn = new LegendaryHero("Genn Greymane")
      {
        UnitType = Constants.UNIT_HHKL_KING_OF_GILNEAS_GILNEAS,
        StartingXp = 2800
      };

      Darius = new LegendaryHero("Darius Crowley")
      {
        UnitType = Constants.UNIT_HPB2_GILNEAN_LORD_GILNEAS,
        StartingXp = 5400
      };

      GilneasCastle = new Capital
      {
        UnitType = Constants.UNIT_H04I_GILNEAS_CASTLE_GILNEAS_OTHER,
        DeathMessage = "The Gilneas castle has fallen",
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