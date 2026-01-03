using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class FelHordeObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectInfos()
  {
    yield return new(UNIT_O02Y_GREAT_HALL_FEL_T1, Unlimited, TownHall);
    yield return new(UNIT_O02Z_STRONGHOLD_FEL_T2, Unlimited, TownHall);
    yield return new(UNIT_O030_FORTRESS_FEL_T3, Unlimited, TownHall);
    yield return new(UNIT_O02V_ALTAR_OF_DOMINATION_FEL_ALTAR, Unlimited, Altar);
    yield return new(UNIT_O02W_BARRACKS_FEL_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_O031_WAR_MILL_FEL_RESEARCH, Unlimited, Research);
    yield return new(UNIT_O033_DARK_ENCLAVE_FEL_MAGIC, Unlimited, Magic);
    yield return new(UNIT_O02X_BEASTIARY_FEL_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_O032_SHIPYARD_FEL_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_O034_WATCH_TOWER_FEL_TOWER, Unlimited, Tower);
    yield return new(UNIT_O035_IMPROVED_WATCH_TOWER_FEL_TOWER_2, Unlimited, Tower);
    yield return new(UNIT_U00Q_TREASURY_FEL_SHOP, Unlimited, Shop);
    yield return new(UNIT_N0AM_FLAME_PILLAR_FEL_TOWER, Unlimited, Tower);
    yield return new(UNIT_N0AN_IMPROVED_FLAME_PILLAR_FEL_TOWER_2, Unlimited, Tower);
    yield return new(UNIT_OCBW_FEL_BURROW_FEL_FARM, Unlimited, Farm);
    yield return new(UNIT_N0AP_FOCAL_DEMON_GATE_FEL_SIEGE, Unlimited, Unique);
    yield return new(UNIT_NBDK_OBSIDIAN_DRAKE_FEL, 6, new List<UnitCategory> { Flyer, Marksman });
    yield return new(UNIT_ODKT_EREDAR_OCCULTIST_FEL, 6, new List<UnitCategory> { Support, Destroyer });
    yield return new(UNIT_NCHW_FEL_WARLOCK_FEL, Unlimited, Support);
    yield return new(UNIT_NCHG_FEL_GRUNT_FEL, Unlimited, Fighter);
    yield return new(UNIT_NCHR_FEL_RAIDER_FEL, Unlimited, new List<UnitCategory> { Fighter, Siege });
    yield return new(UNIT_NCPN_FEL_PEON_FEL_WORKER, Unlimited, Worker);
    yield return new(UNIT_OWAR_BONEBREAKER_FEL, 12, Fighter);
    yield return new(UNIT_O01L_EXECUTIONER_FEL_ELITE, 6, Fighter);
    yield return new(UNIT_O01O_DEMOLISHER_FEL, 8, Siege);
    yield return new(UNIT_U018_EYE_OF_GRILLOK_FEL, 10, Scout);
    yield return new(UNIT_U00V_NECROLYTE_FEL, Unlimited, Support);
    yield return new(UNIT_N058_FEL_CROSSBOWMAN_FEL, Unlimited, Marksman);
    yield return new(UNIT_NINA_INFERNAL_JUGGERNAUT_FEL, 4, new List<UnitCategory> { Siege, Marksman });
    yield return new(UNIT_N086_FEL_DEATH_KNIGHT_FEL_ELITE_TIER, 6, new List<UnitCategory> { Elite, Tank, Support });

    yield return new(UNIT_OBOT_HORDE_TRANSPORT_SHIP_WARSONG_FROSTWOLF_FEL_HORDE, Unlimited);
    yield return new(UNIT_H0AS_SCOUT_SHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AP_FRIGATE_HORDE, Unlimited);
    yield return new(UNIT_H0B2_FIRESHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AY_GALLEY_HORDE, Unlimited);
    yield return new(UNIT_H0B5_BOARDING_VESSEL_HORDE, Unlimited);
    yield return new(UNIT_H0BC_JUGGERNAUT_HORDE, Unlimited);
    yield return new(UNIT_H0AO_BOMBARD_HORDE, 6);

    yield return new(UNIT_N05T_KAZZAK_THE_SUPREME_FEL_DEMI, 1, new List<UnitCategory> { Fighter, Support, AntiMage });
    yield return new(UNIT_N03D_WARCHIEF_OF_THE_FEL_HORDE_FEL, 1, new List<UnitCategory> { Fighter, Support });
    yield return new(UNIT_NBBC_WARCHIEF_OF_THE_BLACKROCK_CLAN_FEL, 1, new List<UnitCategory> { Fighter, Support, Assassin });
    yield return new(UNIT_U02D_DEATH_KNIGHT_LORD_FEL_HORDE, 1, Support);
    yield return new(UNIT_NMAG_LORD_OF_OUTLAND_FEL, 1, new List<UnitCategory> { Tank, Fighter, Destroyer });

    yield return new(UPGRADE_ROBF_DEMONIC_FLUX_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R066_BURNING_OIL_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R00O_SUBDUE_THE_THUNDERBLUFF_TAUREN, Unlimited);
    yield return new(UPGRADE_RORB_REINFORCED_DEFENSES_FROSTWOLF_FEL_HORDE_WARSONG, Unlimited);
    yield return new(UPGRADE_ROSP_SPIKED_BARRICADES_FROSTWOLF_FEL_HORDE_WARSONG, Unlimited);
    yield return new(UPGRADE_R024_NECROLYTE_ADEPT_TRAINING_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R00M_FEL_WARLOCK_ADEPT_TRAINING_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R03I_EREDAR_OCCULTIST_ADEPT_TRAINING_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R00Y_IMPROVED_FRENZY_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R03L_IMPROVED_HEAL_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R036_INCINERATE_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R02L_ILLIDAN_EXISTS, Unlimited);
    yield return new(UPGRADE_R03O_BLOOD_RUNES_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R034_ENHANCED_BREATH_FEL_HORDE_DRAKES, Unlimited);
    yield return new(UPGRADE_R035_IMPROVED_FIREBOLT_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R01Z_PILLAGE_ECHO_ISLES, Unlimited);
    yield return new(UPGRADE_R098_FEL_INFUSED_SKELETON_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R09W_FELSTEEL_REFINING_FEL_HORDE, Unlimited);
    yield return new(UNIT_N05R_FELGUARD_DEMON_GATE_FEL_T2_BLOODFIEND, Unlimited);
    yield return new(UNIT_N06H_PIT_FIEND_DEMON_GATE_FEL_T2_PITFIEND, Unlimited);
    yield return new(UNIT_N07O_TERRORGUARD_DEMON_GATE_FEL_T2_TERROR_GUARD, Unlimited);
    yield return new(UPGRADE_R090_ACTIVATE_THE_BLACKROCK_CLAN_FEL, Unlimited);
  }
}
