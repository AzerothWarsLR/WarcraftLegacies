library LegendForsaken initializer OnInit requires Legend

  globals
    public static Legend LEGEND_SYLVANASV
    public static Legend LEGEND_SCHOLOMANCE
    public static Legend LEGEND_VARIMATHRAS
    public static Legend LEGEND_NATHANOS
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_SYLVANASV = new Legend()
    set LEGEND_SYLVANASV.UnitType = 'Usyl'
    set LEGEND_SYLVANASV.StartingXp = 15400

    set LEGEND_NATHANOS = new Legend()
    set LEGEND_NATHANOS.UnitType = 'H049'
    set LEGEND_NATHANOS.StartingXp = 7000

    set LEGEND_VARIMATHRAS = new Legend()
    set LEGEND_VARIMATHRAS.UnitType = 'Uvar'
    set LEGEND_VARIMATHRAS.PlayerColor = PLAYER_COLOR_RED

    set LEGEND_SCHOLOMANCE = new Legend()
    set LEGEND_SCHOLOMANCE.Unit = gg_unit_u012_1149
    set LEGEND_SCHOLOMANCE.DeathMessage = "Scholomance, the center of the Scourge's operations in Lordaeron, has been destroyed."
endfunction

endlibrary