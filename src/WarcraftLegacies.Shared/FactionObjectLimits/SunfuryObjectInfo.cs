using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class SunfuryObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H02P_HOLDING_SUNFURY_T1, Unlimited, TownHall);
    yield return new(UNIT_H0C4_COVENANT_SUNFURY_T2, Unlimited, TownHall);
    yield return new(UNIT_H0C5_SANCTUARY_SUNFURY_T3, Unlimited, TownHall);
    yield return new(UNIT_H0C7_ARBORETUM_SUNFURY_FARM, 3, Farm);
    yield return new(UNIT_H0C8_FORGE_SUNFURY_RESEARCH, Unlimited, Research);
    yield return new(UNIT_H0C9_TRAINING_QUARTER_SUNFURY_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_H0CB_LYCEUM_ARCANUM_SUNFURY_MAGIC, Unlimited, Magic);
    yield return new(UNIT_H0CA_ANCIENT_POOL_SUNFURY_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_H0CI_ARTIFICER_S_COURT_SUNFURY_SIEGE, Unlimited, Specialist);
    yield return new(UNIT_H0C6_ALTAR_OF_BLOOD_SUNFURY_ALTAR, Unlimited, Altar);
    yield return new(UNIT_H0CC_SHAPER_S_HALL_SUNFURY_SHOP, Unlimited, Shop);
    yield return new(UNIT_H0CD_SCOUT_TOWER_SUNFURY_TOWER, Unlimited, Tower);
    yield return new(UNIT_N0E0_SKY_FURY_TOWER_SUNFURY_TOWER, Unlimited, Tower);
    yield return new(UNIT_N0E1_IMPROVED_SKY_FURY_TOWER_SUNFURY_TOWER, Unlimited, Tower);
    yield return new(UNIT_N0DZ_THE_WELL_OF_ETERNITY_SUNFURY_OTHER, 1, Unique);
    yield return new(UNIT_TP04_SHIPYARD_SUNFURY_SHIPYARD, Unlimited, Shipyard);

    yield return new(UNIT_N0E2_TECHNICIAN_SUNFURY_WORKER, Unlimited, Worker);
    yield return new(UNIT_N09S_CENTURION_SUNFURY, Unlimited, Tank);
    yield return new(UNIT_H0CF_BOWMAN_SUNFURY, Unlimited, Marksman);
    yield return new(UNIT_U02W_ENERGY_WAGON_SUNFURY, 2, Support);
    yield return new(UNIT_H0CH_ASTROMANCER_SUNFURY, Unlimited, Support);
    yield return new(UNIT_H0CG_FLAMEKEEPER_SUNFURY, Unlimited, Support);
    yield return new(UNIT_H0CE_BLOOD_KNIGHT_SQUIRE_SUNFURY, 12, Fighter);
    yield return new(UNIT_N0E3_WARLOCK_SUNFURY, 6, new List<UnitCategory> { Destroyer, Summoner });
    yield return new(UNIT_N0E4_SCORPION_SUNFURY, 6, Siege);
    yield return new(UNIT_N0E8_SKYSHIP_SUNFURY, 3, new List<UnitCategory> { Flyer, Marksman, Support });
    yield return new(UNIT_N0E7_BLOODWARDER_SUNFURY, 6, new List<UnitCategory> { Elite, Destroyer, Summoner, Tank });
    yield return new(UNIT_E01B_ARCANE_ANNIHILATOR_SUNFURY, 6, Marksman);
    yield return new(UNIT_N006_ANCIENT_OF_THE_ARCANE_SUNFURY, 2, new List<UnitCategory> { Destroyer, Summoner, Support, Tank });

    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);

    yield return new(UNIT_H098_SUNFURY_MASTERMIND_QUELTHALAS, 1, new List<UnitCategory> { Support });
    yield return new(UNIT_U02V_HIGH_ASTROMANCER_SUNFURY, 1, new List<UnitCategory> { Destroyer, Marksman });
    yield return new(UNIT_HKAL_PRINCE_OF_QUEL_THALAS_QUELTHALAS, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_U004_THE_DECEIVER_LEGION, 1, Destroyer);
    yield return new(UNIT_N0E5_VOID_REAVER_SUNFURY_DEMI, 1, new List<UnitCategory> { Tank, Support });

    yield return new(UPGRADE_R09H_ASTROMANCER_ADEPT_TRAINING_SUNFURY, Unlimited);
    yield return new(UPGRADE_R09G_FLAMEKEEPER_ADEPT_TRAINING_SUNFURY, Unlimited);
    yield return new(UPGRADE_R09U_SEAL_OF_BLOOD_SUNFURY, Unlimited);
  }
}
