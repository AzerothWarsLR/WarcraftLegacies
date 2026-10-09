using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

/// <summary>The Forsaken's roster, ported from the 24 player map.</summary>
public static class ForsakenObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    //Buildings
    yield return new(UNIT_H089_DARK_MANSION_FORSAKEN, Unlimited, TownHall);
    yield return new(UNIT_H08A_GRIM_ESTATE_FORSAKEN, Unlimited, Keep);
    yield return new(UNIT_H08B_HAUNTED_CASTLE_FORSAKEN, Unlimited, Castle);
    yield return new(UNIT_H08S_UNDERCITY_FORSAKEN, 1, TownHall);
    yield return new(UNIT_H08C_GRAVE_FORSAKEN, Unlimited, Farm);
    yield return new(UNIT_H08D_SCOUT_TOWER_FORSAKEN, Unlimited, Tower);
    yield return new(UNIT_H08E_PLAGUE_TOWER_FORSAKEN, Unlimited, Tower);
    yield return new(UNIT_H08F_IMPROVED_PLAGUE_TOWER_FORSAKEN, Unlimited, Tower);
    yield return new(UNIT_U010_ALTAR_OF_THE_QUEEN_FORSAKEN, Unlimited, Altar);
    yield return new(UNIT_U011_PLAGUETORIUM_FORSAKEN, Unlimited, Barracks);
    yield return new(UNIT_U01J_GRAVEYARD_FORSAKEN, Unlimited, Research);
    yield return new(UNIT_U014_LABORATORY_FORSAKEN, Unlimited, SiegeWorkshop);
    yield return new(UNIT_U016_FORBIDDEN_ARCHIVE_FORSAKEN, Unlimited, Magic);
    yield return new(UNIT_U01W_ROYAL_SEPULCRUM_FORSAKEN, Unlimited, Specialist);
    yield return new(UNIT_U017_FORSAKEN_DEN_FORSAKEN, Unlimited, Shop);
    yield return new(UNIT_U01A_HAUNTED_HARBOR_FORSAKEN, Unlimited, Shipyard);

    //Units
    yield return new(UNIT_U01K_ACOLYTE_FORSAKEN_CULT_WORKER, Unlimited, Builder);
    yield return new(UNIT_H08O_ROTGUARD_FORSAKEN, Unlimited, Fighter);
    yield return new(UNIT_H08N_DREADGUARD_FORSAKEN_CULT, Unlimited, Tank);
    yield return new(UNIT_N07S_DEADEYE_FORSAKEN_CULT, Unlimited, Marksman);
    yield return new(UNIT_H08P_ARCHIVIST_FORSAKEN_CULT, Unlimited, Support);
    yield return new(UNIT_U01R_APOTHECARY_FORSAKEN_CULT, Unlimited, new List<UnitCategory> { Support, Summoner });
    yield return new(UNIT_U01P_PLAGUE_CATAPULT_FORSAKEN, 8, Siege);
    yield return new(UNIT_O05H_PLAGUE_FLYER_FORSAKEN, 12, new List<UnitCategory> { Flyer, AntiAir });
    yield return new(UNIT_N07W_PLAGUE_CONSTRUCT_FORSAKEN, 6, Tank);
    yield return new(UNIT_N0BY_DARK_RANGER_FORSAKEN, 6, new List<UnitCategory> { Marksman, Assassin });
    yield return new(UNIT_N07V_ELDER_BANSHEE_FORSAKEN, 6, new List<UnitCategory> { Support, AntiMage });
    yield return new(UNIT_U02G_ELITE_ABOMINATIONS_SCOURGE_FORSAKEN_CULT, 6, Tank);
    yield return new(UNIT_U01V_VAL_KYR_FORSAKEN, 2, new List<UnitCategory> { Flyer, Support });

    //Ships
    yield return new(UNIT_UBOT_HAUNTED_TRANSPORT_SHIP_SCOURGE_LEGION, Unlimited);
    yield return new(UNIT_H0AT_SCOUT_SHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AW_FRIGATE_EVIL, Unlimited);
    yield return new(UNIT_H0AM_FIRESHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AZ_GALLEY_EVIL, Unlimited);
    yield return new(UNIT_H0AQ_BOARDING_VESSEL_EVIL, Unlimited);
    yield return new(UNIT_H0BB_JUGGERNAUT_EVIL, Unlimited);
    yield return new(UNIT_H0B9_BOMBARD_EVIL, 6);

    //Heroes
    yield return new(UNIT_USYL_DARK_RANGER_FORSAKEN, 1);
    yield return new(UNIT_U01O_GRAND_APOTHECARY_FORSAKEN, 1);
    yield return new(UNIT_U02I_MASTER_OF_THE_ROYAL_APOTHECARY_SOCIETY_FORSAKEN, 1);
    yield return new(UNIT_H049_RANGER_LORD_FORSAKEN, 1);
    yield return new(UNIT_UVAR_ARCH_DREADLORD_FORSAKEN, 1);

    //Upgrades
    yield return new(UPGRADE_R050_DECLARE_FORSAKEN_INDEPENDENCE_FORSAKEN, Unlimited);
    yield return new(UPGRADE_R051_APOTHECARY_ADEPT_TRAINING_SCOURGE, Unlimited);
    yield return new(UPGRADE_R05C_ARCHIVIST_ADEPT_TRAINING_FORSAKEN, Unlimited);
    yield return new(UPGRADE_R07V_BANSHEE_EMPOWEREMENT_FORSAKEN, Unlimited);
    yield return new(UPGRADE_R100_CHAOS_INFUSION_SCOURGE_LEGION, Unlimited);
    yield return new(UPGRADE_R101_TIER_4_UNIVERSAL_UPGRADE, Unlimited);
  }
}
