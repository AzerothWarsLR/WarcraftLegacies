using MacroTools.Data;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.MassiveAttack;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class DruidsSpellSetup
  {
    public static void Setup()
    {
      SpellSystem.Register(new Devour(ABILITY_A0NP_DEVOUR_TORTOLLA)
      {
        PercentageOfMaxHealth = 0.5f,
        Damage = new LeveledAbilityField<float>
        {
          Base = 100,
          PerLevel = 100
        }
      });

      SpellSystem.Register(new Devour(ABILITY_A0S0_DEVOUR_OURO)
      {
        PercentageOfMaxHealth = 0.5f,
        Damage = new LeveledAbilityField<float>
        {
          Base = 100,
          PerLevel = 100
        }
      });

      SpellSystem.Register(new Nova(ABILITY_VP17_MOONFIRE_DRUIDS)
      {
        Radius = 300,
        BaseDamage = 80,
        DamagePerLevel = 20,
        DurationBase = 1,
        DurationLevel = 0,
        StunAbilityId = ABILITY_A0WN_STUN_UNIT_DUMMY,
        StunOrderId = OrderId("thunderbolt"),
        TargetEffect = @"Abilities\Spells\NightElf\Starfall\StarfallTarget.mdl"
      });
      
      PassiveAbilityManager.Register(new MassiveAttackAbility(UNIT_E00A_ANCIENT_GUARDIAN_DRUIDS)
      {
        AttackDamagePercentage = 0.5f,
        Distance = 700
      });
    }
  }
}