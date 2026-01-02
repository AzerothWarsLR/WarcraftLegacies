using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class KultirasObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H062_TOWN_HALL_KULTIRAS_T1, Unlimited, TownHall);
    yield return new(UNIT_H064_KULTIRAS_T2, Unlimited, TownHall);
    yield return new(UNIT_H06I_CASTLE_KULTIRAS_T3, Unlimited, TownHall);
    yield return new(UNIT_H07N_HOMESTEAD_KULTIRAS_FARM, Unlimited, Farm);
    yield return new(UNIT_H07M_ALTAR_OF_ADMIRALS_KULTIRAS_ALTAR, Unlimited, Altar);
    yield return new(UNIT_H07R_SCOUT_TOWER_KULTIRAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H07S_GUARD_TOWER_KULTIRAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H07T_IMPROVED_GUARD_TOWER_KULTIRAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H07U_CANNON_TOWER_KULTIRAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H07V_IMPROVED_CANNON_TOWER_KULTIRAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H07O_BLACKSMITH_KULTIRAS_RESEARCH, Unlimited, Research);
    yield return new(UNIT_H07Q_SCHOOL_OF_THE_TIDES_KULTIRAS_MAGIC, Unlimited, Magic);
    yield return new(UNIT_N07H_TRADE_HOUSE_KULTIRAS_SHOP, Unlimited, Shop);
    yield return new(UNIT_H07W_SHIPYARD_KULTIRAS_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_H06R_GARRISON_KULTIRAS_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_H07P_KULTIRAS_SPECIALIST, Unlimited, SiegeWorkshop);
    yield return new(UNIT_H093_ORDER_CHAPTER_HOUSE_KULTIRAS_SIEGE, Unlimited, Specialist);

    yield return new(UNIT_H01E_DECKHAND_KULTIRAS_WORKER, Unlimited, Worker);
    yield return new(UNIT_E007_THORNSPEAKER_KULTIRAS, Unlimited, Support);
    yield return new(UNIT_N09A_EMBER_CLERIC_KULTIRAS, 12, Support);
    yield return new(UNIT_N09B_WITCH_HUNTER_KULTIRAS, 8, Marksman);
    yield return new(UNIT_H05K_TIDESAGE_KULTIRAS, Unlimited, new List<UnitCategory> { Support, Summoner });
    yield return new(UNIT_H041_MARINE_KULTIRAS, Unlimited, Tank);
    yield return new(UNIT_E00B_WICKERBEAST, Unlimited, Fighter);
    yield return new(UNIT_N07G_MUSKETEER_KULTIRAS, 6, new List<UnitCategory> { Elite, Marksman, Destroyer });
    yield return new(UNIT_N029_SEA_GIANT_KULTIRAS, 12, new List<UnitCategory> { Fighter, Destroyer });
    yield return new(UNIT_H06J_NAVY_SNIPER_KULTIRAS, Unlimited, Marksman);
    yield return new(UNIT_O01A_CANNON_KULTIRAS, 6, Siege);
    yield return new(UNIT_H04O_BOMBER_KULTIRAS, 12, new List<UnitCategory> { Flyer, Siege, Destroyer });
    yield return new(UNIT_H04W_SIEGE_TANK_KULTIRAS, 3, new List<UnitCategory> { Siege, AntiAir });
    yield return new(UNIT_H0A0_FUSILLIER_KULTIRAS, 8, Marksman);

    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);

    yield return new(UPGRADE_R001_RISING_TIDES_KUL_TIRAS_SEA_ELEMENTAL, Unlimited);
    yield return new(UPGRADE_R000_TIDESAGE_ADEPT_TRAINING_KUL_TIRAS, Unlimited);
    yield return new(UPGRADE_R01O_CRUSHING_WAVE_KUL_TIRAS_SEA_GIANT, Unlimited);
    yield return new(UPGRADE_R01T_CLUSTER_ROCKETS_KUL_TIRAS_BOMBER, Unlimited);
    yield return new(UPGRADE_R01U_PILLAGE_STONEMAUL, Unlimited);
    yield return new(UPGRADE_R05G_THORNSPEAKER_ADEPT_TRAINING_KULTIRAS, Unlimited);
    yield return new(UPGRADE_RHAC_IMPROVED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH, Unlimited);
    yield return new(UPGRADE_R08B_LONG_RIFLES_KUL_TIRAS, Unlimited);

    yield return new(UNIT_HAPM_LORD_ADMIRAL_OF_KUL_TIRAS_KULTIRAS, 1, new List<UnitCategory> { Support, Tank, Summoner });
    yield return new(UNIT_H05L_LADY_OF_HOUSE_PROUDMOORE_KULTIRAS, 1, new List<UnitCategory> { Marksman, Destroyer });
    yield return new(UNIT_U026_MATRIARCH_OF_HOUSE_WAYCREST_KULTIRAS, 1, Destroyer);
  }
}
