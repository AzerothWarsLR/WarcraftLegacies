using MacroTools.Data;
using MacroTools.Spells;
using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.MassiveAttack;

namespace WarcraftLegacies.Source.Setup.Spells;

public static class DruidsSpellSetup
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
