using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class OrcishHordeObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_OGRE_GREAT_HALL_ORCISH_HORDE_T1, Unlimited, TownHall);
    yield return new(UNIT_OSTR_STRONGHOLD_ORCISH_HORDE_T2, Unlimited, Keep);
    yield return new(UNIT_OFRT_FORTRESS_ORCISH_HORDE_T3, Unlimited, Castle);
    yield return new(UNIT_OALT_ALTAR_OF_STORMS_ORCISH_HORDE_ALTAR, Unlimited, Altar);
    yield return new(UNIT_OBAR_WAR_CAMP_ORCISH_HORDE_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_OFOR_WAR_MILL_ORCISH_HORDE_RESEARCH, Unlimited, Research);
    yield return new(UNIT_O05G_SIEGE_WORKSHOP_ORCISH_HORDE_SIEGE, Unlimited, UnitCategory.SiegeWorkshop);
    yield return new(UNIT_OSLD_SPIRIT_LODGE_ORCISH_HORDE_MAGIC, Unlimited, Magic);
    yield return new(UNIT_OTRB_BURROW_ORCISH_HORDE_FARM, Unlimited, Farm);
    yield return new(UNIT_OWTW_WATCH_TOWER_ORCISH_HORDE_TOWER, Unlimited, Tower);
    yield return new(UNIT_O002_IMPROVED_WATCH_TOWER_FROSTWOLF_TOWER_2, Unlimited, Tower);
    yield return new(UNIT_NBT2_IMPROVED_BOULDER_TOWER, Unlimited, Tower);
    yield return new(UNIT_OVLN_VOODOO_LOUNGE_ORCISH_HORDE_SHOP, Unlimited, Shop);
    yield return new(UNIT_OSHY_HORDE_PIER_ORCISH_HORDE_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_OBEA_BEASTIARY_ORCISH_HORDE_SPECIALIST, Unlimited, Specialist);
    //yield return new(UNIT_N06Z_FLIGHT_PATH_ORCISH_HORDE_WARSONG, 1, Teleport);
    yield return new(UNIT_OPEO_PEON_ORCISH_HORDE_WORKER, Unlimited, Builder);
    //yield return new(UNIT_NTT2_TAUREN_TENT_ORCISH_HORDE_OTHER, Unlimited, Farm);
    //yield return new(UNIT_H004_TROLL_HUT_ORCISH_HORDE_FARM, Unlimited, Farm);

    yield return new(UNIT_OGRU_GRUNT_ORCISH_HORDE, Unlimited, Fighter);
    yield return new(UNIT_OHUN_HEADHUNTER_ORCISH_HORDE, Unlimited, Marksman);
    yield return new(UNIT_OCAT_CATAPULT_ORCISH_HORDE, 6, Siege);
    yield return new(UNIT_OTBR_BATRIDER_ORCISH_HORDE, 12, Flyer);
    yield return new(UNIT_ODOC_WITCH_DOCTOR_ORCISH_HORDE, Unlimited, Support);
    yield return new(UNIT_OSHM_SHAMAN_ORCISH_HORDE, Unlimited, Support);
    yield return new(UNIT_O00A_FAR_SEER_ORCISH_HORDE_ELITE, 6, new List<UnitCategory> { Elite, Destroyer, Support });
    yield return new(UNIT_N03F_KOR_KRON_ELITE_ORCISH_HORDE_ELITE, 6, new List<UnitCategory> { UnitCategory.Elite, UnitCategory.Fighter, UnitCategory.Destroyer, UnitCategory.Summoner });
    yield return new(UNIT_H0AS_SCOUT_SHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AP_FRIGATE_HORDE, Unlimited);
    yield return new(UNIT_H0B2_FIRESHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AY_GALLEY_HORDE, Unlimited);
    yield return new(UNIT_H0B5_BOARDING_VESSEL_HORDE, Unlimited);
    yield return new(UNIT_H0BC_JUGGERNAUT_HORDE, Unlimited);
    yield return new(UNIT_H0AO_BOMBARD_HORDE, 6);
    yield return new(UNIT_O00G_BLADEMASTER_ORCISH_HORDE, 6, new List<UnitCategory> { UnitCategory.Fighter, UnitCategory.Assassin });

    //yield return new(UPGRADE_ROWS_IMPROVED_PULVERIZE_ORCISH_HORDE, Unlimited);
    //yield return new(UPGRADE_ROST_SHAMAN_ADEPT_TRAINING_ORCISH_HORDE, Unlimited);
    //yield return new(UPGRADE_ROWD_WITCH_DOCTOR_ADEPT_TRAINING_ORCISH_HORDE, Unlimited);
    //yield return new(UPGRADE_ROWT_SPIRIT_WALKER_ADEPT_TRAINING_ORCISH_HORDE, Unlimited);
    //yield return new(UPGRADE_ROLF_AIRBORNE_TOXINS_ORCISH_HORDE, Unlimited);
    //yield return new(UPGRADE_ROSP_SPIKED_BARRICADES_ORCISH_HORDE_FEL_HORDE_WARSONG, Unlimited);
    //yield return new(UPGRADE_RORB_REINFORCED_DEFENSES_ORCISH_HORDE_FEL_HORDE_WARSONG, Unlimited);
    //yield return new(UPGRADE_R00R_IMPROVED_CHAIN_LIGHTNING_ORCISH_HORDE, Unlimited);
    //yield return new(UPGRADE_R00W_TOUGHENED_HIDES_ORCISH_HORDE, Unlimited);
    //yield return new(UPGRADE_R01Z_PILLAGE_ECHO_ISLES, Unlimited);
    //yield return new(UPGRADE_R09N_FLIGHT_PATH_WARSONG, 1);

    yield return new(UNIT_OTHR_WARCHIEF_OF_THE_HORDE_ORCISH_HORDE, 1, new List<UnitCategory> { Destroyer, Summoner });
    //yield return new(UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_ORCISH_HORDE, 1, new List<UnitCategory> { Tank, Support });
    yield return new(UNIT_ORKN_CHIEFTAIN_OF_THE_DARKSPEAR_TRIBE_ORCISH_HORDE, 1, new List<UnitCategory> { Support });
    //yield return new(UNIT_OREX_BEASTMASTER_ORCISH_HORDE, 1, Tank);
    yield return new(UNIT_O06L_WARLORD_OF_THE_WARSONG_CLAN_ORCISH_HORDE, 1, UnitCategory.Fighter);
  }
}
