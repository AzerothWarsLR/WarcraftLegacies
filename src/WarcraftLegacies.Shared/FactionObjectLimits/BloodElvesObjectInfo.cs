using MacroTools.Shared;
using static MacroTools.Shared.UnitCategory;

namespace WarcraftLegacies.Shared.FactionObjectLimits;

/// <summary>The Blood Elves' roster: the Sunfury's buildings with Blood Elf units that use ordinary mana, led by Kael'thas, Rommath and Solarian.</summary>
public static class BloodElvesObjectInfo
{
  private const int Unlimited = 200;

  public static IEnumerable<ObjectInfo> GetAllObjectLimits()
  {
    foreach (var objectInfo in SunfuryObjectInfo.GetAllObjectLimits())
    {
      if (!IsExcluded(objectInfo.ObjectTypeId))
      {
        yield return objectInfo;
      }
    }

    yield return new(UNIT_H0DB_CENTURION_BLOODELVES, Unlimited, Tank);
    yield return new(UNIT_H0DC_BOWMAN_BLOODELVES, Unlimited, Marksman);
    yield return new(UNIT_H0DN_ARCANE_WAGON_BLOODELVES, 2, Support);
    yield return new(UNIT_H0DD_ASTROMANCER_BLOODELVES, Unlimited, Support);
    yield return new(UNIT_H0DE_FLAMEKEEPER_BLOODELVES, Unlimited, Support);
    yield return new(UNIT_H0DF_BLOOD_KNIGHT_SQUIRE_BLOODELVES, 12, Fighter);
    yield return new(UNIT_H0DK_SPELLBREAKER_BLOODELVES, Unlimited, AntiMage);
    yield return new(UNIT_H0DM_BLOOD_MAGE_BLOODELVES, 6, new List<UnitCategory> { Destroyer, Summoner });
    yield return new(UNIT_H0DG_SCORPION_BLOODELVES, 6, Siege);
    yield return new(UNIT_H0DL_DRAGONHAWK_RIDER_BLOODELVES, 6, new List<UnitCategory> { Flyer, Support });
    yield return new(UPGRADE_R10J_CLOUD_BLOODELVES, Unlimited);
    yield return new(UNIT_H0DH_BLOODWARDER_BLOODELVES, 6, new List<UnitCategory> { Elite, Destroyer, Summoner, Tank });
    yield return new(UNIT_H0DI_PRINCE_OF_QUEL_THALAS_BLOODELVES, 1, new List<UnitCategory> { Destroyer, Support });
    yield return new(UNIT_H04F_ARCHMAGE_QUELTHALAS, 1, Support);
    yield return new(UNIT_H0DJ_HIGH_ASTROMANCER_BLOODELVES, 1, new List<UnitCategory> { Destroyer, Marksman });
  }

  private static bool IsExcluded(int objectTypeId) =>
    objectTypeId == UNIT_N09S_CENTURION_SUNFURY ||
    objectTypeId == UNIT_H0CF_BOWMAN_SUNFURY ||
    objectTypeId == UNIT_U02W_ENERGY_WAGON_SUNFURY ||
    objectTypeId == UNIT_H0CH_ASTROMANCER_SUNFURY ||
    objectTypeId == UNIT_H0CG_FLAMEKEEPER_SUNFURY ||
    objectTypeId == UNIT_H0CE_BLOOD_KNIGHT_SQUIRE_SUNFURY ||
    objectTypeId == UNIT_N0E3_WARLOCK_SUNFURY ||
    objectTypeId == UNIT_N0E4_SCORPION_SUNFURY ||
    objectTypeId == UNIT_N0E8_SKYSHIP_SUNFURY ||
    objectTypeId == UNIT_N0E7_BLOODWARDER_SUNFURY ||
    objectTypeId == UNIT_N006_ANCIENT_OF_THE_ARCANE_SUNFURY ||
    objectTypeId == UNIT_N0DZ_THE_WELL_OF_ETERNITY_SUNFURY_OTHER ||
    objectTypeId == UNIT_H098_SUNFURY_MASTERMIND_QUELTHALAS ||
    objectTypeId == UNIT_U02V_HIGH_ASTROMANCER_SUNFURY ||
    objectTypeId == UNIT_HKAL_PRINCE_OF_QUEL_THALAS_QUELTHALAS;
}
