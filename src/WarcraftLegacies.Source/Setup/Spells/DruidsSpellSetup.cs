using MacroTools;
using MacroTools.Spells;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.Spells;

namespace WarcraftLegacies.Source.Setup.Spells
{
  public static class DruidsSpellSetup
  {
    public static void Setup()
    {
      
      SpellSystem.Register(new RegrowTrees(ABILITY_A04C_SEED_GROWTH)
      {
        Radius = 1200
      });

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
    }
  }
}