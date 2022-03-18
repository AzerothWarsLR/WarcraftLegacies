library LegendQuelthalas initializer OnInit requires Legend

  globals
    public static Legend LEGEND_ANASTERIAN
    public static Legend LEGEND_ROMMATH
    public static Legend LEGEND_JENNALLA
    public static Legend LEGEND_SYLVANAS
    public static Legend LEGEND_KORIALSTRASZ
    public static Legend LEGEND_KAEL
    public static Legend LEGEND_LORTHEMAR
    public static Legend LEGEND_KILJAEDEN
    public static Legend LEGEND_PATHALEON

    public static Legend LEGEND_SILVERMOON
    public static Legend LEGEND_SUNWELL
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_SILVERMOON = new Legend()
    set LEGEND_SILVERMOON.Unit = gg_unit_h003_0418
    set LEGEND_SILVERMOON.DeathMessage = "The grand city of the high elves, Silvermoon, has been crushed by her enemies."
    set LEGEND_SILVERMOON.IsCapital = true

    set LEGEND_SUNWELL = new Legend()
    set LEGEND_SUNWELL.Unit = gg_unit_n001_0165
    set LEGEND_SUNWELL.Capturable = true
    set LEGEND_SUNWELL.IsCapital = true

    set LEGEND_ANASTERIAN = new Legend()
    set LEGEND_ANASTERIAN.UnitType = 'H00Q'
    set LEGEND_ANASTERIAN.PlayerColor = PLAYER_COLOR_MAROON
    call LEGEND_ANASTERIAN.AddUnitDependency(LEGEND_SUNWELL.Unit)
    set LEGEND_ANASTERIAN.Essential = true
    set LEGEND_ANASTERIAN.StartingXp = 1000

    set LEGEND_ROMMATH = new Legend()
    set LEGEND_ROMMATH.UnitType = 'H04F'
    set LEGEND_ROMMATH.StartingXp = 1800

    set LEGEND_JENNALLA = new Legend()
    set LEGEND_JENNALLA.UnitType = 'H02B'

    set LEGEND_PATHALEON = new Legend()
    set LEGEND_PATHALEON.UnitType = 'H098'
    set LEGEND_PATHALEON.StartingXp = 1800
    
    set LEGEND_SYLVANAS = new Legend()
    set LEGEND_SYLVANAS.UnitType = 'Hvwd'
    set LEGEND_SYLVANAS.PlayerColor = PLAYER_COLOR_GREEN

    set LEGEND_KAEL = new Legend()
    set LEGEND_KAEL.PlayerColor = PLAYER_COLOR_RED
    set LEGEND_KAEL.UnitType = 'Hkal'
    set LEGEND_KAEL.StartingXp = 1800

    set LEGEND_LORTHEMAR = new Legend()
    set LEGEND_LORTHEMAR.UnitType = 'H02E'
    set LEGEND_LORTHEMAR.StartingXp = 2800

    set LEGEND_KILJAEDEN = new Legend()
    set LEGEND_KILJAEDEN.UnitType = 'U004'
    set LEGEND_KILJAEDEN.PermaDies = true
    set LEGEND_KILJAEDEN.StartingXp = 10800
    set LEGEND_KILJAEDEN.DeathMessage = "Kil'jaeden the Deceiver has been annihilated. The Burning Legion is now without its most formidable lieutenants."
  endfunction

endlibrary