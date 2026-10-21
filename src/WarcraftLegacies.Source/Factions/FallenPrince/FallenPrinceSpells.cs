using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.FallenPrince.Spells;
using WarcraftLegacies.Source.Factions.Scourge.Spells;

namespace WarcraftLegacies.Source.Factions.FallenPrince;

public static class FallenPrinceSpells
{
  public static void Setup()
  {
    SpellRegistry.Register(new ShadowWordDeathSpell(ABILITY_A173_SHADOW_WORD_DEATH_FALLENPRINCE_FALLEN_PRIEST)
    {
      DamagePerSecond = 40,
      Duration = 6,
      BacklashFraction = 0.15f,
      BuffId = BUFF_B103_SHADOW_WORD_DEATH,
      TickEffectPath = @"Abilities\Spells\Undead\DeathCoil\DeathCoilSpecialArt.mdl",
      BacklashEffectPath = @"Abilities\Spells\Undead\DeathPact\DeathPactTarget.mdl"
    });

    SpellRegistry.Register(new GrimTollSpell(ABILITY_A175_GRIM_TOLL_FALLENPRINCE_FALRIC)
    {
      Damage = new LeveledAbilityField<float> { Base = 25, PerLevel = 50 },
      MissingHealthFraction = 0.2f,
      HealFraction = 0.15f,
      StrikeEffectPath = @"Abilities\Spells\Undead\CarrionSwarm\CarrionSwarmDamage.mdl",
      KillEffectPath = @"Abilities\Spells\Undead\DarkRitual\DarkRitualTarget.mdl"
    });

    UnitTypeTraitRegistry.Register(new DeathguardsBulwarkAura
    {
      AbilityTypeId = ABILITY_A176_DEATHGUARD_S_BULWARK_FALLENPRINCE_FALRIC,
      BuffId = BUFF_B104_DEATHGUARD_S_BULWARK,
      Radius = 900,
      ReductionByLevel = new[] { 0.03f, 0.05f, 0.07f, 0.1f }
    }, UNIT_U020_DEATHGUARD_SCOURGE);

    SpellRegistry.Register(new ShieldChargeSpell(ABILITY_A178_SHIELD_CHARGE_FALLENPRINCE_FALRIC)
    {
      Damage = new LeveledAbilityField<float> { Base = 25, PerLevel = 50 },
      Speed = 1100,
      StunAbilityId = ABILITY_A179_SHIELD_CHARGE_STUN_DUMMY,
      ImpactEffectPath = @"Abilities\Spells\Human\ThunderClap\ThunderClapCaster.mdl"
    });

    SpellRegistry.Register(new DefilingHorrorSpell(ABILITY_A17A_DEFILING_HORROR_FALLENPRINCE_FALRIC)
    {
      Radius = 500,
      FearDuration = new LeveledAbilityField<float> { Base = 1.5f, PerLevel = 0.5f },
      HeroFearDuration = 1,
      DamageAmplification = new LeveledAbilityField<float> { Base = 0.15f, PerLevel = 0.05f },
      AmplificationDuration = 8,
      FearApplicatorId = ABILITY_A17B_DEFILING_HORROR_BUFF_APPLICATOR_BUFF_APPLICATOR,
      DefiledAbilityId = ABILITY_A17C_DEFILED_DUMMY,
      DefiledBuffId = BUFF_B106_DEFILED,
      CastEffectPath = @"Abilities\Spells\Other\HowlOfTerror\HowlCaster.mdl"
    });

    SpellRegistry.Register(new SharedSufferingSpell(ABILITY_A17D_SHARED_SUFFERING_FALLENPRINCE_MARWYN)
    {
      DamagePerSecond = new LeveledAbilityField<float> { Base = 10, PerLevel = 10 },
      Duration = 8,
      BurstRadius = 300,
      DebuffAbilityId = ABILITY_A17E_SHARED_SUFFERING_DUMMY,
      BuffId = BUFF_B107_SHARED_SUFFERING,
      TickEffectPath = @"Abilities\Spells\Undead\DeathandDecay\DeathandDecayTarget.mdl",
      BurstEffectPath = @"Abilities\Spells\Undead\AnimateDead\AnimateDeadTarget.mdl"
    });

    SpellRegistry.Register(new WardOfCorruptionSpell(ABILITY_A17F_WARD_OF_CORRUPTION_FALLENPRINCE_MARWYN)
    {
      WardTypeId = UNIT_U108_WARD_OF_CORRUPTION_FALLENPRINCE,
      WardHealth = new LeveledAbilityField<int> { Base = 150, PerLevel = 100 },
      Duration = 18,
      PulseInterval = 3,
      Radius = 500,
      HealPerEffect = 50,
      PulseEffectPath = @"Abilities\Spells\Undead\DevourMagic\DevourMagicBirthMissile.mdl",
      StripEffectPath = @"Abilities\Spells\Human\DispelMagic\DispelMagicTarget.mdl"
    });

    UnitTypeTraitRegistry.Register(new SoulEcho
    {
      AbilityTypeId = ABILITY_A17G_SOUL_ECHO_FALLENPRINCE_MARWYN,
      TargetCount = 3,
      Radius = 600,
      Damage = new LeveledAbilityField<float> { Base = 5, PerLevel = 15 },
      MissilePath = @"Abilities\Weapons\AvengerMissile\AvengerMissile.mdl",
      ImpactEffectPath = @"Abilities\Spells\Undead\DeathCoil\DeathCoilSpecialArt.mdl"
    }, UNIT_U03A_DEATHBRINGER_FALLENPRINCE);

    SpellRegistry.Register(new DeathPact(ABILITY_A17I_DEATH_PACT_FALLENPRINCE)
    {
      Radius = 700.0f,
      KillEffect = @"Abilities\Spells\Undead\DeathPact\DeathPactTarget.mdl",
      HealEffect = @"Abilities\Spells\Human\Heal\HealTarget.mdl",
      HealthRestorePercent = 1.5f,
      ManaRestorePercent = 0.20f
    });

    SpellRegistry.Register(new SoulRendSpell(ABILITY_A17H_SOUL_REND_FALLENPRINCE_MARWYN)
    {
      Damage = new LeveledAbilityField<float> { Base = 100, PerLevel = 100 },
      Radius = 350,
      SoulRange = 600,
      MaximumSouls = 20,
      AreaEffectPath = @"Abilities\Spells\Undead\DeathandDecay\DeathandDecayTarget.mdl",
      StrikeEffectPath = @"Abilities\Spells\Undead\DeathCoil\DeathCoilSpecialArt.mdl",
      SoulMissilePath = @"Abilities\Spells\Undead\Possession\PossessionMissile.mdl"
    });
  }
}
