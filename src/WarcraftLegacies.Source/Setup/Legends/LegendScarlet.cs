using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendScarlet
  {
    public static Legend LegendBrigitte { get; private set; }
    public static Legend LEGEND_TIRION { get; private set; }

    public static void Setup()
    {
      LegendBrigitte = new Legend
      {
        UnitType = FourCC("H00Y"),
        StartingXp = 7000
      };
      Legend.Register(LegendBrigitte);

      LEGEND_TIRION = new Legend
      {
        UnitType = FourCC("H09Z"),
        StartingXp = 7000
      };
      Legend.Register(LEGEND_TIRION);
    }
  }
}