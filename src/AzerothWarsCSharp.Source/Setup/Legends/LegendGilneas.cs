using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendGilneas
  {
    public static Legend LEGEND_TESS { get; private set; }
    public static Legend LEGEND_GENN { get; private set; }
    public static Legend LEGEND_DARIUS { get; private set; }
    public static Legend LEGEND_GOLDRINN { get; private set; }
    public static Legend LEGEND_LIGHTDAWN { get; private set; }
    public static Legend LEGEND_GILNEASCASTLE { get; private set; }
    
    public static void Setup()
    {
      LEGEND_TESS = new Legend
      {
        UnitType = FourCC("Ewar")
      };

      LEGEND_GOLDRINN = new Legend
      {
        UnitType = FourCC("E01E"),
        StartingXp = 8800
      };

      LEGEND_GENN = new Legend
      {
        UnitType = FourCC("HHkl")
      };

      LEGEND_DARIUS = new Legend
      {
        UnitType = FourCC("hpb2")
      };

      LEGEND_LIGHTDAWN = new Legend
      {
        UnitType = FourCC("h057"),
        DeathMessage = "The Light's Dawn Capital has been destroyed.",
        IsCapital = true
      };

      LEGEND_GILNEASCASTLE = new Legend
      {
        UnitType = FourCC("h04I"),
        DeathMessage = "The Gilneas castle has fallen",
        IsCapital = true
      };
    }
  }
}