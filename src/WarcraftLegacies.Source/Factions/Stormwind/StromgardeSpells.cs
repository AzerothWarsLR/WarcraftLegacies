using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Stormwind.Spells;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Stormwind;

/// <summary>Sets up the spells of Stromgarde's heroes.</summary>
public static class StromgardeSpells
{
  /// <summary>Sets up the spells of Thoras, Danath, the Champion of Arathor and the Battlemage.</summary>
  public static void Setup()
  {
    RegisterThoras();
    RegisterDanath();
    RegisterChampionOfArathor();
    new MagicDefenseVulnerability
    {
      UnitTypeId = UNIT_N0Z9_BATTLEMAGE_STROMGARDE,
      ExtraAttackDamage = 0.5f
    }.Register();
  }

  private static void RegisterThoras()
  {
    SpellRegistry.Register(new KingsCommandSpell(ABILITY_A1DK_KING_S_COMMAND_STROMGARDE_THORAS)
    {
      Radius = 600,
      BuffAbilityId = ABILITY_A1DL_KING_S_COMMAND_BUFF_STROMGARDE_THORAS_DUMMY,
      CastEffectPath = @"Abilities\Spells\NightElf\BattleRoar\RoarCaster.mdl"
    });

    new CrownOfArathor
    {
      Hero = AllLegends.Stormwind.Thoras,
      AuraAbilityId = ABILITY_A1DM_CROWN_OF_ARATHOR_STROMGARDE_THORAS,
      BuffAbilityId = ABILITY_A1DN_CROWN_OF_ARATHOR_BELOW_HALF_STROMGARDE_THORAS_BUFF,
      Radius = 700
    }.Register();

    SpellRegistry.Register(new HighlandChargeSpell(ABILITY_A1DO_HIGHLAND_CHARGE_STROMGARDE_THORAS)
    {
      Damage = new LeveledAbilityField<float> { Base = 50, PerLevel = 150 },
      Speed = 1100,
      HitRadius = 150,
      KnockbackDistance = 200,
      KnockbackDuration = 0.4f,
      StunAbilityId = ABILITY_A1DP_HIGHLAND_CHARGE_STUN_DUMMY,
      HitEffectPath = @"Abilities\Weapons\AncientProtectorMissile\AncientProtectorMissile.mdl",
      TrailEffectPath = @"Objects\Spawnmodels\Undead\ImpaleTargetDust\ImpaleTargetDust.mdl"
    });
  }

  private static void RegisterDanath()
  {
    SpellRegistry.Register(new ShieldSlamSpell(ABILITY_A1DQ_SHIELD_SLAM_STROMGARDE_DANATH)
    {
      Damage = new LeveledAbilityField<float> { Base = 0, PerLevel = 50 },
      DamagePerArmor = 5,
      RushSpeed = 1200,
      StrikeDistance = 90,
      StunAbilityId = ABILITY_A1DR_SHIELD_SLAM_STUN_DUMMY,
      HitEffectPath = @"Abilities\Spells\Human\StormBolt\StormBoltMissile.mdl"
    });

    SpellRegistry.Register(new CommandersMarkSpell(ABILITY_A1DS_COMMANDER_S_MARK_STROMGARDE_DANATH)
    {
      DamageBonus = new LeveledAbilityField<float> { Base = 0.05f, PerLevel = 0.05f },
      Duration = 10,
      BuffApplicatorId = ABILITY_A1DT_COMMANDER_S_MARK_STROMGARDE_DANATH_BUFF,
      BuffId = BUFF_B116_COMMANDER_S_MARK
    });

    new BattleHardened
    {
      AbilityTypeId = ABILITY_A1DU_BATTLE_HARDENED_STROMGARDE_DANATH,
      BuffAbilityId = ABILITY_A1DV_BATTLE_HARDENED_STROMGARDE_DANATH_BUFF,
      MaximumStacks = new LeveledAbilityField<int> { Base = 2, PerLevel = 2 },
      StackDuration = 5
    }.Register();

    SpellRegistry.Register(new StandOfHonorHoldSpell(ABILITY_A1DW_STAND_OF_HONOR_HOLD_STROMGARDE_DANATH)
    {
      Duration = new LeveledAbilityField<float> { Base = 3, PerLevel = 2 },
      BuffApplicatorId = ABILITY_A1DX_STAND_OF_HONOR_HOLD_STROMGARDE_DANATH_BUFF,
      BuffId = BUFF_B118_STAND_OF_HONOR_HOLD
    });
  }

  private static void RegisterChampionOfArathor()
  {
    SpellRegistry.Register(new HammerOfArathorSpell(ABILITY_A1DY_HAMMER_OF_ARATHOR_STROMGARDE_CHAMPION_OF_ARATHOR)
    {
      Damage = 90,
      SlowAbilityId = ABILITY_A1DZ_HAMMER_OF_ARATHOR_SLOW_STROMGARDE_CHAMPION_OF_ARATHOR_DUMMY,
      HitEffectPath = @"Abilities\Weapons\AncientProtectorMissile\AncientProtectorMissile.mdl"
    });

    new TrollbaneBloodline
    {
      AbilityTypeId = ABILITY_A1E0_TROLLBANE_BLOODLINE_STROMGARDE_CHAMPION_OF_ARATHOR,
      AttacksPerCleave = 4,
      CleaveFraction = 0.5f,
      Radius = 200,
      CleaveEffectPath = @"Abilities\Spells\Other\Cleave\CleaveDamageTarget.mdl"
    }.Register();

    new LastDefender
    {
      AbilityTypeId = ABILITY_A1E1_LAST_DEFENDER_STROMGARDE_CHAMPION_OF_ARATHOR,
      HealthThreshold = 0.3f,
      DamageReduction = 0.5f,
      Duration = 5,
      Cooldown = 60,
      BuffApplicatorId = ABILITY_A1E2_LAST_DEFENDER_STROMGARDE_CHAMPION_OF_ARATHOR_BUFF,
      BuffId = BUFF_B11A_LAST_DEFENDER
    }.Register();
  }
}
