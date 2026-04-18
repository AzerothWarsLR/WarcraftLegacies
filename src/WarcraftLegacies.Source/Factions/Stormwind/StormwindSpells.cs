using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Factions.Stormwind.Spells;
using WarcraftLegacies.Source.Shared.Spells;

namespace WarcraftLegacies.Source.Factions.Stormwind;

/// <summary>
/// Responsible for setting up all Stormwind <see cref="Spell"/>s.
/// </summary>
public static class StormwindSpells
{
  /// <summary>
  /// Sets up all Stormwind <see cref="Spell"/>s.
  /// </summary>
  public static void Setup()
  {
    SpellRegistry.Register(new CastDummySpell(ABILITY_A12Z_RALLYING_BANNER_STORMWIND_DUMMY)
    {
      DummyAbilityId = ABILITY_A130_RESURRECTION_STORMWIND_CHAMPION_SINGLE,
      DummyAbilityOrderId = ORDER_RESURRECTION,
      TargetType = SpellTargetType.None,
      OriginType = DummyCastOriginType.Caster
    });

    var electricStrike = new ElectricStrike(ABILITY_A0RC_ELECTRIC_STRIKE_DARK_GREEN_WIZARD_S_SANCTUM)
    {
      StunId = ABILITY_A0RD_ELECTRIC_STRIKE_MINI_STUN_DARK_GREEN,
      PurgeId = ABILITY_APRG_PURGE_ELECTRIC_STRIKE,
      PurgeOrder = ORDER_PURGE,
      StunOrder = ORDER_FIREBOLT,
      Radius = 500f,
      Effect = @"Abilities\Spells\Human\Thunderclap\ThunderClapCaster.mdl"
    };
    SpellRegistry.Register(electricStrike);

    var manaSyphon = new GrantMana(ABILITY_A0RG_RESTORE_MANA_STORMWIND_MAGE_TOWER)
    {
      ManaToGrant = 250
    };
    SpellRegistry.Register(manaSyphon);

    UnitTypeTraitRegistry.Register(new RestoreManaFromDamage(ABILITY_A11N_ARCANE_ABSORPTION_SUNFURY_STORMWIND)
    {
      ManaPerDamage = new LeveledAbilityField<float>
      {
        Base = 0.20f,
        PerLevel = 0.20f
      },
      Effect = @"Abilities\Spells\Undead\ReplenishMana\SpiritTouchTarget.mdl"
    }, new[]
    {
        UNIT_H05Y_LORD_WIZARD_STORMWIND,
    });
  }
}
