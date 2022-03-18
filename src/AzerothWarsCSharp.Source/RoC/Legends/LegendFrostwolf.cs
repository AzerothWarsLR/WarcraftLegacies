using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public static class LegendFrostwolf{

  
    public static Legend LEGEND_CAIRNE
    public static Legend LEGEND_THRALL
    public static Legend LEGEND_REXXAR

    public static Legend LEGEND_THUNDERBLUFF
    public static Legend LEGEND_DARKSPEARHOLD
    public static Legend LEGEND_ORGRIMMAR
  

    public static void Setup( ){
      LEGEND_CAIRNE = new Legend();
      LEGEND_CAIRNE.UnitType = FourCC(Ocbh);
      LEGEND_CAIRNE.DeathMessage = "CairneFourCC(s spirit has passed on from this world. The Tauren have already begun to revere their fallen ancestor.";
      LEGEND_CAIRNE.StartingXp = 1000;

      LEGEND_THRALL = new Legend();
      LEGEND_THRALL.UnitType = FourCC(Othr);
      LEGEND_THRALL.Essential = true;

      LEGEND_THUNDERBLUFF = new Legend();
      LEGEND_THUNDERBLUFF.Unit = gg_unit_o00J_1495;
      LEGEND_THUNDERBLUFF.DeathMessage = "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home.";
      LEGEND_THUNDERBLUFF.IsCapital = true;

      LEGEND_DARKSPEARHOLD = new Legend();
      LEGEND_DARKSPEARHOLD.Unit = gg_unit_o02D_0254;
      LEGEND_DARKSPEARHOLD.IsCapital = true;

      LEGEND_REXXAR = new Legend();
      LEGEND_REXXAR.UnitType = FourCC(Orex);
      LEGEND_REXXAR.StartingXp = 1800;

      LEGEND_ORGRIMMAR = new Legend();
      LEGEND_ORGRIMMAR.DeathMessage = "Orgrimmar has been demolished. With it dies the hopes && dreams of a wartorn race seeking refuge in a new world.";
    }

  }
}
