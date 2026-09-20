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
      PulsePeriod = 1,
      HealPerPulse = new LeveledAbilityField<float> { Base = 5, PerLevel = 5 },
      ManaPerPulse = new LeveledAbilityField<float> { Base = 1, PerLevel = 1 },
      SlowAuraAbilityId = ABILITY_A14C_SLOW_AURA_LUNAR_SANCTUARY,
      TrueSightAbilityId = ABILITY_A14D_TRUE_SIGHT_LUNAR_SANCTUARY,
      Effects = new LunarSanctuaryEffectSettings
      {
        BurstPath = @"war3mapImported\HolyNova_Fixed.mdx",
        BurstScale = 3,
        GlowPath = @"war3mapImported\StarfallCaster.mdx",
        GlowScale = 1.5f,
        RingPath = @"war3mapImported\Point Target.mdx",
        RingScale = 4.8f,
        RingColor = (150, 200, 255),
        RingAlpha = 200,
        HealPath = @"Abilities\Spells\Human\Heal\HealTarget.mdl"
      }
    };
    SpellRegistry.Register(lunarSanctuary);
  }
}
