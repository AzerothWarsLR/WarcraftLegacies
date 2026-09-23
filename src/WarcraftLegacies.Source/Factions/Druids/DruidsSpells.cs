using System.Collections.Generic;
using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Druids.Spells;
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

    SpellRegistry.Register(new TreeOfRenewal(ABILITY_A156_TREE_OF_RENEWAL_DRUIDS_CENARIUS)
    {
      TreeTypeId = UNIT_ETRW_TREE_OF_RENEWAL_DRUIDS,
      Duration = 20,
      TreeLife = new LeveledAbilityField<float>
      {
        Base = 300,
        PerLevel = 100
      },
      AuraAbilityIds = new List<int>
      {
        ABILITY_A157_TREE_OF_RENEWAL_HEALING_DRUIDS_TREE_OF_RENEWAL,
        ABILITY_A158_TREE_OF_RENEWAL_ARMOR_DRUIDS_TREE_OF_RENEWAL
      }
    });

    SpellRegistry.Register(new LordOfTheForest(ABILITY_A159_LORD_OF_THE_FOREST_DRUIDS_CENARIUS)
    {
      TreantTypeId = UNIT_ETRT_TREANT_DRUIDS,
      AncientTypeId = UNIT_ETRA_ANCIENT_TREANT_DRUIDS,
      TreantCount = new LeveledAbilityField<int>
      {
        Base = 9,
        PerLevel = 3
      },
      AncientCount = new LeveledAbilityField<int>
      {
        Base = 3,
        PerLevel = 1
      },
      EmergeDamage = new LeveledAbilityField<float>
      {
        Base = 50,
        PerLevel = 50
      },
      Radius = 650,
      EmergeRadius = 350,
      ChannelSeconds = 8,
      SummonSeconds = 40,
      SlowAbilityId = ABILITY_A15A_LORD_OF_THE_FOREST_SLOW_DRUIDS_CENARIUS_DUMMY
    });
  }
}
