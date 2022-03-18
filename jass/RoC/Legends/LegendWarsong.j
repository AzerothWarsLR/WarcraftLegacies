library LegendWarsong initializer OnInit requires Legend

  globals
    public static Legend LEGEND_GROM
    public static Legend LEGEND_JERGOSH
    public static Legend LEGEND_MANNOROTH
    public static Legend LEGEND_STONEMAUL
    public static Legend LEGEND_ENCAMPMENT
    public static Legend LEGEND_CHEN
    public static Legend LEGEND_SAURFANG
  endglobals

  private function OnInit takes nothing returns nothing

    set LEGEND_CHEN = new Legend()
    set LEGEND_CHEN.UnitType = 'Nsjs'
    set LEGEND_CHEN.StartingXp = 1000

    set LEGEND_SAURFANG = new Legend()
    set LEGEND_SAURFANG.UnitType = 'Obla'
    set LEGEND_SAURFANG.StartingXp = 2800

    set LEGEND_JERGOSH = new Legend()
    set LEGEND_JERGOSH.UnitType = 'Oths'

    set LEGEND_MANNOROTH = new Legend()
    set LEGEND_MANNOROTH.UnitType = 'Nman'

    set LEGEND_STONEMAUL = new Legend()
    set LEGEND_STONEMAUL.Unit = gg_unit_o004_0169
    set LEGEND_STONEMAUL.DeathMessage = "The fortress of the Stonemaul Clan has fallen."
    set LEGEND_STONEMAUL.IsCapital = true

    set LEGEND_ENCAMPMENT = new Legend()

    set LEGEND_GROM = new Legend()
    set LEGEND_GROM.UnitType = 'Ogrh'
  endfunction

endlibrary