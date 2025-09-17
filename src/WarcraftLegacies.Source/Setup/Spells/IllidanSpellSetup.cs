using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.PassiveAbilities;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up <see cref="Spell"/>s and <see cref="PassiveAbility"/>s related to Illidan.
  /// </summary>
  public static class IllidanSpellSetup
  {
    /// <summary>
    /// Sets up all <see cref="Spell"/>s and <see cref="PassiveAbility"/>s related to Illidan.
    /// </summary>
    public static void Setup()
    {
      var illidanVariations = new[]
      {
        UNIT_EILL_DEMON_HUNTER_BASE_ILLIDARI,
        FourCC("Eidm"),
        UNIT_EEVM_DEMON_HUNTER_EVIL_MORPHED,
        UNIT_EILM_DEMON_HUNTER,
        UNIT_EEVI_DEMON_HUNTER_HYBRID_ILLIDARI,
        UNIT_E00G_DEMON_HUNTER_EVIL_MORPHED_LEVEL_3,
        UNIT_E00E_DEMON_HUNTER_MORPHED_LEVEL_2,
        UNIT_E00D_DEMON_HUNTER_MORPHED_LEVEL_3
      };

      var warglaivesOfAzzinoth = new WarglaivesOfAzzinoth(illidanVariations,
          ABILITY_A0YW_WARGLAIVES_OF_AZZINOTH_GREEN_LIGHT_BLUE_ILLIDAN)
      {
        Radius = 150,
        DamageBase = 4,
        DamageLevel = 14,
        DamageMultiplierAgainstDemons = 1.2f,
        Effect = @"war3mapImported\Culling Cleave.mdx",
        EffectScale = 1.2f,
        DamageType = DAMAGE_TYPE_MAGIC
      };
      PassiveAbilityManager.Register(warglaivesOfAzzinoth);

      var shadowAssault = new ShadowAssaultSpell(ABILITY_A0TP_SHADOW_ASSAULT_GREEN_AKAMA)
      {
        BaseDamage = 150,
        DamagePerLevel = 50,
        ChargeSpeed = 1200,
        MaxChargeDistance = 1800,
        SpeedUpOrderId = ORDER_BLOODLUST,
        ChargeEffectPath = @"Abilities\Spells\Orc\FeralSpirit\feralspiritdone.mdl",
        SpeedUpAbilityId = ABILITY_A0YT_BLOODLUST_SHADOW_STRIKE,
        ExecuteEffectPath = @"Objects\\Spawnmodels\\Human\\HumanLargeDeathExplode\\HumanLargeDeathExplode.mdl",
        ImpactEffectPath = @"Abilities\Spells\Human\ThunderClap\ThunderClapCaster.mdl",
        BaseExecuteThreshold = 0.25f,
        ExecuteThresholdPerLevel = 0f
      };
      SpellSystem.Register(shadowAssault);

      var cripplingStrike = new DamageMultiplierOnAttack(
          casterUnitTypeId: UNIT_NAKA_ELDER_SAGE_ILLIDARI,
          abilityTypeId: ABILITY_A0YV_CRIPPLING_STRIKE_AKAMA
      )
      {
        BaseUnitMultiplier = 1.4f,
        LevelUnitMultiplier = 0.25f,
        BaseHeroMultiplier = 1.2f,
        LevelHeroMultiplier = 0.15f,
        OnlyAttackDamage = true
      };
      PassiveAbilityManager.Register(cripplingStrike);
    foreach (var unitTypeId in illidanVariations)
    {
    }

    }
  }
}