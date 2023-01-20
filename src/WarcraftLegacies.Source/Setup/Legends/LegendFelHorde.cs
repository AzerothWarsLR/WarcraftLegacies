using MacroTools;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendFelHorde : IRegistersLegends
  {
    public LegendaryHero LegendMagtheridon { get; }
    public LegendaryHero LegendZuluhed { get; }
    public LegendaryHero LegendChogall { get; }
    public LegendaryHero LegendNekrosh { get; }
    public LegendaryHero LegendRend { get; }
    public LegendaryHero LegendTeron { get; }
    public LegendaryHero LegendKargath { get; }
    public LegendaryHero Gruul { get; }

    public Capital LegendBlackrockspire { get; }
    public Capital LegendBlacktemple { get; }
    public Capital LegendHellfirecitadel { get; }
    public Capital LegendKilsorrowFortress { get; }


    public LegendFelHorde(PreplacedUnitSystem preplacedUnitSystem)
    {
      LegendMagtheridon = new LegendaryHero("Magtheridon")
      {
        UnitType = Constants.UNIT_NMAG_LORD_OF_OUTLAND_FEL_HORDE,
        DeathMessage = "Magtheridon’s eternal demon soul has been consumed, and his life permanently extinguished. The Lord of Outland has fallen."
      };

      LegendRend = new LegendaryHero("Rend Blackhand")
      {
        UnitType = FourCC("Nbbc"),
        StartingXp = 2800
      };

      LegendKargath = new LegendaryHero("Kargath Bladefist")
      {
        UnitType = FourCC("N03D"),
      };

      LegendZuluhed = new LegendaryHero("Zuluhed the Whacked")
      {
        UnitType = FourCC("O00Y")
      };

      LegendNekrosh = new LegendaryHero("Nek'rosh Sullcrusher")
      {
        UnitType = FourCC("O01Q")
      };

      LegendChogall = new LegendaryHero("Cho'gall")
      {
        UnitType = FourCC("O01P")
      };

      LegendTeron = new LegendaryHero("Teron Gorefiend")
      {
        UnitType = FourCC("U02D"),
        StartingXp = 5400,
        PlayerColor = PLAYER_COLOR_MAROON
      };
      
      Gruul = new LegendaryHero("Gruul")
      {
        UnitType = Constants.UNIT_E01G_GRONN_OVERLORD_FEL,
        StartingXp = 1400,
      };

      LegendBlackrockspire = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o013")),
        DeathMessage = "Blackrock Spire has been razed."
      };

      LegendKilsorrowFortress = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o017")),
        DeathMessage = "Kilsorrow Fortress has been razed."
      };

      LegendBlacktemple = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00F")),
      };
      LegendBlacktemple.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_NPGR_POWER_GENERATOR_TEAL, new Point(5511.9f, -29688.2f)));
      LegendBlacktemple.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_NPGR_POWER_GENERATOR_TEAL, new Point(5513.1f, -30467.4f)));

      LegendHellfirecitadel = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o008"))
      };
    }

    /// <inheritdoc />
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(LegendMagtheridon);
      LegendaryHeroManager.Register(LegendZuluhed);
      LegendaryHeroManager.Register(LegendChogall);
      LegendaryHeroManager.Register(LegendNekrosh);
      LegendaryHeroManager.Register(LegendRend);
      LegendaryHeroManager.Register(LegendTeron);
      LegendaryHeroManager.Register(LegendKargath);
      LegendaryHeroManager.Register(Gruul);
      CapitalManager.Register(LegendBlackrockspire);
      CapitalManager.Register(LegendBlacktemple);
      CapitalManager.Register(LegendHellfirecitadel);
      CapitalManager.Register(LegendKilsorrowFortress);
    }
  }
}