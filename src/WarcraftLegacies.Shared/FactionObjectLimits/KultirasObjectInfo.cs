using MacroTools.Shared;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class KultirasObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H062_TOWN_HALL_KULTIRAS_T1, Unlimited);
    yield return new(UNIT_H064_KULTIRAS_T2, Unlimited);
    yield return new(UNIT_H06I_CASTLE_KULTIRAS_T3, Unlimited);
    yield return new(UNIT_H07N_HOMESTEAD_KULTIRAS_FARM, Unlimited);
    yield return new(UNIT_H07M_ALTAR_OF_ADMIRALS_KULTIRAS_ALTAR, Unlimited);
    yield return new(UNIT_H07R_SCOUT_TOWER_KULTIRAS_TOWER, Unlimited);
    yield return new(UNIT_H07S_GUARD_TOWER_KULTIRAS_TOWER, Unlimited);
    yield return new(UNIT_H07T_IMPROVED_GUARD_TOWER_KULTIRAS_TOWER, Unlimited);
    yield return new(UNIT_H07U_CANNON_TOWER_KULTIRAS_TOWER, Unlimited);
    yield return new(UNIT_H07V_IMPROVED_CANNON_TOWER_KULTIRAS_TOWER, Unlimited);
    yield return new(UNIT_H07O_BLACKSMITH_KULTIRAS_RESEARCH, Unlimited);
    yield return new(UNIT_H07Q_SCHOOL_OF_THE_TIDES_KULTIRAS_MAGIC, Unlimited);
    yield return new(UNIT_N07H_TRADE_HOUSE_KULTIRAS_SHOP, Unlimited);
    yield return new(UNIT_H07W_SHIPYARD_KULTIRAS_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(UNIT_H06R_GARRISON_KULTIRAS_BARRACKS, Unlimited);
    yield return new(UNIT_H07P_KULTIRAS_SPECIALIST, Unlimited);
    yield return new(UNIT_H093_ORDER_CHAPTER_HOUSE_KULTIRAS_SIEGE, Unlimited);
    yield return new(UNIT_H01E_DECKHAND_KULTIRAS_WORKER, Unlimited);
    yield return new(UNIT_E007_THORNSPEAKER_KULTIRAS, Unlimited);
    yield return new(UNIT_N09A_EMBER_CLERIC_KULTIRAS, 12);
    yield return new(UNIT_N09B_WITCH_HUNTER_KULTIRAS, 8);
    yield return new(UNIT_H05K_TIDESAGE_KULTIRAS, Unlimited);
    yield return new(UNIT_H041_MARINE_KULTIRAS, Unlimited);
    yield return new(UNIT_E00B_WICKERBEAST, Unlimited);
    yield return new(UNIT_N009_REVENANT_SCOURGE, 12);
    yield return new(UNIT_N07G_MUSKETEER_KULTIRAS, 6);
    yield return new(UNIT_N029_SEA_GIANT_KULTIRAS, 12);
    yield return new(UNIT_H06J_NAVY_SNIPER_KULTIRAS, Unlimited);
    yield return new(UNIT_O01A_CANNON_KULTIRAS, 6);
    yield return new(UNIT_H04O_BOMBER_KULTIRAS, 12);
    yield return new(UNIT_H04W_SIEGE_TANK_KULTIRAS, 3);
    yield return new(UNIT_H0A0_FUSILLIER_KULTIRAS, 8);
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
    yield return new(UNIT_HAPM_LORD_ADMIRAL_OF_KUL_TIRAS_KULTIRAS, 1);
    yield return new(UNIT_H05L_LADY_OF_HOUSE_PROUDMOORE_KULTIRAS, 1);
    yield return new(UNIT_U026_MATRIARCH_OF_HOUSE_WAYCREST_KULTIRAS, 1);
  }
}
