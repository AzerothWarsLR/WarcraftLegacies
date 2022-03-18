library LegendTroll initializer OnInit requires Legend

  globals
    public static Legend LEGEND_PRIEST
    public static Legend LEGEND_RASTAKHAN
    public static Legend LEGEND_HAKKAR
  endglobals

  private function OnInit takes nothing returns nothing 
    set LEGEND_PRIEST = new Legend()
    set LEGEND_PRIEST.UnitType = 'O01J'
    set LEGEND_PRIEST.Essential = true

    set LEGEND_HAKKAR = new Legend()
    set LEGEND_HAKKAR.UnitType = 'U023'

    set LEGEND_RASTAKHAN = new Legend()
    set LEGEND_RASTAKHAN.UnitType = 'O026'
    set LEGEND_RASTAKHAN.StartingXp = 2800

  endfunction

endlibrary