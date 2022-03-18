library LegendFrostwolf initializer OnInit requires Legend

  globals
    public static Legend LEGEND_CAIRNE
    public static Legend LEGEND_GAZLOWE
    public static Legend LEGEND_THRALL
    public static Legend LEGEND_REXXAR

    public static Legend LEGEND_THUNDERBLUFF
    public static Legend LEGEND_DARKSPEARHOLD
    public static Legend LEGEND_ORGRIMMAR
  endglobals

  private function OnInit takes nothing returns nothing
    set LEGEND_CAIRNE = new Legend()
    set LEGEND_CAIRNE.UnitType = 'Ocbh'
    set LEGEND_CAIRNE.DeathMessage = "Cairne's spirit has passed on from this world. The Tauren have already begun to revere their fallen ancestor."
    set LEGEND_CAIRNE.StartingXp = 1000

    set LEGEND_THRALL = new Legend()
    set LEGEND_THRALL.UnitType = 'Othr'
    set LEGEND_THRALL.Essential = true
  
    set LEGEND_THUNDERBLUFF = new Legend()
    set LEGEND_THUNDERBLUFF.Unit = gg_unit_o00J_1495
    set LEGEND_THUNDERBLUFF.DeathMessage = "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home."
    set LEGEND_THUNDERBLUFF.IsCapital = true

    set LEGEND_DARKSPEARHOLD = new Legend()
    set LEGEND_DARKSPEARHOLD.Unit = gg_unit_o02D_0254
    set LEGEND_DARKSPEARHOLD.IsCapital = true

    set LEGEND_REXXAR = new Legend()
    set LEGEND_REXXAR.UnitType = 'Orex'
    set LEGEND_REXXAR.StartingXp = 1800

    set LEGEND_ORGRIMMAR = new Legend()
    set LEGEND_ORGRIMMAR.DeathMessage = "Orgrimmar has been demolished. With it dies the hopes and dreams of a wartorn race seeking refuge in a new world."
  endfunction

endlibrary