using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.RoC.Legends
{
  public class LegendFelHorde{

  
    Legend LEGEND_MAGTHERIDON
    Legend LEGEND_ZULUHED
    Legend LEGEND_CHOGALL
    Legend LEGEND_NEKROSH
    Legend LEGEND_REND
    Legend LEGEND_TERON
    Legend LEGEND_KARGATH

    Legend LEGEND_BLACKROCKSPIRE
    Legend LEGEND_BLACKTEMPLE
    Legend LEGEND_HELLFIRECITADEL
  

    private static void OnInit( ){
      LEGEND_MAGTHERIDON = Legend.create();
      LEGEND_MAGTHERIDON.UnitType = FourCC(Nmag);
      LEGEND_MAGTHERIDON.AddUnitDependency(gg_unit_o00F_0659);
      LEGEND_MAGTHERIDON.DeathMessage = "Magtheridon’s eternal demon soul has been consumed, && his life permanently extinguished. The Lord of Outland has fallen.";
      LEGEND_MAGTHERIDON.Essential = true;

      LEGEND_REND = Legend.create();
      LEGEND_REND.UnitType = FourCC(Nbbc);
      LEGEND_REND.StartingXP = 2800;

      LEGEND_KARGATH = Legend.create();
      LEGEND_KARGATH.UnitType = FourCC(N03D);
      LEGEND_KARGATH.StartingXP = 2800;

      LEGEND_ZULUHED = Legend.create();
      LEGEND_ZULUHED.UnitType = FourCC(O00Y);

      LEGEND_NEKROSH = Legend.create();
      LEGEND_NEKROSH.UnitType = FourCC(O01Q);

      LEGEND_CHOGALL = Legend.create();
      LEGEND_CHOGALL.UnitType = FourCC(O01P);

      LEGEND_TERON = Legend.create();
      LEGEND_TERON.UnitType = FourCC(U02D);
      LEGEND_TERON.StartingXP = 5400;
      LEGEND_TERON.PlayerColor = PLAYER_COLOR_MAROON;

      LEGEND_BLACKROCKSPIRE = Legend.create();
      LEGEND_BLACKROCKSPIRE.Unit = gg_unit_o013_2507;
      LEGEND_BLACKROCKSPIRE.DeathMessage = "Blackrock Spire has been razed.";

      LEGEND_BLACKTEMPLE = Legend.create();
      LEGEND_BLACKTEMPLE.Unit = gg_unit_o00F_0659;
      LEGEND_BLACKTEMPLE.IsCapital = true;
      LEGEND_BLACKTEMPLE.Capturable = true;

      LEGEND_HELLFIRECITADEL = Legend.create();
      LEGEND_HELLFIRECITADEL.Unit = gg_unit_o008_0168;
      LEGEND_HELLFIRECITADEL.IsCapital = true;
    }

  }
}
