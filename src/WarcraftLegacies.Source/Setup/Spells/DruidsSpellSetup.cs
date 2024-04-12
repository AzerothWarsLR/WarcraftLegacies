using MacroTools;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;

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
      
      PassiveAbilityManager.Register(new MassiveAttack(UNIT_E00A_ANCIENT_GUARDIAN_DRUIDS, ABILITY_ZB15_MASSIVE_ATTACK_URSOC)
      {
        DummyAbilityId = ABILITY_A104_SHOCKWAVE_WARFRAME_DUMMY,
        DummyOrderId = OrderId("carrionswarm")
      });
    }
  }
}