using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class SentinelsObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_E00V_TEMPLE_OF_ELUNE_SENTINELS_MAGIC, Unlimited);
    yield return new(UNIT_E00R_ALTAR_OF_WATCHERS_SENTINELS_ALTAR, Unlimited);
    yield return new(UNIT_E00L_WAR_ACADEMY_SENTINELS_BARRACKS, Unlimited);
    yield return new(UNIT_EDOB_HUNTER_S_HALL_SENTINELS_RESEARCH, Unlimited);
    yield return new(UNIT_EDEN_DEN_OF_WONDERS_SENTINELS_SHOP, Unlimited);
    yield return new(UNIT_E011_KALDOREI_DOCKS_SENTINELS_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(UNIT_H03N_IMPROVED_HUNTER_TOWER_SENTINELS_TOWER, Unlimited);
    yield return new(UNIT_H03M_HUNTER_TOWER_SENTINELS_TOWER, Unlimited);
    yield return new(UNIT_N06O_SENTINEL_EMBASSY_SENTINELS_T2, Unlimited);
    yield return new(UNIT_N06P_SENTINEL_ENCLAVE_SENTINELS_T3, Unlimited);
    yield return new(UNIT_N06J_SENTINEL_OUTPOST_SENTINELS_T1, Unlimited, UnitCategory.TownHall);
    yield return new(UNIT_N06M_RESIDENCE_SENTINELS_FARM, Unlimited);
    yield return new(UNIT_EDOS_ROOST_SENTINELS_SPECIALIST, Unlimited);
    yield return new(UNIT_E00T_WATCHER_S_BASTION_SENTINELS_SIEGE, Unlimited);
    yield return new(UNIT_EWSP_WISP_DRUIDS_SENTINELS_WORKER, Unlimited, UnitCategory.Worker);
    yield return new(UNIT_E006_PRIESTESS_SENTINELS, Unlimited);
    yield return new(UNIT_N06C_MOONHUNTER_SENTINELS, Unlimited);
    yield return new(UNIT_H04L_PRIESTESS_OF_THE_MOON_SENTINELS_ELITE, 6);
    yield return new(UNIT_EARC_ARCHER_SENTINELS, Unlimited);
    yield return new(UNIT_ESEN_HUNTRESS_SENTINELS, Unlimited);
    yield return new(UNIT_H08V_GLAIVE_MAIDEN_SENTINELS, Unlimited);
    yield return new(UNIT_EBAL_GLAIVE_THROWER_SENTINELS, 8);
    yield return new(UNIT_EHPR_HIPPOGRYPH_RIDER_SENTINELS, 6);
    yield return new(UNIT_N034_GUILD_RANGER_SENTINELS, 12);
    yield return new(UNIT_NNMG_REDEEMED_HIGHBORNE_SENTINELS, 12);
    yield return new(UNIT_E022_MOON_RIDER_SENTINELS, 2);
    yield return new(UNIT_ECHM_CHIMAERA_SENTINELS, 6);
    yield return new(UNIT_H045_WARDEN_SENTINELS, 8);
    yield return new(UNIT_ETRS_NIGHT_ELF_TRANSPORT_SHIP_DRUIDS_SENTINELS, Unlimited);
    yield return new(UNIT_H0AU_SCOUT_SHIP_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0AV_FRIGATE_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B1_FIRESHIP_NIGHTELVES, Unlimited);
    yield return new(UNIT_H057_GALLEY_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B4_BOARDING_VESSEL_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0BA_JUGGERNAUT_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B8_BOMBARD_NIGHTELVES, 6);
    yield return new(UNIT_E025_LIEUTENANT_OF_THE_WATCHERS_SENTINELS, 1);
    yield return new(UNIT_ETYR_HIGH_PRIESTESS_OF_ELUNE_SENTINELS, 1);
    yield return new(UNIT_E002_GENERAL_OF_THE_SENTINEL_ARMY_SENTINELS, 1);
    yield return new(UNIT_EWRD_LEADER_OF_THE_WATCHERS_SENTINELS, 1);
    yield return new(UPGRADE_R00S_PRIESTESS_MASTER_TRAINING_SENTINELS, Unlimited);
    yield return new(UPGRADE_R064_SENTINEL_FORTIFICATIONS_SENTINELS, Unlimited);
    yield return new(UPGRADE_R01W_MOONHUNTER_MASTER_TRAINING_SENTINELS, Unlimited);
    yield return new(UPGRADE_REIB_IMPROVED_BOWS_LIGHT_BLUE_RESEARCH, Unlimited);
    yield return new(UPGRADE_REUV_ULTRAVISION_LIGHT_BLUE_RESEARCH_BROWN_RESEARCH, Unlimited);
    yield return new(UPGRADE_REMG_UPGRADE_MOON_GLAIVE_LIGHT_BLUE_RESEARCH, Unlimited);
    yield return new(UPGRADE_ROEN_IMPROVED_ENSNARE_SENTINELS, Unlimited);
    yield return new(UPGRADE_R04E_YSERA_S_GIFT_DRUIDS, Unlimited);
    yield return new(UPGRADE_R03J_WIND_WALK_SENTINELS, Unlimited);
    yield return new(UPGRADE_R018_IMPROVED_LIGHTNING_BARRAGE_SENTINELS, Unlimited);
  }
}
