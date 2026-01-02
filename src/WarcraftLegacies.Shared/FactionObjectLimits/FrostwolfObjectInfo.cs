using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class FrostwolfObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_OGRE_GREAT_HALL_FROSTWOLF_T1, Unlimited, TownHall);
    yield return new(UNIT_OSTR_STRONGHOLD_FROSTWOLF_T2, Unlimited, TownHall);
    yield return new(UNIT_OFRT_FORTRESS_FROSTWOLF_T3, Unlimited, TownHall);
    yield return new(UNIT_OALT_ALTAR_OF_STORMS_FROSTWOLF_ALTAR, Unlimited, Altar);
    yield return new(UNIT_OBAR_WAR_CAMP_FROSTWOLF_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_OFOR_WAR_MILL_FROSTWOLF_RESEARCH, Unlimited, Research);
    yield return new(UNIT_OTTO_TAUREN_TOTEM_FROSTWOLF_SIEGE, Unlimited, SiegeWorkshop);
    yield return new(UNIT_OSLD_SPIRIT_LODGE_FROSTWOLF_MAGIC, Unlimited, Magic);
    yield return new(UNIT_OTRB_BURROW_FROSTWOLF_FARM, Unlimited, Farm);
    yield return new(UNIT_OWTW_WATCH_TOWER_FROSTWOLF_TOWER, Unlimited, Tower);
    yield return new(UNIT_O002_IMPROVED_WATCH_TOWER_FROSTWOLF_TOWER_2, Unlimited, Tower);
    yield return new(UNIT_NBT2_IMPROVED_BOULDER_TOWER, Unlimited, Tower);
    yield return new(UNIT_OVLN_VOODOO_LOUNGE_FROSTWOLF_SHOP, Unlimited, Shop);
    yield return new(UNIT_OSHY_HORDE_PIER_FROSTWOLF_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_OBEA_BEASTIARY_FROSTWOLF_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_N06Z_FLIGHT_PATH_FROSTWOLF_WARSONG, 1, Teleport);
    yield return new(UNIT_OPEO_PEON_FROSTWOLF_WARSONG_WORKER, Unlimited, Worker);
    yield return new(UNIT_NTT2_TAUREN_TENT_FROSTWOLF_OTHER, Unlimited, Farm);
    yield return new(UNIT_H004_TROLL_HUT_FROSTWOLF_FARM, Unlimited, Farm);

    yield return new(UNIT_OGRU_GRUNT_FROSTWOLF, Unlimited, Fighter);
    yield return new(UNIT_OTAU_TAUREN_FROSTWOLF, Unlimited, Tank);
    yield return new(UNIT_OHUN_HEADHUNTER_FROSTWOLF, Unlimited, Marksman);
    yield return new(UNIT_OCAT_CATAPULT_FROSTWOLF, 6, Siege);
    yield return new(UNIT_OTBR_BATRIDER_FROSTWOLF, 12, Flyer);
    yield return new(UNIT_ODOC_WITCH_DOCTOR_FROSTWOLF, Unlimited, Support);
    yield return new(UNIT_OSHM_SHAMAN_FROSTWOLF, Unlimited, Support);
    yield return new(UNIT_OSPW_SPIRIT_WALKER_FROSTWOLF, Unlimited, Support);
    yield return new(UNIT_O00A_FAR_SEER_FROSTWOLF_ELITE, 6, new List<UnitCategory> { Elite, Destroyer, Support });
    yield return new(UNIT_O06T_TAUREN_GLADIATOR_FROSTWOLF, 6, Tank);
    yield return new(UNIT_H0CN_PACKLEADER_FROSTWOLF, 4, new List<UnitCategory> { Fighter, Support });
    yield return new(UNIT_H0CO_MAMMOTH_WRANGLER_FROSTWOLF, 2, new List<UnitCategory> { Fighter, Support });
    yield return new(UNIT_N049_WANDERER_FROSTWOLF, 4, new List<UnitCategory> { Marksman, Support });
    yield return new(UNIT_OBOT_HORDE_TRANSPORT_SHIP_WARSONG_FROSTWOLF_FEL_HORDE, Unlimited);
    yield return new(UNIT_H0AS_SCOUT_SHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AP_FRIGATE_HORDE, Unlimited);
    yield return new(UNIT_H0B2_FIRESHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AY_GALLEY_HORDE, Unlimited);
    yield return new(UNIT_H0B5_BOARDING_VESSEL_HORDE, Unlimited);
    yield return new(UNIT_H0BC_JUGGERNAUT_HORDE, Unlimited);
    yield return new(UNIT_H0AO_BOMBARD_HORDE, 6);

    yield return new(UPGRADE_ROWS_IMPROVED_PULVERIZE_FROSTWOLF, Unlimited);
    yield return new(UPGRADE_ROST_SHAMAN_ADEPT_TRAINING_FROSTWOLF, Unlimited);
    yield return new(UPGRADE_ROWD_WITCH_DOCTOR_ADEPT_TRAINING_FROSTWOLF, Unlimited);
    yield return new(UPGRADE_ROWT_SPIRIT_WALKER_ADEPT_TRAINING_FROSTWOLF, Unlimited);
    yield return new(UPGRADE_ROLF_AIRBORNE_TOXINS_FROSTWOLF, Unlimited);
    yield return new(UPGRADE_ROSP_SPIKED_BARRICADES_FROSTWOLF_FEL_HORDE_WARSONG, Unlimited);
    yield return new(UPGRADE_RORB_REINFORCED_DEFENSES_FROSTWOLF_FEL_HORDE_WARSONG, Unlimited);
    yield return new(UPGRADE_R00R_IMPROVED_CHAIN_LIGHTNING_FROSTWOLF, Unlimited);
    yield return new(UPGRADE_R00W_TOUGHENED_HIDES_FROSTWOLF, Unlimited);
    yield return new(UPGRADE_R01Z_PILLAGE_ECHO_ISLES, Unlimited);
    yield return new(UPGRADE_R09N_FLIGHT_PATH_WARSONG, 1);

    yield return new(UNIT_H00C_DREK_THAR_FROSTWOLF_DEMI, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_OTHR_WARCHIEF_OF_THE_HORDE_FROSTWOLF, 1, Destroyer);
    yield return new(UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_FROSTWOLF, 1, new List<UnitCategory> { Tank, Support });
    yield return new(UNIT_ORKN_CHIEFTAIN_OF_THE_DARKSPEAR_TRIBE_FROSTWOLF, 1, new List<UnitCategory> { Support });
    yield return new(UNIT_OREX_BEASTMASTER_FROSTWOLF, 1, Tank);
  }
}
