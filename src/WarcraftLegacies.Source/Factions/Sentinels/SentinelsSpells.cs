using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Sentinels.Spells;
using WarcraftLegacies.Source.Shared.Spells;

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

    var lunarSanctuary = new LunarSanctuarySpell(ABILITY_A01D_LUNAR_SANCTUARY_LIGHT_BLUE_TYRANDE)
    {
      Radius = 350,
      Duration = 10,
      Period = 1,
      HealPerPeriod = new LeveledAbilityField<float> { Base = 5, PerLevel = 5 },
      ManaPerPeriod = new LeveledAbilityField<float> { Base = 1, PerLevel = 1 },
      SlowAuraAbilityId = ABILITY_A14C_SLOW_AURA_LUNAR_SANCTUARY,
      TrueSightAbilityId = ABILITY_A14D_TRUE_SIGHT_LUNAR_SANCTUARY,
      SanctuaryEffectPath = @"Abilities\Spells\NightElf\Tranquility\TranquilityTarget.mdl",
      HealEffectPath = @"Abilities\Spells\NightElf\Rejuvenation\RejuvenationTarget.mdl"
    };
    SpellRegistry.Register(lunarSanctuary);
  }
}
