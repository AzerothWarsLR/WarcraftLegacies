using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.BansheesHost.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.BansheesHost;

public static class BansheesHostSpells
{
  public static void Setup()
  {
    SpellRegistry.Register(new KeeningWailSpell(ABILITY_A17J_KEENING_WAIL_BANSHEESHOST_WAILING_SORROW)
    {
      Damage = 75,
      MaxDamage = 700,
      Radius = 400
    });

    SpellRegistry.Register(new AnguishSpell(ABILITY_A17K_ANGUISH_BANSHEESHOST_WAILING_SORROW)
    {
      DamagePerSecond = 40,
      Duration = 8,
      BuffId = BUFF_B108_ANGUISH,
      TickEffectPath = @"Abilities\Spells\Undead\Possession\PossessionMissile.mdl",
      HealEffectPath = @"Abilities\Spells\Undead\VampiricAura\VampiricAuraTarget.mdl"
    });

    UnitTypeTraitRegistry.Register(new LingeringGrief
    {
      Duration = 8,
      Radius = 300,
      DamagePerSecond = 45,
      SpiritEffectPath = @"units\creeps\BansheeGhost\BansheeGhost.mdl",
      TickEffectPath = @"Abilities\Spells\Undead\DeathCoil\DeathCoilSpecialArt.mdl"
    }, UNIT_U10A_WAILING_SORROW_BANSHEESHOST_ELITE);
    SpellRegistry.Register(new SpiritLashSpell(ABILITY_A17N_SPIRIT_LASH_BANSHEESHOST_SYLVANAS)
    {
      Damage = new LeveledAbilityField<float> { Base = 10, PerLevel = 50 },
      Range = 900,
      Width = 120,
      Speed = 1000,
      SilenceAbilityId = ABILITY_A17Q_SILENCE_DUMMY,
      SilenceLevel = 1,
      SpiritPath = @"units\creeps\BansheeGhost\BansheeGhost.mdl",
      HitEffectPath = @"Abilities\Spells\Undead\DeathCoil\DeathCoilSpecialArt.mdl"
    });

    SpellRegistry.Register(new EtherealVeilSpell(ABILITY_A17O_ETHEREAL_VEIL_BANSHEESHOST_SYLVANAS)
    {
      BuffId = BUFF_B109_ETHEREAL_VEIL,
      Duration = new LeveledAbilityField<float> { Base = 3, PerLevel = 1 },
      Alpha = 110
    });

    UnitTypeTraitRegistry.Register(new EtherealVeilTrait
    {
      AbilityTypeId = ABILITY_A17O_ETHEREAL_VEIL_BANSHEESHOST_SYLVANAS,
      BuffId = BUFF_B109_ETHEREAL_VEIL,
      ManaBurned = new LeveledAbilityField<float> { Base = 10, PerLevel = 10 },
      BurnEffectPath = @"Abilities\Spells\Human\Feedback\SpellBreakerAttack.mdl"
    }, UNIT_U03B_BANSHEE_QUEEN_BANSHEESHOST);

    new MourningChorus
    {
      AbilityTypeId = ABILITY_A17P_MOURNING_CHORUS_BANSHEESHOST_SYLVANAS,
      HeroTypeId = UNIT_U03B_BANSHEE_QUEEN_BANSHEESHOST,
      SpiritTypeId = UNIT_U10B_MOURNING_SPIRIT_BANSHEESHOST,
      Radius = 800,
      SpiritDuration = 15,
      ChanceByLevel = new[] { 25, 50, 75, 100 },
      RiseEffectPath = @"Abilities\Spells\Undead\AnimateDead\AnimateDeadTarget.mdl"
    }.Register();

    SpellRegistry.Register(new InspireMadness(ABILITY_A17M_INSPIRE_MADNESS_BANSHEESHOST_SYLVANAS)
    {
      Radius = 300,
      CountBase = 2,
      CountLevel = 4,
      Duration = 30,
      EffectTarget = @"Abilities\Spells\Other\Charm\CharmTarget.mdl",
      EffectScaleTarget = 0.5f
    });

    UnitTypeTraitRegistry.Register(new BlackArrowAlwaysOn(), UNIT_USYL_DARK_RANGER_FORSAKEN);

    SpellRegistry.Register(new ShadowStepSpell(ABILITY_A17U_SHADOW_STEP_FORSAKEN_SYLVANAS)
    {
      Damage = new LeveledAbilityField<float> { Base = 10, PerLevel = 30 },
      LeapDistance = 400,
      LeapDuration = 0.3f,
      ArrowCount = 5,
      FanAngle = 60,
      ArrowRange = 800,
      ArrowWidth = 80,
      ArrowPath = @"Abilities\Weapons\MoonPriestessMissile\MoonPriestessMissile.mdl",
      LeapEffectPath = @"Abilities\Spells\Undead\DarkRitual\DarkRitualTarget.mdl"
    });

    UnitTypeTraitRegistry.Register(new RangerGeneralsFocus
    {
      AbilityTypeId = ABILITY_A17S_RANGER_GENERAL_S_FOCUS_FORSAKEN_SYLVANAS,
      BlackArrowAbilityTypeId = ABILITY_A17R_BLACK_ARROW_FORSAKEN_SYLVANAS,
      AttacksPerPierce = 4,
      Length = 600,
      Width = 100,
      DamageFraction = new LeveledAbilityField<float> { Base = 0.25f, PerLevel = 0.15f },
      MinionTypeId = FourCC("ndr2"),
      MinionCount = 3,
      MinionDuration = 80,
      ArrowPath = @"Abilities\Weapons\MoonPriestessMissile\MoonPriestessMissile.mdl"
    }, UNIT_USYL_DARK_RANGER_FORSAKEN);

    SpellRegistry.Register(new WailingArrowSpell(ABILITY_A17T_WAILING_ARROW_FORSAKEN_SYLVANAS)
    {
      ImpactDamage = new LeveledAbilityField<float> { Base = 100, PerLevel = 100 },
      WailDamage = new LeveledAbilityField<float> { Base = 50, PerLevel = 50 },
      Radius = 350,
      SecondWailDelay = 1,
      SilenceAbilityId = ABILITY_A17Q_SILENCE_DUMMY,
      SilenceLevel = 2,
      ArrowPath = @"Abilities\Weapons\MoonPriestessMissile\MoonPriestessMissile.mdl",
      WailEffectPath = @"Abilities\Spells\Other\HowlOfTerror\HowlCaster.mdl"
    });
  }
}
