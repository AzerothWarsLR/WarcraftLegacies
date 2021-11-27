library LegendStormwind initializer OnInit requires Legend

  globals
    Legend LEGEND_VARIAN
    Legend LEGEND_KHADGAR
    Legend LEGEND_GALEN
    Legend LEGEND_BOLVAR

    Legend LEGEND_STORMWINDKEEP
    Legend LEGEND_DARKSHIRE
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_VARIAN = Legend.create()
    set LEGEND_VARIAN.UnitType = 'H00R'
    call LEGEND_VARIAN.AddUnitDependency(gg_unit_h00X_0007)
    set LEGEND_VARIAN.DeathMessage = "The King of Stormwind dies a warrior’s death, defending hearth and family. The Wrynn Dynasty crumbles with his passing."
    set LEGEND_VARIAN.Essential = true

    set LEGEND_GALEN = Legend.create()
    set LEGEND_GALEN.UnitType = 'H00Z'
    set LEGEND_GALEN.StartingXP = 1000

    set LEGEND_BOLVAR = Legend.create()
    set LEGEND_BOLVAR.UnitType = 'H017'

    set LEGEND_KHADGAR = Legend.create()
    set LEGEND_KHADGAR.UnitType = 'H05Y'

    set LEGEND_STORMWINDKEEP = Legend.create()
    set LEGEND_STORMWINDKEEP.Unit = gg_unit_h00X_0007
    set LEGEND_STORMWINDKEEP.DeathMessage = "Stormwind Keep, the capitol of the nation of Stormwind, has been destroyed!"
    set LEGEND_STORMWINDKEEP.IsCapital = true

    set LEGEND_DARKSHIRE = Legend.create()
    set LEGEND_DARKSHIRE.Unit = gg_unit_h03Y_0077
  endfunction

endlibrary