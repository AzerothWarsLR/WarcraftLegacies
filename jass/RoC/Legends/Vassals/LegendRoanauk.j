library LegendRoanauk initializer OnInit requires Legend

  globals
    public static Legend LEGEND_ROANAUK
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_ROANAUK = new Legend()
    set LEGEND_ROANAUK.UnitType = 'O02N'
  endfunction

endlibrary