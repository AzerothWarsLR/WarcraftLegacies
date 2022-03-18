library LegendBrann initializer OnInit requires Legend

  globals
    public static Legend LEGEND_BRANN
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_BRANN = new Legend()
    set LEGEND_BRANN.UnitType = 'H04Q'
  endfunction

endlibrary