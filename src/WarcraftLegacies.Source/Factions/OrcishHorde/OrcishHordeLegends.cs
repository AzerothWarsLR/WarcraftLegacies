using System.Collections.Generic;
using MacroTools.Artifacts;
using MacroTools.Legends;
using MacroTools.PreplacedWidgets;

namespace WarcraftLegacies.Source.Factions.OrcishHorde;

/// <summary>
/// Responsible for setting up all Orcish Horde <see cref="Legend"/>s.
/// </summary>
public sealed class OrcishHordeLegends
{
  public LegendaryHero Thrall { get; }
  public LegendaryHero Voljin { get; }
  public LegendaryHero GromHellscream { get; }
  public LegendaryHero Garrosh { get; }

  public OrcishHordeLegends()
  {
    Thrall = new LegendaryHero("Thrall")
    {
      UnitType = UNIT_OTHR_WARCHIEF_OF_THE_HORDE_ORCISH_HORDE,
      StartingArtifacts = new()
      {
        new(item.Create(ITEM_I004_THE_DOOMHAMMER, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      }
    };

    Voljin = new LegendaryHero("Vol'jin")
    {
      UnitType = UNIT_ORKN_CHIEFTAIN_OF_THE_DARKSPEAR_TRIBE_ORCISH_HORDE,
      StartingXp = 2800
    };

    GromHellscream = new LegendaryHero("Grom Hellscream")
    {
      UnitType = UNIT_OGRH_CHIEFTAIN_OF_THE_WARSONG_CLAN_ORCISH_HORDE,
      StartingArtifacts = new()
      {
        new(item.Create(ITEM_I01V_GOREHOWL, Regions.ArtifactDummyInstance.Center.X, Regions.ArtifactDummyInstance.Center.Y))
      }
    };

    Garrosh = new LegendaryHero("Garrosh Hellscream")
    {
      UnitType = UNIT_O06L_WARLORD_OF_THE_WARSONG_CLAN_ORCISH_HORDE,
      StartingXp = 8800
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(Thrall);
    LegendaryHeroManager.Register(Voljin);
    LegendaryHeroManager.Register(GromHellscream);
    LegendaryHeroManager.Register(Garrosh);
  }
}
