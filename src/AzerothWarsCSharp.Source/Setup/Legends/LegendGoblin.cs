using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendGoblin
  {
    public static Legend LEGEND_GALLYWIX { get; private set; }
    public static Legend LEGEND_NOGGENFOGGER { get; private set; }
    public static Legend LEGEND_GAZLOWE { get; private set; }

    public static void Setup()
    {
      LEGEND_GALLYWIX = new Legend
      {
        UnitType = FourCC("O04N")
      };

      LEGEND_NOGGENFOGGER = new Legend
      {
        UnitType = FourCC("Nalc"),
        StartingXp = 800
      };

      LEGEND_GAZLOWE = new Legend
      {
        UnitType = FourCC("Ntin"),
        StartingXp = 1800
      };
    }
  }
}