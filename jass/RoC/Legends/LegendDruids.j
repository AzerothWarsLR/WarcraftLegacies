library LegendDruids initializer OnInit requires Legend

  globals
    Legend LEGEND_CENARIUS
    Legend LEGEND_MALFURION
    Legend LEGEND_FANDRAL
    Legend LEGEND_URSOC
    Legend LEGEND_TORTOLLA

    Legend LEGEND_NORDRASSIL

    constant integer UNITTYPE_CENARIUS_ALIVE = 'Ecen'
    constant integer UNITTYPE_CENARIUS_GHOST = 'E00H'
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_CENARIUS = Legend.create()
    set LEGEND_CENARIUS.UnitType = 'Ecen'
    set LEGEND_CENARIUS.PermaDies = true
    set LEGEND_CENARIUS.DeathMessage = "The Lord of the Forest, Cenarius, has fallen. The druids of the Kaldorei have lost their greatest mentor."
    set LEGEND_CENARIUS.DeathSfx = "Objects\\Spawnmodels\\NightElf\\EntBirthTarget\\EntBirthTarget.mdl"
    set LEGEND_CENARIUS.PlayerColor = PLAYER_COLOR_CYAN
    set LEGEND_CENARIUS.StartingXP = 1000

    set LEGEND_MALFURION = Legend.create()
    set LEGEND_MALFURION.UnitType = 'Efur'
    set LEGEND_MALFURION.Essential = true

    set LEGEND_FANDRAL = Legend.create()
    set LEGEND_FANDRAL.UnitType = 'E00K'

    set LEGEND_URSOC = Legend.create()
    set LEGEND_URSOC.UnitType = 'E00A'
    set LEGEND_URSOC.StartingXP = 2800

    set LEGEND_NORDRASSIL = Legend.create()
    set LEGEND_NORDRASSIL.Unit = gg_unit_n002_0130
    set LEGEND_NORDRASSIL.Capturable = true
    set LEGEND_NORDRASSIL.IsCapital = true

    set LEGEND_TORTOLLA = Legend.create()
    set LEGEND_TORTOLLA.UnitType = 'H04U'
    set LEGEND_TORTOLLA.StartingXP = 1800
  endfunction

endlibrary