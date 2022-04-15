using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
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
      Legend.Register(LegendChen);

      LegendSaurfang = new Legend
      {
        UnitType = FourCC("Obla"),
        StartingXp = 2800
      };
      Legend.Register(LegendSaurfang);

      LegendJergosh = new Legend
      {
        UnitType = FourCC("Oths")
      };
      Legend.Register(LegendJergosh);

      LegendMannoroth = new Legend
      {
        UnitType = FourCC("Nman")
      };
      Legend.Register(LegendMannoroth);

      LegendStonemaul = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o004")),
        DeathMessage = "The fortress of the Stonemaul Clan has fallen.",
        
      };
      Legend.Register(LegendStonemaul);

      LegendEncampment = new Legend();
      Legend.Register(LegendEncampment);

      LegendGrom = new Legend
      {
        UnitType = FourCC("Ogrh")
      };
      Legend.Register(LegendGrom);
    }
  }
}