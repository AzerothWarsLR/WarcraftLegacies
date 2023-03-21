using MacroTools;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all <see cref="DalaranSetup.Dalaran"/> <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
  /// </summary>
  public static class DalaranSpellSetup
  {
    /// <summary>
    /// Sets up <see cref="DalaranSpellSetup"/>.
    /// </summary>
    public static void Setup()
    {
      var enchantedBolt = new MassAnySpell(Constants.ABILITY_A10L)
      {
        DummyAbilityId = Constants.ABILITY_A10O,
        DummyAbilityOrderString = "thunderbolt",
        Radius = 250,
        CastFilter = CastFilters.IsTargetEnemyAndAlive,
        TargetType = SpellTargetType.Point,
        DummyCastOriginType = DummyCastOriginType.Caster
      };
      SpellSystem.Register(enchantedBolt);
    }
  }
}