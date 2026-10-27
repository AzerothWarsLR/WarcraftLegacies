using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Illidari.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Illidari;

/// <summary>
/// Responsible for setting up all Illidari <see cref="Spell"/>s and <see cref="UnitTrait"/>s.
/// </summary>
public static class IllidariSpells
{
  /// <summary>
  /// Sets up all Illidari <see cref="Spell"/>s and <see cref="UnitTrait"/>s.
  /// </summary>
  public static void Setup()
  {
    SpellRegistry.Register(new ShadowAssaultSpell(ABILITY_YBBS_BLINK_STRIKE_DEATHSWORN)
    {
      BaseDamage = 25,
      BlinkEffectPath = @"Abilities\Spells\NightElf\Blink\BlinkCaster.mdl"
    });

    SpellRegistry.Register(new AddAbilityOnLearn(ABILITY_A01Q_SHADOW_AURA_AKAMA)
    {
      AbilityToAddId = ABILITY_A0Z1_EVASION_AKAMA
    });

    SpellRegistry.Register(new ChainManaBurn(ABILITY_AYGF_CHAIN_MANA_BURN_ILLIDAN)
    {
      ManaBurned = new LeveledAbilityField<int>
      {
        Base = 50,
        PerLevel = 40
      },
      MaximumBounces = 5,
      BurnReductionPerBounce = 0.15f,
      MaximumBounceRadius = 500,
      BurnedManaDamageMultiplier = 2f,
    });

    SpellRegistry.Register(new SplitHealingWave(ABILITY_YBAW_SPLIT_HEALING_WAVE_SEER)
    {
      DummyAbilityId = ABILITY_YBWW_HEALING_WAVE_SPLIT_WAVE_DUMMY_CASTER,
      DummyAbilityOrderId = ORDER_HEALING_WAVE,
      Radius = 350f
    });
  }
}

