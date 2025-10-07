using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class DruidsObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_ETOL_TREE_OF_LIFE_DRUIDS_T1, Unlimited);
    yield return new(UNIT_ETOA_TREE_OF_AGES_DRUIDS_T2, Unlimited);
    yield return new(UNIT_ETOE_TREE_OF_ETERNITY_DRUIDS_T3, Unlimited);
    yield return new(UNIT_EMOW_MOON_WELL_DRUIDS_FARM, Unlimited);
    yield return new(UNIT_EATE_ALTAR_OF_ELDERS_DRUIDS_ALTAR, Unlimited);
    yield return new(UNIT_EAOE_ANCIENT_OF_LORE_DRUIDS_MAGIC, Unlimited);
    yield return new(UNIT_EAOW_ANCIENT_OF_WIND_DRUIDS_SPECIALIST, Unlimited);
    yield return new(UNIT_EAOM_ANCIENT_OF_WAR_DRUIDS_BARRACKS, Unlimited);
    yield return new(UNIT_ETRP_ANCIENT_PROTECTOR_DRUIDS_TOWER, Unlimited);
    yield return new(UNIT_E010_ANCIENT_OF_CREATION_DRUIDS_RESEARCH, Unlimited);
    yield return new(UNIT_E019_ANCIENT_OF_WONDERS_DRUIDS_SHOP, Unlimited);
    yield return new(UNIT_ESHY_KALDOREI_DOCKS_DRUIDS_SENTINEL_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(UNIT_E000_IMPROVED_ANCIENT_PROTECTOR_DRUIDS_TOWER, Unlimited);
    yield return new(UNIT_EWSP_WISP_DRUIDS_SENTINELS_WORKER, Unlimited, UnitCategory.Worker);
    yield return new(UNIT_EDRY_DRYAD_DRUIDS, Unlimited);
    yield return new(UNIT_EDOT_DRUID_OF_THE_TALON_DRUIDS, Unlimited);
    yield return new(UNIT_EMTG_MOUNTAIN_GIANT_DRUIDS, 12);
    yield return new(UNIT_EFDR_FAERIE_DRAGON_DRUIDS, 6);
    yield return new(UNIT_EDOC_DRUID_OF_THE_CLAW_DRUIDS, Unlimited);
    yield return new(UNIT_EDCM_BEAR_BEAR_FORM, Unlimited);
    yield return new(UNIT_E00N_KEEPER_OF_THE_GROVE_DRUIDS_ELITE, 6);
    yield return new(UNIT_N05H_SAPLING_DRUIDS, Unlimited);
    yield return new(UNIT_N065_GREEN_DRAGON_DRUIDS, 6);
    yield return new(UNIT_E012_SIEGE_ANCIENT_DRUIDS_ELITE, 6);
    yield return new(UNIT_ETRS_NIGHT_ELF_TRANSPORT_SHIP_DRUIDS_SENTINELS, Unlimited);
    yield return new(UNIT_H0AU_SCOUT_SHIP_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0AV_FRIGATE_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B1_FIRESHIP_NIGHTELVES, Unlimited);
    yield return new(UNIT_H057_GALLEY_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B4_BOARDING_VESSEL_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0BA_JUGGERNAUT_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B8_BOMBARD_NIGHTELVES, 6);
    yield return new(UNIT_ECEN_DEMIGOD_OF_THE_NIGHT_ELVES_DRUIDS, 1);
    yield return new(UNIT_E00H_DEMIGOD_OF_THE_NIGHT_ELVES_DRUIDS_GHOST, 1);
    yield return new(UNIT_EFUR_ARCHDRUID_DRUIDS, 1);
    yield return new(UNIT_E00A_ANCIENT_GUARDIAN_DRUIDS, 1);
    yield return new(UNIT_E00X_ELEMENTAL_GUARDIAN_DRUIDS_DEMI, 1);
    yield return new(UNIT_H04U_DEMIGOD_DRUIDS, 1);
    yield return new(UPGRADE_REDT_DRUID_OF_THE_TALON_ADVANCED_TRAINING_DRUIDS, Unlimited);
    yield return new(UPGRADE_RENB_NATURE_S_BLESSING_BROWN_RESEARCH, Unlimited);
    yield return new(UPGRADE_RERS_RESISTANT_SKIN_MOUNTAIN_GIANT, Unlimited);
    yield return new(UPGRADE_REUV_ULTRAVISION_LIGHT_BLUE_RESEARCH_BROWN_RESEARCH, Unlimited);
    yield return new(UPGRADE_REWS_WELL_SPRING, Unlimited);
    yield return new(UPGRADE_REDC_DRUID_OF_THE_CLAW_ADEPT_TRAINING_DRUID_OF_THE_CLAW_MASTER_TRAINING_DRUIDS, Unlimited);
    yield return new(UPGRADE_R04E_YSERA_S_GIFT_DRUIDS, Unlimited);
    yield return new(UPGRADE_R02G_EMERALD_FLAMES_DRUIDS, Unlimited);
    yield return new(UPGRADE_R05X_BLESSING_OF_URSOL_DRUIDS, Unlimited);
    yield return new(UPGRADE_R002_QUEST_COMPLETED_CROWN_OF_THE_SNOW_DRUIDS, Unlimited);
    yield return new(UPGRADE_R00A_IMPROVED_THORNS_DRUIDS, Unlimited);
    yield return new(UPGRADE_R02T_IMPROVED_MOONWELLS_DRUIDS, Unlimited);
    yield return new(UPGRADE_R046_GRASPING_VINES_DRUIDS, Unlimited);
    yield return new(UPGRADE_R047_CRIPPLING_POISON_DRUIDS, Unlimited);
    yield return new(UPGRADE_R048_DEADLY_POISON_DRUIDS, Unlimited);
    yield return new(UPGRADE_R008_DOMINATION_POWER, Unlimited);
    yield return new(UPGRADE_R015_IMPROVED_MANA_FLARE_DRUIDS, Unlimited);
    yield return new(UPGRADE_R09V_STORM_CROW_FORM_DRUIDS, Unlimited);
  }
}
