using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.ControlPointSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Mechanics.BlackEmpire
{
  public static class BlackEmpirePortalSetup
  {
    public static BlackEmpirePortal? TwilightHighlandsPortal { get; private set; }
    public static BlackEmpirePortal? NorthrendPortal { get; private set; }
    public static BlackEmpirePortal? TanarisPortal { get; private set; }

    public static void Setup()
    {
      var twilightInteriorPos = new Point(-24805, -1872);
      var northrendInteriorPos = new Point(-25513, -1379);
      var tanarisInteriorPos = new Point(-26208, -1945);
      var shimmeringPortalId = FourCC("OTsp");

      BlackEmpirePortalManager.RegisterPortals(new[]
      {
        NorthrendPortal = new BlackEmpirePortal(
          PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, northrendInteriorPos),
          PreplacedUnitSystem.GetDestructable(shimmeringPortalId, northrendInteriorPos),
          Regions.Ny_Ulduar_Interior.Center,
          PreplacedUnitSystem.GetUnit(Constants.UNIT_N07F_NY_ALOTHA_PORTAL_GREEN_TWILIGHT_HIGHLANDS,
            Regions.NyNorth.Center), "Northrend",
          ControlPointManager.GetFromUnitType(Constants.UNIT_N02S_STORM_PEAKS_15GOLD_MIN)),

        TanarisPortal = new BlackEmpirePortal(
          PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, tanarisInteriorPos),
          PreplacedUnitSystem.GetDestructable(shimmeringPortalId, tanarisInteriorPos),
          Regions.Ny_Silithus_Interior.Center,
          PreplacedUnitSystem.GetUnit(Constants.UNIT_N07F_NY_ALOTHA_PORTAL_GREEN_TWILIGHT_HIGHLANDS,
            Regions.NyTanaris.Center), "Ul'dum",
          ControlPointManager.GetFromUnitType(Constants.UNIT_N0BD_ULDUM_10GOLD_MIN)),

        TwilightHighlandsPortal = new BlackEmpirePortal(
          PreplacedUnitSystem.GetUnit(Constants.UNIT_H03V_ENTRANCE_PORTAL, twilightInteriorPos),
          PreplacedUnitSystem.GetDestructable(shimmeringPortalId, twilightInteriorPos),
          Regions.Ny_Twilight_Highlands_Interior.Center,
          PreplacedUnitSystem.GetUnit(Constants.UNIT_N07F_NY_ALOTHA_PORTAL_GREEN_TWILIGHT_HIGHLANDS,
            Regions.NyHighland.Center), "Twilight",
          ControlPointManager.GetFromUnitType(Constants.UNIT_N04V_NORTHERN_HIGHLANDS_10GOLD_MIN))
      });
    }
  }
}