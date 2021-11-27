library LegendEdwin initializer OnInit requires Legend

  globals
    Legend LEGEND_EDWIN
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_EDWIN = Legend.create()
    set LEGEND_EDWIN.UnitType = 'E00O'
  endfunction

endlibrary