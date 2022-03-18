library LegendEdwin initializer OnInit requires Legend

  globals
    public static Legend LEGEND_EDWIN
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_EDWIN = new Legend()
    set LEGEND_EDWIN.UnitType = 'E00O'
  endfunction

endlibrary