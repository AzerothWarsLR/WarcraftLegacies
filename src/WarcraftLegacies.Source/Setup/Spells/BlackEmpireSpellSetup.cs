using MacroTools;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class BlackEmpireSpellSetup
  {
    /// <summary>
    /// Sets up <see cref="BlackEmpireSpellSetup"/>.
    /// </summary>
    public static void Setup()
    {
      var GenesisAttack = new SpellOnAttack(UNIT_U029_STYGIAN_HULK_YOGG,
        ABILITY_ABES_GENESIS_ATTACK_ICON_STYGIAN_HULK)
      {
        DummyAbilityId = ABILITY_ABEG_PARASITE_GENESIS_ATTACK_REAL,
        DummyOrderId = OrderId("parasite"),
        ProcChance = 1.0f
      };
      PassiveAbilityManager.Register(GenesisAttack);
    }
  }
}