using MacroTools.Data;
using MacroTools.Spells;
using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.Slipstream;
using WarcraftLegacies.Source.UnitTypeTraits;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.Spells;

/// <summary>
/// Responsible for setting up all Illidari <see cref="Spell"/>s and <see cref="UnitTypeTrait"/>s.
/// </summary>
public static class IllidariSpellSetup
{
  /// <summary>
  /// Sets up all Illidari <see cref="Spell"/>s and <see cref="UnitTypeTrait"/>s.
  /// </summary>
  public static void Setup()
  {
    SpellSystem.Register(new SlipstreamSpellSpecificDestination(ABILITY_A07D_PORTAL_TO_BLACK_TEMPLE_ILLIDAN)
    {
      PortalUnitTypeId = UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
      OpeningDelay = 20,
      ClosingDelay = 15,
      TargetLocation = new Point(5030, -30000),
      Color = new Color(255, 255, 250, 255)
    });

    var illidanVariations = new[]
    {
      UNIT_EEVI_DEMON_HUNTER_ILLIDARI_HYBRID_ILLIDAN,
      UNIT_EEVM_DEMON_HUNTER_MORPHED_LEVEL_1_ILLIDARI,
      UNIT_ZF4B_DEMON_HUNTER_MORPHED_LEVEL_2_ILLIDARI,
      UNIT_ZB88_DEMON_HUNTER_MORPHED_LEVEL_3_ILLIDARI
    };

    var warglaivesOfAzzinoth = new WarglaivesOfAzzinoth(illidanVariations,
      ABILITY_A0YW_WARGLAIVES_OF_AZZINOTH_ILLIDAN)
    {
      Radius = 150,
      DamageBase = 4,
      DamageLevel = 14,
      DamageMultiplierAgainstDemons = 1.2f,
      Effect = @"war3mapImported\Culling Cleave.mdx",
      EffectScale = 1.2f,
      DamageType = damagetype.Magic
    };
    UnitTypeTraitRegistry.Register(warglaivesOfAzzinoth);

    var shadowAssault = new ShadowAssaultSpell(ABILITY_A0TP_SHADOW_ASSAULT_AKAMA)
    {
      BaseDamage = 150,
      DamagePerLevel = 50,
      BlinkEffectPath = @"Abilities\Spells\NightElf\Blink\BlinkCaster.mdl",
      ExecuteEffectPath = @"Objects\\Spawnmodels\\Human\\HumanLargeDeathExplode\\HumanLargeDeathExplode.mdl",
      DamageEffectPath = @"Abilities\Spells\Human\ThunderClap\ThunderClapCaster.mdl",
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
    UnitTypeTraitRegistry.Register(cripplingStrike);

    SpellSystem.Register(new AddAbilityOnLearn(ABILITY_A01Q_SHADOW_AURA_AKAMA)
    {
      AbilityToAddId = ABILITY_A0Z1_EVASION_AKAMA
    });
  }
}

