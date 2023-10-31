using MacroTools;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all <see cref="GilneasSetup.Gilneas"/> <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
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
        BuffApplicatorID = Constants.ABILITY_STB0_VANISH_BUFF_TESS,
        BuffID = Constants.BUFF_B01O_VANISH,
        AbilitiesToAdd = new[]
        {
          Constants.ABILITY_STJW_PERMANENT_INVISIBILITY_TESS,
          Constants.ABILITY_ST8K_TESS_DAMAGE_TESS_GREYMANE_VANISH_DUMMY,
        }
      };
      SpellSystem.Register(vanish);
    }
  }
}