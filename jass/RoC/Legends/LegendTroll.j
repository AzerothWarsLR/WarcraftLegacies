library LegendTroll initializer OnInit requires Legend

  globals
    Legend LEGEND_PRIEST
    Legend LEGEND_RASTAKHAN
    Legend LEGEND_HAKKAR
  endglobals

  private function OnInit takes nothing returns nothing 
    set LEGEND_PRIEST = Legend.create()
    set LEGEND_PRIEST.UnitType = 'O01J'
    set LEGEND_PRIEST.Essential = true

    set LEGEND_HAKKAR = Legend.create()
    set LEGEND_HAKKAR.UnitType = 'U023'

    set LEGEND_RASTAKHAN = Legend.create()
    set LEGEND_RASTAKHAN.UnitType = 'O026'
    set LEGEND_RASTAKHAN.StartingXP = 2800

  endfunction

endlibrary