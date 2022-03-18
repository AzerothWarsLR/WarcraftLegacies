using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public static class LegendNaga{

  
    public static Legend LEGEND_ILLIDAN
    public static Legend LEGEND_VASHJ
    public static Legend LEGEND_NAJENTUS
    public static Legend LEGEND_AZSHARA
    public static Legend LEGEND_NZOTH
    public static Legend LEGEND_ALTRUIS
    public static Legend LEGEND_AKAMA

    public static Legend LEGEND_NAZJATAR
    public static Legend LEGEND_VAULT
  

    public static void Setup( ){
      LEGEND_ILLIDAN = new Legend();
      LEGEND_ILLIDAN.Unit = gg_unit_Eill_0748;
      LEGEND_ILLIDAN.PlayerColor = PLAYER_COLOR_PURPLE;

      LEGEND_VASHJ = new Legend();
      LEGEND_VASHJ.UnitType = FourCC(Hvsh);
      LEGEND_VASHJ.StartingXp = 2800;

      LEGEND_AZSHARA = new Legend();
      LEGEND_AZSHARA.UnitType = FourCC(H08U);

      LEGEND_NAJENTUS = new Legend();
      LEGEND_NAJENTUS.UnitType = FourCC(U00S);
      LEGEND_NAJENTUS.StartingXp = 2800;

      LEGEND_ALTRUIS = new Legend();
      LEGEND_ALTRUIS.UnitType = FourCC(E015);
      LEGEND_ALTRUIS.StartingXp = 4000;

      LEGEND_AKAMA = new Legend();
      LEGEND_AKAMA.UnitType = FourCC(Naka);
      LEGEND_AKAMA.StartingXp = 4000;

      LEGEND_NZOTH = new Legend();
      LEGEND_NZOTH.Unit = gg_unit_U01Z_1237;
      LEGEND_NZOTH.DeathMessage = "NFourCC(zoth the Corruptor lay in wait for millenia before enacting final ploy. In the end, it was all for naught; N)zoth lies dead, && he will never witness the true floatization of his Black Empire.";
      LEGEND_NZOTH.PermaDies = true;

      LEGEND_NAZJATAR = new Legend();
      LEGEND_NAZJATAR.Unit = gg_unit_n045_3377;
      LEGEND_NAZJATAR.DeathMessage = "The Eternal Palace, the royal seat of Queen Azshara && the Nazjatar Empire, has been destroyed.";
      LEGEND_NAZJATAR.IsCapital = true;
      LEGEND_NAZJATAR.Hivemind = true;

      LEGEND_VAULT = new Legend();
      LEGEND_VAULT.Unit = gg_unit_n05A_2845;
      LEGEND_VAULT.DeathMessage = "The Aetheneum vault has been destroyed, && with it, ages of knowledge is lost.";
      LEGEND_VAULT.IsCapital = true;
    }

  }
}
