library LegendBrann initializer OnInit requires Legend

  globals
    Legend LEGEND_BRANN
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_BRANN = Legend.create()
    set LEGEND_BRANN.UnitType = 'H04Q'
  endfunction

endlibrary