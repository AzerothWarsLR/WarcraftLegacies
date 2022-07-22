using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendGoblin
  {
    public static Legend LEGEND_GALLYWIX { get; private set; }
    public static Legend LEGEND_NOGGENFOGGER { get; private set; }
    public static Legend LEGEND_GAZLOWE { get; private set; }
    
    public static Legend? KezanTradingCenter { get; private set; }

    public static void Setup()
    {
      LEGEND_GALLYWIX = new Legend
      {
        UnitType = FourCC("O04N")
      };
      Legend.Register(LEGEND_GALLYWIX);

      LEGEND_NOGGENFOGGER = new Legend
      {
        UnitType = FourCC("Nalc"),
        StartingXp = 800
      };
      Legend.Register(LEGEND_NOGGENFOGGER);

      LEGEND_GAZLOWE = new Legend
      {
        UnitType = FourCC("Ntin"),
        StartingXp = 1800
      };
      Legend.Register(LEGEND_GAZLOWE);

      KezanTradingCenter = new Legend
      {
        UnitType = Constants.UNIT_O04M_KEZAN_TRADING_CENTER_GOBLIN
      };
      KezanTradingCenter.AddProtector(PreplacedUnitSystem.GetUnit(Constants.UNIT_O05I_MISSILE_BATTERY_GOBLIN));
    }
  }
}