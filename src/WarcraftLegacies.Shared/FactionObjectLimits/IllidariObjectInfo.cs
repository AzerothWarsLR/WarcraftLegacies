using MacroTools.Shared;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class IllidariObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_NNTT_BETRAYER_S_RESERVOIR_ILLIDARI_T1, Unlimited, UnitCategory.TownHall);
    yield return new(UNIT_N04T_BETRAYER_S_SPIRE_ILLIDARI_T2, Unlimited);
    yield return new(UNIT_N055_BETRAYER_S_CITADEL_ILLIDARI_T3, Unlimited);
    yield return new(UNIT_NNAD_ALTAR_OF_THE_BETRAYER_ILLIDARI_ALTAR, Unlimited);
    yield return new(UNIT_NNSG_SPAWNERY_ILLIDARI_BARRACKS, Unlimited);
    yield return new(UNIT_H06S_STEAMWORKS_ILLIDARI_RESEARCH, Unlimited);
    yield return new(UNIT_N0A3_ARCHIVE_ILLIDARI_MAGIC, Unlimited);
    yield return new(UNIT_NNSA_CLUTCHERY_ILLIDARI_SPECIALIST, Unlimited);
    yield return new(UNIT_NNFM_INCUBATION_POOL_ILLIDARI_FARM, Unlimited);
    yield return new(UNIT_NNTG_TIDAL_WATCHER_ILLIDARI_TOWER, Unlimited);
    yield return new(UNIT_N005_IMPROVED_TIDAL_WATCHER_ILLIDARI_TOWER, Unlimited);
    yield return new(UNIT_NMRB_STEAMVAULT_ILLIDARI_SHOP, Unlimited);
    yield return new(UNIT_N08W_DRAENEI_HUT_ILLIDARI_SIEGE, Unlimited);
    yield return new(UNIT_E020_ANCIENT_SHIPYARD_ILLIDARI_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(UNIT_NMPE_MUR_GUL_SLAVE_ILLIDARI_NZOTH_WORKER, Unlimited, UnitCategory.Worker);
    yield return new(UNIT_NMYR_NAGA_MYRMIDON_ILLIDARI, Unlimited);
    yield return new(UNIT_NSNP_SNAP_DRAGON_ILLIDARI, Unlimited);
    yield return new(UNIT_NNSW_SIREN_ILLIDARI, Unlimited);
    yield return new(UNIT_NMSC_SHADOWCASTER_ILLIDARI, Unlimited);
    yield return new(UNIT_NNSU_COILFANG_SUMMONER_ILLIDARI, 6);
    yield return new(UNIT_NNRG_ROYAL_GUARD_ILLIDARI, 6);
    yield return new(UNIT_NHYC_DRAGON_TURTLE_ILLIDARI, 8);
    yield return new(UNIT_NWGS_COUATL_NZOTH_ILLIDARI, 8);
    yield return new(UNIT_E00Y_SCYLLA_ILLIDARI, 4);
    yield return new(UNIT_H0AC_SEA_WITCH_ILLIDARI_ELITE, 6);
    yield return new(UNIT_NDRN_DEATHSWORN_ILLIDARI, Unlimited);
    yield return new(UNIT_NDRS_SEER_ILLIDARI, 6);
    yield return new(UNIT_ETRS_NIGHT_ELF_TRANSPORT_SHIP_DRUIDS_SENTINELS, Unlimited);
    yield return new(UNIT_H0AU_SCOUT_SHIP_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0AV_FRIGATE_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B1_FIRESHIP_NIGHTELVES, Unlimited);
    yield return new(UNIT_H057_GALLEY_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B4_BOARDING_VESSEL_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0BA_JUGGERNAUT_NIGHTELVES, Unlimited);
    yield return new(UNIT_H0B8_BOMBARD_NIGHTELVES, 6);
    yield return new(UNIT_HVSH_SEA_WITCH_ILLIDARI, 1);
    yield return new(UNIT_U00S_HIGH_WARLORD_ILLIDARI, 1);
    yield return new(UNIT_NAKA_ELDER_SAGE_ILLIDARI, 1);
    yield return new(UPGRADE_RNSW_SIREN_ADEPT_TRAINING, Unlimited);
    yield return new(UPGRADE_R02V_SHADOWCASTER_ADEPT_TRAINING, Unlimited);
    yield return new(UPGRADE_ZBSI_SEA_WITCHES_ILLIDARI, Unlimited);
    yield return new(UPGRADE_ZB9L_COILFANG_SUMMONERS_ILLIDARI, Unlimited);

    yield return new(UNIT_EEVI_DEMON_HUNTER_ILLIDARI_HYBRID_ILLIDAN, 1);
    yield return new(UNIT_EEVM_DEMON_HUNTER_MORPHED_LEVEL_1_ILLIDARI, 1);
  }
}
