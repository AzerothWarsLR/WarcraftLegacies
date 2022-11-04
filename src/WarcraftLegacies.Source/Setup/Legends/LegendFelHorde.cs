using MacroTools;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendFelHorde
  {
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


    public static void Setup()
    {
      LegendMagtheridon = new Legend
      {
        UnitType = Constants.UNIT_NMAG_LORD_OF_OUTLAND_FEL_HORDE,
        DeathMessage = "Magtheridon’s eternal demon soul has been consumed, and his life permanently extinguished. The Lord of Outland has fallen."
      };
      Legend.Register(LegendMagtheridon);

      LegendRend = new Legend
      {
        UnitType = FourCC("Nbbc"),
        StartingXp = 2800
      };
      Legend.Register(LegendRend);

      LegendKargath = new Legend
      {
        UnitType = FourCC("N03D"),
        StartingXp = 2800
      };
      Legend.Register(LegendKargath);

      LegendZuluhed = new Legend
      {
        UnitType = FourCC("O00Y")
      };
      Legend.Register(LegendZuluhed);

      LegendNekrosh = new Legend
      {
        UnitType = FourCC("O01Q")
      };
      Legend.Register(LegendNekrosh);

      LegendChogall = new Legend
      {
        UnitType = FourCC("O01P")
      };
      Legend.Register(LegendChogall);

      LegendTeron = new Legend
      {
        UnitType = FourCC("U02D"),
        StartingXp = 5400,
        PlayerColor = PLAYER_COLOR_MAROON
      };
      Legend.Register(LegendTeron);

      LegendBlackrockspire = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o013")),
        DeathMessage = "Blackrock Spire has been razed."
      };
      Legend.Register(LegendBlackrockspire);

      LegendBlacktemple = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o00F")),
        Capturable = true
      };
      Legend.Register(LegendBlacktemple);

      LegendHellfirecitadel = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o008"))
      };
      Legend.Register(LegendHellfirecitadel);
    }
  }
}