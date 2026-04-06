using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class HordeObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_OGRE_GREAT_HALL_HORDE_T1, Unlimited, TownHall);
    yield return new(UNIT_OSTR_STRONGHOLD_HORDE_T2, Unlimited, Keep);
    yield return new(UNIT_OFRT_FORTRESS_HORDE_T3, Unlimited, Castle);
    yield return new(UNIT_OALT_ALTAR_OF_STORMS_HORDE_ALTAR, Unlimited, Altar);
    yield return new(UNIT_OBAR_WAR_CAMP_HORDE_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_OFOR_WAR_MILL_HORDE_RESEARCH, Unlimited, Research);
    yield return new(UNIT_OTTO_TAUREN_TOTEM_HORDE_SPECIALIST, Unlimited, SiegeWorkshop);
    yield return new(UNIT_OSLD_SPIRIT_LODGE_HORDE_MAGIC, Unlimited, Magic);
    yield return new(UNIT_OTRB_BURROW_HORDE_FARM, Unlimited, Farm);
    yield return new(UNIT_OWTW_WATCH_TOWER_HORDE_TOWER, Unlimited, Tower);
    yield return new(UNIT_O002_IMPROVED_WATCH_TOWER_HORDE_TOWER_2, Unlimited, Tower);
    yield return new(UNIT_NBT2_IMPROVED_BOULDER_TOWER, Unlimited, Tower);
    yield return new(UNIT_OVLN_VOODOO_LOUNGE_HORDE_SHOP, Unlimited, Shop);
    yield return new(UNIT_OSHY_HORDE_PIER_HORDE_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_OBEA_BEASTIARY_HORDE_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_N06Z_FLIGHT_PATH_HORDE, 1, Teleport);
    yield return new(UNIT_OPEO_PEON_HORDE_WORKER, Unlimited, Builder);
    yield return new(UNIT_NTT2_TAUREN_TENT_HORDE_OTHER, Unlimited, Farm);
    yield return new(UNIT_H004_TROLL_HUT_HORDE_FARM, Unlimited, Farm);

    yield return new(UNIT_OGRU_GRUNT_HORDE, Unlimited, Fighter);
    yield return new(UNIT_OTAU_TAUREN_HORDE, Unlimited, Tank);
    yield return new(UNIT_OHUN_HEADHUNTER_HORDE, Unlimited, Marksman);
    yield return new(UNIT_OCAT_CATAPULT_HORDE, 6, Siege);
    yield return new(UNIT_OTBR_BATRIDER_HORDE, 12, Flyer);
    yield return new(UNIT_ODOC_WITCH_DOCTOR_HORDE, Unlimited, Support);
    yield return new(UNIT_OSHM_SHAMAN_HORDE, Unlimited, Support);
    yield return new(UNIT_OSPW_SPIRIT_WALKER_HORDE, Unlimited, Support);
    yield return new(UNIT_OBOT_HORDE_TRANSPORT_SHIP_HORDE_FEL_HORDE, Unlimited);
    yield return new(UNIT_H0AS_SCOUT_SHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AP_FRIGATE_HORDE, Unlimited);
    yield return new(UNIT_H0B2_FIRESHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AY_GALLEY_HORDE, Unlimited);
    yield return new(UNIT_H0B5_BOARDING_VESSEL_HORDE, Unlimited);
    yield return new(UNIT_H0BC_JUGGERNAUT_HORDE, Unlimited);
    yield return new(UNIT_H0AO_BOMBARD_HORDE, 6);

    yield return new(UPGRADE_ROWS_IMPROVED_PULVERIZE_HORDE, Unlimited);
    yield return new(UPGRADE_ROST_SHAMAN_ADEPT_TRAINING_HORDE, Unlimited);
    yield return new(UPGRADE_ROWD_WITCH_DOCTOR_ADEPT_TRAINING_HORDE, Unlimited);
    yield return new(UPGRADE_ROLF_AIRBORNE_TOXINS_HORDE, Unlimited);
    yield return new(UPGRADE_ROSP_SPIKED_BARRICADES_HORDE_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_RORB_REINFORCED_DEFENSES_HORDE_FEL_HORDE, Unlimited);
    yield return new(UPGRADE_R00W_TOUGHENED_HIDES_HORDE, Unlimited);
    yield return new(UPGRADE_R09N_FLIGHT_PATH_HORDE, 1);

    yield return new(UNIT_OTHR_WARCHIEF_OF_THE_HORDE_HORDE, 1, new List<UnitCategory> { Destroyer, Summoner });
    yield return new(UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_HORDE, 1, new List<UnitCategory> { Tank, Support });
    yield return new(UNIT_ORKN_CHIEFTAIN_OF_THE_DARKSPEAR_TRIBE_HORDE, 1, new List<UnitCategory> { Support });
  }
}
