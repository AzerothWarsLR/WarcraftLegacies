using System.Collections.Generic;
using MacroTools;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class SentinelSpellSetup
  {
    public static void Setup()
    { 
      PassiveAbilityManager.Register(new DefensiveOrbs(UNIT_E025_LIEUTENANT_OF_THE_WATCHERS_SENTINELS, ABILITY_A10A_GLAIVE_STORM_ICON_NAISHA)
      {
        OrbitRadius = 350,
        OrbitalPeriod = 4,
        OrbEffectPath = @"war3mapImported\ArcaneGlaive_2.mdx",
        Damage = new LeveledAbilityField<float> { Base = 25, PerLevel = 25 },
        CollisionRadius = new LeveledAbilityField<float> { Base = 150, PerLevel = 0},
        OrbDuration = 20,
        AbilityWhitelist = new List<int>
        {
          ABILITY_A0FC_BARBED_NET_NAISHA,
          ABILITY_A0MG_QUICK_KNIVES_NAISHA,
        }
      });

    }
  }
}