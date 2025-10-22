using MacroTools.Spells;
using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.UnitTypeTraits;

namespace WarcraftLegacies.Source.Setup.Spells;

/// <summary>
/// Responsible for setting up all Stormwind <see cref="Spell"/>s.
/// </summary>
public static class StormwindSpellSetup
{
  /// <summary>
  /// Sets up all Stormwind <see cref="Spell"/>s.
  /// </summary>
  public static void Setup()
  {
    var legendaryWarrior = new ChannelSpellOnAttack(UNIT_H00R_KING_OF_STORMWIND_STORMWIND,
      ABILITY_A12C_LEGENDARY_WARRIOR_VARIAN)
    {
      DummyAbilityId = ABILITY_A12D_LEGENDARY_WARRIOR_STORMWIND_DUMMY,
      DummyOrderId = ORDER_VOODOO,
      ProcChance = 0.15f,
      DurationBase = (int)0.5,
      DurationLevel = (int)0.5
    };
    UnitTypeTraitRegistry.Register(legendaryWarrior);

    SpellSystem.Register(new AnySpellOnTarget(ABILITY_A12Z_RALLYING_BANNER_STORMWIND_DUMMY)
    {
      DummyAbilityId = ABILITY_A130_RESURRECTION_STORMWIND_CHAMPION_SINGLE,
      DummyAbilityOrderId = ORDER_RESURRECTION,
    });

    var electricStrike = new ElectricStrike(ABILITY_A0RC_ELECTRIC_STRIKE_DARK_GREEN_WIZARD_S_SANCTUM)
    {
      StunId = ABILITY_A0RD_ELECTRIC_STRIKE_MINI_STUN_DARK_GREEN,
      PurgeId = ABILITY_APRG_PURGE_ELECTRIKE_STRIKE,
      PurgeOrder = ORDER_PURGE,
      StunOrder = ORDER_FIREBOLT,
      Radius = 500f,
      Effect = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl"
    };
    SpellSystem.Register(electricStrike);

    var manaSyphon = new GrantMana(ABILITY_A0RG_RESTORE_MANA_STORMWIND_MAGE_TOWER)
    {
      ManaToGrant = 250
    };
    SpellSystem.Register(manaSyphon);
  }
}
