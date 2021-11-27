library LegendRoanauk initializer OnInit requires Legend

  globals
    Legend LEGEND_ROANAUK
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_ROANAUK = Legend.create()
    set LEGEND_ROANAUK.UnitType = 'O02N'
  endfunction

endlibrary