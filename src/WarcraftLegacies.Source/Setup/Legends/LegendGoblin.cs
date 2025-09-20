using MacroTools.LegendSystem;
using MacroTools.Systems;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendGoblin
{
  public LegendaryHero Gallywix { get; }
  public LegendaryHero Noggenfogger { get; }
  public LegendaryHero Gazlowe { get; }
  public Capital KezanTradingCenter { get; }

  public LegendGoblin(PreplacedUnitSystem preplacedUnitSystem)
  {
    Gallywix = new LegendaryHero("Gallywix")
    {
      UnitType = UNIT_O04N_TRADE_PRINCE_OF_THE_BILGEWATER_CARTEL_GOBLIN,
      StartingXp = 2800
    };

    Noggenfogger = new LegendaryHero("Noggenfogger")
    {
      UnitType = UNIT_VH01_BARON_OF_GADGETZAN_GOBLIN,
    };

    Gazlowe = new LegendaryHero("Gazlowe")
    {
      UnitType = UNIT_NTIN_CHIEF_ENGINEER_GOBLIN,
      StartingXp = 1800
    };

    KezanTradingCenter = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(UNIT_O04M_KEZAN_TRADING_CENTER_GOBLIN_SPECIAL),
      DeathMessage = "The Trade center for the Goblin Empire has fallen.",
      Essential = true
    };
    KezanTradingCenter.AddProtector(preplacedUnitSystem.GetUnit(UNIT_O05I_MISSILE_BATTERY_GOBLIN_TOWER));
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Gallywix);
    LegendaryHeroManager.Register(Noggenfogger);
    LegendaryHeroManager.Register(Gazlowe);
    CapitalManager.Register(KezanTradingCenter);
  }
}
