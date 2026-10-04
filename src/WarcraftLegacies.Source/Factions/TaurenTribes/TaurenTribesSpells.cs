using System.Collections.Generic;
using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Frostwolf.Spells;
using WarcraftLegacies.Source.Factions.TaurenTribes.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.TaurenTribes;

public static class TaurenTribesSpells
{
  public static void Setup()
  {
    var devour = new Devour(ABILITY_ADEV_DEVOUR_KODO_BEAST)
    {
      PercentageOfMaxHealth = 0.5f
    };
    SpellRegistry.Register(devour);

    var voodooHex = new InspireMadness(ABILITY_MD28_VOODOO_HEX_ROKHAN)
    {
      Radius = 400,
      CountBase = 5,
      CountLevel = 5,
      Duration = 60,
      ChancePercentage = 60.0f,
      EffectTarget = @"Abilities\Spells\Other\Charm\CharmTarget.mdl",
      EffectScaleTarget = 0.5f
    };
    SpellRegistry.Register(voodooHex);

    SpellRegistry.Register(new SpeedBurst(ABILITY_A164_WIND_WALK_TAUREN_TRIBES_SPIRIT_EAGLE)
    {
      SpeedBonus = 0.25f,
      Duration = 5
    });

    SpellRegistry.Register(new PiercingFrenzy(ABILITY_A16F_RAKING_TALONS_TAUREN_TRIBES_SPIRIT_EAGLE)
    {
      Duration = 10
    });

    SpellRegistry.Register(new PiercingFrenzy(ABILITY_A16G_SAVAGE_FRENZY_TAUREN_TRIBES_SPIRIT_WYVERN)
    {
      Duration = 10
    });

    SpellRegistry.Register(new Sunstrike(ABILITY_A16U_SUNSTRIKE_TAUREN_TRIBES)
    {
      Damage = 75,
      Healing = 60,
      HealRadius = 300
    });

    SpellRegistry.Register(new AncestralLegion(ABILITY_A0YX_ANCESTRAL_LEGION_FROSTWOLF_CAIRNE)
    {
      Duration = 60,
      HealthBonus = new LeveledAbilityField<float>
      {
        Base = 0.2f,
        PerLevel = 0.1f
      },
      DamageBonus = new LeveledAbilityField<float>
      {
        Base = 0.2f,
        PerLevel = 0.1f
      },
      SummonCap = new LeveledAbilityField<int>
      {
        Base = 6,
        PerLevel = 6
      },
      RememberChance = 1f,
      RememberableUnitTypeId = UNIT_OTAU_TAUREN_TAUREN_TRIBES,
      SummonEffect = @"Abilities\Spells\Demon\DarkPortal\DarkPortalTarget.mdl",
      DeathEffect = @"Abilities\Spells\Orc\Disenchant\DisenchantSpecialArt.mdl"
    });

    var warStompChieftainOgreLord = new MassAnySpell(ABILITY_AT06_WAR_STOMP_TAUREN_TRIBES)
    {
      Radius = 300,
      Damage = new LeveledAbilityField<float>
      {
        PerLevel = 25
      },
      DummyAbilityId = ABILITY_AT11_STUN_UNIT_TAUREN_TRIBES,
      DummyAbilityOrderId = ORDER_THUNDERBOLT,
      SpecialEffect = @"Abilities\Spells\Orc\WarStomp\WarStompCaster.mdl",
      CastFilter = CastFilters.IsTargetEnemyAliveAndGroundUnits,
      TargetType = SpellTargetType.None
    };
    SpellRegistry.Register(warStompChieftainOgreLord);

    SpellRegistry.Register(new ChallengingTaunt(ABILITY_A15C_CHALLENGING_TAUNT_TAUREN_TRIBES_OGRE_LORD)
    {
      ArmorAbilityId = ABILITY_A15D_CHALLENGING_TAUNT_ARMOR_TAUREN_TRIBES_OGRE_LORD_DUMMY
    });

    var bestialWrathRexxar = new BestialWrathSpell(ABILITY_A14L_BESTIAL_WRATH_REXXAR)
    {
      Radius = 600,
      Duration = new LeveledAbilityField<float> { Base = 5, PerLevel = 1 },
      AttackSpeedAbilityId = ABILITY_A14M_BESTIAL_WRATH_ATTACK_SPEED_REXXAR,
      DamageBonusAbilityId = ABILITY_A14N_BESTIAL_WRATH_DAMAGE_BONUS_REXXAR,
      BuffApplicatorId = ABILITY_A14O_BESTIAL_WRATH_BUFF_APPLICATOR_BUFF_APPLICATOR,
      BuffId = BUFF_B0DV_BESTIAL_WRATH,
      BeastUnitTypeIds = new[]
      {
        UNIT_NGZ4_MISHA_GREY_REXXAR_SUMMON,
        UNIT_NQB4_BERSERK_QUILBEAST_LEVEL_4_GREY_REXXAR_SUMMON,
        UNIT_N01J_SPIRIT_REXXAR
      }
    };
    SpellRegistry.Register(bestialWrathRexxar);

    var wildThrowRexxar = new Stormbolt(ABILITY_A14Q_WILD_THROW_REXXAR)
    {
      Damage = new LeveledAbilityField<float>
      {
        Base = 25f,
        PerLevel = 75f
      },
      DebuffAbilityId = ABILITY_A15Z_WILD_THROW_SLOW_REXXAR,
      DebuffOrderId = ORDER_SLOW,
      EffectModel = @"Abilities\Weapons\RexxarMissile\RexxarMissile",
      EffectScale = 1.8f
    };
    SpellRegistry.Register(wildThrowRexxar);

    SpellRegistry.Register(new SpiritMend(ABILITY_A14Y_SPIRIT_MEND_TAUREN_TRIBES_MAGATHA)
    {
      Healing = new LeveledAbilityField<float>
      {
        Base = 25,
        PerLevel = 25
      },
      MaximumBounces = 3,
      HealingReductionPerBounce = 0.15f,
      BounceRadius = 500,
      ShieldAbilityId = ABILITY_A152_EARTHEN_SHIELD_TAUREN_TRIBES_MAGATHA_DUMMY
    });

    SpellRegistry.Register(new GrimtotemWard(ABILITY_A14Z_GRIMTOTEM_WARD_TAUREN_TRIBES_MAGATHA)
    {
      WardTypeId = UNIT_OTGW_GRIMTOTEM_WARD_TAUREN_TRIBES,
      Duration = 15,
      AuraAbilityIds = new List<int>
      {
        ABILITY_A154_GRIMTOTEM_WARD_HEALING_TAUREN_TRIBES_GRIMTOTEM_WARD,
        ABILITY_A155_GRIMTOTEM_WARD_SLOW_TAUREN_TRIBES_GRIMTOTEM_WARD
      }
    });

    SpellRegistry.Register(new CronesCurse(ABILITY_A150_CRONE_S_CURSE_TAUREN_TRIBES_MAGATHA)
    {
      Healing = new LeveledAbilityField<float>
      {
        Base = 25,
        PerLevel = 50
      },
      Radius = 500,
      Duration = 12,
      HeroDuration = 6
    });

    SpellRegistry.Register(new WrathOfTheEarthMother(ABILITY_A151_WRATH_OF_THE_EARTH_MOTHER_TAUREN_TRIBES_MAGATHA)
    {
      Amount = new LeveledAbilityField<float>
      {
        Base = 15,
        PerLevel = 15
      },
      Radius = 450,
      Duration = 8,
      Period = 1,
      RootAbilityId = ABILITY_A153_EARTH_MOTHER_S_ROOTS_TAUREN_TRIBES_MAGATHA_DUMMY,
      RootBuffId = BUFF_B0E2_EARTH_MOTHER_S_ROOTS
    });
  }
}
