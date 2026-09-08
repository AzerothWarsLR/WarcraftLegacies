using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class TaurenTribesObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_OTNT_CHIEF_S_LODGE_TAUREN_TRIBES_T1, Unlimited, TownHall);
    yield return new(UNIT_OTWL_WARCHIEF_S_LODGE_TAUREN_TRIBES_T2, Unlimited, Keep);
    yield return new(UNIT_OTHL_HIGH_CHIEFTAIN_S_LODGE_TAUREN_TRIBES_T3, Unlimited, Castle);
    yield return new(UNIT_OTWC_PROVING_GROUND_TAUREN_TRIBES_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_OTSL_HALL_OF_ELDERS_TAUREN_TRIBES, Unlimited, Magic);
    yield return new(UNIT_OTBE_WYVERN_ROOST_TAUREN_TRIBES, Unlimited, Specialist);
    yield return new(UNIT_O006_OGRE_MOUND_TAUREN_TRIBES, Unlimited, SiegeWorkshop);
    yield return new(UNIT_OTWM_WAR_MILL_TAUREN_TRIBES_RESEARCH, Unlimited, Research);
    yield return new(UNIT_OTFM_TEPEE_TAUREN_TRIBES_FARM, Unlimited, Farm);
    yield return new(UNIT_OTSY_TAUREN_DOCKS_TAUREN_TRIBES_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_OTSH_BLOODHOOF_TRADING_POST_TAUREN_TRIBES_SHOP, Unlimited, Shop);
    yield return new(UNIT_OTTW_WATCH_TOWER_TAUREN_TRIBES_TOWER, Unlimited, Tower);
    yield return new(UNIT_OTT2_IMPROVED_WATCH_TOWER_TAUREN_TRIBES_TOWER_2, Unlimited, Tower);
    yield return new(UNIT_OTAL_ALTAR_OF_THE_ANCESTORS_TAUREN_TRIBES_ALTAR, Unlimited, Altar);

    yield return new(UNIT_OBOT_HORDE_TRANSPORT_SHIP_WARSONG_FROSTWOLF_FEL_HORDE_ORCISH_HORDE, Unlimited);
    yield return new(UNIT_H0AS_SCOUT_SHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AP_FRIGATE_HORDE, Unlimited);
    yield return new(UNIT_H0B2_FIRESHIP_HORDE, Unlimited);
    yield return new(UNIT_H0AY_GALLEY_HORDE, Unlimited);
    yield return new(UNIT_H0B5_BOARDING_VESSEL_HORDE, Unlimited);
    yield return new(UNIT_H0BC_JUGGERNAUT_HORDE, Unlimited);
    yield return new(UNIT_H0AO_BOMBARD_HORDE, 6);

    yield return new(UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_TAUREN_TRIBES, 1, new List<UnitCategory> { Tank, Support });
    yield return new(UNIT_OREX_BEASTMASTER_TAUREN_TRIBES, 1, Tank);

    yield return new(UPGRADE_R04R_NAVIGATION_UNIVERSAL_UPGRADE, Unlimited);
    yield return new(UPGRADE_R09N_FLIGHT_PATH_ORCISH_HORDE_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_ROSP_SPIKED_BARRICADES_FEL_HORDE_ORCISH_HORDE_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RORB_REINFORCED_DEFENSES_FEL_HORDE_ORCISH_HORDE_TAUREN_TRIBES, Unlimited);

    yield return new(UNIT_VP51_TAUREN_CHIEFTAIN_TAUREN_TRIBES_ELITE, 0, new List<UnitCategory> { Elite, Fighter });
    yield return new(UNIT_VP52_OGRE_LORD_TAUREN_TRIBES_ELITE, 0, new List<UnitCategory> { Elite, Destroyer });
    yield return new(UNIT_VP56_SUNWALKER_CHAMPION_TAUREN_TRIBES_ELITE, 6, new List<UnitCategory> { Elite, Support });

    yield return new(UNIT_OTAU_TAUREN_TAUREN_TRIBES, Unlimited, Tank);
    yield return new(UNIT_N049_BLUFFWATCHER_TAUREN_TRIBES, Unlimited, Marksman);
    yield return new(UNIT_OKOD_KODO_BEAST_TAUREN_TRIBES, 6, Support);
    yield return new(UNIT_VP59_BRAVE_WORKER_TAUREN_TRIBES_WORKER, Unlimited, Builder);

    yield return new(UNIT_VP54_EARTHCALLER_TAUREN_TRIBES, Unlimited, Support);
    yield return new(UNIT_OSPW_SPIRIT_WALKER_TAUREN_TRIBES, Unlimited, Support);
    yield return new(UNIT_VP57_ANCESTRAL_SPIRIT_TAUREN_TRIBES, 3, AntiMage);

    yield return new(UNIT_OWYV_WYVERN_TAUREN_TRIBES, 8, new List<UnitCategory> { Flyer, AntiAir });
    yield return new(UNIT_VP55_EAGLE_SPIRIT_TAUREN_TRIBES, 4, new List<UnitCategory> { Flyer, Fighter });

    yield return new(UNIT_VP50_OGRE_STONE_THROWER_TAUREN_TRIBES, 6, Siege);
    yield return new(UNIT_N08O_OGRE_MAGI_TAUREN_TRIBES, 12, Support);
    yield return new(UNIT_VP58_OGRE_CRUSHER_TAUREN_TRIBES, Unlimited, Destroyer);

    yield return new(UPGRADE_RT01_TAUREN_CHIEFTAINS_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT02_OGRE_LORDS_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT03_RITE_OF_STRENGTH_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT04_RITE_OF_VISION_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT05_EARTHCALLER_ADEPT_TRAINING_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT06_SPIRIT_WALKER_ADEPT_TRAINING_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT07_OGRE_MAGI_ADEPT_TRAINING_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT08_TARGET_PRACTICE_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT09_WAR_DRUMS_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT10_GUIDING_WINDS_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT11_STINGING_TAIL_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT12_MONSTROUS_STRENGTH_TAUREN_TRIBES, Unlimited);
    yield return new(UPGRADE_RT13_MASS_BLOODLUST_TAUREN_TRIBES, Unlimited);
  }
}
