library LegendDalaran initializer OnInit requires Legend

  globals
    public static Legend LEGEND_ANTONIDAS
    public static Legend LEGEND_MEDIVH
    public static Legend LEGEND_JAINA
    public static Legend LEGEND_KALECGOS
    public static Legend LEGEND_MALYGOS

    public static Legend LEGEND_DALARAN
  endglobals

  private function OnInit takes nothing returns nothing 
    set LEGEND_JAINA = new Legend()
    set LEGEND_JAINA.UnitType = 'Hjai'
    set LEGEND_JAINA.Essential = true

    set LEGEND_MEDIVH = new Legend()
    set LEGEND_MEDIVH.UnitType = 'Haah'
    set LEGEND_MEDIVH.StartingXp = 2800

    set LEGEND_KALECGOS = new Legend()
    set LEGEND_KALECGOS.UnitType = 'U027'
    set LEGEND_KALECGOS.StartingXp = 9800

    set LEGEND_MALYGOS = new Legend()
    set LEGEND_MALYGOS.UnitType = 'U026'
    set LEGEND_MALYGOS.StartingXp = 10900

    set LEGEND_DALARAN = new Legend()
    set LEGEND_DALARAN.Unit = gg_unit_h002_0230
    set LEGEND_DALARAN.DeathMessage = "The Violet Citadel, the ultimate bastion of arcane knowledge in the Eastern Kingdoms, crumbles like a sand castle."
    set LEGEND_DALARAN.IsCapital = true

    set LEGEND_ANTONIDAS = new Legend()
    set LEGEND_ANTONIDAS.UnitType = 'Hant'
    set LEGEND_ANTONIDAS.StartingXp = 1000
    call LEGEND_ANTONIDAS.AddUnitDependency(LEGEND_DALARAN.Unit)
    set LEGEND_ANTONIDAS.DeathMessage = "Archmage Antonidas has been cut down, his vast knowledge forever lost with his death. The mages of Dalaran have lost their brightest mind."
  endfunction

endlibrary