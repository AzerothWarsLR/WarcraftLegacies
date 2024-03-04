using MacroTools;
using MacroTools.LegendSystem;
using WCSharp.Shared.Data;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendFelHorde
  {
    public LegendaryHero Magtheridon { get; }
    public LegendaryHero Zuluhed { get; }
    public LegendaryHero Chogall { get; }
    public LegendaryHero Nekrosh { get; }
    public LegendaryHero Rend { get; }
    public LegendaryHero Teron { get; }
    public LegendaryHero Kargath { get; }
    public LegendaryHero Gruul { get; }

    public Capital BlackrockSpire { get; }
    public Capital BlackTemple { get; }
    public Capital HellfireCitadel { get; }
    public Capital KilsorrowFortress { get; }


    public LegendFelHorde(PreplacedUnitSystem preplacedUnitSystem)
    {
      Magtheridon = new LegendaryHero("Magtheridon")
      {
        UnitType = Constants.UNIT_NMAG_LORD_OF_OUTLAND_FEL_HORDE,
        StartingXp = 1800,
        DeathMessage = "Magtheridon’s eternal demon soul has been consumed, and his life permanently extinguished. The Lord of Outland has fallen."
      };

      Rend = new LegendaryHero("Rend Blackhand")
      {
        UnitType = FourCC("Nbbc"),
        StartingXp = 2800
      };

      Kargath = new LegendaryHero("Kargath Bladefist")
      {
        UnitType = FourCC("N03D"),
      };

      Zuluhed = new LegendaryHero("Zuluhed the Whacked")
      {
        UnitType = FourCC("O00Y")
      };

      Nekrosh = new LegendaryHero("Nek'rosh Sullcrusher")
      {
        UnitType = FourCC("O01Q")
      };

      Chogall = new LegendaryHero("Cho'gall")
      {
        UnitType = FourCC("O01P")
      };

      Teron = new LegendaryHero("Teron Gorefiend")
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

      BlackrockSpire = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o013")),
        DeathMessage = "Blackrock Spire has been razed."
      };

      KilsorrowFortress = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o017")),
        DeathMessage = "Kilsorrow Fortress has been razed.",
        Essential = true
      };

      BlackTemple = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o00F")),
        Essential = true
      };
      BlackTemple.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_NPGR_POWER_GENERATOR_TEAL, new Point(5511.9f, -29688.2f)));
      BlackTemple.AddProtector(preplacedUnitSystem.GetUnit(Constants.UNIT_NPGR_POWER_GENERATOR_TEAL, new Point(5513.1f, -30467.4f)));

      HellfireCitadel = new Capital
      {
        Unit = preplacedUnitSystem.GetUnit(FourCC("o008")),
        Essential = true
      };
    }
    
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Magtheridon);
      LegendaryHeroManager.Register(Zuluhed);
      LegendaryHeroManager.Register(Chogall);
      LegendaryHeroManager.Register(Nekrosh);
      LegendaryHeroManager.Register(Rend);
      LegendaryHeroManager.Register(Teron);
      LegendaryHeroManager.Register(Kargath);
      LegendaryHeroManager.Register(Gruul);
      CapitalManager.Register(BlackrockSpire);
      CapitalManager.Register(BlackTemple);
      CapitalManager.Register(HellfireCitadel);
      CapitalManager.Register(KilsorrowFortress);
    }
  }
}