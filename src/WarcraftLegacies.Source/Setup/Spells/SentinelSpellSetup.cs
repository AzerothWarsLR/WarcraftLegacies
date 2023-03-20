using System.Collections.Generic;
using MacroTools;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class SentinelSpellSetup
  {
    public static void Setup()
    { 
      PassiveAbilityManager.Register(new DefensiveOrbs(Constants.UNIT_E025, Constants.ABILITY_A10A_GLAIVE_STORM_ICON_NAISHA)
      {
        OrbitRadius = 350,
        OrbitalPeriod = 4,
        OrbEffectPath = @"war3mapImported\ArcaneGlaive_2.mdx",
        Damage = new LeveledAbilityField<float> { Base = 25, PerLevel = 25 },
        CollisionRadius = new LeveledAbilityField<float> { Base = 150, PerLevel = 0},
        OrbDuration = 20,
        AbilityWhitelist = new List<int>
        {
          Constants.ABILITY_A04J_ARCANE_BURST_HIGH_ELVES_ANASTERIAN,
          Constants.ABILITY_A013_DEVOUR_MAGIC_GUL_DAN,
          Constants.ABILITY_AHPX_ASHES_OF_AL_AR_QUEL_THALAS_ANASTERIAN_KAEL_THAS
        }
      });

    }
  }
}