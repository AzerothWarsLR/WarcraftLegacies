library LegendFelHorde initializer OnInit requires Legend

  globals
    public static Legend LEGEND_MAGTHERIDON
    public static Legend LEGEND_ZULUHED
    public static Legend LEGEND_CHOGALL
    public static Legend LEGEND_NEKROSH
    public static Legend LEGEND_REND
    public static Legend LEGEND_TERON
    
    public static Legend LEGEND_BLACKROCKSPIRE
    public static Legend LEGEND_BLACKTEMPLE
    public static Legend LEGEND_HELLFIRECITADEL
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_MAGTHERIDON = new Legend()
    set LEGEND_MAGTHERIDON.UnitType = 'Nmag'
    call LEGEND_MAGTHERIDON.AddUnitDependency(gg_unit_o00F_0659)
    set LEGEND_MAGTHERIDON.DeathMessage = "Magtheridon’s eternal demon soul has been consumed, and his life permanently extinguished. The Lord of Outland has fallen."
    set LEGEND_MAGTHERIDON.Essential = true
    set LEGEND_MAGTHERIDON.StartingXp = 1800

    set LEGEND_REND = new Legend()
    set LEGEND_REND.UnitType = 'Nbbc'
    set LEGEND_REND.StartingXp = 2800

    set LEGEND_ZULUHED = new Legend()
    set LEGEND_ZULUHED.UnitType = 'O00Y'

    set LEGEND_NEKROSH = new Legend()
    set LEGEND_NEKROSH.UnitType = 'O01Q'

    set LEGEND_CHOGALL = new Legend()
    set LEGEND_CHOGALL.UnitType = 'O01P'

    set LEGEND_TERON = new Legend()
    set LEGEND_TERON.UnitType = 'U02D'
    set LEGEND_TERON.StartingXp = 5400
    set LEGEND_TERON.PlayerColor = PLAYER_COLOR_MAROON

    set LEGEND_BLACKROCKSPIRE = new Legend()
    set LEGEND_BLACKROCKSPIRE.Unit = gg_unit_o013_2507
    set LEGEND_BLACKROCKSPIRE.DeathMessage = "Blackrock Spire has been razed."

    set LEGEND_BLACKTEMPLE = new Legend()
    set LEGEND_BLACKTEMPLE.Unit = gg_unit_o00F_0659
    set LEGEND_BLACKTEMPLE.IsCapital = true
    set LEGEND_BLACKTEMPLE.Capturable = true
    
    set LEGEND_HELLFIRECITADEL = new Legend()
    set LEGEND_HELLFIRECITADEL.Unit = gg_unit_o008_0168
    set LEGEND_HELLFIRECITADEL.IsCapital = true
  endfunction

endlibrary