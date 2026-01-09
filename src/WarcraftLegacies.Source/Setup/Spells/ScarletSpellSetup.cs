using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.UnitTypeTraits;

namespace WarcraftLegacies.Source.Setup.Spells;

public static class ScarletSpellSetup
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new NoTargetSpellOnCast(ABILITY_Z3X2_HEALING_FRENZY_ICON_SALLY)
    {
      DummyAbilityId = ABILITY_Z3X9_HEALING_FRENZY_SALLY_DUMMY,
      DummyOrderId = ORDER_FAN_OF_KNIVES,
      ProcChance = 1.0f,
      AbilityWhitelist = new List<int>
      {
        ABILITY_ANHW_HEALING_WAVE_PINK_VOL_JIN,
        ABILITY_Z9X3_SWIFT_HOLY_LIGHT_SALLY,
        ABILITY_A078_SPIRITUAL_GUIDANCE_SALLY,
        ABILITY_A0DK_DISPEL_MAGIC_SALLY,
      }
    }, UNIT_H08H_HIGH_INQUISITOR_SCARLET);

    var crusaderShout = new Stomp(ABILITY_A0KB_CRUSADER_S_SHOUT_SAIDEN)
    {
      Radius = 600,
      DamageBase = 00,
      DamageLevel = 00,
      DurationBase = 2,
      DurationLevel = 1,
      StunAbilityId = ABILITY_A0KD_SOUL_BURN_SAIDEN_DUMMY,
      StunOrderId = ORDER_SOUL_BURN,
      SpecialEffect = @"war3mapImported\RoarCasterScarlet.mdx"
    };
    SpellRegistry.Register(crusaderShout);

    UnitTypeTraitRegistry.Register(new SummonUnitOnDeath
    {
      Duration = 30,
      SummonUnitTypeId = UNIT_ST6W_UNHOLY_ARCHON_SCARLET_QUEST,
      SummonCount = 1,
      SpecialEffectPath = @"Abilities\Spells\Undead\DarkRitual\DarkRitualTarget.mdl",
      RequiredResearch = UPGRADE_R040_QUEST_COMPLETED_ONSLAUGHT
    }, UNIT_N09N_BISHOP_OF_THE_LIGHT_SCARLET);

    var recklessOnslaught = new CooldownReset(ABILITY_A0TC_RECKLESS_ONSLAUGHT_SCARLET);
    SpellRegistry.Register(recklessOnslaught);

  }
}
