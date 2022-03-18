library LegendBlackEmpire initializer OnInit requires Legend

  globals
    public static Legend LEGEND_YOR
    public static Legend LEGEND_YOGG
  endglobals

  private function OnInit takes nothing returns nothing

    set LEGEND_YOGG = new Legend()
    set LEGEND_YOGG.Unit = gg_unit_U02C_2829
    set LEGEND_YOGG.PermaDies = true
    set LEGEND_YOGG.DeathMessage = "The Old God Yogg-Saron has fallen"

    set LEGEND_YOR = new Legend()
    set LEGEND_YOR.UnitType = 'U02A'
    set LEGEND_YOR.StartingXp = 5800

  endfunction

endlibrary