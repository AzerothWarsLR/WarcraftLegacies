using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public static class BlackEmpirePortalSetup
  {
    public static BlackEmpirePortal TwilightHighlandsPortal { get; private set; }
    public static BlackEmpirePortal NorthrendPortal { get; private set; }
    public static BlackEmpirePortal TanarisPortal { get; private set; }

    public static void Setup()
    {
      BlackEmpirePortalManager.RegisterPortals(new[]
      {
        TwilightHighlandsPortal = new BlackEmpirePortal(
          PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, new Point(-24805, 1872)),
          null,
          Regions.Ny_Twilight_Highlands_Interior.Center,
          PreplacedUnitSystem.GetUnit(Constants.UNIT_N07F_NY_ALOTHA_PORTAL_GREEN_TWILIGHT_HIGHLANDS,
            Regions.NyHighland.Center), "Twilight",
          ControlPointManager.GetFromUnitType(Constants.UNIT_N04V_NORTHERN_HIGHLANDS_10GOLD_MIN)),

        NorthrendPortal = new BlackEmpirePortal(
          PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, new Point(-25513, -1379)),
          null,
          Regions.NyNorth.Center,
          PreplacedUnitSystem.GetUnit(Constants.UNIT_N07F_NY_ALOTHA_PORTAL_GREEN_TWILIGHT_HIGHLANDS,
            Regions.Ny_Ulduar_Interior.Center), "Northrend",
          ControlPointManager.GetFromUnitType(Constants.UNIT_N04V_NORTHERN_HIGHLANDS_10GOLD_MIN)),

        TanarisPortal = new BlackEmpirePortal(
          PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, new Point(-26208, -1945)),
          null,
          Regions.Ny_Silithus_Interior.Center,
          PreplacedUnitSystem.GetUnit(Constants.UNIT_N07F_NY_ALOTHA_PORTAL_GREEN_TWILIGHT_HIGHLANDS,
            Regions.NyTanaris.Center), "Ul'dum",
          ControlPointManager.GetFromUnitType(Constants.UNIT_N04V_NORTHERN_HIGHLANDS_10GOLD_MIN))
      });
    }
  }
}