using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Druids.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Druids;

public static class DruidsSpells
{
  public static void Setup()
  {
    SpellRegistry.Register(new Devour(ABILITY_A0NP_DEVOUR_TORTOLLA)
    {
      PercentageOfMaxHealth = 0.5f,
      Damage = new LeveledAbilityField<float>
      {
        Base = 100,
        PerLevel = 100
      }
    });

    SpellRegistry.Register(new Devour(ABILITY_A0S0_DEVOUR_OURO)
    {
      PercentageOfMaxHealth = 0.5f,
      Damage = new LeveledAbilityField<float>
      {
        Base = 100,
        PerLevel = 100
      }
    });

    SpellRegistry.Register(new EmeraldDreamSpell(ABILITY_A14E_EMERALD_DREAM_MALFURION)
    {
      DreamDuration = new LeveledAbilityField<float> { Base = 1.5f, PerLevel = 0.5f },
      HealFraction = new LeveledAbilityField<float> { Base = 0.1f, PerLevel = 0.1f },
      ManaFraction = new LeveledAbilityField<float> { Base = 0.05f, PerLevel = 0.05f },
      TickPeriod = 0.5f,
      Effects = new EmeraldDreamEffectSettings
      {
        DreamPath = @"Abilities\Spells\NightElf\Tranquility\TranquilityTarget.mdl",
        FlashPath = @"Abilities\Spells\NightElf\Rejuvenation\RejuvenationTarget.mdl",
        DreamTint = (110, 255, 180, 130)
      }
    });

    SpellRegistry.Register(new SeedOfRebirthSpell(ABILITY_A15O_SEED_OF_REBIRTH_MALFURION)
    {
      InitialDamage = new float[] { 75, 150, 200, 250 },
      DamagePerSecond = new LeveledAbilityField<float> { Base = 5, PerLevel = 5 },
      Duration = 15,
      TickPeriod = 0.25f,
      VisionRadius = 250,
      TreantUnitTypeId = UNIT_EFON_TREANT_DRUIDS_SUMMONED,
      BuffApplicatorId = ABILITY_A15P_SEED_OF_REBIRTH_BUFF_APPLICATOR,
      SeedEffectPath = @"Abilities\Spells\NightElf\EntanglingRoots\EntanglingRootsTarget.mdl",
      SeedEffectScale = 0.6f,
      SproutEffectPath = @"Objects\Spawnmodels\NightElf\EntBirthTarget\EntBirthTarget.mdl"
    });
  }
}
