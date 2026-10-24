using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

/// <summary>Theramore's roster: Dalaran's buildings with Theramore's own mages, Kul Tiran soldiers and storm sorcerers, led by Jaina, Marcus Jonathan and Garran Vimes.</summary>
public static class TheramoreObjectInfo
{
  private const int Unlimited = 200;
  private const int SpecialistLimit = 4;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    foreach (var objectInfo in DalaranObjectInfo.GetAllObjectLimits())
    {
      if (!IsExcluded(objectInfo.ObjectTypeId))
      {
        yield return objectInfo;
      }
    }

    yield return new(UNIT_H0DA_BASTION_THERAMORE_SPECIALIST, Unlimited, Specialist);
    yield return new(UNIT_H041_MARINE_KULTIRAS, Unlimited, Fighter);
    yield return new(UNIT_H0D7_NAVY_SNIPER_THERAMORE, Unlimited, Marksman);
    yield return new(UNIT_H0D6_ARCANIST_THERAMORE, Unlimited, Support);
    yield return new(UNIT_H0D0_TIDESAGE_THERAMORE, Unlimited, Support);
    yield return new(UPGRADE_R10G_TIDESAGE_ADEPT_TRAINING_THERAMORE, Unlimited);
    yield return new(UNIT_H0D9_BOSUN_THERAMORE, SpecialistLimit, Tank);
    yield return new(UNIT_H0D8_CANNON_THERAMORE, SpecialistLimit, Siege);
    yield return new(UNIT_H0D4_STORM_SORCERER_THERAMORE_ELITE, SpecialistLimit, new List<UnitCategory> { Elite, Destroyer });
    yield return new(UNIT_H0D1_GENERAL_OF_THERAMORE_THERAMORE, 1, new List<UnitCategory> { Tank, Fighter });
    yield return new(UNIT_H0D2_CAPTAIN_OF_THE_THERAMORE_GUARD_THERAMORE, 1, new List<UnitCategory> { Marksman, Assassin });
  }

  private static bool IsExcluded(int objectTypeId) =>
    objectTypeId == UNIT_HANT_GRAND_MAGUS_OF_THE_KIRIN_TOR_DALARAN ||
    objectTypeId == UNIT_H09N_MATRIARCH_OF_TIRISFAL_DALARAN ||
    objectTypeId == UNIT_HAAH_THE_FALLEN_GUARDIAN_DALARAN ||
    objectTypeId == UNIT_N007_KIRIN_TOR_DALARAN_ELITE ||
    objectTypeId == UNIT_H032_BATTLEMAGE_DALARAN ||
    objectTypeId == UNIT_NHYM_HYDROMANCER_DALARAN ||
    objectTypeId == UNIT_H02D_GEOMANCER_DALARAN ||
    objectTypeId == UNIT_H01I_ARCANIST_DALARAN ||
    objectTypeId == UNIT_N0AK_INITIATE_MAGE_DALARAN ||
    objectTypeId == UNIT_N096_EARTH_GOLEM_DALARAN ||
    objectTypeId == UNIT_N0AC_BLUE_DRAGON_DALARAN ||
    objectTypeId == UNIT_O02U_CRYSTAL_ARTILLERY_DALARAN ||
    objectTypeId == UNIT_N0AO_WAY_GATE_DALARAN_SIEGE ||
    objectTypeId == UNIT_H067_MANAFORGE_DALARAN_SPECIALIST ||
    objectTypeId == UNIT_H0A9_MANOR_GILNEAS_OTHER ||
    objectTypeId == UPGRADE_R06O_IMPROVED_PHASE_BLADE_DALARAN ||
    objectTypeId == UPGRADE_R06J_IMPROVED_SLOW_DALARAN ||
    objectTypeId == UPGRADE_R00E_HYDROMANCER_ADEPT_TRAINING_DALARAN ||
    objectTypeId == UPGRADE_R01V_GEOMANCER_ADEPT_TRAINING_DALARAN ||
    objectTypeId == UPGRADE_RDTP_TELEPORTATION_DALARAN;
}
