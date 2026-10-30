using System.Collections.Generic;
using MacroTools.Researches;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Ironforge.Spells;
using WarcraftLegacies.Source.Factions.OrcishHorde.UnitTraits;
using WarcraftLegacies.Source.Shared.Researches;
using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Factions.Ironforge;

/// <summary>Spells and unit traits used by the Wildhammer.</summary>
public static class WildhammerSpells
{
  /// <summary>Registers the Wildhammer's spells and unit traits.</summary>
  public static void Setup()
  {
    RegisterKurdran();
    RegisterTalonaxe();
    RegisterCloudGuardian();
    RegisterUnits();
  }

  private static void RegisterUnits()
  {
    UnitTypeTraitRegistry.Register(new BaneOfTheDark
    {
      RequiredResearch = UPGRADE_R11A_THE_HAMMER_FALLS_WILDHAMMER,
      DamageBonus = 0.15f
    }, new[]
    {
      UNIT_H0FL_GRYPHON_RIDER_WILDHAMMER, UNIT_H0F6_GRYPHON_WILDHAMMER, UNIT_H0F7_SOARER_WILDHAMMER,
      UNIT_H0F5_CLOUD_GUARDIAN_WILDHAMMER_ELITE, UNIT_H0FC_AERIE_RIDER_WILDHAMMER_SUMMON, UNIT_H0FE_SHARPBEAK_WILDHAMMER_SUMMON,
      UNIT_H0FF_SHARPBEAK_WILDHAMMER_SUMMON, UNIT_H0FG_SHARPBEAK_WILDHAMMER_SUMMON
    });

    UnitTypeTraitRegistry.Register(new RagingAxes
    {
      BuffId = BUFF_B10V_RAGING_AXES_WILDHAMMER_SIEGEBREAKER,
      DamageMultiplier = 1.5f,
      RecoilFraction = 0.5f
    }, UNIT_H0F4_SIEGEBREAKER_WILDHAMMER);

    UnitTypeTraitRegistry.Register(new Fixation
    {
      AbilityTypeId = ABILITY_A1BL_FIXATION_WILDHAMMER_SIEGEBREAKER,
      DamageBonus = 0.25f,
      DamageReduction = 0.25f
    }, UNIT_H0F4_SIEGEBREAKER_WILDHAMMER);

    SpellRegistry.Register(new IntoTheFraySpell(ABILITY_A1BM_INTO_THE_FRAY_WILDHAMMER_RAM_VANGUARD)
    {
      Radius = 600,
      Duration = 10,
      HealthThreshold = 0.1f,
      DamageReduction = 0.95f,
      BuffApplicatorId = ABILITY_A1BN_INTO_THE_FRAY_WILDHAMMER_RAM_VANGUARD_BUFF,
      BuffId = BUFF_B10W_INTO_THE_FRAY,
      CastEffectPath = @"war3mapImported\WildhammerFrayCaster.mdl"
    });

    var travelersFriend = new TravelersFriendSpell(ABILITY_A1BO_TRAVELER_S_FRIEND_WILDHAMMER_MESSENGER)
    {
      DetachAbilityId = ABILITY_A1BP_DETACH_WILDHAMMER_MESSENGER,
      TrueSightAbilityId = ABILITY_ATRU_TRUE_SIGHT_TEAL_FEL_WRAITH_RED_SHADE
    };
    SpellRegistry.Register(travelersFriend);
    SpellRegistry.Register(new TravelersFriendDetachSpell(ABILITY_A1BP_DETACH_WILDHAMMER_MESSENGER)
    {
      TravelersFriend = travelersFriend
    });

    foreach (var (ironforgeResearch, wildhammerResearch) in WildhammerFaction.SharedResearchEquivalents)
    {
      ResearchManager.Register(new CustomResearch(wildhammerResearch, 0)
      {
        ResearchFunc = researchingPlayer => researchingPlayer.SetTechResearched(ironforgeResearch, 1)
      });
    }
  }

  private static void RegisterKurdran()
  {
    SpellRegistry.Register(new CallOfTheAerieSpell(ABILITY_A1B2_CALL_OF_THE_AERIE_WILDHAMMER_KURDRAN)
    {
      RiderUnitTypeId = UNIT_H0FC_AERIE_RIDER_WILDHAMMER_SUMMON,
      RiderDuration = 30,
      ExtraRiderResearch = UPGRADE_R11B_STORM_OVER_NORTHREND_WILDHAMMER,
      HalvedCooldownResearch = UPGRADE_R119_SONS_OF_LOTHAR_WILDHAMMER,
      SummonEffectPath = @"Abilities\Spells\Orc\FeralSpirit\feralspirittarget.mdl"
    });

    SpellRegistry.Register(new SkyreesDiveSpell(ABILITY_A1AX_SKY_REE_S_DIVE_WILDHAMMER_KURDRAN)
    {
      Damage = new LeveledAbilityField<float> { Base = 0, PerLevel = 50 },
      Radius = 225,
      KnockbackDistance = 200,
      KnockbackDuration = 0.35f,
      LeapHeight = 350,
      LeapSpeed = 1000,
      ImpactPath = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl"
    });

    SpellRegistry.Register(new TalonsOfSkyreeSpell(ABILITY_A1AY_TALONS_OF_SKY_REE_WILDHAMMER_KURDRAN)
    {
      Damage = new LeveledAbilityField<float> { Base = 0, PerLevel = 50 },
      SwoopSpeed = 1500,
      LiftDuration = 2,
      LiftHeight = 400,
      RiseTime = 0.5f,
      SlamSpeed = 2000,
      StunAbilityId = ABILITY_A1AZ_TALONS_OF_SKY_REE_STUN_DUMMY,
      SlamEffectPath = @"Abilities\Spells\Orc\WarStomp\WarStompCaster.mdl"
    });

    UnitTypeTraitRegistry.Register(new LethalStrike
    {
      AbilityTypeId = ABILITY_A1B0_LETHAL_STRIKE_WILDHAMMER_KURDRAN,
      HitsRequired = 4,
      BonusDamage = 0,
      BonusDamagePerLevel = 25
    }, UNIT_H0CW_SKY_THANE_OF_THE_WILDHAMMER_WILDHAMMER);
  }

  private static void RegisterTalonaxe()
  {
    SpellRegistry.Register(new BloodHuntSpell(ABILITY_A1B3_BLOOD_HUNT_WILDHAMMER_TALONAXE)
    {
      BiteDamage = new LeveledAbilityField<float> { Base = 0, PerLevel = 40 },
      DamagePerSecond = new LeveledAbilityField<float> { Base = 5, PerLevel = 10 },
      Duration = new LeveledAbilityField<float> { Base = 1, PerLevel = 0.5f },
      BleedDuration = 5,
      BleedApplicatorId = ABILITY_A1BS_BLOOD_HUNT_WILDHAMMER_TALONAXE_BUFF,
      BleedBuffId = BUFF_B10X_BLOOD_HUNT,
      WolfSpeed = 900,
      PinAbilityId = ABILITY_A1B4_BLOOD_HUNT_PIN_DUMMY,
      WolfPath = @"war3mapImported\WildhammerBloodHuntWolf.mdl"
    });

    SpellRegistry.Register(new MastersWhistleSpell(ABILITY_A1B5_MASTER_S_WHISTLE_WILDHAMMER_TALONAXE)
    {
      Radius = 600,
      Heal = new LeveledAbilityField<float> { Base = 25, PerLevel = 50 },
      Duration = 8,
      GryphonTypeIds = new HashSet<int>
      {
        UNIT_H0FL_GRYPHON_RIDER_WILDHAMMER,
        UNIT_H0F5_CLOUD_GUARDIAN_WILDHAMMER_ELITE,
        UNIT_H0F6_GRYPHON_WILDHAMMER,
        UNIT_H0F7_SOARER_WILDHAMMER,
        UNIT_H0FC_AERIE_RIDER_WILDHAMMER_SUMMON,
        UNIT_H0FE_SHARPBEAK_WILDHAMMER_SUMMON,
        UNIT_H0FF_SHARPBEAK_WILDHAMMER_SUMMON,
        UNIT_H0FG_SHARPBEAK_WILDHAMMER_SUMMON
      },
      AttackSpeedAbilityId = ABILITY_A1B7_MASTER_S_WHISTLE_ATTACK_SPEED_WILDHAMMER_TALONAXE,
      BuffApplicatorId = ABILITY_A1B6_MASTER_S_WHISTLE_WILDHAMMER_TALONAXE_BUFF,
      BuffId = BUFF_B10U_MASTER_S_WHISTLE,
      HealEffectPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
    });
  }

  private static void RegisterCloudGuardian()
  {
    SpellRegistry.Register(new StormJavelinSpell(ABILITY_A1BA_STORM_JAVELIN_WILDHAMMER_CLOUD_GUARDIAN)
    {
      Damage = 50,
      DamagePerPierce = 25,
      Range = 800,
      Speed = 1200,
      CollisionRadius = 90,
      SlowAbilityId = ABILITY_A1BB_STORM_JAVELIN_SLOW_DUMMY,
      JavelinPath = @"war3mapImported\WildhammerCloudGuardianMissile.mdl",
      HitEffectPath = @"Abilities\Weapons\Bolt\BoltImpact.mdl"
    });

    SpellRegistry.Register(new UpdraftSpell(ABILITY_A1BC_UPDRAFT_WILDHAMMER_CLOUD_GUARDIAN)
    {
      Radius = 250,
      KnockbackDistance = 200,
      KnockbackDuration = 0.35f,
      WallDamage = 50,
      WallEffectPath = @"Abilities\Weapons\AncientProtectorMissile\AncientProtectorMissile.mdl",
      SlowAbilityId = ABILITY_A1BD_UPDRAFT_SLOW_DUMMY,
      CastEffectPath = @"Abilities\Spells\NightElf\Cyclone\CycloneTarget.mdl",
      CastEffectDuration = 1
    });

    UnitTypeTraitRegistry.Register(new SpellOnAttack(ABILITY_A1BT_MASTER_OF_LIGHTNING_WILDHAMMER_CLOUD_GUARDIAN)
    {
      DummyAbilityId = ABILITY_VP27_FORKED_LIGHTNING_IRONFORGE_FALSTAD_DUMMY,
      DummyOrderId = ORDER_FORKED_LIGHTNING,
      ProcChance = 0.15f,
      RequiredResearch = UPGRADE_VP31_MASTERS_OF_LIGHTNING_IRONFORGE,
      BonusChance = 0.05f,
      BonusChanceResearch = UPGRADE_R11C_WRATH_OF_THE_THUNDERAAN_WILDHAMMER
    }, UNIT_H0F5_CLOUD_GUARDIAN_WILDHAMMER_ELITE);
  }
}
