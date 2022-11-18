using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Illidari <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
  /// </summary>
  public static class IllidariSpellSetup
  {
    /// <summary>
    /// Sets up all Illidari <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
    /// </summary>
    public static void Setup()
    {
      PassiveAbilityManager.Register(new TakeExtraDamageOnWater(new[]
      {
        Constants.UNIT_NMYR_NAGA_MYRMIDON_ILLIDARI,
        Constants.UNIT_NNSW_NAGA_SIREN_ILLIDARI
      }, Constants.ABILITY_A0UZ_EVASION_60)
      {
        DamageMultiplier = 200
      });
    }
  }
}