using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.Spells;
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
        DummyAbilityId = ABILITY_AEPU_PURGE_SHOCKING_BLADE,
        DummyOrderId = OrderId("purge"),
        ProcChance = 0.20f
      };
      PassiveAbilityManager.Register(purgeAttack);

      var stormSurge = new Stomp(ABILITY_AESS_STORM_SURGE_ARMORED_MISTRAL)
      {
        Radius = 300,
        DamageBase = 60,
        DurationBase = 3,
        StunAbilityId = ABILITY_AEPU_PURGE_SHOCKING_BLADE,
        StunOrderId = OrderId("purge"),
        SpecialEffect = @"war3mapImported\Cyclon Explosion.mdx"
      };
      SpellSystem.Register(stormSurge);
    }
  }
}