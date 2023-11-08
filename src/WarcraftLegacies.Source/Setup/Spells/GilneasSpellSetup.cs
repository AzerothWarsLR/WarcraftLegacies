using MacroTools;
using MacroTools.Spells;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Setup.Spells
{
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
        BuffApplicatorId = Constants.ABILITY_STB0_VANISH_BUFF_TESS,
        BuffId = Constants.BUFF_B01O_VANISH,
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