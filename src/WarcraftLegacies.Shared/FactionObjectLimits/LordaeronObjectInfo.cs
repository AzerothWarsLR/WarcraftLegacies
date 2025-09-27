using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class LordaeronObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_HTOW_TOWN_HALL_LORDAERON_T1, Unlimited);
    yield return new(UNIT_HKEE_KEEP_LORDAERON_T2, Unlimited);
    yield return new(UNIT_HCAS_CASTLE_LORDAERON_T3, Unlimited);
    yield return new(UNIT_HHOU_FARM_LORDAERON_FARM, Unlimited);
    yield return new(UNIT_HALT_ALTAR_OF_KINGS_LORDAERON_ALTAR, Unlimited);
    yield return new(UNIT_HBAR_BARRACKS_LORDAERON_BARRACKS, Unlimited);
    yield return new(UNIT_HBLA_BLACKSMITH_LORDAERON_RESEARCH, Unlimited);
    yield return new(UNIT_H035_ARCANE_STUDY_LORDAERON_MAGIC, Unlimited);
    yield return new(UNIT_HWTW_SCOUT_TOWER_LORDAERON_TOWER, Unlimited);
    yield return new(UNIT_HGTW_GUARD_TOWER_LORDAERON_TOWER, Unlimited);
    yield return new(UNIT_H006_IMPROVED_GUARD_TOWER_LORDAERON_TOWER, Unlimited);
    yield return new(UNIT_HCTW_CANNON_TOWER_LORDAERON_TOWER, Unlimited);
    yield return new(UNIT_H007_IMPROVED_CANNON_TOWER_LORDAERON_TOWER, Unlimited);
    yield return new(UNIT_HSHY_SHIPYARD_LORDAERON_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(UNIT_NMRK_MARKETPLACE_LORDAERON_SHOP, Unlimited);
    yield return new(UNIT_H06C_HIGH_TOWER_LORDAERON_SPECIALIST, Unlimited);
    yield return new(UNIT_H094_SIEGE_WORKSHOP_LORDAERON_SIEGE, Unlimited);
    yield return new(UNIT_HPEA_PEASANT_LORDAERON_STORMWIND_WORKER, Unlimited);
    yield return new(UNIT_HFOO_FOOTMAN_LORDAERON, Unlimited);
    yield return new(UNIT_HKNI_KNIGHT_LORDAERON, Unlimited);
    yield return new(UNIT_NCHP_MAGE_LORDAERON, Unlimited);
    yield return new(UNIT_H00F_PALADIN_LORDAERON, 6);
    yield return new(UNIT_NWE2_THUNDER_EAGLE_LORDAERON, 6);
    yield return new(UNIT_H01C_HUNTSMAN_LORDAERON, Unlimited);
    yield return new(UNIT_N03K_PASTOR_LORDAERON, Unlimited);
    yield return new(UNIT_HCTH_SILVER_HAND_SQUIRE_LORDAERON, 12);
    yield return new(UNIT_H02Q_PEGASUS_KNIGHT_LORDAERON, 6);
    yield return new(UNIT_E017_SCORPION_LORDAERON, 8);
    yield return new(UNIT_O02F_MANGONEL_LORDAERON, 6);
    yield return new(UNIT_H09Y_THRONE_GUARD_LORDAERON, 2);
    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);
    yield return new(UNIT_H012_CAPTAIN_FALRIC_LORDAERON_DEMI, 1);
    yield return new(UNIT_HART_CROWN_PRINCE_OF_LORDAERON_LORDAERON, 1);
    yield return new(UNIT_HUTH_LEADER_OF_THE_SILVER_HAND_LORDAERON, 1);
    yield return new(UNIT_H01J_THE_ASHBRINGER_LORDAERON, 1);
    yield return new(UNIT_HLGR_GRAND_MARSHAL_SCARLET, 1);
    yield return new(UNIT_HARF_HIGH_KING_LORDAERON_HIGH_KING, 1);
    yield return new(UPGRADE_R02E_LIGHT_S_PRAISE_MASTER_TRAINING_ARATHOR_LORDAERON, Unlimited);
    yield return new(UPGRADE_R00I_MAGE_MASTER_TRAINING_LORDAERON, Unlimited);
    yield return new(UPGRADE_RHAN_ANIMAL_WAR_TRAINING_DARK_GREEN_PURPLE_RESEARCH, Unlimited);
    yield return new(
      UPGRADE_RHAC_IMPROVED_MASONRY_ADVANCED_MASONRY_IMBUED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH,
      Unlimited);
    yield return new(UPGRADE_R04D_SEAL_OF_RIGHTEOUSNESS_LORDAERON, Unlimited);
    yield return new(UPGRADE_R01P_ENSNARE_LORDAERON, Unlimited);
    yield return new(UPGRADE_R04A_RAPID_FIRE_LORDAERON, Unlimited);
    yield return new(UPGRADE_R00B_VETERAN_FOOTMEN_LORDAERON, Unlimited);
    yield return new(UPGRADE_R0XZ_THE_SCARLET_CRUSADE_LORDAERON_SCARLET, Unlimited);
  }
}
