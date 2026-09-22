using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Druids.Spells.LivingWall;
using WarcraftLegacies.Source.Shared.Spells;

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

    SpellRegistry.Register(new LivingWallSpell(ABILITY_A14X_LIVING_WALL_KEEPER_OF_THE_GROVE)
    {
      ChannelDuration = 20,
      TreeUnitTypeId = UNIT_E10A_LIVING_WALL_DRUIDS
    });
  }
}
