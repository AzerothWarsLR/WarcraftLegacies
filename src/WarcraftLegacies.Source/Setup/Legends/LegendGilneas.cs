using MacroTools.FactionSystem;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendGilneas
  {
    public static Legend LegendTess { get; private set; }
    public static Legend LegendGenn { get; private set; }
    public static Legend LegendDarius { get; private set; }
    public static Legend LegendGoldrinn { get; private set; }
    public static Legend LegendLightdawn { get; private set; }
    public static Legend LegendGilneascastle { get; private set; }

    public static void Setup()
    {
      LegendTess = new Legend
      {
        UnitType = Constants.UNIT_EWAR_PRINCESS_OF_GILNEAS_GILNEAS
      };
      Legend.Register(LegendTess);

      LegendGoldrinn = new Legend
      {
        UnitType = Constants.UNIT_E01E_ANCIENT_GUARDIAN_GILNEAS,
        StartingXp = 8800
      };
      Legend.Register(LegendGoldrinn);

      LegendGenn = new Legend
      {
        Name = "Genn Greymane",
        UnitType = Constants.UNIT_HHKL_KING_OF_GILNEAS_GILNEAS,
        StartingXp = 2800
      };
      Legend.Register(LegendGenn);

      LegendDarius = new Legend
      {
        UnitType = Constants.UNIT_HPB2_GILNEAN_LORD_GILNEAS
      };
      Legend.Register(LegendDarius);

      LegendLightdawn = new Legend
      {
        UnitType = Constants.UNIT_H057_LIGHT_S_DAWN_CATHEDRAL_GILNEAS,
        DeathMessage = "The Light's Dawn Capital has been destroyed.",
      };
      Legend.Register(LegendLightdawn);

      LegendGilneascastle = new Legend
      {
        UnitType = Constants.UNIT_H04I_GILNEAS_CASTLE_GILNEAS,
        DeathMessage = "The Gilneas castle has fallen",  
      };
      Legend.Register(LegendGilneascastle);
    }
  }
}