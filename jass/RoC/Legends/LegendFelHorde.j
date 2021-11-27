library LegendFelHorde initializer OnInit requires Legend

  globals
    Legend LEGEND_MAGTHERIDON
    Legend LEGEND_ZULUHED
    Legend LEGEND_CHOGALL
    Legend LEGEND_NEKROSH
    Legend LEGEND_REND
    Legend LEGEND_TERON
    
    Legend LEGEND_BLACKROCKSPIRE
    Legend LEGEND_BLACKTEMPLE
    Legend LEGEND_HELLFIRECITADEL
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_MAGTHERIDON = Legend.create()
    set LEGEND_MAGTHERIDON.UnitType = 'Nmag'
    call LEGEND_MAGTHERIDON.AddUnitDependency(gg_unit_o00F_0659)
    set LEGEND_MAGTHERIDON.DeathMessage = "Magtheridon’s eternal demon soul has been consumed, and his life permanently extinguished. The Lord of Outland has fallen."
    set LEGEND_MAGTHERIDON.Essential = true
    set LEGEND_MAGTHERIDON.StartingXP = 1800

    set LEGEND_REND = Legend.create()
    set LEGEND_REND.UnitType = 'Nbbc'
    set LEGEND_REND.StartingXP = 2800

    set LEGEND_ZULUHED = Legend.create()
    set LEGEND_ZULUHED.UnitType = 'O00Y'

    set LEGEND_NEKROSH = Legend.create()
    set LEGEND_NEKROSH.UnitType = 'O01Q'

    set LEGEND_CHOGALL = Legend.create()
    set LEGEND_CHOGALL.UnitType = 'O01P'

    set LEGEND_TERON = Legend.create()
    set LEGEND_TERON.UnitType = 'U02D'
    set LEGEND_TERON.StartingXP = 5400
    set LEGEND_TERON.PlayerColor = PLAYER_COLOR_MAROON

    set LEGEND_BLACKROCKSPIRE = Legend.create()
    set LEGEND_BLACKROCKSPIRE.Unit = gg_unit_o013_2507
    set LEGEND_BLACKROCKSPIRE.DeathMessage = "Blackrock Spire has been razed."

    set LEGEND_BLACKTEMPLE = Legend.create()
    set LEGEND_BLACKTEMPLE.Unit = gg_unit_o00F_0659
    set LEGEND_BLACKTEMPLE.IsCapital = true
    set LEGEND_BLACKTEMPLE.Capturable = true
    
    set LEGEND_HELLFIRECITADEL = Legend.create()
    set LEGEND_HELLFIRECITADEL.Unit = gg_unit_o008_0168
    set LEGEND_HELLFIRECITADEL.IsCapital = true
  endfunction

endlibrary