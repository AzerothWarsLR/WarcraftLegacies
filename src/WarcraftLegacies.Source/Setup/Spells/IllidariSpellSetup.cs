using MacroTools.Data;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.PassiveAbilities;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.Slipstream;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.Spells;

/// <summary>
/// Responsible for setting up all Illidari <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
/// </summary>
public static class IllidariSpellSetup
{
  /// <summary>
  /// Sets up all Illidari <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
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
      UNIT_EEVI_DEMON_HUNTER_HYBRID_ILLIDARI,
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
  }
}
