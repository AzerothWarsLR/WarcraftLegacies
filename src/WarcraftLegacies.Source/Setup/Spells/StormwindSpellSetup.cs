using MacroTools;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells.Slipstream;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Stormwind <see cref="Spell"/>s.
  /// </summary>
  public static class StormwindSpellSetup
  {
    /// <summary>
    /// Sets up all Stormwind <see cref="Spell"/>s.
    /// </summary>
    public static void Setup()
    {
      SpellSystem.Register(new SlipstreamSpell(Constants.ABILITY_A00D_SLIPSTREAM_STORMWIND_KHADGAR)
      {
        PortalUnitTypeId = Constants.UNIT_N0D9_SLIPSTREAM_PORTAL_STORMWIND_KHADGAR,
        OpeningDelay = 5,
        ClosingDelay = 10,
        Color = new Color(40, 40, 255, 255)
      });

      PassiveAbilityManager.Register(new RestoreManaFromDamage(Constants.UNIT_H05Y_LORD_WIZARD_STORMWIND, Constants.ABILITY_A11N_ARCANE_ABSORPTION_KHADGAR)
      {
        ManaPerDamage = new LeveledAbilityField<float>
        {
          Base = 0.20f,
          PerLevel = 0.20f
        },
        Effect = "Abilities\\Spells\\Undead\\ReplenishMana\\SpiritTouchTarget.mdl"
      });
    }
  }
}