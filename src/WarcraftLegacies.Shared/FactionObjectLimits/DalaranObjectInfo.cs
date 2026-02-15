using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class DalaranObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H065_REFUGE_DALARAN_T1, Unlimited, TownHall);
    yield return new(UNIT_H066_CONCLAVE_DALARAN_T2, Unlimited, Keep);
    yield return new(UNIT_H068_OBSERVATORY_DALARAN_T3, Unlimited, Castle);
    yield return new(UNIT_H0A9_MANOR_GILNEAS_OTHER, Unlimited, GilneasManor);
    yield return new(UNIT_H024_LIGHT_HOUSE_STORMWIND_OTHER, Unlimited, Lighthouse);
    yield return new(UNIT_H063_ARCANE_WELL_DALARAN_FARM, Unlimited, Farm);
    yield return new(UNIT_H00I_WINDMILL_LORDAERON_OTHER, Unlimited, Farm);
    yield return new(UNIT_H05P_DALARAN_BUILDING_DALARAN_OTHER_1, Unlimited, Farm);
    yield return new(UNIT_H05Q_DALARAN_BUILDING_DALARAN_OTHER_2, Unlimited, Farm);
    yield return new(UNIT_H05O_DALARAN_BUILDING_DALARAN_OTHER_3, Unlimited, Farm);
    yield return new(UNIT_H044_ALTAR_OF_KNOWLEDGE_DALARAN_ALTAR, Unlimited, Altar);
    yield return new(UNIT_H069_MILITARY_QUARTER_DALARAN_BARRACKS, Unlimited, Barracks);
    yield return new(UNIT_H02N_LUMBER_MILL_DALARAN_RESEARCH, Unlimited, Research);
    yield return new(UNIT_H036_ARCANE_SANCTUARY_DALARAN_MAGIC, Unlimited, Magic);
    yield return new(UNIT_HVLT_ARCANE_VAULT_DALARAN_SHOP, Unlimited, Shop);
    yield return new(UNIT_H076_SHIPYARD_DALARAN_SHIPYARD, Unlimited, Shipyard);
    yield return new(UNIT_H067_MANAFORGE_DALARAN_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_N0AO_WAY_GATE_DALARAN_SIEGE, 2, Waygate);

    yield return new(UNIT_H078_SCOUT_TOWER_DALARAN_TOWER, Unlimited, Tower);
    yield return new(UNIT_H079_ARCANE_TOWER_DALARAN_TOWER, Unlimited, Tower);
    yield return new(UNIT_H07A_IMPROVED_ARCANE_TOWER_DALARAN_TOWER, Unlimited, Tower);
    yield return new(UNIT_NDGT_KIRIN_TOR_TOWER_DALARAN_TOWER, Unlimited, Tower);
    yield return new(UNIT_N004_IMPROVED_KIRIN_TOR_TOWER_DALARAN_TOWER, Unlimited, Tower);
    yield return new(UNIT_N03G_VIOLET_TOWER_DALARAN, Unlimited, Tower);

    yield return new(UNIT_H022_FARMER_DALARAN_WORKER, Unlimited, Worker);
    yield return new(UNIT_NHYM_HYDROMANCER_DALARAN, Unlimited, Support);
    yield return new(UNIT_H032_BATTLEMAGE_DALARAN, Unlimited, Fighter);
    yield return new(UNIT_H02D_GEOMANCER_DALARAN, Unlimited, Support);
    yield return new(UNIT_H01I_ARCANIST_DALARAN, Unlimited, Support);
    yield return new(UNIT_N007_KIRIN_TOR_DALARAN_ELITE, 6, new List<UnitCategory> { Elite, Destroyer });
    yield return new(UNIT_N096_EARTH_GOLEM_DALARAN, 6, Tank);
    yield return new(UNIT_N0AK_INITIATE_MAGE_DALARAN, Unlimited, new List<UnitCategory> { Marksman, Support });
    yield return new(UNIT_O02U_CRYSTAL_ARTILLERY_DALARAN, 6, Siege);
    yield return new(UNIT_N0AC_BLUE_DRAGON_DALARAN, 6, Flyer);

    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);

    yield return new(UNIT_NJKS_JAILOR_KASSAN_DALARAN_DEMI, 1, Fighter);
    yield return new(UNIT_HJAI_ARCHMAGE_OF_DALARAN_DALARAN, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_HANT_GRAND_MAGUS_OF_THE_KIRIN_TOR_DALARAN, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_H09N_MATRIARCH_OF_TIRISFAL_DALARAN, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_HAAH_THE_FALLEN_GUARDIAN_DALARAN, 1, Marksman);

    yield return new(UPGRADE_R01I_ARCANIST_ADEPT_TRAINING_DALARAN, Unlimited);
    yield return new(UPGRADE_R01V_GEOMANCER_ADEPT_TRAINING_DALARAN, Unlimited);
    yield return new(UPGRADE_R00E_HYDROMANCER_ADEPT_TRAINING_DALARAN, Unlimited);
    yield return new(
      UPGRADE_RHAC_IMPROVED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH,
      Unlimited);
    yield return new(UPGRADE_R06J_IMPROVED_SLOW_DALARAN, Unlimited);
    yield return new(UPGRADE_R061_IMPROVED_FORKED_LIGHTNING_DALARAN, Unlimited);
    yield return new(UPGRADE_R06O_IMPROVED_PHASE_BLADE_DALARAN, Unlimited);
  }
}
