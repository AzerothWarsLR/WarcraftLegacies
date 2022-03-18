library LegendSentinels initializer OnInit requires Legend, LegendDruids

  globals
    public static Legend LEGEND_MAIEV
    public static Legend LEGEND_TYRANDE
    public static Legend LEGEND_SHANDRIS
    public static Legend LEGEND_JAROD

    public static Legend LEGEND_AUBERDINE
    public static Legend LEGEND_FEATHERMOON
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_MAIEV = new Legend()
    set LEGEND_MAIEV.UnitType = 'Ewrd'

    set LEGEND_AUBERDINE = new Legend()
    set LEGEND_AUBERDINE.Unit = gg_unit_e00J_0320
    set LEGEND_AUBERDINE.IsCapital = true

    set LEGEND_FEATHERMOON = new Legend()
    set LEGEND_FEATHERMOON.Unit = gg_unit_e00M_2545
    set LEGEND_FEATHERMOON.IsCapital = true

    set LEGEND_TYRANDE = new Legend()
    set LEGEND_TYRANDE.UnitType = 'Etyr'
    set LEGEND_TYRANDE.PlayerColor = PLAYER_COLOR_CYAN
    set LEGEND_TYRANDE.Essential = true

    set LEGEND_SHANDRIS = new Legend()
    set LEGEND_SHANDRIS.UnitType = 'E002'
    set LEGEND_SHANDRIS.StartingXp = 1000

    set LEGEND_JAROD = new Legend()
    set LEGEND_JAROD.UnitType = 'O02E'
    set LEGEND_JAROD.StartingXp = 4000
  endfunction

endlibrary