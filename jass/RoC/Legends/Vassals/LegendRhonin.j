library LegendRhonin initializer OnInit requires Legend

  globals
    public static Legend LEGEND_RHONIN
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_RHONIN = new Legend()
    set LEGEND_RHONIN.UnitType = 'H04K'
  endfunction

endlibrary