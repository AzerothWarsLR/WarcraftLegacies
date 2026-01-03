using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class DraeneiObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_O02P_CRYSTAL_HALL_DRAENEI_T1, Unlimited, TownHall);
    yield return new(UNIT_O050_METROPOLIS_DRAENEI_T2, Unlimited, TownHall);
    yield return new(UNIT_O051_DIVINE_CITADEL_DRAENEI_T3, Unlimited, TownHall);
    yield return new(UNIT_O058_ALTAR_OF_LIGHT_DRAENEI_ALTAR, Unlimited, Altar);
    yield return new(UNIT_O052_CEREMONIAL_ALTAR_DRAENEI_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_O053_LIGHTFORGE_DRAENEI_RESEARCH, Unlimited, Research);
    yield return new(UNIT_O054_ASTRAL_SANCTUM_DRAENEI_MAGIC, Unlimited, Magic);
    yield return new(UNIT_O055_CRYSTAL_SPIRE_DRAENEI_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_O056_ARCANE_WELL_DRAENEI_FARM, 60, new List<UnitCategory>() { Farm, Unique });
    yield return new(UNIT_O057_VAULT_OF_RELICS_DRAENEI_SHOP, Unlimited, Shop);
    yield return new(UNIT_U00U_CRYSTAL_PROTECTOR_DRAENEI_TOWER, Unlimited, Tower);
    yield return new(UNIT_U01Q_IMPROVED_CRYSTAL_PROTECTOR_DRAENEI_TOWER_2, Unlimited, Tower);
    yield return new(UNIT_O059_SHIPYARD_DRAENEI_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_O05U_LIGHTFORGED_GATEWAY_DRAENEI_ELITE, Unlimited, Specialist);

    yield return new(UNIT_O05A_GEMCRAFTER_DRAENEI_WORKER, Unlimited, Worker);
    yield return new(UNIT_O05B_DEFENDER_DRAENEI, Unlimited, Tank);
    yield return new(UNIT_H09T_RANGARI_DRAENEI, Unlimited, Marksman);
    yield return new(UNIT_E01K_POLYBOLOS_DRAENEI, 3, Siege);
    yield return new(UNIT_O05D_ELEMENTALIST_DRAENEI, Unlimited, new List<UnitCategory> { Support, Summoner });
    yield return new(UNIT_O05C_LUMINARCH_DRAENEI, Unlimited, Support);
    yield return new(UNIT_H09R_VINDICATOR_DRAENEI, 6, new List<UnitCategory> { Elite, Fighter, Tank, Support });
    yield return new(UNIT_NMDR_BROWN_ELEKK_DRAENEI, Unlimited, Fighter);
    yield return new(UNIT_H09U_ELEKK_KNIGHT_DRAENEI, 4, new List<UnitCategory> { Tank, Summoner, Support });
    yield return new(UNIT_U02H_NETHER_RAY_DRAENEI, 6, new List<UnitCategory> { Flyer, Marksman });
    yield return new(UNIT_N0BJ_LIGHTFORGED_SHARPSHOOTER_DRAENEI, 6, Marksman);
    yield return new(UNIT_N0BP_LIGHTFORGED_JUGGERNAUT_NEXUS, 4, new List<UnitCategory> { Marksman, Support });
    yield return new(UNIT_N0BM_LIGHTFORGED_DRAGOON_DRAENEI, 8, new List<UnitCategory> { Tank, Fighter });

    yield return new(UNIT_ETRS_NIGHT_ELF_TRANSPORT_SHIP_DRUIDS_SENTINELS, Unlimited);
    yield return new(UNIT_H0AU_SCOUT_SHIP_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0AV_FRIGATE_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B1_FIRESHIP_NIGHTELVES, Unlimited);
    yield return new(UNIT_H057_GALLEY_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B4_BOARDING_VESSEL_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0BA_JUGGERNAUT_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B8_BOMBARD_NIGHTELVES, Unlimited);

    yield return new(UNIT_H09S_HAMMER_OF_THE_LIGHT_DRAENEI, 1, Support);
    yield return new(UNIT_E01I_AGELESS_ONE_DRUIDS, 1, Support);
    yield return new(UNIT_E01J_HIGH_SHAMAN_DRUIDS, 1, new List<UnitCategory> { Support, Summoner });
    yield return new(UNIT_H09M_THE_NAARU_DRAENEI, 1, new List<UnitCategory> { Destroyer, Support });

    yield return new(UPGRADE_R078_ELEMENTALIST_ADEPT_TRAINING_DRAENEI, Unlimited);
    yield return new(UPGRADE_R07C_LUMINARCH_ADEPT_TRAINING_DRAENEI, Unlimited);
    yield return new(UPGRADE_RD01_CRYSTAL_SHIELDS_DRAENEI, Unlimited);
    yield return new(UPGRADE_RD02_KALIMDOR_WILDS_ACCLIMATIZATION_DRAENEI, Unlimited);
    yield return new(UPGRADE_RD04_ALIGNED_CRYSTAL_MECHANISM_DRAENEI, Unlimited);
    yield return new(UPGRADE_RD06_AZEROTHIAN_HUSBANDRY_DRAENEI, Unlimited);
    yield return new(UPGRADE_RD05_PROTECTOR_OF_KINGS_DRAENEI, Unlimited);
    yield return new(UPGRADE_RD07_IMPROVED_CRYSTAL_DISCHARGE_DRAENEI, Unlimited);
    yield return new(UPGRADE_RD08_RESTORE_MANA_DRAENEI, Unlimited);
    yield return new(UPGRADE_RD09_ENDLESS_ENERGY_DRAENEI, Unlimited);
    yield return new(UPGRADE_RD10_NAARU_S_SHIELD_DRAENEI, Unlimited);
  }
}
