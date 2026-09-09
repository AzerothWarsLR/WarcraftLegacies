using MacroTools.Spells;
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
  }
}
