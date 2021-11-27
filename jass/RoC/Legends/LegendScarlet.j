library LegendScarlet initializer OnInit requires Legend

  globals
    Legend LEGEND_BRIGITTE
  endglobals

  private function OnInit takes nothing returns nothing

    set LEGEND_BRIGITTE = Legend.create()
    set LEGEND_BRIGITTE.UnitType = 'H00Y'
    set LEGEND_BRIGITTE.StartingXP = 7000

endfunction

endlibrary