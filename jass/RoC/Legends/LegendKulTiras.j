library LegendKultiras initializer OnInit requires Legend

  globals
    Legend LEGEND_ADMIRAL
    Legend LEGEND_LUCILLE
  endglobals

  private function OnInit takes nothing returns nothing 
    set LEGEND_ADMIRAL = Legend.create()
    set LEGEND_ADMIRAL.UnitType = 'Hapm'
    set LEGEND_ADMIRAL.Essential = true

    set LEGEND_LUCILLE = Legend.create()
    set LEGEND_LUCILLE.UnitType = 'E016'
    set LEGEND_LUCILLE.StartingXP = 2800

  endfunction

endlibrary