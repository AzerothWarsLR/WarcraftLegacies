using MacroTools.Shared;
using static Constants;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

public static class DalaranObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    yield return new(UNIT_H065_REFUGE_DALARAN_T1, Unlimited, UnitCategory.TownHall);
    yield return new(UNIT_H066_CONCLAVE_DALARAN_T2, Unlimited); //Conclave
    yield return new(UNIT_H068_OBSERVATORY_DALARAN_T3, Unlimited); //Observatory
    yield return new(UNIT_H0A9_MANOR_GILNEAS_OTHER, Unlimited, UnitCategory.GilneasManor); //Greymane Manor
    yield return new(UNIT_H024_LIGHT_HOUSE_STORMWIND_OTHER, Unlimited, UnitCategory.LightHouse); // Lighthouse
    yield return new(UNIT_H063_ARCANE_WELL_DALARAN_FARM, Unlimited, UnitCategory.Farm); //farm
    yield return new(UNIT_H00I_WINDMILL_LORDAERON_OTHER, Unlimited, UnitCategory.SpecailFarm4); //farm
    yield return new(UNIT_H05P_DALARAN_BUILDING_DALARAN_OTHER_1, Unlimited, UnitCategory.SpecailFarm1); //farm in Dalaran
    yield return new(UNIT_H05Q_DALARAN_BUILDING_DALARAN_OTHER_2, Unlimited, UnitCategory.SpecailFarm2); //farm in Dalaran
    yield return new(UNIT_H05O_DALARAN_BUILDING_DALARAN_OTHER_3, Unlimited, UnitCategory.SpecailFarm3); //farm in Dalaran
    yield return new(UNIT_H044_ALTAR_OF_KNOWLEDGE_DALARAN_ALTAR, Unlimited, UnitCategory.Altar); //Altar of Knowledge
    yield return new(UNIT_H069_MILITARY_QUARTER_DALARAN_BARRACKS, Unlimited, UnitCategory.Barracks); //Barracks
    yield return new(UNIT_H02N_LUMBER_MILL_DALARAN_RESEARCH, Unlimited, UnitCategory.Research); //Lumber Mill
    yield return new(UNIT_H036_ARCANE_SANCTUARY_DALARAN_MAGIC, Unlimited, UnitCategory.Magic); //Arcane Sanctuary
    yield return new(UNIT_HVLT_ARCANE_VAULT_DALARAN_SHOP, Unlimited, UnitCategory.Shop); //Arcane Vault
    yield return new(UNIT_H076_SHIPYARD_DALARAN_SHIPYARD, Unlimited, UnitCategory.Shipyard); //Shipyeard
    yield return new(UNIT_H067_MANAFORGE_DALARAN_SPECIALIST, Unlimited, UnitCategory.Specialist); //Manaforge
    yield return new(UNIT_N0AO_WAY_GATE_DALARAN_SIEGE, 2, UnitCategory.Waygate); //Way Gate

    yield return new(UNIT_H078_SCOUT_TOWER_DALARAN_TOWER, Unlimited, UnitCategory.Tower); //Scout Tower
    yield return new(UNIT_H079_ARCANE_TOWER_DALARAN_TOWER, Unlimited, UnitCategory.Tower2); //Arcane Tower
    yield return new(UNIT_H07A_IMPROVED_ARCANE_TOWER_DALARAN_TOWER, Unlimited, UnitCategory.Tower3); //Arcane Tower (Improved)
    yield return new(UNIT_NDGT_KIRIN_TOR_TOWER_DALARAN_TOWER, Unlimited, UnitCategory.Tower4); //Dalaran Tower
    yield return new(UNIT_N004_IMPROVED_KIRIN_TOR_TOWER_DALARAN_TOWER, Unlimited, UnitCategory.Tower5); //Dalaran Tower (Improved)
    yield return new(UNIT_N03G_VIOLET_TOWER_DALARAN, Unlimited, UnitCategory.Tower6); //Violet Towers

    yield return new(UNIT_H022_FARMER_DALARAN_WORKER, Unlimited, UnitCategory.Worker); //worker
    yield return new(UNIT_NHYM_HYDROMANCER_DALARAN, Unlimited, UnitCategory.CasterBasic); //Hydromancer
    yield return new(UNIT_H032_BATTLEMAGE_DALARAN, Unlimited, UnitCategory.MeleeBasic); //Battlemage
    yield return new(UNIT_H02D_GEOMANCER_DALARAN, Unlimited, UnitCategory.CasterSupport); //Geomancer
    yield return new(UNIT_H01I_ARCANIST_DALARAN, Unlimited, UnitCategory.CasterAdvanced); //Arcanist
    yield return new(UNIT_N007_KIRIN_TOR_DALARAN_ELITE, 6, UnitCategory.Elite); //Kirin Tor
    yield return new(UNIT_N096_EARTH_GOLEM_DALARAN, 6, UnitCategory.MeleeSpecial); //Earth Golem
    yield return new(UNIT_N0AK_INITIATE_MAGE_DALARAN, Unlimited, UnitCategory.RangedBasic); //Initiate Mage
    yield return new(UNIT_O02U_CRYSTAL_ARTILLERY_DALARAN, 6, UnitCategory.Siege); //Crystal Artillery



    yield return new(UNIT_N0AC_BLUE_DRAGON_DALARAN, 6);
    yield return new(UNIT_HBOT_TRANSPORT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AR_SCOUT_SHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AX_FRIGATE_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B3_FIRESHIP_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B0_GALLEY_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B6_BOARDING_VESSEL_ALLIANCE, Unlimited);
    yield return new(UNIT_H0AN_JUGGERNAUT_ALLIANCE, Unlimited);
    yield return new(UNIT_H0B7_BOMBARD_ALLIANCE, 6);
    yield return new(UNIT_NJKS_JAILOR_KASSAN_DALARAN_DEMI, 1);
    yield return new(UNIT_HJAI_ARCHMAGE_OF_DALARAN_DALARAN, 1);
    yield return new(UNIT_HANT_GRAND_MAGUS_OF_THE_KIRIN_TOR_DALARAN, 1);
    yield return new(UNIT_H09N_MATRIARCH_OF_TIRISFAL_DALARAN, 1);
    yield return new(UNIT_HAAH_THE_FALLEN_GUARDIAN_DALARAN, 1);
    yield return new(UPGRADE_R01I_ARCANIST_GRANDMASTER_TRAINING_DALARAN, Unlimited);
    yield return new(UPGRADE_R01V_GEOMANCER_GRANDMASTER_TRAINING_DALARAN, Unlimited);
    yield return new(UPGRADE_R00E_HYDROMANCER_GRANDMASTER_TRAINING_DALARAN, Unlimited);
    yield return new(
      UPGRADE_RHAC_IMPROVED_MASONRY_ADVANCED_MASONRY_IMBUED_MASONRY_YELLOW_PURPLE_ORANGE_GREEN_DARK_GREEN_RESEARCH,
      Unlimited);
    yield return new(UPGRADE_R06J_IMPROVED_SLOW_DALARAN, Unlimited);
    yield return new(UPGRADE_R061_IMPROVED_FORKED_LIGHTNING_DALARAN, Unlimited);
    yield return new(UPGRADE_R06O_IMPROVED_PHASE_BLADE_DALARAN, Unlimited);
  }
}
