library LegendRhonin initializer OnInit requires Legend

  globals
    Legend LEGEND_RHONIN
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_RHONIN = Legend.create()
    set LEGEND_RHONIN.UnitType = 'H04K'
  endfunction

endlibrary