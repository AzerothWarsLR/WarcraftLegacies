using MacroTools;
using MacroTools.LegendSystem;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendGoblin
  {
    public static LegendaryHero? Gallywix { get; private set; }
    public static LegendaryHero? Noggenfogger { get; private set; }
    public static LegendaryHero? Gazlowe { get; private set; }
    public static Capital? KezanTradingCenter { get; private set; }

    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      Gallywix = new LegendaryHero("Gallywix")
      {
        UnitType = Constants.UNIT_O04N_TRADE_PRINCE_OF_THE_BILGEWATER_CARTEL_GOBLIN
      };
      LegendaryHeroManager.Register(Gallywix);

      Noggenfogger = new LegendaryHero("Noggenfogger")
      {
        UnitType = Constants.UNIT_NALC_BARON_OF_GADGETZAN_GOBLIN,
        StartingXp = 800
      };
      LegendaryHeroManager.Register(Noggenfogger);

      Gazlowe = new LegendaryHero("Gazlowe")
      {
        UnitType = Constants.UNIT_NTIN_CHIEF_ENGINEER_GOBLIN,
        StartingXp = 1800
      };
      LegendaryHeroManager.Register(Gazlowe);

      KezanTradingCenter = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(Constants.UNIT_O04M_KEZAN_TRADING_CENTER_GOBLIN_SPECIAL),
        DeathMessage = "The Trade center for the Goblin Empire has fallen."
      };
      KezanTradingCenter.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_O05I_MISSILE_BATTERY_GOBLIN_TOWER));
      CapitalManager.Register(KezanTradingCenter);
    }
  }
}