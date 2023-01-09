using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Setup.Legends
{
  /// <summary>
  /// Responsible for setting up all Gilneas <see cref="Legend"/>s.
  /// </summary>
  public static class LegendGilneas
  {
    public static LegendaryHero Tess { get; private set; }
    public static LegendaryHero Genn { get; private set; }
    public static LegendaryHero Darius { get; private set; }
    public static LegendaryHero Goldrinn { get; private set; }
    public static Capital NorthshireAbbey { get; private set; }
    public static Capital GilneasCastle { get; private set; }

    /// <summary>
    /// Sets up <see cref="LegendGilneas"/>.
    /// </summary>
    public static void Setup()
    {
      Tess = new LegendaryHero("Tess Greymane")
      {
        UnitType = Constants.UNIT_EWAR_PRINCESS_OF_GILNEAS_GILNEAS,
      };
      LegendaryHeroManager.Register(Tess);

      Goldrinn = new LegendaryHero("Goldrinn")
      {
        UnitType = Constants.UNIT_E01E_ANCIENT_GUARDIAN_GILNEAS,
        StartingXp = 8800,
      };
      LegendaryHeroManager.Register(Goldrinn);

      Genn = new LegendaryHero("Genn Greymane")
      {
        UnitType = Constants.UNIT_HHKL_KING_OF_GILNEAS_GILNEAS,
        StartingXp = 2800
      };
      LegendaryHeroManager.Register(Genn);

      Darius = new LegendaryHero("Darius Crowley")
      {
        UnitType = Constants.UNIT_HPB2_GILNEAN_LORD_GILNEAS,
      };
      LegendaryHeroManager.Register(Darius);

      NorthshireAbbey = new Capital
      {
        UnitType = Constants.UNIT_H02R_NORTHSHIRE_ABBEY_STORMWIND_OTHER
      };
      CapitalManager.Register(NorthshireAbbey);

      GilneasCastle = new Capital
      {
        UnitType = Constants.UNIT_H04I_GILNEAS_CASTLE_GILNEAS_OTHER,
        DeathMessage = "The Gilneas castle has fallen",  
      };
      CapitalManager.Register(GilneasCastle);
    }
  }
}