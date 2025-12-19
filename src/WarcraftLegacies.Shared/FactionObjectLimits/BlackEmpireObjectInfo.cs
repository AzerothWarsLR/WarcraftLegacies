using MacroTools.Shared;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class BlackEmpireObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_N0AR_TWISTING_HALLS_NZOTH_T1, Unlimited);
    yield return new(UNIT_N0AS_WHISPERING_LABYRINTH_NZOTH_T2, Unlimited);
    yield return new(UNIT_N0AT_CATHEDRAL_OF_MADNESS_NZOTH_T3, Unlimited);
    yield return new(UNIT_N0AU_PULSATING_PORTAL_NZOTH_FARM, Unlimited);
    yield return new(UNIT_H06U_SIPHONING_CRYSTAL_NZOTH_RESEARCH, Unlimited);
    yield return new(UNIT_N0AW_INCUBATION_POOL_NZOTH_BARRACKS, Unlimited);
    yield return new(UNIT_N0B3_SHADOW_LAIR_NZOTH_MAGIC, Unlimited);
    yield return new(UNIT_ST5K_PIT_OF_TORMENT_NZOTH_SPECIALIST, Unlimited);
    yield return new(UNIT_N0AX_MUTATION_CIRCLE_NZOTH_SPECIALIST, Unlimited);
    yield return new(UNIT_N0B2_OMINOUS_VAULT_NZOTH_SHOP, Unlimited);
    yield return new(UNIT_N0AV_ALTAR_OF_MADNESS_NZOTH_ALTAR, Unlimited);
    yield return new(UNIT_H09E_MADNESS_POOL_NZOTH_TOWER, Unlimited);
    yield return new(UNIT_N0AY_ACID_SPITTER_NZOTH_TOWER, Unlimited);
    yield return new(UNIT_N0B0_IMPROVED_ACID_SPITTER_NZOTH_TOWER, Unlimited);
    yield return new(UNIT_N0AZ_SLEEPLESS_WATCHER_NZOTH_TOWER, Unlimited);
    yield return new(UNIT_N0B1_IMPROVED_SLEEPLESS_WATCHER_NZOTH_TOWER, Unlimited);
    yield return new(UNIT_N0B5_SCAVENGER_NZOTH_WORKER, Unlimited);
    yield return new(UNIT_N0B4_REAPER_NZOTH, 6);
    yield return new(UNIT_O01G_BRUTE_NZOTH, Unlimited);
    yield return new(UNIT_O04V_LURKER_NZOTH, Unlimited);
    yield return new(UNIT_U029_STYGIAN_HULK_NZOTH, 8);
    yield return new(UNIT_SHZ5_AQIR_NZOTH, 6);
    yield return new(UNIT_N077_MINDLASHER_NZOTH, Unlimited);
    yield return new(UNIT_O04Y_FATEWEAVER_NZOTH, Unlimited);
    yield return new(UNIT_U02F_FORGOTTEN_ONE_NZOTH, 1, limitIncreaseHint: "completing certain Quests");
    yield return new(UNIT_BHN1_HERALD_NZOTH, 6);
    yield return new(UNIT_O04Z_FLYING_HORROR_NZOTH, 12);
    yield return new(UNIT_N0AH_DEFORMED_CHIMERA_NZOTH, 4);
    yield return new(UNIT_H09F_DEEP_FIEND_NZOTH, 12);
    yield return new(UNIT_USHP_HAUNTED_HARBOR_SCOURGE_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(UNIT_H0AT_SCOUT_SHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AW_FRIGATE_EVIL, Unlimited);
    yield return new(UNIT_UBOT_HAUNTED_TRANSPORT_SHIP_SCOURGE_LEGION, Unlimited);
    yield return new(UNIT_H0AM_FIRESHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AZ_GALLEY_EVIL, Unlimited);
    yield return new(UNIT_H0AQ_BOARDING_VESSEL_EVIL, Unlimited);
    yield return new(UNIT_H0BB_JUGGERNAUT_EVIL, Unlimited);
    yield return new(UNIT_H0B9_BOMBARD_EVIL, 6);
    yield return new(UNIT_U00P_LIEUTENANT_OF_N_ZOTH_NZOTH, 1);
    yield return new(UNIT_U02B_N_RAQI_ABERRATION_NZOTH, 1);
    yield return new(UNIT_E01D_HARBINGER_OF_NY_ALOTHA_NZOTH, 1);
    yield return new(UPGRADE_RBEF_FATEWEAVER_ADEPT_TRAINING_BLACKEMPIRE, Unlimited);
    yield return new(UPGRADE_RBEM_MINDLASHER_ADEPT_TRAINING_BLACKEMPIRE, Unlimited);
    yield return new(UPGRADE_RBEH_HERALD_ADEPT_TRAINING_BLACKEMPIRE, Unlimited);
    yield return new(UPGRADE_RBEP_PARALYSING_FEAR_BLACK_EMPIRE, Unlimited);
    yield return new(UPGRADE_RBEV_SHADOW_VEIL_BLACK_EMPIRE, Unlimited);
    yield return new(UPGRADE_RBEA_ACCELERATED_CYCLE_BLACK_EMPIRE_STYGIAN_HULK, Unlimited);
    yield return new(UPGRADE_RBFC_CURSED_FLESH_BLACK_EMPIRE_AQIR_AND_FORGOTTEN_ONE, Unlimited);
    yield return new(UPGRADE_RBES_UNWORLDLY_SCYTHE_BLACK_EMPIRE_REAPER, Unlimited);
  }
}
