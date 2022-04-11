using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
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

      LEGEND_TIRION = new Legend
      {
        UnitType = FourCC("H09Z"),
        StartingXp = 7000
      };
    }
  }
}