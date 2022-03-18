library LegendLordaeron initializer OnInit requires Legend

  globals
    public static Legend LEGEND_UTHER
    public static Legend LEGEND_ARTHAS
    public static Legend LEGEND_MOGRAINE
    public static Legend LEGEND_GARITHOS

    public static Legend LEGEND_CAPITALPALACE
    public static Legend LEGEND_STRATHOLME
    public static Legend LEGEND_TYRSHAND
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_MOGRAINE = new Legend()
    set LEGEND_MOGRAINE.UnitType = 'H01J'
    set LEGEND_MOGRAINE.StartingXp = 2800

    set LEGEND_GARITHOS = new Legend()
    set LEGEND_GARITHOS.UnitType = 'Hlgr'
    set LEGEND_GARITHOS.StartingXp = 2800

    set LEGEND_CAPITALPALACE = new Legend()
    set LEGEND_CAPITALPALACE.Unit = gg_unit_h000_0406
    set LEGEND_CAPITALPALACE.DeathMessage = "The capital city of Lordaeron has been razed, and King Terenas is dead."
    set LEGEND_CAPITALPALACE.IsCapital = true

    set LEGEND_STRATHOLME = new Legend()
    set LEGEND_STRATHOLME.Unit = gg_unit_h01G_0885
    set LEGEND_STRATHOLME.DeathMessage = "The majestic city of Stratholme has been destroyed."
    set LEGEND_STRATHOLME.IsCapital = true

    set LEGEND_TYRSHAND = new Legend()
    set LEGEND_TYRSHAND.Unit = gg_unit_h030_0839
    set LEGEND_TYRSHAND.DeathMessage = "Tyr's Hand, the bastion of human power in Lordaeron, has fallen."
    set LEGEND_TYRSHAND.IsCapital = true

    set LEGEND_UTHER = new Legend()
    set LEGEND_UTHER.UnitType = 'Huth'
    call LEGEND_UTHER.AddUnitDependency(gg_unit_h000_0406)
    call LEGEND_UTHER.AddUnitDependency(gg_unit_nico_0666)
    set LEGEND_UTHER.DeathMessage = "Uther the Lightbringer makes his last stand, perishing in the defense of the light. Lordaeron, and humanity itself, has lost one of its finest exemplars in this dark hour."
    set LEGEND_UTHER.PlayerColor = PLAYER_COLOR_LIGHT_BLUE
    set LEGEND_UTHER.StartingXp = 1000

    set LEGEND_ARTHAS = new Legend()
    set LEGEND_ARTHAS.UnitType = 'Hart'
    set LEGEND_ARTHAS.PlayerColor = PLAYER_COLOR_BLUE
    call LEGEND_ARTHAS.AddUnitDependency(LEGEND_STRATHOLME.Unit)
    call LEGEND_ARTHAS.AddUnitDependency(gg_unit_nico_0666)
    set LEGEND_ARTHAS.Essential = true

  endfunction

endlibrary