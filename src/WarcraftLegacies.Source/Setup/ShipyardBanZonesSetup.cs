using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.Setup;

public static class ShipyardBanZonesSetup
{
  public static void Setup()
  {
    ShipyardBanZones.Setup(new[]
    {
      Regions.CaerDarrowShipyard,
      Regions.Auberdine_Ships,
      Regions.Kali_Ships,
      Regions.Dustwallow_Ships,
      Regions.STV_Ships,
      Regions.Fenris_ships,
      Regions.Auberdine_Ships_2,
      Regions.Outland_Ships,
      Regions.Northern_Kali_Ships,
      Regions.Stromwind_antiship,
      Regions.StratholmeShipyard,
      Regions.Gilneas_Canals,
      Regions.TwistingNether,
      Regions.Dun_Morogh_Ships,
      Regions.Northrend_ships,
      Regions.Desolace_Ships,
      Regions.South_EK_Ships,
      Regions.IcecrownShipyard,
      Regions.Loch_Modan_Ships,
      Regions.Quel_Ships_1,
      Regions.Quel_Ships_2,
      Regions.Quel_Ships_3
    });
  }
}
