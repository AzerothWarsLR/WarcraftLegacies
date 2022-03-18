library LegendTwilight initializer OnInit requires Legend

  globals
    public static Legend LEGEND_DEATHWING
    public static Legend LEGEND_FELUDIUS
    public static Legend LEGEND_IGNACIOUS
    public static Legend LEGEND_AZIL
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_DEATHWING = new Legend()
    set LEGEND_DEATHWING.Unit = gg_unit_u01Y_0071
    set LEGEND_DEATHWING.PermaDies = true
    set LEGEND_DEATHWING.DeathMessage = "Deathwing, The Black Scourge, is no more. The Destroyer has finally been defeated."

    set LEGEND_AZIL = new Legend()
    set LEGEND_AZIL.UnitType = 'H08Q'
    set LEGEND_AZIL.StartingXp = 1800

    set LEGEND_FELUDIUS = new Legend()
    set LEGEND_FELUDIUS.UnitType = 'U01S'
    set LEGEND_FELUDIUS.StartingXp = 2800

    set LEGEND_IGNACIOUS = new Legend()
    set LEGEND_IGNACIOUS.UnitType = 'O04H'
    set LEGEND_IGNACIOUS.StartingXp = 2800

endfunction

endlibrary