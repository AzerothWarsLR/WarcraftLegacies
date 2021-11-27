library BlackEmpirePortalSetup initializer OnInit requires BlackEmpirePortal

  globals
    BlackEmpirePortal BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS
    BlackEmpirePortal BLACKEMPIREPORTAL_NORTHREND
    BlackEmpirePortal BLACKEMPIREPORTAL_TANARIS
    BlackEmpirePortal BLACKEMPIREPORTAL_ILLIDAN
  endglobals

  private function OnInit takes nothing returns nothing
    set BLACKEMPIREPORTAL_TANARIS = BlackEmpirePortal.create(gg_unit_h03V_0257, gg_dest_OTsp_35728, GetRectCenterX(gg_rct_Ny_Silithus_Interior), GetRectCenterY(gg_rct_Ny_Silithus_Interior), gg_unit_n07F_1001, "Uldum")
    set BLACKEMPIREPORTAL_TANARIS.NearbyControlPoint = ControlPoint.ByUnitType('n020')

    set BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS = BlackEmpirePortal.create(gg_unit_h03V_0396, gg_dest_OTsp_19293, GetRectCenterX(gg_rct_Ny_Twilight_Highlands_Interior), GetRectCenterY(gg_rct_Ny_Twilight_Highlands_Interior), gg_unit_n07F_1069, "Twilight")
    set BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS.Next = BLACKEMPIREPORTAL_TANARIS
    set BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS.NearbyControlPoint = ControlPoint.ByUnitType('n04V')

    set BLACKEMPIREPORTAL_NORTHREND = BlackEmpirePortal.create(gg_unit_h03V_1110, gg_dest_OTsp_35727, GetRectCenterX(gg_rct_Ny_Ulduar_Interior), GetRectCenterY(gg_rct_Ny_Ulduar_Interior), gg_unit_n07F_1101, "Northrend")
    set BLACKEMPIREPORTAL_NORTHREND.Next = BLACKEMPIREPORTAL_TWILIGHTHIGHLANDS
    set BLACKEMPIREPORTAL_NORTHREND.NearbyControlPoint = ControlPoint.ByUnitType('n02S')

    set BLACKEMPIREPORTAL_ILLIDAN = BlackEmpirePortal.create(gg_unit_h03V_0183, gg_dest_OTsp_35732, GetRectCenterX(gg_rct_Ny_Nazjatar_Interior), GetRectCenterY(gg_rct_Ny_Nazjatar_Interior), gg_unit_n07E_0958, "N'zoth")

    set BlackEmpirePortal.Objective = BLACKEMPIREPORTAL_NORTHREND //The first portal that an Obelisk needs to be built at
  endfunction

endlibrary