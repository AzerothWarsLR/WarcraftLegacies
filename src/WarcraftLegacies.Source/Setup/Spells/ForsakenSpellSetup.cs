using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Forsaken <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
  /// </summary>
  public static class ForsakenSpellSetup
  {
    /// <summary>
    /// Sets up all Forsaken <see cref="Spell"/>s and <see cref="PassiveAbility"/>s.
    /// </summary>
    public static void Setup()
    {
      SpellSystem.Register(new CorruptBuildingSpell(Constants.ABILITY_A0N8_CORRUPT_FORSAKEN, 72, 60, 500));
      PassiveAbilityManager.Register(new PersistentSoul(Constants.UNIT_N07W_PLAGUE_REVENANT_FORSAKEN,
        Constants.ABILITY_A05L_PERSISTENT_SOUL_FORSAKEN_PLAGUE_REVENANT)
      {
        ReanimationCountLevel = 1,
        Duration = 40,
        BuffId = Constants.BUFF_B069_PERSISTENT_SOUL_FORSAKEN_PLAGUE_REVENANT,
        Radius = 700
      });
    }
  }
}