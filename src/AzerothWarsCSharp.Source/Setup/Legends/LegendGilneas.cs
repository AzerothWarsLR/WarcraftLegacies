using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
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
        UnitType = FourCC("Ewar")
      };
      Legend.Register(LegendTess);

      LegendGoldrinn = new Legend
      {
        UnitType = FourCC("E01E"),
        StartingXp = 8800
      };
      Legend.Register(LegendGoldrinn);

      LegendGenn = new Legend
      {
        UnitType = FourCC("HHkl")
      };
      Legend.Register(LegendGenn);

      LegendDarius = new Legend
      {
        UnitType = FourCC("hpb2")
      };
      Legend.Register(LegendDarius);

      LegendLightdawn = new Legend
      {
        UnitType = FourCC("h057"),
        DeathMessage = "The Light's Dawn Capital has been destroyed.",
        IsCapital = true
      };
      Legend.Register(LegendLightdawn);

      LegendGilneascastle = new Legend
      {
        UnitType = FourCC("h04I"),
        DeathMessage = "The Gilneas castle has fallen",
        IsCapital = true
      };
      Legend.Register(LegendGilneascastle);
    }
  }
}