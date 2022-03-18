library LegendStormwind initializer OnInit requires Legend

  globals
    public static Legend LEGEND_VARIAN
    public static Legend LEGEND_KHADGAR
    public static Legend LEGEND_GALEN
    public static Legend LEGEND_BOLVAR

    public static Legend LEGEND_STORMWINDKEEP
    public static Legend LEGEND_DARKSHIRE
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_VARIAN = new Legend()
    set LEGEND_VARIAN.UnitType = 'H00R'
    call LEGEND_VARIAN.AddUnitDependency(gg_unit_h00X_0007)
    set LEGEND_VARIAN.DeathMessage = "The King of Stormwind dies a warrior’s death, defending hearth and family. The Wrynn Dynasty crumbles with his passing."
    set LEGEND_VARIAN.Essential = true

    set LEGEND_GALEN = new Legend()
    set LEGEND_GALEN.UnitType = 'H00Z'
    set LEGEND_GALEN.StartingXp = 1000

    set LEGEND_BOLVAR = new Legend()
    set LEGEND_BOLVAR.UnitType = 'H017'

    set LEGEND_KHADGAR = new Legend()
    set LEGEND_KHADGAR.UnitType = 'H05Y'

    set LEGEND_STORMWINDKEEP = new Legend()
    set LEGEND_STORMWINDKEEP.Unit = gg_unit_h00X_0007
    set LEGEND_STORMWINDKEEP.DeathMessage = "Stormwind Keep, the capitol of the nation of Stormwind, has been destroyed!"
    set LEGEND_STORMWINDKEEP.IsCapital = true

    set LEGEND_DARKSHIRE = new Legend()
    set LEGEND_DARKSHIRE.Unit = gg_unit_h03Y_0077
  endfunction

endlibrary