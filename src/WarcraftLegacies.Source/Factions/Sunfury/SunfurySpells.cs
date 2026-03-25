using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Sunfury.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Sunfury;

public static class SunfurySpells
{
  public static void Setup()
  {
    var resurgentFlameStrike = new ResurgentSpell(ABILITY_A04H_RESURGENT_FLAME_STRIKE_QUEL_THALAS_KAEL_THAS,
      ABILITY_A0F9_RESURGENT_FLAME_STRIKE_QUEL_THALAS_KAEL_THAS_DUMMY, ORDER_FLAMESTRIKE)
    {
      Duration = 14,
      Interval = 7
    };
    SpellRegistry.Register(resurgentFlameStrike);

    var massBanish = new MassAnySpell(ABILITY_A0FD_MASS_BANISH_QUEL_THALAS_KAEL_THAS)
    {
      DummyAbilityId = ABILITY_A0FE_MASS_BANISH_QUEL_THALAS_KAEL_THAS_DUMMY_CASTER,
      DummyAbilityOrderId = ORDER_BANISH,
      Radius = 250,
      CastFilter = CastFilters.IsTargetOrganicAndAlive,
      TargetType = SpellTargetType.Point
    };
    SpellRegistry.Register(massBanish);

    var siphoningRitual = new SiphoningRitual(ABILITY_A0FA_SIPHONING_RITUAL_QUEL_THALAS_KAEL_THAS)
    {
      TargetCountBase = 24,
      TargetCountLevel = 0,
      LifeDrainedPerSecondBase = 30,
      LifeDrainedPerSecondLevel = 10,
      ManaDrainedPerSecondBase = 15,
      ManaDrainedPerSecondLevel = 5,
      Range = 800,
      Radius = 225,
      Interval = 0.1f
    };
    SpellRegistry.Register(siphoningRitual);

    UnitTypeTraitRegistry.Register(new RestoreManaFromDamage(ABILITY_A11N_ARCANE_ABSORPTION_SUNFURY_STORMWIND)
    {
      ManaPerDamage = new LeveledAbilityField<float>
      {
        Base = 0.20f,
        PerLevel = 0.20f
      },
      Effect = @"Abilities\Spells\Undead\ReplenishMana\SpiritTouchTarget.mdl"
    }, new[]
    {
      UNIT_N0E7_BLOODWARDER_SUNFURY,
      UNIT_H05Y_LORD_WIZARD_STORMWIND,
      UNIT_N0E8_SKYSHIP_SUNFURY
    });
  }
}
