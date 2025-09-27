using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class SunfuryObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H02P_HOLDING_SUNFURY_T1, Unlimited, UnitCategory.TownHall);
    yield return new(UNIT_H0C4_COVENANT_SUNFURY_T2, Unlimited);
    yield return new(UNIT_H0C5_SANCTUARY_SUNFURY_T3, Unlimited);
    yield return new(UNIT_H0C7_ARBORETUM_SUNFURY_FARM, 3);
    yield return new(UNIT_H0C8_FORGE_SUNFURY_RESEARCH, Unlimited);
    yield return new(UNIT_H0C9_TRAINING_QUARTER_SUNFURY_BARRACKS, Unlimited);
    yield return new(UNIT_H0CB_LYCEUM_ARCANUM_SUNFURY_MAGIC, Unlimited);
    yield return new(UNIT_H0CA_ANCIENT_POOL_SUNFURY_SPECIALIST, Unlimited);
    yield return new(UNIT_H0CI_ARTIFICER_S_COURT_SUNFURY_SIEGE, Unlimited);
    yield return new(UNIT_H0C6_ALTAR_OF_BLOOD_SUNFURY_ALTAR, Unlimited);
    yield return new(UNIT_H0CC_SHAPER_S_HALL_SUNFURY_SHOP, Unlimited);
    yield return new(UNIT_H0CD_SCOUT_TOWER_SUNFURY_TOWER, Unlimited);
    yield return new(UNIT_N0E0_SKY_FURY_TOWER_SUNFURY_TOWER, Unlimited);
    yield return new(UNIT_N0E1_IMPROVED_SKY_FURY_TOWER_SUNFURY_TOWER, Unlimited);
    yield return new(UNIT_N0DZ_THE_WELL_OF_ETERNITY_SUNFURY_OTHER, 1);
    yield return new(UNIT_TP04_SHIPYARD_SUNFURY_SHIPYARD, Unlimited, UnitCategory.Shipyard);
    yield return new(UNIT_N0E2_TECHNICIAN_SUNFURY_WORKER, Unlimited, UnitCategory.Worker);
    yield return new(UNIT_N09S_CENTURION_SUNFURY, Unlimited);
    yield return new(UNIT_H0CF_BOWMAN_SUNFURY, Unlimited);
    yield return new(UNIT_U02W_ENERGY_WAGON_SUNFURY, 2);
    yield return new(UNIT_H0CH_ASTROMANCER_SUNFURY, Unlimited);
    yield return new(UNIT_H0CG_FLAMEKEEPER_SUNFURY, Unlimited);
    yield return new(UNIT_H0CE_BLOOD_KNIGHT_SQUIRE_SUNFURY, 12);
    yield return new(UNIT_N0E3_WARLOCK_SUNFURY, 6);
    yield return new(UNIT_N0E4_SCORPION_SUNFURY, 6);
    yield return new(UNIT_N0E8_SKYSHIP_SUNFURY, 3);
    yield return new(UNIT_N0E7_BLOODWARDER_SUNFURY, 6);
    yield return new(UNIT_E01B_ARCANE_ANNIHILATOR_SUNFURY, 6);
    yield return new(UNIT_N006_ANCIENT_OF_THE_ARCANE_SUNFURY, 2);
    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);
    yield return new(UNIT_H098_SUNFURY_MASTERMIND_HIGH_ELVES, 1);
    yield return new(UNIT_U02V_HIGH_ASTROMANCER_SUNFURY, 1);
    yield return new(UNIT_HKAL_PRINCE_OF_QUEL_THALAS_QUEL_THALAS, 1);
    yield return new(UNIT_U004_THE_DECEIVER_LEGION, 1);
    yield return new(UNIT_N0E5_VOID_REAVER_SUNFURY_DEMI, 1);
    yield return new(UPGRADE_R09H_ASTROMANCER_MASTER_TRAINING_SUNFURY, Unlimited);
    yield return new(UPGRADE_R09G_FLAMEKEEPER_MASTER_TRAINING_SUNFURY, Unlimited);
    yield return new(UPGRADE_R09U_SEAL_OF_BLOOD_SUNFURY, Unlimited);
  }
}
