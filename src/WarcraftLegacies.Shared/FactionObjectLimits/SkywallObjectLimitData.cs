namespace WarcraftLegacies.Shared.FactionObjectLimits
{
  public static class SkywallObjectLimitData
  {
    private const int Unlimited = 200;

    public static IEnumerable<ObjectLimit> GetAllObjectLimits()
    {
      yield return new(Constants.UNIT_N05Q_HOLDFAST_ELEMENTAL_T1, Unlimited);
      yield return new(Constants.UNIT_N05W_FORTIFIED_BURG_ELEMENTAL_T2, Unlimited);
      yield return new(Constants.UNIT_N06R_GREAT_ALCAZAR_ELEMENTAL_T3, Unlimited);
      yield return new(Constants.UNIT_H03I_NIJARA_ELEMENTAL_RESEARCH, Unlimited);
      yield return new(Constants.UNIT_N08A_FOUNDRY_ELEMENTAL_BARRACKS, Unlimited);
      yield return new(Constants.UNIT_N07N_PAVILION_ELEMENTAL_MAGIC, Unlimited);
      yield return new(Constants.UNIT_N08B_DJINN_PALACE_ELEMENTAL_SPECIALIST, Unlimited);
      yield return new(Constants.UNIT_N07J_FORGE_OF_WISHES_ELEMENTAL_SHOP, Unlimited);
      yield return new(Constants.UNIT_N078_ALTAR_OF_ELEMENTS_ELEMENTAL_ALTAR, Unlimited);
      yield return new(Constants.UNIT_N08L_LATTICE_SPIRE_ELEMENTAL_TOWER, Unlimited);
      yield return new(Constants.UNIT_N08N_IMPROVED_LATTICE_SPIRE_ELEMENTAL_TOWER, Unlimited);

      yield return new(Constants.UNIT_LS05_SHAPER_ELEMENTAL, Unlimited);
      yield return new(Constants.UNIT_N08S_ARMORED_MISTRAL_ELEMENTAL, 6);
      yield return new(Constants.UNIT_O01I_ANIMATED_ARMOR_ELEMENTAL, Unlimited);
      yield return new(Constants.UNIT_SFH5_AIR_REVENANT_ELEMENTAL, Unlimited);
      yield return new(Constants.UNIT_SGH5_BALLISTA_CARRIER_ELEMENTAL, 8);
      yield return new(Constants.UNIT_O05E_LURKING_TEMPEST_ELEMENTAL, Unlimited);
      yield return new(Constants.UNIT_N08Z_WHIPPING_WIND_ELEMENTAL, Unlimited);
      yield return new(Constants.UNIT_OETL_TIDAL_LORD_ELEMENTAL, 6);
      yield return new(Constants.UNIT_U02P_DJINN_ELEMENTAL, 4);
      yield return new(Constants.UNIT_LS06_EFREET_ELEMENTAL, 4);
      yield return new(Constants.UNIT_N0CG_CORE_HOUND_RAGNAROS, 12);
      yield return new(Constants.UNIT_N0CF_FIRE_WYRM_RAGNAROS, 2);

      yield return new(Constants.UNIT_H07X_SHIPYARD_ELEMENTAL_SHIPYARD, Unlimited);
      yield return new(Constants.UNIT_ETRS_NIGHT_ELF_TRANSPORT_SHIP_DRUIDS_SENTINELS, Unlimited);
      yield return new(Constants.UNIT_H0AU_SCOUT_SHIP_NIGHT_ELVES, Unlimited);
      yield return new(Constants.UNIT_H0AV_FRIGATE_NIGHT_ELVES, Unlimited);
      yield return new(Constants.UNIT_H0B1_FIRESHIP_NIGHT_ELVES, Unlimited);
      yield return new(Constants.UNIT_H057_GALLEY_NIGHT_ELVES, Unlimited);
      yield return new(Constants.UNIT_H0B4_BOARDING_VESSEL_NIGHT_ELVES, Unlimited);
      yield return new(Constants.UNIT_H0BA_JUGGERNAUT_NIGHT_ELVES, Unlimited);
      yield return new(Constants.UNIT_H0B8_BOMBARD_NIGHT_ELVES, Unlimited);

      yield return new(Constants.UNIT_U02K_LORD_OF_THE_FIRELANDS_ELEMENTAL, 1);
      yield return new(Constants.UNIT_E023_GRAND_VIZIER_ELEMENTAL, 1);
      yield return new(Constants.UNIT_U01S_WINDLORD_ELEMENTAL, 1);
      yield return new(Constants.UNIT_UELN_THE_TIDEHUNTER_ELEMENTAL, 1);

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
}