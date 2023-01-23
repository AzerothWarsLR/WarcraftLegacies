using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all <see cref="IronforgeSetup.Ironforge"/> <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
  /// </summary>
  public static class IronforgeSpellSetup
  {
    /// <summary>
    /// Sets up <see cref="IronforgeSpellSetup"/>.
    /// </summary>
    public static void Setup()
    {
      SpellSystem.Register(new TitanForgeArtifact(Constants.ABILITY_A0T3_TITANFORGE_ARTIFACT_IRONFORGE, 0, 75));
    }
  }
}