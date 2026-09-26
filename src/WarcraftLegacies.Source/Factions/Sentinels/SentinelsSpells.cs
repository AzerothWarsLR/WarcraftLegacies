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

    SpellRegistry.Register(new GlaiveTrapSpell(ABILITY_A14F_GLAIVE_TRAP_NAISHA)
    {
      Damage = new LeveledAbilityField<float> { Base = 50, PerLevel = 50 },
      BlastRadius = 250,
      TriggerRadius = 150,
      ArmTime = 2,
      Lifetime = 60,
      TrapCount = 3,
      SpreadFraction = 0.55f,
      StunAbilityId = ABILITY_A14J_GLAIVE_TRAP_STUN_GLAIVE_TRAP,
      Effects = new GlaiveTrapEffectSettings
      {
        GlaivePath = @"war3mapImported\ArcaneGlaive_2.mdx",
        GlaiveScale = 1.2f,
        AllyGlaiveAlpha = 120,
        EruptionPath = @"Abilities\Spells\Orc\StasisTrap\StasisTotemTarget.mdl",
        EruptionScale = 2,
        EruptionDuration = 1
      }
    });

    SpellRegistry.Register(new WatchersFocusSpell(ABILITY_A14G_WATCHER_S_FOCUS_NAISHA)
    {
      Radius = 500,
      Duration = new LeveledAbilityField<float> { Base = 8, PerLevel = 2 },
      CritAbilityId = ABILITY_A14H_WATCHER_S_FOCUS_CRITICAL_STRIKE_NAISHA,
      BuffApplicatorId = ABILITY_A14I_WATCHER_S_FOCUS_BUFF_APPLICATOR_BUFF_APPLICATOR,
      BuffId = BUFF_B0DU_WATCHER_S_FOCUS
    });
  }
}
