using MacroTools.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Gilneas;

public static class GilneasSpells
{
  /// <summary>
  /// Sets up <see cref="GilneasSpells"/>.
  /// </summary>
  public static void Setup()
  {
    var thunderClapGil = new MassAnySpell(ABILITY_MD13_THUNDER_CLAP_GILNEAS_GREY_GUARD)
    {
      Radius = 300,
      Damage = new LeveledAbilityField<float>
      {
        Base = 55
      },
      DummyAbilityId = ABILITY_MD14_THUNDER_CLAP_DUMMY_GREY_GUARD,
      DummyAbilityOrderId = ORDER_CRIPPLE,
      SpecialEffect = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl",
      CastFilter = CastFilters.IsTargetEnemyAliveAndGroundUnits,
      TargetType = SpellTargetType.None
    };
    SpellRegistry.Register(thunderClapGil);
  }
}
