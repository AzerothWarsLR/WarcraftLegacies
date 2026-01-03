using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class AhnqirajObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectInfos()
  {
    yield return new(UNIT_U020_MONUMENT_CTHUN_T1, Unlimited, TownHall);
    yield return new(UNIT_U021_RUINED_TEMPLE_CTHUN_T2, Unlimited, TownHall);
    yield return new(UNIT_U022_NEXUS_CTHUN_T3, Unlimited, TownHall);
    yield return new(UNIT_N071_PILLAR_OF_C_THUN_CTHUN_PILLARS, Unlimited, new List<UnitCategory> { Tower, Farm });
    yield return new(UNIT_U01G_SPIRIT_HALL_CTHUN_RESEARCH, Unlimited, Research);
    yield return new(UNIT_O00R_HATCHERY_CTHUN_BARRACK, Unlimited, Barracks);
    yield return new(UNIT_O00D_PYRAMID_CTHUN_MAGIC, Unlimited, Magic);
    yield return new(UNIT_U01H_ANCIENT_CATACOMBS_CTHUN_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_U01I_CHAMBER_OF_WONDERS_CTHUN_SHOP, Unlimited, Shop);
    yield return new(UNIT_U01F_ALTAR_OF_THE_OLD_ONES_CTHUN_ALTAR, Unlimited, Altar);
    yield return new(UNIT_U019_WORKER_CTHUN_WORKER, Unlimited, Worker);
    yield return new(UNIT_O000_ROYALTY_CTHUN_ELITES, 6, new List<UnitCategory> { Elite, Fighter });
    yield return new(UNIT_N06I_SOLDIER_CTHUN_SILITHID_WARRIOR, Unlimited, new List<UnitCategory> { Tank, Summoner });
    yield return new(UNIT_O00L_CREMATOGASTER_CTHUN_SILITHID_REAVER, Unlimited, Marksman);
    yield return new(UNIT_U013_SUPER_MAJOR_CTHUN, 12, new List<UnitCategory> { Fighter, Siege });
    yield return new(UNIT_N060_TUNNELER_CTHUN_SILITHID_TUNNELER, Unlimited, Support);
    yield return new(UNIT_N05V_SHADOW_WEAVER_CTHUN_FACELESS_SHADOW_WEAVER, Unlimited, Support);
    yield return new(UNIT_O001_TOL_VIR_STATUE_CTHUN_TOL_VIR_STATUE, 6, Support);
    yield return new(UNIT_O02N_ELATE_CTHUN, 24, new List<UnitCategory> { Flyer, Marksman });
    yield return new(UNIT_H01N_VILE_CORRUPTER_CTHUN, 4, new List<UnitCategory> { Flyer, Marksman, Summoner });
    yield return new(UNIT_SL2O_OBSIDIAN_ERADICATOR_CTHUN, 12, new List<UnitCategory> { Tank, AntiMage });

    yield return new(UNIT_U02S_ANCIENT_SAND_WORM, 1, Tank);
    yield return new(UNIT_E005_THE_PROPHET, 1, new List<UnitCategory> { Support, Summoner });
    yield return new(UNIT_U00Z_OBSIDIAN_DESTROYER, 1, Destroyer);

    yield return new(UPGRADE_RS01_TUNNELER_ADEPT_TRAINING_CTHUN, Unlimited);
    yield return new(UPGRADE_RZ02_SHADOW_WEAVER_ADEPT_TRAINING_CTHUN, Unlimited);
    yield return new(UPGRADE_RL11_TOL_VIR_STATUE_ADEPT_TRAINING_CTHUN, Unlimited);
    yield return new(UPGRADE_RYW5_IMPROVED_SWARM_BEETLE_CTHUN_WARRIOR, Unlimited);
    yield return new(UPGRADE_RTL3_IMPROVED_SEED_OF_MADNESS_CTHUN_WARRIOR, Unlimited);
    yield return new(UPGRADE_RHL9_WEB_CTHUN, Unlimited);
    yield return new(UPGRADE_R003_PROGENESIS_C_THUN, Unlimited);
    yield return new(UPGRADE_ZB12_CLEAVING_ATTACK_C_THUN, Unlimited);
    yield return new(UPGRADE_ZB14_ELONGATED_SNOUTS_C_THUN_SILITHID_WASP, Unlimited);
    yield return new(UPGRADE_ZBEH_DEFENSIVE_COCOOON_AHN_QIRAJ, Unlimited);
    yield return new(UPGRADE_ZBRI_RAPID_INCUBATION_AHN_QIRAJ, Unlimited);
    yield return new(UPGRADE_ZBHS_SHAPED_OBSIDIAN_C_THUN, Unlimited);
    yield return new(UPGRADE_ZBML_SPELL_CONDUCTION_C_THUN, Unlimited);
    yield return new(UPGRADE_RDBD_DEEP_BURROW_C_THUN, Unlimited);
  }
}
