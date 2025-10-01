using MacroTools.LegendSystem;
using MacroTools.Systems;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.Legends;

public sealed class LegendFelHorde
{
  public LegendaryHero Magtheridon { get; }
  public LegendaryHero Rend { get; }
  public LegendaryHero Teron { get; }
  public LegendaryHero Kargath { get; }

  public Capital BlackrockSpire { get; }
  public Capital BlackTemple { get; }
  public Capital HellfireCitadel { get; }
  public Capital KilsorrowFortress { get; }


  public LegendFelHorde(PreplacedUnitSystem preplacedUnitSystem)
  {
    Magtheridon = new LegendaryHero("Magtheridon")
    {
      UnitType = UNIT_NMAG_LORD_OF_OUTLAND_FEL_HORDE,
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

    Teron = new LegendaryHero("Teron Gorefiend")
    {
      UnitType = FourCC("U02D"),
      StartingXp = 5400,
      PlayerColor = playercolor.Maroon
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
    BlackTemple.AddProtector(preplacedUnitSystem.GetUnit(UNIT_NPGR_POWER_GENERATOR_TEAL, new Point(5511.9f, -29688.2f)));
    BlackTemple.AddProtector(preplacedUnitSystem.GetUnit(UNIT_NPGR_POWER_GENERATOR_TEAL, new Point(5513.1f, -30467.4f)));

    HellfireCitadel = new Capital
    {
      Unit = preplacedUnitSystem.GetUnit(FourCC("o008")),
      Essential = true
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Magtheridon);
    LegendaryHeroManager.Register(Rend);
    LegendaryHeroManager.Register(Teron);
    LegendaryHeroManager.Register(Kargath);
    CapitalManager.Register(BlackrockSpire);
    CapitalManager.Register(BlackTemple);
    CapitalManager.Register(HellfireCitadel);
    CapitalManager.Register(KilsorrowFortress);
  }
}
