using AzerothWarsCSharp.Source.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendFelHorde{

  
    public static Legend LEGEND_MAGTHERIDON { get; private set; }
    public static Legend LEGEND_ZULUHED { get; private set; }
    public static Legend LEGEND_CHOGALL { get; private set; }
    public static Legend LEGEND_NEKROSH { get; private set; }
    public static Legend LEGEND_REND { get; private set; }
    public static Legend LEGEND_TERON { get; private set; }
    public static Legend LEGEND_KARGATH { get; private set; }

    public static Legend LEGEND_BLACKROCKSPIRE { get; private set; }
    public static Legend LEGEND_BLACKTEMPLE { get; private set; }
    public static Legend LEGEND_HELLFIRECITADEL { get; private set; }
  

    public static void Setup( ){
      LEGEND_MAGTHERIDON = new Legend();
      LEGEND_MAGTHERIDON.UnitType = FourCC(Nmag);
      LEGEND_MAGTHERIDON.AddUnitDependency(gg_unit_o00F_0659);
      LEGEND_MAGTHERIDON.DeathMessage = "Magtheridon’s eternal demon soul has been consumed, && his life permanently extinguished. The Lord of Outland has fallen.";
      LEGEND_MAGTHERIDON.Essential = true;

      LEGEND_REND = new Legend();
      LEGEND_REND.UnitType = FourCC(Nbbc);
      LEGEND_REND.StartingXp = 2800;

      LEGEND_KARGATH = new Legend();
      LEGEND_KARGATH.UnitType = FourCC(N03D);
      LEGEND_KARGATH.StartingXp = 2800;

      LEGEND_ZULUHED = new Legend();
      LEGEND_ZULUHED.UnitType = FourCC(O00Y);

      LEGEND_NEKROSH = new Legend();
      LEGEND_NEKROSH.UnitType = FourCC(O01Q);

      LEGEND_CHOGALL = new Legend();
      LEGEND_CHOGALL.UnitType = FourCC(O01P);

      LEGEND_TERON = new Legend();
      LEGEND_TERON.UnitType = FourCC(U02D);
      LEGEND_TERON.StartingXp = 5400;
      LEGEND_TERON.PlayerColor = PLAYER_COLOR_MAROON;

      LEGEND_BLACKROCKSPIRE = new Legend();
      LEGEND_BLACKROCKSPIRE.Unit = gg_unit_o013_2507;
      LEGEND_BLACKROCKSPIRE.DeathMessage = "Blackrock Spire has been razed.";

      LEGEND_BLACKTEMPLE = new Legend();
      LEGEND_BLACKTEMPLE.Unit = gg_unit_o00F_0659;
      LEGEND_BLACKTEMPLE.IsCapital = true;
      LEGEND_BLACKTEMPLE.Capturable = true;

      LEGEND_HELLFIRECITADEL = new Legend();
      LEGEND_HELLFIRECITADEL.Unit = gg_unit_o008_0168;
      LEGEND_HELLFIRECITADEL.IsCapital = true;
    }

  }
}
