library LegendLegion initializer OnInit requires Legend

  globals
    public static Legend LEGEND_ARCHIMONDE
    public static Legend LEGEND_ANETHERON
    public static Legend LEGEND_TICHONDRIUS
    public static Legend LEGEND_MALGANIS

    public static Legend LEGEND_LEGIONNEXUS
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_ARCHIMONDE = new Legend()
    set LEGEND_ARCHIMONDE.Unit = gg_unit_Uwar_2344
    set LEGEND_ARCHIMONDE.PermaDies = true
    set LEGEND_ARCHIMONDE.DeathMessage = "Archimonde the Defiler has been banished from Azeroth, marking the end of his second failed invasion."
    set LEGEND_ARCHIMONDE.StartingXp = 10800
    set LEGEND_ARCHIMONDE.Essential = true
    
    set LEGEND_ANETHERON = new Legend()
    set LEGEND_ANETHERON.UnitType = 'U00L'
    set LEGEND_ANETHERON.PlayerColor = PLAYER_COLOR_ORANGE

    set LEGEND_TICHONDRIUS = new Legend()
    set LEGEND_TICHONDRIUS.UnitType = 'Utic'
    set LEGEND_TICHONDRIUS.PlayerColor = PLAYER_COLOR_RED

    set LEGEND_MALGANIS = new Legend()
    set LEGEND_MALGANIS.UnitType = 'Umal'
    set LEGEND_MALGANIS.PlayerColor = PLAYER_COLOR_GREEN

    set LEGEND_LEGIONNEXUS = new Legend()
    set LEGEND_LEGIONNEXUS.Unit = gg_unit_u01Q_3871
    set LEGEND_LEGIONNEXUS.DeathMessage = "The Legion Nexus was destroyed. The Burning Legion is now cut off from Azeroth."
    set LEGEND_LEGIONNEXUS.IsCapital = true
  endfunction

endlibrary