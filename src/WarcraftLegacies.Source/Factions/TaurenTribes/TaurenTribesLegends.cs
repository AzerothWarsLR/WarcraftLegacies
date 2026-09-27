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
  public LegendaryHero Rokhan { get; }
  public LegendaryHero Magatha { get; }
  public Capital ThunderBluff { get; }
  public Capital StonemaulKeep { get; }

  public TaurenTribesLegends()
  {
    CairneBloodhoof = new LegendaryHero("Cairne Bloodhoof")
    {
      UnitType = UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_TAUREN_TRIBES,
      StartingArtifacts = new()
      {
        new(item.Create(ITEM_I00L_BLOODHOOF_TOTEM, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      }
    };

    Rexxar = new LegendaryHero("Rexxar")
    {
      UnitType = UNIT_OREX_BEASTMASTER_TAUREN_TRIBES
    };

    Rokhan = new LegendaryHero("Rokhan")
    {
      UnitType = UNIT_MD25_DARKSPEAR_CHAMPION_TAUREN_TRIBES,
      StartingXp = 2800
    };

    Magatha = new LegendaryHero("Magatha Grimtotem")
    {
      UnitType = UNIT_TP83_GRIMTOTEM_MATRIARCH_TAUREN_TRIBES,
      StartingXp = 8800
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
    LegendaryHeroManager.Register(Rokhan);
    LegendaryHeroManager.Register(Magatha);
    CapitalManager.Register(ThunderBluff);
    CapitalManager.Register(StonemaulKeep);
  }
}
