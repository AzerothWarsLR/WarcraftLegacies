using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Ironforge.Spells;
using WarcraftLegacies.Source.Factions.TaurenTribes.Spells;
using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>Spells and unit traits used by the Dark Iron.</summary>
public static class DarkIronSpells
{
  /// <summary>Registers the Dark Iron's spells and unit traits.</summary>
  public static void Setup()
  {
    SpellRegistry.Register(new MoltenHammerSpell(ABILITY_A19P_MOLTEN_HAMMER_DARKIRON_THANE)
    {
      Radius = 175,
      Duration = 4,
      DamagePerSecond = 15,
      FireEffectPath = @"Environment\SmallBuildingFire\SmallBuildingFire2.mdl"
    });

    SpellRegistry.Register(new ChallengingTaunt(ABILITY_A19Q_CHALLENGING_TAUNT_DARKIRON_THANE)
    {
      ArmorAbilityId = ABILITY_A15D_CHALLENGING_TAUNT_ARMOR_TAUREN_TRIBES_OGRE_LORD_DUMMY
    });

    UnitTypeTraitRegistry.Register(new FirebrandStrikes
    {
      AbilityTypeId = ABILITY_A19R_FIREBRAND_STRIKES_DARKIRON_THANE,
      DamagePerSecond = 10,
      Duration = 3,
      BuffApplicatorId = ABILITY_A19S_FIREBRAND_DARKIRON_THANE_BUFF,
      BuffId = BUFF_B10K_FIREBRAND,
      IgniteAbilityId = ABILITY_A19T_BREATH_OF_FIRE_DARKIRON_FIREBRAND_STRIKES_DUMMY
    }, UNIT_H0EB_DARK_IRON_THANE_DARKIRON_ELITE);

    RegisterMoira();
    RegisterAngerforge();
    RegisterRagnaros();
    RegisterShadowcaster();
  }

  private static void RegisterShadowcaster()
  {
    SpellRegistry.Register(new ShadowflameBrandSpell(ABILITY_A1AJ_SHADOWFLAME_BRAND_DARKIRON_SHADOWCASTER)
    {
      DamagePerSecond = 10,
      Duration = 6,
      BurstDamage = 75,
      BurstRadius = 200,
      BurstEffectPath = @"Abilities\Spells\Other\Incinerate\FireLordDeathExplode.mdl"
    });

    SpellRegistry.Register(new ShadowforgeRuneSpell(ABILITY_A1AL_SHADOWFORGE_RUNE_DARKIRON_SHADOWCASTER)
    {
      Radius = 250,
      Duration = 20,
      PulseInterval = 2,
      DamagePerPulse = 15,
      SlowAbilityId = ABILITY_A1AM_SHADOWFORGE_RUNE_SLOW_DUMMY,
      RunePath = @"Doodads\Cinematic\GlowingRunes\GlowingRunes0.mdl",
      RuneScale = 1.5f,
      PulseEffectPath = @"Abilities\Spells\Other\ImmolationRed\ImmolationRedDamage.mdl"
    });
  }

  private static void RegisterMoira()
  {
    SpellRegistry.Register(new ShadowflameWordSpell(ABILITY_A19U_SHADOWFLAME_WORD_DARKIRON_MOIRA)
    {
      DamagePerSecond = new LeveledAbilityField<float> { Base = 5, PerLevel = 10 },
      Duration = 6,
      Jumps = 2,
      BonusJumpResearchId = UPGRADE_R10N_QUEST_COMPLETED_SHATTER_THE_VIOLET_CITADEL,
      JumpRange = 500,
      BuffApplicatorId = ABILITY_A19V_SHADOWFLAME_WORD_DARKIRON_MOIRA_BUFF,
      BuffId = BUFF_B10L_SHADOWFLAME_WORD,
      TickEffectPath = @"Abilities\Spells\Undead\DeathCoil\DeathCoilSpecialArt.mdl"
    });

    SpellRegistry.Register(new QueensMendingSpell(ABILITY_A19W_QUEEN_S_MENDING_DARKIRON_MOIRA)
    {
      Heal = new LeveledAbilityField<float> { Base = 75, PerLevel = 75 },
      ShieldDuration = 6,
      BuffApplicatorId = ABILITY_A19X_QUEEN_S_MENDING_DARKIRON_MOIRA_BUFF,
      BuffId = BUFF_B10M_QUEEN_S_MENDING,
      HealEffectPath = @"Abilities\Spells\Human\HolyBolt\HolyBoltSpecialArt.mdl",
      ShieldEffectPath = @"war3mapImported\SoulArmorCream.mdl"
    });

    new VoiceOfTheThrone
    {
      AbilityTypeId = ABILITY_A19Y_VOICE_OF_THE_THRONE_DARKIRON_MOIRA,
      HealFraction = new LeveledAbilityField<float> { Base = 0, PerLevel = 0.02f },
      Radius = 800,
      HealEffectPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
    }.Register();

    SpellRegistry.Register(new ShadowflameRiteSpell(ABILITY_A19Z_SHADOWFLAME_RITE_DARKIRON_MOIRA)
    {
      DamagePerSecond = new LeveledAbilityField<float> { Base = 20, PerLevel = 20 },
      HealPerSecond = new LeveledAbilityField<float> { Base = 15, PerLevel = 15 },
      Radius = 300,
      RingEffectPath = @"Environment\SmallBuildingFire\SmallBuildingFire2.mdl",
      RingRed = 140,
      RingGreen = 60,
      RingBlue = 255,
      DamageEffectPath = @"Abilities\Spells\Demon\RainOfFire\RainOfFireTarget.mdl",
      HealEffectPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
    });
  }

  private static void RegisterAngerforge()
  {
    UnitTypeTraitRegistry.Register(new LastStand
    {
      AbilityTypeId = ABILITY_A1A1_LAST_STAND_DARKIRON_ANGERFORGE,
      Cooldown = new LeveledAbilityField<float> { Base = 4, PerLevel = 0 },
      HealthThreshold = 0.4f,
      SummonCount = 2,
      SummonUnitTypeId = UNIT_H0EI_ANVILRAGE_RESERVIST_DARKIRON_SUMMON,
      SummonDuration = new LeveledAbilityField<float> { Base = 4, PerLevel = 4 },
      SummonEffectPath = @"Abilities\Spells\Undead\Darksummoning\DarkSummonTarget.mdl"
    }, UNIT_H0CV_GENERAL_OF_THE_DARK_IRON_DARKIRON);

    SpellRegistry.Register(new ForwardShadowforgeSpell(ABILITY_A1A2_FORWARD_SHADOWFORGE_DARKIRON_ANGERFORGE)
    {
      Radius = 900,
      Duration = 10,
      AttackSpeedAbilityId = ABILITY_A1A4_FORWARD_SHADOWFORGE_ATTACK_SPEED_DARKIRON_ANGERFORGE,
      MoveSpeedAbilityId = ABILITY_A1A5_FORWARD_SHADOWFORGE_SPEED_DARKIRON_ANGERFORGE,
      StunAbilityId = ABILITY_A1A6_FORWARD_SHADOWFORGE_STUN_DUMMY,
      BuffApplicatorId = ABILITY_A1A3_FORWARD_SHADOWFORGE_DARKIRON_ANGERFORGE_BUFF,
      BuffId = BUFF_B10N_FORWARD_SHADOWFORGE,
      CastEffectPath = @"Abilities\Spells\Other\HowlOfTerror\HowlCaster.mdl"
    });

    SpellRegistry.Register(new TunnelStrikeSpell(ABILITY_A1A8_TUNNEL_STRIKE_DARKIRON_EARTHBORER)
    {
      TunnelSpeed = 700,
      Damage = 50,
      Radius = 200,
      LodgedDuration = 5,
      UpgradeResearchId = UPGRADE_R10P_SEISMIC_DRILLS_DARKIRON,
      UpgradedDamageBonus = 50,
      UpgradedLodgedReduction = 2,
      StunAbilityId = ABILITY_A1A9_TUNNEL_STRIKE_STUN_DUMMY,
      LodgedAbilityId = ABILITY_A1AA_DRILL_LODGED_DUMMY_DUMMY_DARKIRON,
      DustEffectPath = @"Objects\Spawnmodels\Undead\ImpaleTargetDust\ImpaleTargetDust.mdl",
      EruptEffectPath = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl"
    });

    new AttackAnimation { Animation = "spell" }.Register(UNIT_H0EF_EARTHBORER_DARKIRON);

    SpellRegistry.Register(new VolatileFlask(ABILITY_A1AQ_VOLATILE_FLASK_DARKIRON)
    {
      Damage = 25f,
      Radius = 175f,
      MaxDamage = 300f
    });
  }

  private static void RegisterRagnaros()
  {
    SpellRegistry.Register(new LivingMeteorSpell(ABILITY_A1AC_LIVING_METEOR_DARKIRON_RAGNAROS)
    {
      ImpactDamage = new LeveledAbilityField<float> { Base = 20, PerLevel = 40 },
      DamagePerSecond = new LeveledAbilityField<float> { Base = 10, PerLevel = 15 },
      RollDistance = new LeveledAbilityField<float> { Base = 500, PerLevel = 100 },
      Radius = 200,
      FallHeight = 1200,
      FallSpeed = 1200,
      RollSpeed = 300,
      BurnInterval = 0.5f,
      MeteorPath = @"war3mapImported\LivingMeteor.mdl",
      MeteorScale = 0.65f
    });

    SpellRegistry.Register(new MoltenShieldSpell(ABILITY_A1AD_MOLTEN_SHIELD_DARKIRON_RAGNAROS)
    {
      DamageReduction = new LeveledAbilityField<float> { Base = 0.1f, PerLevel = 0.1f },
      MaximumBurst = new LeveledAbilityField<float> { Base = 100, PerLevel = 100 },
      Duration = 8,
      BurstRadius = 400,
      BuffApplicatorId = ABILITY_A1AE_MOLTEN_SHIELD_DARKIRON_RAGNAROS_BUFF,
      BuffId = BUFF_B10Q_MOLTEN_SHIELD,
      MoveSpeedAbilityId = ABILITY_A1AF_MOLTEN_SHIELD_SPEED_DARKIRON_RAGNAROS,
      BurstEffectPath = @"Abilities\Spells\Other\Incinerate\FireLordDeathExplode.mdl"
    });

    new FirelordsHunger
    {
      AbilityTypeId = ABILITY_A1AG_FIRELORD_S_HUNGER_DARKIRON_RAGNAROS,
      KillsPerDamage = 5,
      DamagePerHeroKill = 3,
      MaximumDamage = new LeveledAbilityField<int> { Base = 0, PerLevel = 15 }
    }.Register();

    SpellRegistry.Register(new SulfurasSmashSpell(ABILITY_A1AH_SULFURAS_SMASH_DARKIRON_RAGNAROS)
    {
      Damage = new LeveledAbilityField<float> { Base = 150, PerLevel = 100 },
      Radius = 350,
      CentreRadius = 175,
      LandingTime = 1.25f,
      LaunchHeight = 1500,
      StunAbilityId = ABILITY_A1AI_SULFURAS_SMASH_STUN_DUMMY,
      HammerPath = @"war3mapImported\SulfurasMissile.mdl",
      HammerScale = 2,
      ImpactPath = @"war3mapImported\SulfurasSmash.mdl",
      ImpactScale = 1.5f,
      ImpactDuration = 10
    });
  }
}
