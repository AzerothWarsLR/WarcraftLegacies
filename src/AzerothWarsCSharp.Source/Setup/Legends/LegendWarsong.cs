using AzerothWarsCSharp.MacroTools;
using Legend = AzerothWarsCSharp.MacroTools.Factions.Legend;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendWarsong
  {
    public static Legend? LegendGrom { get; private set; }
    public static Legend? LegendJergosh { get; private set; }
    public static Legend? LegendMannoroth { get; private set; }
    public static Legend? LegendStonemaul { get; private set; }
    public static Legend? LegendEncampment { get; private set; }
    public static Legend? LegendChen { get; private set; }
    public static Legend? LegendSaurfang { get; private set; }


    public static void Setup()
    {
      LegendChen = new Legend
      {
        UnitType = FourCC("Nsjs"),
        StartingXp = 1000
      };

      LegendSaurfang = new Legend
      {
        UnitType = FourCC("Obla"),
        StartingXp = 2800
      };

      LegendJergosh = new Legend
      {
        UnitType = FourCC("Oths")
      };

      LegendMannoroth = new Legend
      {
        UnitType = FourCC("Nman")
      };

      LegendStonemaul = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o004")),
        DeathMessage = "The fortress of the Stonemaul Clan has fallen.",
        IsCapital = true
      };

      LegendEncampment = new Legend();

      LegendGrom = new Legend
      {
        UnitType = FourCC("Ogrh")
      };
    }
  }
}