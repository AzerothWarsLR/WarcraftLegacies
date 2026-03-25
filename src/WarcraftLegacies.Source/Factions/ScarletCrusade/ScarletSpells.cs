using MacroTools.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.ScarletCrusade;

public static class ScarletSpells
{
  public static void Setup()
  {
    var crusaderShout = new MassAnySpell(ABILITY_A0KB_CRUSADER_S_SHOUT_SAIDEN)
    {
      Radius = 600,
      DummyAbilityId = ABILITY_A0KD_SOUL_BURN_SAIDEN_DUMMY,
      DummyAbilityOrderId = ORDER_SOUL_BURN,
      SpecialEffect = @"war3mapImported\RoarCasterScarlet.mdx",
      CastFilter = CastFilters.IsTargetEnemyAndAliveUnits,
      TargetType = SpellTargetType.None
    };
    SpellRegistry.Register(crusaderShout);

    var recklessOnslaught = new CooldownReset(ABILITY_A0TC_RECKLESS_ONSLAUGHT_SCARLET);
    SpellRegistry.Register(recklessOnslaught);
  }
}
