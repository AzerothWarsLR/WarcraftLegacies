using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.Slipstream;
using WarcraftLegacies.Source.UnitTypeTraits;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Setup.Spells;

/// <summary>
/// Responsible for setting up all Illidari <see cref="Spell"/>s and <see cref="UnitTrait"/>s.
/// </summary>
public static class IllidariSpellSetup
{
  /// <summary>
  /// Sets up all Illidari <see cref="Spell"/>s and <see cref="UnitTrait"/>s.
  /// </summary>
  public static void Setup()
  {
    SpellRegistry.Register(new SlipstreamSpellSpecificDestination(ABILITY_A07D_PORTAL_TO_BLACK_TEMPLE_ILLIDAN)
    {
      PortalUnitTypeId = UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
      OpeningDelay = 20,
      ClosingDelay = 15,
      TargetLocation = new Point(6930, -30177),
      Color = new Color(255, 255, 250, 255)
    });

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
    SpellRegistry.Register(shadowAssault);

    SpellRegistry.Register(new ShadowAssaultSpell(ABILITY_YBBS_BLINK_STRIKE_DEATHSWORN)
    {
      BaseDamage = 25,
      BlinkEffectPath = @"Abilities\Spells\NightElf\Blink\BlinkCaster.mdl"
    });

    UnitTypeTraitRegistry.Register(new DamageMultiplierOnAttack(ABILITY_A0YV_CRIPPLING_STRIKE_AKAMA)
    {
      BaseUnitMultiplier = 1.4f,
      LevelUnitMultiplier = 0.25f,
      BaseHeroMultiplier = 1.2f,
      LevelHeroMultiplier = 0.15f,
      OnlyAttackDamage = true
    }, UNIT_NAKA_ELDER_SAGE_ILLIDARI);

    SpellRegistry.Register(new AddAbilityOnLearn(ABILITY_A01Q_SHADOW_AURA_AKAMA)
    {
      AbilityToAddId = ABILITY_A0Z1_EVASION_AKAMA
    });

    SpellRegistry.Register(new ChainManaBurn(ABILITY_AYGF_CHAIN_MANA_BURN_ILLIDAN)
    {
      ManaBurned = new LeveledAbilityField<int>
      {
        Base = 100,
        PerLevel = 75
      },
      MaximumBounces = 5,
      BurnReductionPerBounce = 0.15f,
      MaximumBounceRadius = 500
    });

    ItemTypeTraitRegistry.Register(new WarglaivesOfAzzinoth
    {
      Radius = 150,
      DamageBase = 35,
      DamageLevel = 0,
      DamageMultiplierAgainstDemons = 1.2f,
      Effect = @"war3mapImported\Culling Cleave.mdx",
      EffectScale = 1.2f,
      DamageType = damagetype.Magic
    }, ITEM_I0WG_WARGLAIVES_OF_AZZINOTH);

    UnitTypeTraitRegistry.Register(new Kingslayer
    {
      RequiredResearch = UPGRADE_YBPH_KINGSLAYER_ILLIDARI,
      DamageBonus = 0.6f
    }, UNIT_NDRN_DEATHSWORN_ILLIDARI);

    SpellRegistry.Register(new SplitHealingWave(ABILITY_YBAW_SPLIT_HEALING_WAVE_SEER)
    {
      DummyAbilityId = ABILITY_YBWW_HEALING_WAVE_SPLIT_WAVE_DUMMY_CASTER,
      DummyAbilityOrderId = ORDER_HEALING_WAVE,
      Radius = 350f
    });
  }
}

