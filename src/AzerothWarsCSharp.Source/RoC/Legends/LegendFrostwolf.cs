using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public class LegendFrostwolf{

  
    Legend LEGEND_CAIRNE
    Legend LEGEND_THRALL
    Legend LEGEND_REXXAR

    Legend LEGEND_THUNDERBLUFF
    Legend LEGEND_DARKSPEARHOLD
    Legend LEGEND_ORGRIMMAR
  

    private static void OnInit( ){
      LEGEND_CAIRNE = Legend.create();
      LEGEND_CAIRNE.UnitType = FourCC(Ocbh);
      LEGEND_CAIRNE.DeathMessage = "CairneFourCC(s spirit has passed on from this world. The Tauren have already begun to revere their fallen ancestor.";
      LEGEND_CAIRNE.StartingXP = 1000;

      LEGEND_THRALL = Legend.create();
      LEGEND_THRALL.UnitType = FourCC(Othr);
      LEGEND_THRALL.Essential = true;

      LEGEND_THUNDERBLUFF = Legend.create();
      LEGEND_THUNDERBLUFF.Unit = gg_unit_o00J_1495;
      LEGEND_THUNDERBLUFF.DeathMessage = "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home.";
      LEGEND_THUNDERBLUFF.IsCapital = true;

      LEGEND_DARKSPEARHOLD = Legend.create();
      LEGEND_DARKSPEARHOLD.Unit = gg_unit_o02D_0254;
      LEGEND_DARKSPEARHOLD.IsCapital = true;

      LEGEND_REXXAR = Legend.create();
      LEGEND_REXXAR.UnitType = FourCC(Orex);
      LEGEND_REXXAR.StartingXP = 1800;

      LEGEND_ORGRIMMAR = Legend.create();
      LEGEND_ORGRIMMAR.DeathMessage = "Orgrimmar has been demolished. With it dies the hopes && dreams of a wartorn race seeking refuge in a new world.";
    }

  }
}
