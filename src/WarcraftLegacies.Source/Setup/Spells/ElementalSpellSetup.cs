using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class ElementalSpellSetup
  {
    /// <summary>
    /// Sets up <see cref="ElementalSpellSetup"/>.
    /// </summary>
    public static void Setup()
    {
      var purgeAttack = new SpellOnAttack(UNIT_O01I_ANIMATED_ARMOR_ELEMENTAL,
        ABILITY_AELP_SHOCKING_BLADES_ANIMATED_ARMOR)
      {
        DummyAbilityId = ABILITY_APG2_PURGE_TEAL_DARK_SHAMAN_PINK_SHAMAN,
        DummyOrderId = OrderId("purge"),
        ProcChance = 0.25f
      };
      PassiveAbilityManager.Register(purgeAttack);
    }
  }
}