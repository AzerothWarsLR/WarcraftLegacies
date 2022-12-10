using MacroTools.FactionSystem;

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
    public static Capital LightDawn { get; private set; }
    public static Capital GilneasCastle { get; private set; }

    /// <summary>
    /// Sets up <see cref="LegendGilneas"/>.
    /// </summary>
    public static void Setup()
    {
      Tess = new LegendaryHero
      {
        UnitType = Constants.UNIT_EWAR_PRINCESS_OF_GILNEAS_GILNEAS,
        Name = "Tess Greymane"
      };
      Legend.Register(Tess);

      Goldrinn = new LegendaryHero
      {
        UnitType = Constants.UNIT_E01E_ANCIENT_GUARDIAN_GILNEAS,
        StartingXp = 8800,
        Name = "Goldrinn"
      };
      Legend.Register(Goldrinn);

      Genn = new LegendaryHero
      {
        Name = "Genn Greymane",
        UnitType = Constants.UNIT_HHKL_KING_OF_GILNEAS_GILNEAS,
        StartingXp = 2800
      };
      Legend.Register(Genn);

      Darius = new LegendaryHero
      {
        UnitType = Constants.UNIT_HPB2_GILNEAN_LORD_GILNEAS,
        Name = "Darius Crowley"
      };
      Legend.Register(Darius);

      LightDawn = new Capital
      {
        UnitType = Constants.UNIT_H057_LIGHT_S_DAWN_CATHEDRAL_GILNEAS,
        DeathMessage = "The Light's Dawn Capital has been destroyed.",
      };
      Legend.Register(LightDawn);

      GilneasCastle = new Capital
      {
        UnitType = Constants.UNIT_H04I_GILNEAS_CASTLE_GILNEAS,
        DeathMessage = "The Gilneas castle has fallen",  
      };
      Legend.Register(GilneasCastle);
    }
  }
}