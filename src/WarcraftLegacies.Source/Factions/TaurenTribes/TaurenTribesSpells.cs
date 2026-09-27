using System.Collections.Generic;
using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.TaurenTribes.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.TaurenTribes;

public static class TaurenTribesSpells
{
  public static void Setup()
  {
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

    var warStompSunwalkerChampion = new MassAnySpell(ABILITY_AT15_WAR_STOMP_TAUREN_TRIBES_SUNWALKER_CHAMPION)
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
    SpellRegistry.Register(warStompSunwalkerChampion);

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
