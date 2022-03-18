library LegendKultiras initializer OnInit requires Legend

  globals
    public static Legend LEGEND_ADMIRAL
    public static Legend LEGEND_LUCILLE
  endglobals

  private function OnInit takes nothing returns nothing 
    set LEGEND_ADMIRAL = new Legend()
    set LEGEND_ADMIRAL.UnitType = 'Hapm'
    set LEGEND_ADMIRAL.Essential = true

    set LEGEND_LUCILLE = new Legend()
    set LEGEND_LUCILLE.UnitType = 'E016'
    set LEGEND_LUCILLE.StartingXp = 2800

  endfunction

endlibrary