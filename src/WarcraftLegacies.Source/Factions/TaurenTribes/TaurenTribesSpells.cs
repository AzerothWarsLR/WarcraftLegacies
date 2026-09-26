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
        PerLevel = 50f
      },
      StunAbilityId = ABILITY_A14R_WILD_THROW_DUMMY_STUN_REXXAR,
      EffectModel = @"Abilities\Weapons\RexxarMissile\RexxarMissile",
      EffectScale = 1.8f
    };
    SpellRegistry.Register(wildThrowRexxar);
  }
}
