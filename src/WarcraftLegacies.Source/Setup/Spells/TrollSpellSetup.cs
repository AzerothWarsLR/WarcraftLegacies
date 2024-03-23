using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Fel Horde <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
  /// </summary>
  public static class TrollSpellSetup
  {
    /// <summary>
    /// Sets up <see cref="TrollSpellSetup"/>.
    /// </summary>
    public static void Setup()
    {
      PassiveAbilityManager.Register(new Execute(UNIT_O021_RAVAGER_ZANDALAR)
      {
        DamageMultNonResistant = 4,
        DamageMultResistant = 2,
        DamageMultStructure = 1
      });
    }
  }
}