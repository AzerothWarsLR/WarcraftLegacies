library LegendIronforge initializer OnInit requires Legend

  globals
    public static Legend LEGEND_DAGRAN
    public static Legend LEGEND_FALSTAD
    public static Legend LEGEND_MAGNI

    public static Legend LEGEND_GREATFORGE
    public static Legend LEGEND_THELSAMAR
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_DAGRAN = new Legend()
    set LEGEND_DAGRAN.UnitType = 'H03G'
    set LEGEND_DAGRAN.StartingXp = 1000

    set LEGEND_FALSTAD = new Legend()
    set LEGEND_FALSTAD.UnitType = 'H028'
    set LEGEND_FALSTAD.StartingXp = 1000

    set LEGEND_MAGNI = new Legend()
    set LEGEND_MAGNI.UnitType = 'H00S'
    call LEGEND_MAGNI.AddUnitDependency(gg_unit_h001_0180)
    set LEGEND_MAGNI.DeathMessage = "King Magni Bronzebeard has died."
    set LEGEND_MAGNI.Essential = true
    set LEGEND_MAGNI.StartingXp = 1000

    set LEGEND_GREATFORGE = new Legend()
    set LEGEND_GREATFORGE.Unit = gg_unit_h001_0180
    set LEGEND_GREATFORGE.DeathMessage = "The Great Forge has been extinguished."
    set LEGEND_GREATFORGE.IsCapital = true

    set LEGEND_THELSAMAR = new Legend()
    set LEGEND_THELSAMAR.Unit = gg_unit_h05H_1847
  endfunction

endlibrary