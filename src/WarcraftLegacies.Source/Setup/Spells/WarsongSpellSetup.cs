using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

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
      var spellResistanceAura = new SpellResistanceAura(FourCC("o02M"));
      PassiveAbilityManager.Register(spellResistanceAura);
    }
  }
}