library LegendSentinels initializer OnInit requires Legend, LegendDruids

  globals
    Legend LEGEND_MAIEV
    Legend LEGEND_TYRANDE
    Legend LEGEND_SHANDRIS
    Legend LEGEND_JAROD

    Legend LEGEND_AUBERDINE
    Legend LEGEND_FEATHERMOON
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_MAIEV = Legend.create()
    set LEGEND_MAIEV.UnitType = 'Ewrd'

    set LEGEND_AUBERDINE = Legend.create()
    set LEGEND_AUBERDINE.Unit = gg_unit_e00J_0320
    set LEGEND_AUBERDINE.IsCapital = true

    set LEGEND_FEATHERMOON = Legend.create()
    set LEGEND_FEATHERMOON.Unit = gg_unit_e00M_2545
    set LEGEND_FEATHERMOON.IsCapital = true

    set LEGEND_TYRANDE = Legend.create()
    set LEGEND_TYRANDE.UnitType = 'Etyr'
    set LEGEND_TYRANDE.PlayerColor = PLAYER_COLOR_CYAN
    set LEGEND_TYRANDE.Essential = true

    set LEGEND_SHANDRIS = Legend.create()
    set LEGEND_SHANDRIS.UnitType = 'E002'
    set LEGEND_SHANDRIS.StartingXP = 1000

    set LEGEND_JAROD = Legend.create()
    set LEGEND_JAROD.UnitType = 'O02E'
    set LEGEND_JAROD.StartingXP = 4000
  endfunction

endlibrary