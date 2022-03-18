library LegendXavius initializer OnInit requires Legend

  globals
    public static Legend LEGEND_XAVIUS
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_XAVIUS = new Legend()
    set LEGEND_XAVIUS.UnitType = 'H047'
  endfunction

endlibrary