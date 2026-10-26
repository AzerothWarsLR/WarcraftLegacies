using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Theramore.Spells;

namespace WarcraftLegacies.Source.Factions.Theramore;

public static class TheramoreSpells
{
  public static void Setup()
  {
    SpellRegistry.Register(new HoldTheLineSpell(ABILITY_A18G_HOLD_THE_LINE_THERAMORE_MARCUS_JONATHAN)
    {
      Radius = 300,
      Duration = 8,
      ArmorPerAlly = new LeveledAbilityField<float> { Base = 0.25f, PerLevel = 0.25f },
      MaximumArmor = new LeveledAbilityField<float> { Base = 2, PerLevel = 1 },
      ArmorAuraId = ABILITY_A18O_HOLD_THE_LINE_ARMOR_DUMMY_THERAMORE,
      ArmorPerAuraLevel = 0.5f,
      MaximumAuraLevel = 12
    });

    SpellRegistry.Register(new PikeThrustSpell(ABILITY_A18H_PIKE_THRUST_THERAMORE_MARCUS_JONATHAN)
    {
      Damage = new LeveledAbilityField<float> { Base = 25, PerLevel = 50 },
      Length = 400,
      Width = 120,
      PushDistance = 200,
      PushDuration = 0.3f,
      StunAbilityId = ABILITY_A18K_THERAMORE_STUN_DUMMY_THERAMORE,
      HitEffectPath = @"Abilities\Spells\Other\Stampede\StampedeMissileDeath.mdl"
    });

    UnitTypeTraitRegistry.Register(new PikeReach
    {
      AbilityTypeId = ABILITY_A18I_PIKE_REACH_THERAMORE_MARCUS_JONATHAN,
      DamageFraction = new LeveledAbilityField<float> { Base = 0.1f, PerLevel = 0.1f },
      Reach = 120,
      SearchRadius = 100
    }, UNIT_H0D1_GENERAL_OF_THERAMORE_THERAMORE);

    SpellRegistry.Register(new ChargeOfTheramoreSpell(ABILITY_A18J_CHARGE_OF_THERAMORE_THERAMORE_MARCUS_JONATHAN)
    {
      Radius = 700,
      Duration = 2.5f,
      ChargeSpeed = 522,
      HitRadius = 120,
      Damage = new LeveledAbilityField<float> { Base = 0, PerLevel = 50 },
      KnockbackDistance = 150,
      StunAbilityId = ABILITY_A18X_THERAMORE_SHORT_STUN_DUMMY_THERAMORE,
      ChargeEffectPath = @"Abilities\Spells\Orc\WarStomp\WarStompCaster.mdl",
      HitEffectPath = @"Abilities\Spells\Human\ThunderClap\ThunderClapCaster.mdl"
    });

    SpellRegistry.Register(new PistolShotSpell(ABILITY_A18L_PISTOL_SHOT_THERAMORE_GARRAN_VIMES)
    {
      Damage = new LeveledAbilityField<float> { Base = 25, PerLevel = 50 },
      PassThroughFraction = 0.5f,
      PassThroughLength = 500,
      PassThroughWidth = 100,
      StunAbilityId = ABILITY_A18X_THERAMORE_SHORT_STUN_DUMMY_THERAMORE,
      HitEffectPath = @"Abilities\Weapons\Rifle\RifleImpact.mdl"
    });

    var markedTarget = new MarkedTarget
    {
      AbilityTypeId = ABILITY_A18M_MARKED_TARGET_THERAMORE_GARRAN_VIMES,
      ChancePercent = new LeveledAbilityField<float> { Base = 0, PerLevel = 20 },
      MarkAuraId = ABILITY_A18W_MARKED_BUFF_DUMMY_THERAMORE,
      MeleeFormTypeId = UNIT_H0D3_CAPTAIN_OF_THE_THERAMORE_GUARD_THERAMORE,
      Duration = 6,
      DamageBonus = new LeveledAbilityField<float> { Base = 0, PerLevel = 0.02f },
      MarkEffectPath = @"war3mapImported\MarkOfIronWill.mdl"
    };
    markedTarget.Register();
    UnitTypeTraitRegistry.Register(markedTarget, new[]
    {
      UNIT_H0D2_CAPTAIN_OF_THE_THERAMORE_GUARD_THERAMORE,
      UNIT_H0D3_CAPTAIN_OF_THE_THERAMORE_GUARD_THERAMORE
    });

    UnitTypeTraitRegistry.Register(new SwordStanceLifesteal
    {
      AbilityTypeId = ABILITY_A18N_STEEL_AND_POWDER_THERAMORE_GARRAN_VIMES,
      LifestealFraction = new LeveledAbilityField<float> { Base = 0.05f, PerLevel = 0.05f },
      HealEffectPath = @"Abilities\Spells\Undead\VampiricAura\VampiricAuraTarget.mdl"
    }, UNIT_H0D3_CAPTAIN_OF_THE_THERAMORE_GUARD_THERAMORE);

    SpellRegistry.Register(new PowderKegSpell(ABILITY_A18P_POWDER_KEG_THERAMORE_GARRAN_VIMES)
    {
      KegTypeId = UNIT_H0D5_POWDER_KEG_THERAMORE,
      FuseDuration = 8,
      Radius = 300,
      Damage = new LeveledAbilityField<float> { Base = 100, PerLevel = 150 },
      StunAbilityId = ABILITY_A18K_THERAMORE_STUN_DUMMY_THERAMORE,
      ExplosionEffectPath = @"Objects\Spawnmodels\Other\NeutralBuildingExplosion\NeutralBuildingExplosion.mdl"
    });

    SpellRegistry.Register(new StormBrandSpell(ABILITY_A18Q_STORM_BRAND_THERAMORE_STORM_SORCERER)
    {
      Duration = 10,
      StrikeInterval = 2,
      StrikeDamage = 40,
      ArcDamage = 20,
      ArcRadius = 300,
      BrandEffectPath = @"Abilities\Spells\Orc\Purge\PurgeBuffTarget.mdl",
      StrikeEffectPath = @"Abilities\Spells\Other\Monsoon\MonsoonBoltTarget.mdl"
    });

    SpellRegistry.Register(new GaleForceSpell(ABILITY_A18R_GALE_FORCE_THERAMORE_STORM_SORCERER)
    {
      Range = 500,
      ConeAngle = 60,
      Damage = 50,
      PushDistance = 250,
      PushDuration = 0.4f,
      WindEffectPath = @"Abilities\Spells\NightElf\Cyclone\CycloneTarget.mdl"
    });

    UnitTypeTraitRegistry.Register(new EyeOfTheStorm
    {
      Radius = 600,
      ChancePercent = 30,
      Duration = 4,
      AttackSpeedAbilityId = ABILITY_A18T_EYE_OF_THE_STORM_ATTACK_SPEED_DUMMY_EYE_OF_THE_STORM,
      EffectPath = @"war3mapImported\LightningBuffOverhead.mdl"
    }, UNIT_H0D4_STORM_SORCERER_THERAMORE_ELITE);
  }
}
