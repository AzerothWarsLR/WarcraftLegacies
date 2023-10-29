using MacroTools;
using MacroTools.DummyCasters;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all <see cref="GilneasSetup.Dalaran"/> <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
  /// </summary>
  public static class GilneasSpellSetup
  {
    /// <summary>
    /// Sets up <see cref="GilneasSpellSetup"/>.
    /// </summary>
    public static void Setup()
    {
      var vanish = new AddAbilityOnCast(Constants.ABILITY_ST9J_VANISH_TESS)
      {
        Duration = new LeveledAbilityField<float> { Base = 5, PerLevel = 5 },
        AbilitiesToAdd = new[]
        {
          Constants.ABILITY_STJW_PERMANENT_INVISIBILITY_TESS,
          Constants.ABILITY_ST8K_TESS_DAMAGE_TESS,
        }
      };
      SpellSystem.Register(vanish);
    }
  }
}