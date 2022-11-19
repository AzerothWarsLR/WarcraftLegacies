using MacroTools;
using MacroTools.FactionSystem;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendGoblin
  {
    public static Legend? Gallywix { get; private set; }
    public static Legend? Noggenfogger { get; private set; }
    public static Legend? Gazlowe { get; private set; }
    public static Legend? KezanTradingCenter { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Gallywix = new Legend
      {
        UnitType = Constants.UNIT_O04N_TRADE_PRINCE_OF_THE_BILGEWATER_CARTEL_GOBLIN
      };
      Legend.Register(Gallywix);

      Noggenfogger = new Legend
      {
        UnitType = Constants.UNIT_NALC_BARON_OF_GADGETZAN_GOBLIN,
        StartingXp = 800
      };
      Legend.Register(Noggenfogger);

      Gazlowe = new Legend
      {
        UnitType = Constants.UNIT_NTIN_CHIEF_ENGINEER_GOBLIN,
        StartingXp = 1800
      };
      Legend.Register(Gazlowe);

      KezanTradingCenter = new Legend
      {
        UnitType = Constants.UNIT_O04M_KEZAN_TRADING_CENTER_GOBLIN
      };
      KezanTradingCenter.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_O05I_MISSILE_BATTERY_GOBLIN));
    }
  }
}