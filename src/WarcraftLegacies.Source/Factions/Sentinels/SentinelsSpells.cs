using MacroTools.Spells;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Factions.Sentinels;

public static class SentinelsSpells
{
  public static void Setup()
  {
    var elunesGaze = new MassAnySpell(ABILITY_A00E_ELUNE_S_GAZE_SENTINELS)
    {
      DummyAbilityId = ABILITY_A0VY_INVISIBILITY_LB,
      DummyAbilityOrderId = ORDER_INVISIBILITY,
      Radius = 350,
      CastFilter = CastFilters.IsTargetOrganicAndAlive,
      TargetType = SpellTargetType.None
    };
    SpellRegistry.Register(elunesGaze);

  }
}
