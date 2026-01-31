using MacroTools.Legends;
using MacroTools.PreplacedWidgets;

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


  public LegendFelHorde()
  {
    Magtheridon = new LegendaryHero("Magtheridon")
    {
      UnitType = UNIT_NMAG_LORD_OF_OUTLAND_FEL,
      StartingXp = 1800,
      DeathMessage = "Magtheridon’s eternal demon soul has been consumed, and his life permanently extinguished. The Lord of Outland has fallen."
    };

    Rend = new LegendaryHero("Rend Blackhand")
    {
      UnitType = UNIT_NBBC_WARCHIEF_OF_THE_BLACKROCK_CLAN_FEL,
      StartingXp = 2800
    };

    Kargath = new LegendaryHero("Kargath Bladefist")
    {
      UnitType = UNIT_N03D_WARCHIEF_OF_THE_FEL_HORDE_FEL,
    };

    Teron = new LegendaryHero("Teron Gorefiend")
    {
      UnitType = UNIT_U02D_DEATH_KNIGHT_LORD_FEL_HORDE,
      StartingXp = 5400,
      PlayerColor = playercolor.Maroon
    };

    BlackrockSpire = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O013_BLACKROCK_SPIRE_FEL),
      DeathMessage = "Blackrock Spire has been razed."
    };

    KilsorrowFortress = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O017_KIL_SORROW_FORTRESS),
      DeathMessage = "Kilsorrow Fortress has been razed.",
      Essential = true
    };

    BlackTemple = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O00F_BLACK_TEMPLE_ILLIDARI_FEL_HORDE),
      Essential = true
    };
    BlackTemple.AddProtector(AllPreplacedWidgets.Units.GetClosest(UNIT_NPGR_POWER_GENERATOR_FEL, 5511.9f, -29688.2f));
    BlackTemple.AddProtector(AllPreplacedWidgets.Units.GetClosest(UNIT_NPGR_POWER_GENERATOR_FEL, 5513.1f, -30467.4f));

    HellfireCitadel = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O008_HELLFIRE_CITADEL_FEL),
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
