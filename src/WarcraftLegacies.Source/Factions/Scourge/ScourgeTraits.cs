using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Scourge.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Scourge;

public static class ScourgeTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new PersistentSoul(ABILITY_A05L_PERSISTENT_SOUL_SCOURGE_REVENANT)
    {
      ReanimationCountLevel = 1,
      Duration = 40,
      BuffId = BUFF_B069_PERSISTENT_SOUL_FORSAKEN_PLAGUE_REVENANT,
      Radius = 700
    }, UNIT_N009_REVENANT_SCOURGE);

    UnitTypeTraitRegistry.Register(new RemoveOnDeath
    {
      DeathEffectPath = @"Objects\Spawnmodels\Undead\UDeathSmall\UDeathSmall.mdl"
    }, UNIT_N094_ICECROWN_OBELISK_SCOURGE);

    UnitTypeTraitRegistry.Register(new SummonUnitOnCast(ABILITY_ST52_ARMY_OF_THE_DEAD_SCOURGE)
    {
      Duration = 45,
      SummonUnitTypeId = UNIT_NDR2_DARK_MINION_SCOURGE_DEATH_KNIGHT,
      SummonCount = new LeveledAbilityField<int>
      {
        Base = 0,
        PerLevel = 1
      },
      SpecialEffectPath = @"Abilities\Spells\Undead\RaiseSkeletonWarrior\RaiseSkeleton.mdl",
      ProcChance = 1.0f,
      AbilityWhitelist = new List<int>
      {
        ABILITY_AUDC_DEATH_COIL_RED_BARON_RIVENDARE,
        ABILITY_YBSR_SUMMON_RAMSTEIN_BARON_RIVENDARE,
        ABILITY_A09Y_DEATH_S_ADVANCE_SCOURGE_RIVENDARE,
        ABILITY_A07R_UNIVERSAL_SHACKLES_KARGATH
      }
    }, UNIT_U00A_SCOURGE_COMMANDER_SCOURGE);

    UnitTypeTraitRegistry.Register(new SummoningMastery(ABILITY_AUAN_ANIMATE_DEAD_KEL_THUZAD)
    {
      HitPointPercentageBonus = new LeveledAbilityField<float>
      {
        Base = -0.2f,
        PerLevel = 0.2f
      },
      AttackDamagePercentageBonus = new LeveledAbilityField<float>
      {
        Base = -0.2f,
        PerLevel = 0.2f
      }
    }, new[]
    {
      UNIT_U00M_MASTER_OF_THE_CULT_OF_THE_DAMNED_SCOURGE_GHOST,
      UNIT_U001_MASTER_OF_THE_CULT_OF_THE_DAMNED_SCOURGE_NECROMANCER,
      UNIT_UKTL_ARCHLICH_OF_THE_SCOURGE_SCOURGE_LICH
    });
  }
}
