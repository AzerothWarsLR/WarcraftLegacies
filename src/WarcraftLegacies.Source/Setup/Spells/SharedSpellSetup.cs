using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.UnitTypeTraits;

namespace WarcraftLegacies.Source.Setup.Spells;

public static class SharedSpellSetup
{
  public static void Setup()
  {
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

    UnitTypeTraitRegistry.Register(new ProvidesIncome(-2), UNIT_NBOT_GOBLIN_PRIVATEER_NEUTRAL_GOBLIN);
  }
}
