using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class ScarletCrusadeObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H0BM_TOWN_HALL_SCARLET_T1, Unlimited, TownHall);
    yield return new(UNIT_H0BN_SCARLET_T2, Unlimited, Keep);
    yield return new(UNIT_H0BO_CASTLE_SCARLET_T3, Unlimited, Castle);
    yield return new(UNIT_H0BP_FARMSTEAD_SCARLET_FARM, Unlimited, Farm);
    yield return new(UNIT_H0A3_BLACKSMITH_SCARLET_RESEARCH, Unlimited, Research);
    yield return new(UNIT_H09X_SHIPYARD_SCARLET_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_H0AG_HALL_OF_SWORDS_SCARLET_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_H0BE_STUDIUM_SCARLET_MAGIC, Unlimited, Magic);
    yield return new(UNIT_H0BL_ROOKERY_SCARLET_BEAST, Unlimited, FlyingBuilding);
    yield return new(UNIT_N035_DIVINE_BASTION_SCARLET_SPECIAL, 1, Specialist);
    yield return new(UNIT_H0BI_BOMBARD_TOWER_SCARLET_TOWER, Unlimited, Tower);
    yield return new(UNIT_H0BJ_IMPROVED_BOMBARD_TOWER_SCARLET_TOWER, Unlimited, Tower);
    yield return new(UNIT_H0BQ_ALTAR_OF_CRUSADERS_SCARLET_ALTAR, Unlimited, Altar);
    yield return new(UNIT_N0D8_VENDOR_HALL_SCARLET_SHOP, Unlimited, Shop);
    yield return new(UNIT_H022_FARMER_DALARAN_WORKER, Unlimited, Worker);
    yield return new(UNIT_H06B_TEMPLAR_LORDAERON, 6, new List<UnitCategory> { Elite, Fighter, Tank, Support });
    yield return new(UNIT_H08I_CRUSADER_SCARLET, Unlimited, Tank);
    yield return new(UNIT_H09P_LONGBOWMAN_SCARLET, Unlimited, Marksman);
    yield return new(UNIT_H08L_CAVALIER_SCARLET, Unlimited, Fighter);
    yield return new(UNIT_N068_INQUISITOR_SCARLET, Unlimited, Support);
    yield return new(UNIT_H08K_MONK_SCARLET, Unlimited, Support);
    yield return new(UNIT_N09N_BISHOP_OF_THE_LIGHT_SCARLET, 6, Support);
    yield return new(UNIT_H09Q_CRIMSON_COMMANDER_SCARLET, 8, new List<UnitCategory> { Tank, Summoner });
    yield return new(UNIT_O06V_EAGLE_RIDER_SCARLET, 6, new List<UnitCategory> { Flyer, Marksman });
    yield return new(UNIT_E01L_GRYPHON_MARKSMAN_SCARLET, 6, new List<UnitCategory> { Flyer, Marksman });
    yield return new(UNIT_O04C_SERAPHIM_SCARLET, 6, Fighter);
    yield return new(UNIT_O00X_ARCHANGEL_SCARLET, 3, Fighter);

    yield return new(UNIT_H08G_GRAND_CRUSADER_SCARLET, 1, Support);
    yield return new(UNIT_H0A2_SCARLET_COMMANDER_SCARLET, 1, new List<UnitCategory> { Support, Destroyer });
    yield return new(UNIT_H08H_HIGH_INQUISITOR_SCARLET, 1, Support);
    yield return new(UNIT_H00Y_HIGH_GENERAL_SCARLET, 1, Destroyer);

    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);

    yield return new(UPGRADE_R05D_MONK_ADEPT_TRAINING_SCARLET, Unlimited);
    yield return new(UPGRADE_R04F_INQUISITOR_INITIATE_TRAINING_SCARLET_CRUSADE, Unlimited);
    yield return new(UPGRADE_RHSE_MAGIC_SENTRY, Unlimited);
    yield return new(
      UPGRADE_RHAC_IMPROVED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH,
      Unlimited);
  }
}
