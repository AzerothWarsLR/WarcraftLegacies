using MacroTools.Legends;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Factions.Warsong;

public sealed class ZandalarLegends
{
  public LegendaryHero Rastakhan { get; }
  public LegendaryHero Zul { get; }
  public LegendaryHero Hakkar { get; }
  public LegendaryHero Gahzrilla { get; }
  public Capital Zandalar { get; }

  public ZandalarLegends()
  {
    Zul = new LegendaryHero("Zul")
    {
      UnitType = UNIT_MD39_ZANDALARI_PROPHET_ZANDALAR
    };

    Gahzrilla = new LegendaryHero("Gahzrilla")
    {
      UnitType = UNIT_MD40_DEMIGOD_ZANDALAR,
      StartingXp = 1800
    };

    Rastakhan = new LegendaryHero("Rastakhan")
    {
      UnitType = UNIT_MD41_KING_OF_THE_ZANDALARI_ZANDALAR,
      StartingXp = 3680
    };

    Hakkar = new LegendaryHero("Hakkar")
    {
      UnitType = UNIT_MD61_DEMIGOD_OF_THE_TROLLS_ZANDALAR,
      StartingXp = 8800
    };
    Zandalar = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O00V_DAZAR_ALOR_CREEP),
      DeathMessage = "The Capital of the Zandalari has fallen, At long last the troll empire has fallen.",
      Essential = true
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Zul);
    LegendaryHeroManager.Register(Gahzrilla);
    LegendaryHeroManager.Register(Rastakhan);
    LegendaryHeroManager.Register(Hakkar);
    CapitalManager.Register(Zandalar);
  }
}
