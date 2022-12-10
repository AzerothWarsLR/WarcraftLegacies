using MacroTools;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendFelHorde
  {
    public static LegendaryHero LegendMagtheridon { get; private set; }
    public static LegendaryHero LegendZuluhed { get; private set; }
    public static LegendaryHero LegendChogall { get; private set; }
    public static LegendaryHero LegendNekrosh { get; private set; }
    public static LegendaryHero LegendRend { get; private set; }
    public static LegendaryHero LegendTeron { get; private set; }
    public static LegendaryHero LegendKargath { get; private set; }
    public static Capital LegendBlackrockspire { get; private set; }
    public static Capital LegendBlacktemple { get; private set; }
    public static Capital LegendHellfirecitadel { get; private set; }


    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendMagtheridon = new LegendaryHero
      {
        UnitType = Constants.UNIT_NMAG_LORD_OF_OUTLAND_FEL_HORDE,
        DeathMessage = "Magtheridon’s eternal demon soul has been consumed, and his life permanently extinguished. The Lord of Outland has fallen."
      };
      Legend.Register(LegendMagtheridon);

      LegendRend = new LegendaryHero
      {
        UnitType = FourCC("Nbbc"),
        StartingXp = 2800
      };
      Legend.Register(LegendRend);

      LegendKargath = new LegendaryHero
      {
        UnitType = FourCC("N03D"),
        StartingXp = 2800
      };
      Legend.Register(LegendKargath);

      LegendZuluhed = new LegendaryHero
      {
        UnitType = FourCC("O00Y")
      };
      Legend.Register(LegendZuluhed);

      LegendNekrosh = new LegendaryHero
      {
        UnitType = FourCC("O01Q")
      };
      Legend.Register(LegendNekrosh);

      LegendChogall = new LegendaryHero
      {
        UnitType = FourCC("O01P")
      };
      Legend.Register(LegendChogall);

      LegendTeron = new LegendaryHero
      {
        UnitType = FourCC("U02D"),
        StartingXp = 5400,
        PlayerColor = PLAYER_COLOR_MAROON
      };
      Legend.Register(LegendTeron);

      LegendBlackrockspire = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o013")),
        DeathMessage = "Blackrock Spire has been razed."
      };
      Legend.Register(LegendBlackrockspire);

      LegendBlacktemple = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00F")),
        Capturable = true
      };
      Legend.Register(LegendBlacktemple);

      LegendHellfirecitadel = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o008"))
      };
      Legend.Register(LegendHellfirecitadel);
    }
  }
}