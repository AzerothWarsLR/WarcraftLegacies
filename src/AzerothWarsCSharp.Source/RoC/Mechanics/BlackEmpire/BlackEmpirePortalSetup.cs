using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Mechanics.BlackEmpire
{
  public class BlackEmpirePortalSetup{

  
    BlackEmpirePortal BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS
    BlackEmpirePortal BLACKEMPIREPORTAL_NORTHREND
    BlackEmpirePortal BLACKEMPIREPORTAL_TANARIS
    BlackEmpirePortal BLACKEMPIREPORTAL_ILLIDAN
  

    public static void Setup( ){

      BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS = BlackEmpirePortal.create(gg_unit_h03V_0396, gg_dest_OTsp_19293, GetRectCenterX(gg_rct_Ny_Twilight_Highlands_Interior), GetRectCenterY(gg_rct_Ny_Twilight_Highlands_Interior), gg_unit_n07F_1069, "Twilight");
      BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS.NearbyControlPoint = ControlPoint.GetFromUnitType(FourCC(n04V));

      BLACKEMPIREPORTAL_TANARIS = BlackEmpirePortal.create(gg_unit_h03V_0257, gg_dest_OTsp_35728, GetRectCenterX(gg_rct_Ny_Silithus_Interior), GetRectCenterY(gg_rct_Ny_Silithus_Interior), gg_unit_n07F_1001, "Uldum");
      BLACKEMPIREPORTAL_TANARIS.Next = BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS;
      BLACKEMPIREPORTAL_TANARIS.NearbyControlPoint = ControlPoint.GetFromUnitType(FourCC(n0BD));

      BLACKEMPIREPORTAL_NORTHREND = BlackEmpirePortal.create(gg_unit_h03V_1110, gg_dest_OTsp_35727, GetRectCenterX(gg_rct_Ny_Ulduar_Interior), GetRectCenterY(gg_rct_Ny_Ulduar_Interior), gg_unit_n07F_1101, "Northrend");
      BLACKEMPIREPORTAL_NORTHREND.Next = BLACKEMPIREPORTAL_TANARIS;
      BLACKEMPIREPORTAL_NORTHREND.NearbyControlPoint = ControlPoint.GetFromUnitType(FourCC(n02S));

      BLACKEMPIREPORTAL_ILLIDAN = BlackEmpirePortal.create(gg_unit_h03V_0183, gg_dest_OTsp_35732, GetRectCenterX(gg_rct_Ny_Nazjatar_Interior), GetRectCenterY(gg_rct_Ny_Nazjatar_Interior), gg_unit_n07E_0958, "NFourCC(zoth");

      BlackEmpirePortal.Objective = BLACKEMPIREPORTAL_NORTHREND ;//The first portal that an Obelisk needs to be built at
    }

  }
}
