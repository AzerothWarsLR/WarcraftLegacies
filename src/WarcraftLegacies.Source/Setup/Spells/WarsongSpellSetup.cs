using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all <see cref="WarsongSetup.WarsongClan"/> <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
  /// </summary>
  public static class WarsongSpellSetup
  {
    /// <summary>
    /// Sets up <see cref="WarsongSpellSetup"/>.
    /// </summary>
    public static void Setup()
    {
      PassiveAbilityManager.Register(new Execute(Constants.UNIT_O00G_BLADEMASTER_WARSONG));
    }
  }
}