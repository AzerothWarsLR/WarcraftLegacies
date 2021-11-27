library LegendXavius initializer OnInit requires Legend

  globals
    Legend LEGEND_XAVIUS
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_XAVIUS = Legend.create()
    set LEGEND_XAVIUS.UnitType = 'H047'
  endfunction

endlibrary