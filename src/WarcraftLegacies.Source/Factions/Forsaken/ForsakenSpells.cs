using MacroTools.Spells;
using MacroTools.UnitTraits;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Forsaken.Spells;
using WarcraftLegacies.Source.Factions.Legion.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Forsaken;

/// <summary>Sets up the Forsaken's unit abilities.</summary>
public static class ForsakenSpells
{
  /// <summary>Registers the Forsaken's spells and unit traits.</summary>
  public static void Setup()
  {
    SpellRegistry.Register(new MassAnySpell(ABILITY_A185_SLAM_FORSAKEN_PLAGUE_CONSTRUCT)
    {
      Radius = 250,
      Damage = new LeveledAbilityField<float>
      {
        Base = 25
      },
      MaxDamage = 150,
      DummyAbilityId = ABILITY_S00H_THUNDER_CLAP_DUMMY,
      DummyAbilityOrderId = ORDER_CRIPPLE,
      SpecialEffect = @"Abilities\Spells\Orc\WarStomp\WarStompCaster.mdl",
      CastFilter = CastFilters.IsTargetEnemyAliveAndGroundUnits,
      TargetType = SpellTargetType.None
    });

    UnitTypeTraitRegistry.Register(new DeathThroes
    {
      BurstDamage = 75,
      BurstRadius = 250,
      BurstEffectPath = @"Objects\Spawnmodels\Undead\UndeadLargeDeathExplode\UndeadLargeDeathExplode.mdl",
      CloudDuration = 12,
      CloudRadius = 250,
      CloudDamagePerSecond = 10,
      CloudEffectPath = @"Units\Undead\PlagueCloud\PlagueCloud.mdl",
      CloudTickEffectPath = @"Units\Undead\PlagueCloud\PlagueCloudtarget.mdl"
    }, UNIT_N07W_PLAGUE_CONSTRUCT_FORSAKEN);

    new DarkMinionsOnKill
    {
      KillerTypeId = UNIT_N0BY_DARK_RANGER_FORSAKEN,
      MinionTypeId = FourCC("ndr1"),
      Chance = 20,
      MinionDuration = 60,
      RiseEffectPath = @"Abilities\Spells\Undead\AnimateDead\AnimateDeadTarget.mdl"
    }.Register();

    SpellRegistry.Register(new MassAnySpell(ABILITY_A188_MASS_SLEEP_FORSAKEN_VARIMATHRAS)
    {
      Radius = 250,
      DummyAbilityId = ABILITY_A189_MASS_SLEEP_DUMMY_MASS_SLEEP,
      DummyAbilityOrderId = ORDER_SLEEP,
      SpecialEffect = @"Abilities\Spells\Undead\Sleep\SleepSpecialArt.mdl",
      CastFilter = CastFilters.IsTargetEnemyAndAliveUnits,
      TargetType = SpellTargetType.Point
    });

    SpellRegistry.Register(new PhantomStep(ABILITY_A187_PHANTOM_STEP_FORSAKEN_VARIMATHRAS)
    {
      CasterEffect = @"Abilities\Spells\Orc\MirrorImage\MirrorImageCaster.mdl",
      DummyAbilityId = ABILITY_TPY4_PHANTOM_STEP_DUMMY,
      DummyOrderId = ORDER_WAND_ILLUSION
    });

    SpellRegistry.Register(new HellfireRainSpell(ABILITY_A18A_HELLFIRE_RAIN_FORSAKEN_VARIMATHRAS)
    {
      WavesByLevel = new[] { 5, 7, 9, 11 },
      WaveInterval = 1,
      ChannelFractionNeeded = 0.75f,
      MeteorDamage = new LeveledAbilityField<float> { Base = 35, PerLevel = 40 },
      MeteorRadius = 250,
      MeteorDelay = 1,
      StunAbilityId = ABILITY_A18C_HELLFIRE_RAIN_STUN_DUMMY_HELLFIRE_RAIN,
      FelFireDamagePerSecond = new LeveledAbilityField<float> { Base = 10, PerLevel = 5 },
      FelFireDuration = 5,
      MeteorEffectPath = @"Units\Demon\Infernal\InfernalBirth.mdl",
      FelFireEffectPath = @"Environment\LargeBuildingFire\LargeBuildingFire1.mdl",
      FelFireTickEffectPath = @"Abilities\Spells\Demon\RainOfFire\RainOfFireTarget.mdl"
    });

    UnitTypeTraitRegistry.Register(new FixedUnitColor { Color = playercolor.Red }, UNIT_UVAR_ARCH_DREADLORD_FORSAKEN);

    SpellRegistry.Register(new UnravellingDoomSpell(ABILITY_A18B_UNRAVELLING_DOOM_FORSAKEN_VARIMATHRAS)
    {
      DoomBuffId = FourCC("BNdo"),
      BaseDamagePerSecond = new LeveledAbilityField<float> { Base = 10, PerLevel = 40 },
      DamageGrowthPerSecond = new LeveledAbilityField<float> { Base = 2, PerLevel = 3 },
      DoomGuardTypeId = FourCC("nbal"),
      DoomGuardDuration = 120,
      DamagePerStep = 250,
      BonusPerStep = 0.1f,
      MaxBonus = 1,
      RiseEffectPath = @"Abilities\Spells\Other\Doom\DoomDeath.mdl"
    });
  }
}
