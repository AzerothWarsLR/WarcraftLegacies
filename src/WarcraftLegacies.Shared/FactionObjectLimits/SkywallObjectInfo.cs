using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class SkywallObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_N05Q_HOLDFAST_SKYWALL_T1, Unlimited, TownHall);
    yield return new(UNIT_N05W_FORTIFIED_BURG_SKYWALL_T2, Unlimited, Keep);
    yield return new(UNIT_N06R_GREAT_ALCAZAR_SKYWALL_T3, Unlimited, Castle);
    yield return new(UNIT_H03I_NIJARA_SKYWALL_RESEARCH, Unlimited, Research);
    yield return new(UNIT_N08A_FOUNDRY_SKYWALL_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_N07N_PAVILION_SKYWALL_MAGIC, Unlimited, Magic);
    yield return new(UNIT_N08B_DJINN_PALACE_SKYWALL_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_N07J_FORGE_OF_WISHES_SKYWALL_SHOP, Unlimited, Shop);
    yield return new(UNIT_N078_ALTAR_OF_ELEMENTS_SKYWALL_ALTAR, Unlimited, Altar);
    yield return new(UNIT_N08L_LATTICE_SPIRE_SKYWALL_TOWER, Unlimited, Tower);
    yield return new(UNIT_N08N_IMPROVED_LATTICE_SPIRE_SKYWALL_TOWER, Unlimited, Tower);

    yield return new(UNIT_LS05_SHAPER_SKYWALL_WORKER, Unlimited, Worker);
    yield return new(UNIT_N08S_ELEMENTAL_LORD_SKYWALL, 6, new List<UnitCategory> { Elite, Support, Marksman });
    yield return new(UNIT_O01I_ANIMATED_ARMOR_SKYWALL, Unlimited, Tank);
    yield return new(UNIT_SFH5_AIR_REVENANT_SKYWALL, Unlimited, new List<UnitCategory> { Marksman, Support });
    yield return new(UNIT_SGH5_BALLISTA_CARRIER_SKYWALL, 8, new List<UnitCategory> { Siege, Support });
    yield return new(UNIT_O05E_LURKING_TEMPEST_SKYWALL, Unlimited, Support);
    yield return new(UNIT_N08Z_WHIPPING_WIND_SKYWALL, Unlimited, Support);
    yield return new(UNIT_OETL_TIDAL_LORD_SKYWALL, 6, new List<UnitCategory> { Destroyer, Summoner, Support });
    yield return new(UNIT_U02P_DJINN_SKYWALL, 4, Support, limitIncreaseHint: "completing Druids Demise");
    yield return new(UNIT_LS06_EFREET_SKYWALL, 4, new List<UnitCategory> { Destroyer, Support }, limitIncreaseHint: "completing Druids Demise");
    yield return new(UNIT_N0CG_CORE_HOUND_RAGNAROS, 12, Fighter);
    yield return new(UNIT_N0CF_FIRE_WYRM_RAGNAROS, 2, new List<UnitCategory> { Marksman, Destroyer });

    yield return new(UNIT_H07X_SHIPYARD_SKYWALL_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_ETRS_NIGHT_ELF_TRANSPORT_SHIP_DRUIDS_SENTINELS, Unlimited);
    yield return new(UNIT_H0AU_SCOUT_SHIP_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0AV_FRIGATE_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B1_FIRESHIP_NIGHTELVES, Unlimited);
    yield return new(UNIT_H057_GALLEY_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B4_BOARDING_VESSEL_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0BA_JUGGERNAUT_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B8_BOMBARD_NIGHTELVES, Unlimited);

    yield return new(UNIT_U02K_LORD_OF_THE_FIRELANDS_SKYWALL, 1, new List<UnitCategory> { Tank, Summoner, Support });
    yield return new(UNIT_E023_GRAND_VIZIER_SKYWALL, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_U01S_WINDLORD_SKYWALL, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_UELN_THE_TIDEHUNTER_SKYWALL, 1, Destroyer);

    yield return new(UPGRADE_RELT_WINDFORGING_SKYWALL, Unlimited);
    yield return new(UPGRADE_RELP_SHOCKING_BLADES_SKYWALL, Unlimited);
    yield return new(UPGRADE_RELA_INFUSED_STEEL_SKYWALL, Unlimited);
    yield return new(UPGRADE_RELL_LURKING_TEMPEST_ADEPT_TRAINING_SKYWALL, Unlimited);
    yield return new(UPGRADE_RELW_WHIPPING_WIND_ADEPT_TRAINING_SKYWALL, Unlimited);
    yield return new(UPGRADE_RELO_TIDAL_LORD_ADEPT_TRAINING_SKYWALL, Unlimited);
    yield return new(UPGRADE_RELD_MAGMA_FIRE_ELEMENTAL, Unlimited);
    yield return new(UPGRADE_RELS_MAGMA_HEART_ELEMENTAL, Unlimited);
    yield return new(UPGRADE_REOW_OFFENSIVE_WISHES_ELEMENTAL, Unlimited);
    yield return new(UPGRADE_RELB_BURSTING_MIRACLES_ELEMENTAL, Unlimited);
    yield return new(UPGRADE_RELG_INSPIRING_GIFTS_ELEMENTAL, Unlimited);
  }
}
