using MacroTools.Legends;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Factions.TaurenTribes;

/// <summary>
/// Responsible for setting up all Tauren Tribes <see cref="Legend"/>s.
/// </summary>
public sealed class TaurenTribesLegends
{
  public LegendaryHero CairneBloodhoof { get; }
  public LegendaryHero Rexxar { get; }
  public LegendaryHero Chen { get; }
  public LegendaryHero Magatha { get; }
  public Capital ThunderBluff { get; }
  public Capital StonemaulKeep { get; }

  public TaurenTribesLegends()
  {
    CairneBloodhoof = new LegendaryHero("Cairne Bloodhoof")
    {
      UnitType = UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_TAUREN_TRIBES
    };

    Rexxar = new LegendaryHero("Rexxar")
    {
      UnitType = UNIT_OREX_BEASTMASTER_TAUREN_TRIBES
    };

    Chen = new LegendaryHero("Chen Stormstout")
    {
      UnitType = UNIT_TP80_BREWMASTER_TAUREN_TRIBES
    };

    Magatha = new LegendaryHero("Magatha Grimtotem")
    {
      UnitType = UNIT_TP83_GRIMTOTEM_MATRIARCH_TAUREN_TRIBES
    };

    ThunderBluff = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O00J_THUNDER_BLUFF_FROSTWOLF_OTHER),
      DeathMessage =
        "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home.",
      Essential = true
    };

    StonemaulKeep = new Capital
    {
      Unit = AllPreplacedWidgets.Units.Get(UNIT_O004_STONEMAUL_KEEP),
      DeathMessage = "The fortress of the Stonemaul Clan has fallen.",
      Essential = true
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(CairneBloodhoof);
    LegendaryHeroManager.Register(Rexxar);
    LegendaryHeroManager.Register(Chen);
    LegendaryHeroManager.Register(Magatha);
    CapitalManager.Register(ThunderBluff);
    CapitalManager.Register(StonemaulKeep);
  }
}
