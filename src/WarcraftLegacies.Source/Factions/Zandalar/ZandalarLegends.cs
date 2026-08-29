using MacroTools.Legends;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Factions.Warsong;

public sealed class ZandalarLegends
{
  public LegendaryHero Rastakhan { get; }
  public LegendaryHero Zul { get; }
  public LegendaryHero Haakar { get; }
  public LegendaryHero Gahzrilla { get; }
  public Capital Zulfarrak { get; }
  public Capital Zandalar { get; }

  public ZandalarLegends()
  {
    Zul = new LegendaryHero("Zul")
    {
      //UnitType = ,
      StartingXp = 1000
    };

    Gahzrilla = new LegendaryHero("Varok Gahzrilla")
    {
      //UnitType = ,
      StartingXp = 2800
    };

    Rastakhan = new LegendaryHero("Rastakhan")
    {
      //UnitType = ,
      PermaDies = true,
      DeathMessage =
        "Mannoroth the Corrupter has fallen.",
      StartingXp = 41800
    };

    Haakar = new LegendaryHero("Haakar")
    {
      //UnitType = ,
      StartingXp = 8800
    };

    Zulfarrak = new Capital
    {
      //Unit = AllPreplacedWidgets.Units.Get(),
      DeathMessage = "The fortress of the Stonemaul Clan has fallen.",
      Essential = true
    };

    Zandalar = new Capital
    {
      //Unit = AllPreplacedWidgets.Units.Get(),
      DeathMessage = "Orgrimmar has been demolished and with it die the hopes and dreams of a wartorn race seeking refuge in a new world.",
      Essential = true
    };
  }

  public void RegisterLegends()
  {
    //LegendaryHeroManager.Register();
    //LegendaryHeroManager.Register();
    //LegendaryHeroManager.Register();
    //LegendaryHeroManager.Register();
    // LegendaryHeroManager.Register();
    //LegendaryHeroManager.Register();
    CapitalManager.Register(Zulfarrak);
    CapitalManager.Register(Zandalar);
  }
}
