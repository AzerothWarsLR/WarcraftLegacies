library LegendGilneas initializer OnInit requires Legend

  globals
    public static Legend LEGEND_TESS
    public static Legend LEGEND_GENN
    public static Legend LEGEND_DARIUS
    public static Legend LEGEND_GOLDRINN
    
    public static Legend LEGEND_LIGHTDAWN
    public static Legend LEGEND_GILNEASCASTLE

  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_TESS = new Legend()
    set LEGEND_TESS.Unit = gg_unit_Ewar_0424

    set LEGEND_GOLDRINN = new Legend()
    set LEGEND_GOLDRINN.UnitType = 'E01E'
    set LEGEND_GOLDRINN.StartingXp = 8800

    set LEGEND_GENN = new Legend()
    set LEGEND_GENN.Unit = gg_unit_Hhkl_1500

    set LEGEND_DARIUS = new Legend()
    set LEGEND_DARIUS.Unit = gg_unit_Hpb2_3787

    set LEGEND_LIGHTDAWN = new Legend()
    set LEGEND_LIGHTDAWN.Unit = gg_unit_h057_3921
    set LEGEND_LIGHTDAWN.DeathMessage = "The Light's Dawn Capital has been destroyed."
    set LEGEND_LIGHTDAWN.IsCapital = true

    set LEGEND_GILNEASCASTLE = new Legend()
    set LEGEND_GILNEASCASTLE.Unit = gg_unit_h04I_0101
    set LEGEND_GILNEASCASTLE.DeathMessage = "The Gilneas castle has fallen"
    set LEGEND_GILNEASCASTLE.IsCapital = true
  endfunction

endlibrary