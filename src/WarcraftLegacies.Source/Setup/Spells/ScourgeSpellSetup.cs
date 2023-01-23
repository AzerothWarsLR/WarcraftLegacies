using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Mechanics.Scourge;

namespace WarcraftLegacies.Source.Setup.Spells
{
  /// <summary>
  /// Responsible for setting up all Scourge <see cref="Spell"/>s.
  /// </summary>
  public static class ScourgeSpellSetup
  {
    /// <summary>
    /// Sets up all Scourge <see cref="Spell"/>s.
    /// </summary>
    public static void Setup()
    {
      SpellSystem.Register(new SingleTargetRecall(Constants.ABILITY_A0W8_RECALL_FROZEN_THRONE));

      PassiveAbilityManager.Register(new PersistentSoul(Constants.UNIT_N009_REVENANT_SCOURGE,
        Constants.ABILITY_A05L_PERSISTENT_SOUL_SCOURGE_REVENANT)
      {
        ReanimationCountLevel = 1,
        Duration = 40,
        BuffId = Constants.BUFF_B069_PERSISTENT_SOUL_FORSAKEN_PLAGUE_REVENANT,
        Radius = 700
      });
      Plagueling.Setup(); //Todo: convert this into being a proper passive ability
    }
  }
}