using MacroTools.DummyCasters;
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
      var enchantedBolt = new MassAnySpell(Constants.ABILITY_A10L_ENCHANTED_BOLTS_DALARAN)
      {
        DummyAbilityId = Constants.ABILITY_A10O_ENCHANTED_BOLT_DALARAN_DUMMY,
        DummyAbilityOrderId = OrderId("thunderbolt"),
        Radius = 250,
        CastFilter = CastFilters.IsTargetEnemyAndAlive,
        TargetType = SpellTargetType.Point,
        DummyCastOriginType = DummyCastOriginType.Caster
      };
      SpellSystem.Register(enchantedBolt);

      SpellSystem.Register(new ChannelAnySpellCaster(Constants.ABILITY_A11A_TIME_S_SHIELD_DALARAN_2)
      {
        DummyAbilityId = Constants.ABILITY_A11K_TIME_S_SHIELD_DALARAN_DUMMY,
        DummyAbilityOrderString = "voodoo",
        Duration = 4
      });

      var rebornTime = new CooldownReset(Constants.ABILITY_A10T_REBORN_THROUGH_TIME_DALARAN);
      SpellSystem.Register(rebornTime);
    }
  }
}