using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class GilneasObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H01R_TOWN_HALL_GILNEAS_T1, Unlimited, TownHall);
    yield return new(UNIT_H023_GILNEAS_T2, Unlimited, Keep);
    yield return new(UNIT_H02C_CASTLE_GILNEAS_T3, Unlimited, Castle);
    yield return new(UNIT_H0A9_MANOR_GILNEAS_OTHER, Unlimited, GilneasManor);
    yield return new(UNIT_H024_LIGHT_HOUSE_STORMWIND_OTHER, Unlimited, Lighthouse);
    yield return new(UNIT_H02F_HOUSEHOLD_GILNEAS_FARM, Unlimited, Farm);
    yield return new(UNIT_H01T_INN_LORDAERON_OTHER, Unlimited, Farm);
    yield return new(UNIT_H05P_DALARAN_BUILDING_DALARAN_OTHER_1, Unlimited, Farm);
    yield return new(UNIT_H05Q_DALARAN_BUILDING_DALARAN_OTHER_2, Unlimited, Farm);
    yield return new(UNIT_H05O_DALARAN_BUILDING_DALARAN_OTHER_3, Unlimited, Farm);
    yield return new(UNIT_H02X_ALTAR_OF_KINGS_GILNEAS_ALTAR, Unlimited, Altar);
    yield return new(UNIT_H03D_TEMPLE_OF_THE_CURSED_GILNEAS_MAGIC, Unlimited, Magic);
    yield return new(UNIT_H03E_WORGEN_MANOR_GILNEAS_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_N008_TRADE_HOUSE_GILNEAS_SHOP, Unlimited, Shop);
    yield return new(UNIT_H03H_SHIPYARD_GILNEAS_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_H03O_BLACKSMITH_GILNEAS_RESEARCH, Unlimited, Research);
    yield return new(UNIT_H03Q_CITY_WATCH_GILNEAS_BARRACKS, Unlimited, Barracks);

    yield return new(UNIT_H039_SCOUT_TOWER_GILNEAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H03A_GUARD_TOWER_GILNEAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H03B_CANNON_TOWER_GILNEAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H052_IMPROVED_GUARD_TOWER_GILNEAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_H04N_IMPROVED_CANNON_TOWER_GILNEAS_TOWER, Unlimited, Tower);
    yield return new(UNIT_N03G_VIOLET_TOWER_DALARAN, Unlimited, Tower);

    yield return new(UNIT_HPEA_PEASANT_LORDAERON_STORMWIND_WORKER, Unlimited, Worker);
    yield return new(UNIT_H04M_CLERIC_GILNEAS, Unlimited, Support);
    yield return new(UNIT_N06K_DRUID_OF_THE_SCYTHE_GILNEAS, Unlimited, Support);
    yield return new(UNIT_H04X_HARVEST_WITCH_GILNEAS, 6, Support);
    yield return new(UNIT_O06P_WORGEN_SHAMAN_GILNEAS, 6, Support);

    yield return new(UNIT_H04E_PROTECTOR_GILNEAS, Unlimited, Fighter);
    yield return new(UNIT_N06L_ARMORED_WOLF_GILNEAS, Unlimited, Fighter);
    yield return new(UNIT_O01V_GREYGUARD_GILNEAS, 6, new List<UnitCategory> { Tank, Elite });
    yield return new(UNIT_O02J_WORGEN_GILNEAS, 12, Fighter);

    yield return new(UNIT_H03L_SHOTGUNNER_GILNEAS, Unlimited, Marksman);
    yield return new(UNIT_O04U_CYCLONE_CANNON_GILNEAS, 6, Siege);

    yield return new(UNIT_E01E_ANCIENT_GUARDIAN_GILNEAS, 1, new List<UnitCategory> { Fighter, Support });
    yield return new(UNIT_TGGN_PRINCESS_OF_GILNEAS_GILNEAS, 1, new List<UnitCategory> { Marksman, Assassin });
    yield return new(UNIT_HHKL_KING_OF_GILNEAS_GILNEAS, 1, new List<UnitCategory> { Tank, Support });
    yield return new(UNIT_HPB2_GILNEAN_LORD_GILNEAS, 1, new List<UnitCategory> { Fighter, Support });

    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);
    yield return new(UPGRADE_R04O_CLERIC_ADEPT_TRAINING_GILNEAS, Unlimited);
    yield return new(UPGRADE_R04P_DRUID_OF_THE_SCYTHE_ADEPT_TRAINING_GILNEAS, Unlimited);
    yield return new(
      UPGRADE_RHAC_IMPROVED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH,
      Unlimited);
    yield return new(UPGRADE_R09M_HARVEST_WITCH_ADEPT_TRAINING_GILNEAS, Unlimited);
  }
}
