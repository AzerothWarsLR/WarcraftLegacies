using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

/// <summary>The Banshee's Host's roster: a thinned Scourge, with the first of the Forsaken among its ranks.</summary>
public static class BansheesHostObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_UNPL_NECROPOLIS_SCOURGE_T1, Unlimited, TownHall);
    yield return new(UNIT_UNP1_HALLS_OF_THE_DEAD_SCOURGE_T2, Unlimited, Keep);
    yield return new(UNIT_UNP2_BLACK_CITADEL_SCOURGE_T3, Unlimited, Castle);
    yield return new(UNIT_UZIG_ZIGGURAT_SCOURGE_FARM, Unlimited, Farm);
    yield return new(UNIT_UZG1_SPIRIT_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });
    yield return new(UNIT_UZG2_NERUBIAN_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });
    yield return new(UNIT_UAOD_ALTAR_OF_DARKNESS_SCOURGE_ALTAR, Unlimited, Altar);
    yield return new(UNIT_USEP_CRYPT_SCOURGE_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_UGRV_GRAVEYARD_SCOURGE_RESEARCH, Unlimited, Research);
    yield return new(UNIT_USLH_SLAUGHTERHOUSE_SCOURGE_SPECIALIST, Unlimited, SiegeWorkshop);
    yield return new(UNIT_UTOD_TEMPLE_OF_THE_DAMNED_SCOURGE_MAGIC, Unlimited, Magic);
    yield return new(UNIT_UTOM_TOMB_OF_RELICS_SCOURGE_SHOP, Unlimited, Shop);
    yield return new(UNIT_USHP_HAUNTED_HARBOR_SCOURGE_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_U002_IMPROVED_SPIRIT_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });
    yield return new(UNIT_U003_IMPROVED_NERUBIAN_TOWER_SCOURGE_TOWER, Unlimited, new List<UnitCategory> { Farm, Tower });

    yield return new(UNIT_UACO_ACOLYTE_SCOURGE_WORKER, Unlimited, Builder);
    yield return new(UNIT_H08O_ROTGUARD_FORSAKEN, Unlimited, Fighter);
    yield return new(UNIT_H08N_DREADGUARD_FORSAKEN_CULT, Unlimited, Tank);
    yield return new(UNIT_N07S_DEADEYE_FORSAKEN_CULT, Unlimited, Marksman);
    yield return new(UNIT_UBAN_BANSHEE_SCOURGE, Unlimited, Support);
    yield return new(UNIT_U01R_APOTHECARY_FORSAKEN_CULT, Unlimited, new List<UnitCategory> { Support, Summoner });
    yield return new(UNIT_UMTW_MEAT_WAGON_SCOURGE, 6, Siege);
    yield return new(UNIT_UOBS_OBSIDIAN_STATUE_SCOURGE, 2, Support);
    yield return new(UNIT_U10A_WAILING_SORROW_BANSHEESHOST_ELITE, 4, new List<UnitCategory> { Elite, Support });

    yield return new(UNIT_UBOT_HAUNTED_TRANSPORT_SHIP_SCOURGE_LEGION, Unlimited);
    yield return new(UNIT_H0AT_SCOUT_SHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AW_FRIGATE_EVIL, Unlimited);
    yield return new(UNIT_H0AM_FIRESHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AZ_GALLEY_EVIL, Unlimited);
    yield return new(UNIT_H0AQ_BOARDING_VESSEL_EVIL, Unlimited);
    yield return new(UNIT_H0BB_JUGGERNAUT_EVIL, Unlimited);
    yield return new(UNIT_H0B9_BOMBARD_EVIL, 6);

    yield return new(UNIT_U01O_GRAND_APOTHECARY_FORSAKEN, 1);

    yield return new(UPGRADE_RUBA_BANSHEE_ADEPT_TRAINING_SCOURGE_RESEARCH, Unlimited);
    yield return new(UPGRADE_R051_APOTHECARY_ADEPT_TRAINING_SCOURGE, Unlimited);
  }
}
