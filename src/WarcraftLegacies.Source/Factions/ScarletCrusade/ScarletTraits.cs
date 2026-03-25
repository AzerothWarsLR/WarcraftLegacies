using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Shared.UnitTraits;

namespace WarcraftLegacies.Source.Factions.ScarletCrusade;

public static class ScarletTraits
{
  public static void Setup()
  {
    UnitTypeTraitRegistry.Register(new SpellOnCast(ABILITY_Z3X2_HEALING_FRENZY_ICON_SALLY)
    {
      DummyAbilityId = ABILITY_Z3X9_HEALING_FRENZY_SALLY_DUMMY,
      DummyOrderId = ORDER_FAN_OF_KNIVES,
      AbilityWhitelist = new List<int>
      {
        ABILITY_ANHW_HEALING_WAVE_PINK_VOL_JIN,
        ABILITY_Z9X3_SWIFT_HOLY_LIGHT_SALLY,
        ABILITY_A078_SPIRITUAL_GUIDANCE_SALLY,
        ABILITY_A0DK_DISPEL_MAGIC_SALLY,
      },
      TargetType = SpellTargetType.None
    }, UNIT_H08H_HIGH_INQUISITOR_SCARLET);

    UnitTypeTraitRegistry.Register(new SummonUnitOnDeath
    {
      Duration = 30,
      SummonUnitTypeId = UNIT_ST6W_UNHOLY_ARCHON_SCARLET_QUEST,
      SummonCount = 1,
      SpecialEffectPath = @"Abilities\Spells\Undead\DarkRitual\DarkRitualTarget.mdl",
      RequiredResearch = UPGRADE_R040_QUEST_COMPLETED_ONSLAUGHT
    }, UNIT_N09N_BISHOP_OF_THE_LIGHT_SCARLET);
  }
}
