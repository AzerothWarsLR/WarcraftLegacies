using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Dragonmaw <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
  /// </summary>
  public static class DragonmawSpellSetup
  {
    /// <summary>
    /// Sets up all Dragonmaw <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
    /// </summary>
    public static void Setup()
    {
      SpellSystem.Register(new MassAnySpell(Constants.ABILITY_A0OJ_MASS_UNHOLY_ARMOR_DRAGONMAW_GORFAX)
      {
        DummyAbilityId = Constants.ABILITY_A0HG_UNHOLY_ARMOR_DRAGONMAW_GORFAX,
        DummyAbilityOrderString = "innerfire",
        Radius = 400,
        CastFilter = CastFilters.IsTargetAllyAndAlive,
        TargetType = SpellTargetType.Point
      });
      
      SpellSystem.Register(new UnholyArmor(Constants.ABILITY_A0HG_UNHOLY_ARMOR_DRAGONMAW_GORFAX)
      {
        PercentageDamage = 0.06f
      });
    }
  }
}