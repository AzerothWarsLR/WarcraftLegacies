library LegendNaga initializer OnInit requires Legend

  globals
    public static Legend LEGEND_ILLIDAN
    public static Legend LEGEND_VASHJ
    public static Legend LEGEND_NAJENTUS
    public static Legend LEGEND_AZSHARA
    public static Legend LEGEND_NZOTH
    public static Legend LEGEND_ALTRUIS
    public static Legend LEGEND_AKAMA
    
    public static Legend LEGEND_NAZJATAR
    public static Legend LEGEND_VAULT
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_ILLIDAN = new Legend()
    set LEGEND_ILLIDAN.Unit = gg_unit_Eill_0748
    set LEGEND_ILLIDAN.PlayerColor = PLAYER_COLOR_PURPLE

    set LEGEND_VASHJ = new Legend()
    set LEGEND_VASHJ.UnitType = 'Hvsh'
    set LEGEND_VASHJ.StartingXp = 2800

    set LEGEND_AZSHARA = new Legend()
    set LEGEND_AZSHARA.UnitType = 'H08U'

    set LEGEND_NAJENTUS = new Legend()
    set LEGEND_NAJENTUS.UnitType = 'U00S'
    set LEGEND_NAJENTUS.StartingXp = 2800

    set LEGEND_ALTRUIS = new Legend()
    set LEGEND_ALTRUIS.UnitType = 'E015'
    set LEGEND_ALTRUIS.StartingXp = 4000

    set LEGEND_AKAMA = new Legend()
    set LEGEND_AKAMA.UnitType = 'Naka'
    set LEGEND_AKAMA.StartingXp = 4000

    set LEGEND_NZOTH = new Legend()
    set LEGEND_NZOTH.Unit = gg_unit_U01Z_1237
    set LEGEND_NZOTH.DeathMessage = "The Old God N'zoth has fallen"
    set LEGEND_NZOTH.PermaDies = true

    set LEGEND_NAZJATAR = new Legend()
    set LEGEND_NAZJATAR.Unit = gg_unit_n045_3377
    set LEGEND_NAZJATAR.DeathMessage = "The Temple of Azshara has fallen."
    set LEGEND_NAZJATAR.IsCapital = true

    set LEGEND_VAULT = new Legend()
    set LEGEND_VAULT.Unit = gg_unit_n05A_2845
    set LEGEND_VAULT.DeathMessage = "The vault under the Aetheneum has been lost forever"
    set LEGEND_VAULT.IsCapital = true
  endfunction

endlibrary