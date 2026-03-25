using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Legion.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Legion;

public static class LegionTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new RestoreHealthFromEachTargetDamaged(ABILITY_VP02_VAMPIRIC_SIPHON_LEGION_DREADLORDS)
    {
      HealthPerTarget = new LeveledAbilityField<int>
      {
        Base = -5,
        PerLevel = 10
      },
      HealthPerLevel = 1,
      Effect = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
    }, new[]
    {
      UNIT_UMAL_THE_CUNNING_LEGION,
      UNIT_UTIC_THE_DARKENER_LEGION,
      UNIT_U00L_ENVOY_OF_ARCHIMONDE_LEGION
    });

    UnitTypeTraitRegistry.Register(
      new RestoreHealthFromEachTargetDamaged(ABILITY_VP08_VAMPIRIC_SIPHON_LEGION_ELITES)
      {
        HealthPerTarget = new LeveledAbilityField<int> { Base = -5, PerLevel = 10 },
        HealthPerLevel = 1,
        Effect = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
      }, new[]
      {
        UNIT_U007_DREADLORD_LEGION_ELITE,
        UNIT_N04O_DOOM_LORD_LEGION
      });
  }
}
