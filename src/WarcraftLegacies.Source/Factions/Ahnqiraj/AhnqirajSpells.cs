using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Ahnqiraj.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Ahnqiraj;

public static class AhnqirajSpells
{
  public static void Setup()
  {
    SpellRegistry.Register(new InstantKill(ABILITY_ZBBS_HATCH_INCUBATE)
    {
      Target = InstantKill.KillTarget.Self
    });

    SpellRegistry.Register(new InspireMadness(ABILITY_ZBIM_INSPIRE_MADNESS_C_THUN)
    {
      Radius = 300,
      CountBase = 14,
      Duration = 30,
      EffectTarget = @"Abilities\Spells\Other\Charm\CharmTarget.mdl",
      EffectScaleTarget = 0.5f
    });

    SpellRegistry.Register(new UnstableEvolution(ABILITY_ZBUE_UNSTABLE_EVOLUTION_C_THUN)
    {
      Radius = 300,
      Duration = 30,
      AttackDamageMultiplier = new LeveledAbilityField<float>
      {
        Base = 1.5f,
        PerLevel = 0.5f
      },
      AttackSpeedMultiplier = new LeveledAbilityField<float>
      {
        Base = 2
      },
      MaxHealthMultiplier = new LeveledAbilityField<float>
      {
        Base = 1.25f,
        PerLevel = 0.25f
      },
      EffectTarget = @"Abilities\Spells\Human\Feedback\ArcaneTowerAttack.mdl",
      EffectScaleTarget = 1
    });

    SpellRegistry.Register(new SpawnTentacle(ABILITY_ZBST_SPAWN_TENTACLE_C_THUN)
    {
      HitPoints = new LeveledAbilityField<int>
      {
        Base = 500,
        PerLevel = 100
      },
      AttackDamageBase = new LeveledAbilityField<int>
      {
        Base = 20,
        PerLevel = 20
      },
      UnitTypeId = UNIT_ZBTH_TENTACLE_SPAWN_TENTACLE_C_THUN,
      Duration = new LeveledAbilityField<float>
      {
        Base = 30
      }
    });
  }
}
