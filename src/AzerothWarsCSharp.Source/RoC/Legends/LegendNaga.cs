using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public class LegendNaga{

  
    Legend LEGEND_ILLIDAN
    Legend LEGEND_VASHJ
    Legend LEGEND_NAJENTUS
    Legend LEGEND_AZSHARA
    Legend LEGEND_NZOTH
    Legend LEGEND_ALTRUIS
    Legend LEGEND_AKAMA

    Legend LEGEND_NAZJATAR
    Legend LEGEND_VAULT
  

    private static void OnInit( ){
      LEGEND_ILLIDAN = Legend.create();
      LEGEND_ILLIDAN.Unit = gg_unit_Eill_0748;
      LEGEND_ILLIDAN.PlayerColor = PLAYER_COLOR_PURPLE;

      LEGEND_VASHJ = Legend.create();
      LEGEND_VASHJ.UnitType = FourCC(Hvsh);
      LEGEND_VASHJ.StartingXP = 2800;

      LEGEND_AZSHARA = Legend.create();
      LEGEND_AZSHARA.UnitType = FourCC(H08U);

      LEGEND_NAJENTUS = Legend.create();
      LEGEND_NAJENTUS.UnitType = FourCC(U00S);
      LEGEND_NAJENTUS.StartingXP = 2800;

      LEGEND_ALTRUIS = Legend.create();
      LEGEND_ALTRUIS.UnitType = FourCC(E015);
      LEGEND_ALTRUIS.StartingXP = 4000;

      LEGEND_AKAMA = Legend.create();
      LEGEND_AKAMA.UnitType = FourCC(Naka);
      LEGEND_AKAMA.StartingXP = 4000;

      LEGEND_NZOTH = Legend.create();
      LEGEND_NZOTH.Unit = gg_unit_U01Z_1237;
      LEGEND_NZOTH.DeathMessage = "NFourCC(zoth the Corruptor lay in wait for millenia before enacting final ploy. In the end, it was all for naught; N)zoth lies dead, && he will never witness the true floatization of his Black Empire.";
      LEGEND_NZOTH.PermaDies = true;

      LEGEND_NAZJATAR = Legend.create();
      LEGEND_NAZJATAR.Unit = gg_unit_n045_3377;
      LEGEND_NAZJATAR.DeathMessage = "The Eternal Palace, the royal seat of Queen Azshara && the Nazjatar Empire, has been destroyed.";
      LEGEND_NAZJATAR.IsCapital = true;
      LEGEND_NAZJATAR.Hivemind = true;

      LEGEND_VAULT = Legend.create();
      LEGEND_VAULT.Unit = gg_unit_n05A_2845;
      LEGEND_VAULT.DeathMessage = "The Aetheneum vault has been destroyed, && with it, ages of knowledge is lost.";
      LEGEND_VAULT.IsCapital = true;
    }

  }
}
