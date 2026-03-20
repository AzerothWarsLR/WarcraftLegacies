using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.UnitTypeTraits;

namespace WarcraftLegacies.Source.Factions.Quelthalas;

public static class QuelthalasTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new DefensiveOrbs(ABILITY_A055_DEFENSIVE_ORBS_QUEL_THALAS_ANASTERIAN)
    {
      OrbitRadius = 350,
      OrbitalPeriod = 4,
      OrbEffectPath = @"war3mapImported\OrbFireX.mdx",
      Damage = new LeveledAbilityField<float> { Base = 20, PerLevel = 10 },
      CollisionRadius = new LeveledAbilityField<float> { Base = 100, PerLevel = 0 },
      OrbDuration = 30,
      AbilityWhitelist = new List<int>
      {
        ABILITY_A04J_ARCANE_BURST_HIGH_ELVES_ANASTERIAN,
        ABILITY_A013_DEVOUR_MAGIC_ANASTERIAN,
        ABILITY_AHPX_ASHES_OF_AL_AR_QUEL_THALAS_ANASTERIAN_KAEL_THAS
      }
    }, UNIT_H00Q_KING_OF_QUEL_THALAS_QUELTHALAS);
  }
}
