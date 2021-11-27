library LegendTwilight initializer OnInit requires Legend

  globals
    Legend LEGEND_DEATHWING
    Legend LEGEND_FELUDIUS
    Legend LEGEND_IGNACIOUS
    Legend LEGEND_AZIL
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_DEATHWING = Legend.create()
    set LEGEND_DEATHWING.Unit = gg_unit_u01Y_0071
    set LEGEND_DEATHWING.PermaDies = true
    set LEGEND_DEATHWING.DeathMessage = "Deathwing, The Black Scourge, is no more. The Destroyer has finally been defeated."

    set LEGEND_AZIL = Legend.create()
    set LEGEND_AZIL.UnitType = 'H08Q'
    set LEGEND_AZIL.StartingXP = 1800

    set LEGEND_FELUDIUS = Legend.create()
    set LEGEND_FELUDIUS.UnitType = 'U01S'
    set LEGEND_FELUDIUS.StartingXP = 2800

    set LEGEND_IGNACIOUS = Legend.create()
    set LEGEND_IGNACIOUS.UnitType = 'O04H'
    set LEGEND_IGNACIOUS.StartingXP = 2800

endfunction

endlibrary