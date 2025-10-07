using MacroTools.Shared;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class SkywallObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(Constants.UNIT_N05Q_HOLDFAST_SKYWALL_T1, Unlimited);
    yield return new(Constants.UNIT_N05W_FORTIFIED_BURG_SKYWALL_T2, Unlimited);
    yield return new(Constants.UNIT_N06R_GREAT_ALCAZAR_SKYWALL_T3, Unlimited);
    yield return new(Constants.UNIT_H03I_NIJARA_SKYWALL_RESEARCH, Unlimited);
    yield return new(Constants.UNIT_N08A_FOUNDRY_SKYWALL_BARRACKS, Unlimited);
    yield return new(Constants.UNIT_N07N_PAVILION_SKYWALL_MAGIC, Unlimited);
    yield return new(Constants.UNIT_N08B_DJINN_PALACE_SKYWALL_SPECIALIST, Unlimited);
    yield return new(Constants.UNIT_N07J_FORGE_OF_WISHES_SKYWALL_SHOP, Unlimited);
    yield return new(Constants.UNIT_N078_ALTAR_OF_ELEMENTS_SKYWALL_ALTAR, Unlimited);
    yield return new(Constants.UNIT_N08L_LATTICE_SPIRE_SKYWALL_TOWER, Unlimited);
    yield return new(Constants.UNIT_N08N_IMPROVED_LATTICE_SPIRE_SKYWALL_TOWER, Unlimited);

    yield return new(Constants.UNIT_LS05_SHAPER_SKYWALL_WORKER, Unlimited);
    yield return new(Constants.UNIT_N08S_ELEMENTAL_LORD_SKYWALL, 6);
    yield return new(Constants.UNIT_O01I_ANIMATED_ARMOR_SKYWALL, Unlimited);
    yield return new(Constants.UNIT_SFH5_AIR_REVENANT_SKYWALL, Unlimited);
    yield return new(Constants.UNIT_SGH5_BALLISTA_CARRIER_SKYWALL, 8);
    yield return new(Constants.UNIT_O05E_LURKING_TEMPEST_SKYWALL, Unlimited);
    yield return new(Constants.UNIT_N08Z_WHIPPING_WIND_SKYWALL, Unlimited);
    yield return new(Constants.UNIT_OETL_TIDAL_LORD_SKYWALL, 6);
    yield return new(Constants.UNIT_U02P_DJINN_SKYWALL, 4, limitIncreaseHint: "completing Druids Demise");
    yield return new(Constants.UNIT_LS06_EFREET_SKYWALL, 4, limitIncreaseHint: "completing Druids Demise");
    yield return new(Constants.UNIT_N0CG_CORE_HOUND_RAGNAROS, 12);
    yield return new(Constants.UNIT_N0CF_FIRE_WYRM_RAGNAROS, 2);

    yield return new(Constants.UNIT_H07X_SHIPYARD_SKYWALL_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(Constants.UNIT_ETRS_NIGHT_ELF_TRANSPORT_SHIP_DRUIDS_SENTINELS, Unlimited);
    yield return new(Constants.UNIT_H0AU_SCOUT_SHIP_NIGHTELVES, Unlimited);
    yield return new(Constants.UNIT_H0AV_FRIGATE_NIGHTELVES, Unlimited);
    yield return new(Constants.UNIT_H0B1_FIRESHIP_NIGHTELVES, Unlimited);
    yield return new(Constants.UNIT_H057_GALLEY_NIGHTELVES, Unlimited);
    yield return new(Constants.UNIT_H0B4_BOARDING_VESSEL_NIGHTELVES, Unlimited);
    yield return new(Constants.UNIT_H0BA_JUGGERNAUT_NIGHTELVES, Unlimited);
    yield return new(Constants.UNIT_H0B8_BOMBARD_NIGHTELVES, Unlimited);

    yield return new(Constants.UNIT_U02K_LORD_OF_THE_FIRELANDS_SKYWALL, 1);
    yield return new(Constants.UNIT_E023_GRAND_VIZIER_SKYWALL, 1);
    yield return new(Constants.UNIT_U01S_WINDLORD_SKYWALL, 1);
    yield return new(Constants.UNIT_UELN_THE_TIDEHUNTER_SKYWALL, 1);

    yield return new(Constants.UPGRADE_RELT_WINDFORGING_SKYWALL, Unlimited);
    yield return new(Constants.UPGRADE_RELP_SHOCKING_BLADES_SKYWALL, Unlimited);
    yield return new(Constants.UPGRADE_RELA_INFUSED_STEEL_SKYWALL, Unlimited);
    yield return new(Constants.UPGRADE_RELL_LURKING_TEMPEST_MASTER_TRAINING_SKYWALL, Unlimited);
    yield return new(Constants.UPGRADE_RELW_WHIPPING_WIND_MASTER_TRAINING_SKYWALL, Unlimited);
    yield return new(Constants.UPGRADE_RELO_TIDAL_LORD_MASTER_TRAINING_SKYWALL, Unlimited);
    yield return new(Constants.UPGRADE_RELD_MAGMA_FIRE_ELEMENTAL, Unlimited);
    yield return new(Constants.UPGRADE_RELS_MAGMA_HEART_ELEMENTAL, Unlimited);
    yield return new(Constants.UPGRADE_REOW_OFFENSIVE_WISHES_ELEMENTAL, Unlimited);
    yield return new(Constants.UPGRADE_RELB_BURSTING_MIRACLES_ELEMENTAL, Unlimited);
    yield return new(Constants.UPGRADE_RELG_INSPIRING_GIFTS_ELEMENTAL, Unlimited);
  }
}
