using MacroTools.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Frostwolf;

public static class FrostwolfSpells
{
  public static void Setup()
  {
    var cripplingShout = new MassAnySpell(ABILITY_TP07_CRIPPLING_SHOUT_FROSTWOLF)
    {
      Radius = 700,
      DummyAbilityId = ABILITY_TP08_CRIPPLE_DUMMY,
      DummyAbilityOrderId = ORDER_CRIPPLE,
      SpecialEffect = @"abilities\spells\nightelf\battleroar\roarcaster.mdx",
      CastFilter = CastFilters.IsTargetEnemyAndAliveUnits,
      TargetType = SpellTargetType.None
    };
    SpellRegistry.Register(cripplingShout);
  }
}
