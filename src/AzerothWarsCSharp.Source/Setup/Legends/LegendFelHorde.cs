using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendFelHorde{

  
    public static Legend LegendMagtheridon { get; private set; }
    public static Legend LegendZuluhed { get; private set; }
    public static Legend LegendChogall { get; private set; }
    public static Legend LegendNekrosh { get; private set; }
    public static Legend LegendRend { get; private set; }
    public static Legend LegendTeron { get; private set; }
    public static Legend LegendKargath { get; private set; }

    public static Legend LegendBlackrockspire { get; private set; }
    public static Legend LegendBlacktemple { get; private set; }
    public static Legend LegendHellfirecitadel { get; private set; }
  

    public static void Setup( ){
      LegendMagtheridon = new Legend();
      LegendMagtheridon.UnitType = FourCC("Nmag");
      LegendMagtheridon.AddUnitDependency(PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00F")));
      LegendMagtheridon.DeathMessage = "Magtheridon’s eternal demon soul has been consumed, && his life permanently extinguished. The Lord of Outland has fallen.";
      LegendMagtheridon.Essential = true;

      LegendRend = new Legend();
      LegendRend.UnitType = FourCC("Nbbc");
      LegendRend.StartingXp = 2800;

      LegendKargath = new Legend();
      LegendKargath.UnitType = FourCC("N03D");
      LegendKargath.StartingXp = 2800;

      LegendZuluhed = new Legend();
      LegendZuluhed.UnitType = FourCC("O00Y");

      LegendNekrosh = new Legend();
      LegendNekrosh.UnitType = FourCC("O01Q");

      LegendChogall = new Legend();
      LegendChogall.UnitType = FourCC("O01P");

      LegendTeron = new Legend();
      LegendTeron.UnitType = FourCC("U02D");
      LegendTeron.StartingXp = 5400;
      LegendTeron.PlayerColor = PLAYER_COLOR_MAROON;

      LegendBlackrockspire = new Legend();
      LegendBlackrockspire.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o013"));
      LegendBlackrockspire.DeathMessage = "Blackrock Spire has been razed.";

      LegendBlacktemple = new Legend();
      LegendBlacktemple.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00F"));
      LegendBlacktemple.IsCapital = true;
      LegendBlacktemple.Capturable = true;

      LegendHellfirecitadel = new Legend();
      LegendHellfirecitadel.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o008"));
      LegendHellfirecitadel.IsCapital = true;
    }

  }
}
