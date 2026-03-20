using MacroTools.Spells;
using MacroTools.UnitTraits;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.UnitTypeTraits.MassiveAttack;

namespace WarcraftLegacies.Source.Factions.Druids;

public static class DruidsSpells
{
  public static void Setup()
  {
    SpellRegistry.Register(new Devour(ABILITY_A0NP_DEVOUR_TORTOLLA)
    {
      PercentageOfMaxHealth = 0.5f,
      Damage = new LeveledAbilityField<float>
      {
        Base = 100,
        PerLevel = 100
      }
    });

    SpellRegistry.Register(new Devour(ABILITY_A0S0_DEVOUR_OURO)
    {
      PercentageOfMaxHealth = 0.5f,
      Damage = new LeveledAbilityField<float>
      {
        Base = 100,
        PerLevel = 100
      }
    });

    UnitTypeTraitRegistry.Register(new MassiveAttackAbility
    {
      AttackDamagePercentage = 0.5f,
      Distance = 700
    }, UNIT_E00A_ANCIENT_GUARDIAN_DRUIDS);
  }
}
