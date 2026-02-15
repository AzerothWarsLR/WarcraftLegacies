using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class LegionObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_U00H_SOUL_TOWER_LEGION_TOWER, Unlimited, Tower);
    yield return new(UNIT_U00I_IMPROVED_SOUL_TOWER_LEGION_TOWER, Unlimited, Tower);
    yield return new(UNIT_U00F_DORMANT_SPIRE_LEGION_T1, Unlimited, TownHall);
    yield return new(UNIT_U00C_LEGION_BASTION_LEGION_T2, Unlimited, Keep);
    yield return new(UNIT_U00N_BURNING_CITADEL_LEGION_T3, Unlimited, Castle);
    yield return new(UNIT_N040_SOUL_FORGE_LEGION_RESEARCH, Unlimited, Research);
    yield return new(UNIT_U009_SHIPYARD_LEGION_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_U00E_SOUL_PRISON_LEGION_FARM, Unlimited, Farm);
    yield return new(UNIT_U01N_ALTAR_OF_DESTRUCTION_LEGION_ALTAR, Unlimited, Altar);
    yield return new(UNIT_U015_UNHOLY_RELIQUARY_LEGION_SHOP, Unlimited, Shop);
    yield return new(UNIT_U006_SUMMONING_CIRCLE_LEGION_MAGIC, 3, Magic, limitIncreaseHint: "completing certain Quests");
    yield return new(UNIT_N04Q_NETHER_PIT_LEGION_BARRACKS, 3, Barracks, limitIncreaseHint: "completing certain Quests");
    yield return new(UNIT_N04N_INFERNAL_SIEGEWORKS_LEGION_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_NDMG_DEMON_GATE_LEGION_SIEGE, Unlimited, Specialist);

    yield return new(UNIT_U00D_LEGION_HERALD_LEGION_WORKER, Unlimited, Worker);
    yield return new(UNIT_U007_DREADLORD_LEGION_ELITE, 6, new List<UnitCategory> { Elite, Fighter, Destroyer });
    yield return new(UNIT_N04P_EREDAR_SUMMONER_LEGION, Unlimited, Support);
    yield return new(UNIT_NINC_BURNING_ARCHER_LEGION, Unlimited, Marksman);
    yield return new(UNIT_N04K_SUCCUBUS_LEGION, Unlimited, Support);
    yield return new(UNIT_N0DO_DOOM_GUARD_LEGION, 12, new List<UnitCategory> { Fighter, Summoner });
    yield return new(UNIT_N04O_DOOM_LORD_LEGION, 6, new List<UnitCategory> { Fighter });
    yield return new(UNIT_N04L_INFERNAL_JUGGERNAUT_LEGION, 6, new List<UnitCategory> { Siege, Summoner });
    yield return new(UNIT_O04P_NATHREZIM_WARLOCK_LEGION, 6, Support);
    yield return new(UNIT_NINF_INFERNAL_LEGION, 12, new List<UnitCategory> { Tank, AntiMage });
    yield return new(UNIT_N04H_FEL_GUARD_LEGION, Unlimited, Fighter);
    yield return new(UNIT_N04U_NETHER_DRAGON_LEGION, 4, Flyer);
    yield return new(UNIT_N03L_SKY_BARGE_LEGION, 4, new List<UnitCategory> { Flyer, Marksman, Siege });

    yield return new(UNIT_UMAL_THE_CUNNING_LEGION, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_UTIC_THE_DARKENER_LEGION, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_U00L_ENVOY_OF_ARCHIMONDE_LEGION, 1, Fighter);

    yield return new(UNIT_UBOT_HAUNTED_TRANSPORT_SHIP_SCOURGE_LEGION, Unlimited);
    yield return new(UNIT_H0AT_SCOUT_SHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AW_FRIGATE_EVIL, Unlimited);
    yield return new(UNIT_H0AM_FIRESHIP_EVIL, Unlimited);
    yield return new(UNIT_H0AZ_GALLEY_EVIL, Unlimited);
    yield return new(UNIT_H0AQ_BOARDING_VESSEL_EVIL, Unlimited);
    yield return new(UNIT_H0BB_JUGGERNAUT_EVIL, Unlimited);
    yield return new(UNIT_H0B9_BOMBARD_EVIL, 6);

    yield return new(UPGRADE_R02C_THE_DARK_PORTAL_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R028_SUCCUBIS_ADEPT_TRAINING_LEGION, Unlimited);
    yield return new(UPGRADE_R042_NATHREZIM_WARLOCK_ADEPT_TRAINING_LEGION, Unlimited);
    yield return new(UPGRADE_R027_EREDAR_SUMMONER_ADEPT_TRAINING_LEGION, Unlimited);
    yield return new(UPGRADE_R04G_IMPROVED_CARRION_SWARM_LEGION, Unlimited);
    yield return new(UPGRADE_R03Z_WAR_PLATING_LEGION, Unlimited);
    yield return new(UPGRADE_R096_REMATERIALIZATION_LEGION, 1);
    yield return new(UPGRADE_R04R_NAVIGATION_UNIVERSAL_UPGRADE, 1);
    yield return new(UPGRADE_R03L_IMPROVED_HEAL_FEL_HORDE, 1);
  }
}
