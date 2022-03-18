library LegendDruids initializer OnInit requires Legend

  globals
    public static Legend LEGEND_CENARIUS
    public static Legend LEGEND_MALFURION
    public static Legend LEGEND_FANDRAL
    public static Legend LEGEND_URSOC
    public static Legend LEGEND_TORTOLLA

    public static Legend LEGEND_NORDRASSIL

    constant integer UNITTYPE_CENARIUS_ALIVE = 'Ecen'
    constant integer UNITTYPE_CENARIUS_GHOST = 'E00H'
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_CENARIUS = new Legend()
    set LEGEND_CENARIUS.UnitType = 'Ecen'
    set LEGEND_CENARIUS.PermaDies = true
    set LEGEND_CENARIUS.DeathMessage = "The Lord of the Forest, Cenarius, has fallen. The druids of the Kaldorei have lost their greatest mentor."
    set LEGEND_CENARIUS.DeathSfx = "Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl"
    set LEGEND_CENARIUS.PlayerColor = PLAYER_COLOR_CYAN
    set LEGEND_CENARIUS.StartingXp = 1000

    set LEGEND_MALFURION = new Legend()
    set LEGEND_MALFURION.UnitType = 'Efur'
    set LEGEND_MALFURION.Essential = true

    set LEGEND_FANDRAL = new Legend()
    set LEGEND_FANDRAL.UnitType = 'E00K'

    set LEGEND_URSOC = new Legend()
    set LEGEND_URSOC.UnitType = 'E00A'
    set LEGEND_URSOC.StartingXp = 2800

    set LEGEND_NORDRASSIL = new Legend()
    set LEGEND_NORDRASSIL.Unit = gg_unit_n002_0130
    set LEGEND_NORDRASSIL.Capturable = true
    set LEGEND_NORDRASSIL.IsCapital = true

    set LEGEND_TORTOLLA = new Legend()
    set LEGEND_TORTOLLA.UnitType = 'H04U'
    set LEGEND_TORTOLLA.StartingXp = 1800
  endfunction

endlibrary