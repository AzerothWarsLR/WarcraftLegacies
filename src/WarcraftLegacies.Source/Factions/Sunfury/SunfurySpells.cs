using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Sunfury.Spells;
using WarcraftLegacies.Source.Shared.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sunfury;

public static class SunfurySpells
{
  public static void Setup()
  {
    var resurgentFlameStrike = new ResurgentSpell(ABILITY_A04H_RESURGENT_FLAME_STRIKE_QUEL_THALAS_KAEL_THAS,
      ABILITY_A0F9_RESURGENT_FLAME_STRIKE_QUEL_THALAS_KAEL_THAS_DUMMY, ORDER_FLAMESTRIKE)
    {
      Duration = 14,
      Interval = 7
    };
    SpellRegistry.Register(resurgentFlameStrike);

    var massBanish = new MassAnySpell(ABILITY_A0FD_MASS_BANISH_QUEL_THALAS_KAEL_THAS)
    {
      DummyAbilityId = ABILITY_A0FE_MASS_BANISH_QUEL_THALAS_KAEL_THAS_DUMMY_CASTER,
      DummyAbilityOrderId = ORDER_BANISH,
      Radius = 250,
      CastFilter = CastFilters.IsTargetOrganicAndAlive,
      TargetType = SpellTargetType.Point
    };
    SpellRegistry.Register(massBanish);

    var siphoningRitual = new SiphoningRitual(ABILITY_A0FA_SIPHONING_RITUAL_QUEL_THALAS_KAEL_THAS)
    {
      TargetCountBase = 24,
      TargetCountLevel = 0,
      LifeDrainedPerSecondBase = 30,
      LifeDrainedPerSecondLevel = 10,
      ManaDrainedPerSecondBase = 15,
      ManaDrainedPerSecondLevel = 5,
      Range = 800,
      Radius = 225,
      Interval = 0.1f
    };
    SpellRegistry.Register(siphoningRitual);

    SpellRegistry.Register(new PsychicBlowSpell(ABILITY_A19A_PSYCHIC_BLOW_SUNFURY_THALADRED)
    {
      Damage = new LeveledAbilityField<float> { Base = 10, PerLevel = 50 },
      KnockbackDistance = 300,
      KnockbackDuration = 0.3f,
      StunAbilityId = ABILITY_A19B_PSYCHIC_BLOW_STUN_DUMMY,
      ImpactEffectPath = @"Abilities\Spells\Undead\DeathCoil\DeathCoilSpecialArt.mdl"
    });

    SpellRegistry.Register(new DarkenersGazeSpell(ABILITY_A19C_DARKENER_S_GAZE_SUNFURY_THALADRED)
    {
      Duration = 8,
      SpeedAbilityId = ABILITY_A19E_DARKENER_S_GAZE_SPEED_SUNFURY_THALADRED,
      BuffApplicatorId = ABILITY_A19D_DARKENER_S_GAZE_SUNFURY_THALADRED_BUFF,
      BuffId = BUFF_B10H_DARKENER_S_GAZE
    });

    UnitTypeTraitRegistry.Register(new DarkenersGazeTrait
    {
      AbilityTypeId = ABILITY_A19C_DARKENER_S_GAZE_SUNFURY_THALADRED,
      BuffId = BUFF_B10H_DARKENER_S_GAZE,
      BonusDamage = new LeveledAbilityField<float> { Base = 0, PerLevel = 15 }
    }, UNIT_H0DP_SUNFURY_CHAMPION_SUNFURY);

    UnitTypeTraitRegistry.Register(new SiphoningStrikes
    {
      AbilityTypeId = ABILITY_A19F_SIPHONING_STRIKES_SUNFURY_THALADRED,
      Mana = new LeveledAbilityField<float> { Base = 0, PerLevel = 4 },
      AllyMana = new LeveledAbilityField<float> { Base = 0, PerLevel = 1 },
      Radius = 500,
      DrainEffectPath = @"Abilities\Spells\Undead\AbsorbMana\AbsorbManaBirthMissile.mdl",
      RestoreEffectPath = @"Abilities\Spells\Undead\ReplenishMana\SpiritTouchTarget.mdl"
    }, UNIT_H0DP_SUNFURY_CHAMPION_SUNFURY);

    SpellRegistry.Register(new NightfallSpell(ABILITY_A19G_NIGHTFALL_SUNFURY_THALADRED)
    {
      Radius = 350,
      Duration = 6,
      DamagePerSecond = new LeveledAbilityField<float> { Base = 10, PerLevel = 20 },
      ManaPerSecond = new LeveledAbilityField<float> { Base = 4, PerLevel = 4 },
      SilenceAbilityId = ABILITY_A19H_NIGHTFALL_SILENCE_DUMMY,
      CastEffectPath = @"Abilities\Spells\Undead\DarkRitual\DarkRitualTarget.mdl",
      AreaEffectPath = @"Abilities\Spells\Undead\DeathandDecay\DeathandDecayTarget.mdl",
      AreaEffectScale = 1.2f
    });

    var fanOfFelBlades = new FanOfFelBladesSpell(ABILITY_A19I_FAN_OF_FEL_BLADES_SUNFURY_KAGANI)
    {
      Radius = 400,
      Damage = new LeveledAbilityField<float> { Base = 10, PerLevel = 40 },
      BonusDamage = new LeveledAbilityField<float> { Base = 0, PerLevel = 30 },
      MarkDuration = 6,
      BuffApplicatorId = ABILITY_A19J_MARKED_SUNFURY_KAGANI_BUFF,
      BuffId = BUFF_B10I_MARKED,
      CastEffectPath = @"Abilities\Spells\NightElf\FanOfKnives\FanOfKnivesCaster.mdl",
      MarkEffectPath = @"war3mapImported\MarkOfIronWill.mdl"
    };
    SpellRegistry.Register(fanOfFelBlades);
    UnitTypeTraitRegistry.Register(new FanOfFelBladesTrait { Spell = fanOfFelBlades },
      UNIT_H0DQ_SUNFURY_ASSASSIN_SUNFURY);

    UnitTypeTraitRegistry.Register(new FelTippedBlades
    {
      AbilityTypeId = ABILITY_A19K_FEL_TIPPED_BLADES_SUNFURY_KAGANI,
      DamagePerStack = new LeveledAbilityField<float> { Base = 1, PerLevel = 1 },
      MaxStacks = 5,
      Duration = 5,
      SlowAbilityId = ABILITY_A19L_FEL_POISON_SLOW_SUNFURY_KAGANI,
      BuffApplicatorId = ABILITY_A19M_FEL_POISON_SUNFURY_KAGANI_BUFF,
      BuffId = BUFF_B10J_FEL_POISON
    }, UNIT_H0DQ_SUNFURY_ASSASSIN_SUNFURY);

    SpellRegistry.Register(new TempestStormSpell(ABILITY_A199_TEMPEST_STORM_BLOODELVES_TEMPEST_KEEP)
    {
      Center = new Point(4118, -21702),
      RadiusX = 533,
      RadiusY = 494,
      Duration = 25,
      TickInterval = 1,
      DamagePerTick = 40,
      StormEffectPath = @"Doodads\Cinematic\EnergyField\EnergyField.mdl",
      StormEffectScale = 1,
      StormEffectSpacing = 300,
      StormRed = 200,
      StormGreen = 90,
      StormBlue = 255
    });

    UnitTypeTraitRegistry.Register(new RestoreManaFromDamage(ABILITY_A11N_ARCANE_ABSORPTION_SUNFURY_STORMWIND)
    {
      ManaPerDamage = new LeveledAbilityField<float>
      {
        Base = 0.20f,
        PerLevel = 0.20f
      },
      Effect = @"Abilities\Spells\Undead\ReplenishMana\SpiritTouchTarget.mdl"
    }, new[]
    {
      UNIT_N0E7_BLOODWARDER_SUNFURY,
      UNIT_N0E8_SKYSHIP_SUNFURY
    });

    UnitTypeTraitRegistry.Register(new AutocastOnCreated(ORDER_FLAMING_ARROWS), new[]
    {
      UNIT_H0CE_BLOOD_KNIGHT_SQUIRE_SUNFURY,
      UNIT_H0DF_BLOOD_KNIGHT_SQUIRE_BLOODELVES
    });

    UnitTypeTraitRegistry.Register(new AutocastOnCreated(ORDER_POISON_ARROWS), new[]
    {
      UNIT_H0CF_BOWMAN_SUNFURY,
      UNIT_H0DC_BOWMAN_BLOODELVES
    });
  }
}
