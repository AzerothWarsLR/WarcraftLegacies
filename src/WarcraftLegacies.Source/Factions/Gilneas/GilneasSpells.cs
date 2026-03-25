using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Gilneas.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Gilneas;

public static class GilneasSpells
{
  /// <summary>
  /// Sets up <see cref="GilneasSpells"/>.
  /// </summary>
  public static void Setup()
  {
    var vanish = new AddAbilityOnCast(ABILITY_ST9J_VANISH_TESS)
    {
      Duration = new LeveledAbilityField<float> { Base = 5, PerLevel = 5 },
      BuffApplicatorId = ABILITY_STB0_VANISH_BUFF_TESS,
      BuffId = BUFF_B01O_VANISH,
      AbilitiesToAdd = new[]
      {
        ABILITY_STJW_PERMANENT_INVISIBILITY_TESS,
        ABILITY_ST8K_TESS_DAMAGE_TESS_GREYMANE_VANISH_DUMMY,
      }
    };
    SpellRegistry.Register(vanish);

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
