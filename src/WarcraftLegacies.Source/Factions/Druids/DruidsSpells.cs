using System.Collections.Generic;
using MacroTools.Spells;
using WarcraftLegacies.Source.Factions.Druids.Spells;
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

    SpellRegistry.Register(new EmeraldDreamSpell(ABILITY_A14E_EMERALD_DREAM_MALFURION)
    {
      DreamDuration = new LeveledAbilityField<float> { Base = 1.5f, PerLevel = 0.5f },
      HealFraction = new LeveledAbilityField<float> { Base = 0.1f, PerLevel = 0.1f },
      ManaFraction = new LeveledAbilityField<float> { Base = 0.05f, PerLevel = 0.05f },
      TickPeriod = 0.5f,
      Effects = new EmeraldDreamEffectSettings
      {
        DreamPath = @"Abilities\Spells\NightElf\Tranquility\TranquilityTarget.mdl",
        FlashPath = @"Abilities\Spells\NightElf\Rejuvenation\RejuvenationTarget.mdl",
        DreamTint = (110, 255, 180, 130),
        SleepPath = @"Abilities\Spells\Undead\Sleep\SleepTarget.mdl",
        BurstPath = @"Abilities\Spells\NightElf\MoonWell\MoonWellCasterArt.mdl",
        SoundLabel = "Tranquility"
      }
    });

    SpellRegistry.Register(new SeedOfRebirthSpell(ABILITY_A15O_SEED_OF_REBIRTH_MALFURION)
    {
      InitialDamage = new float[] { 75, 150, 200, 250 },
      DamagePerSecond = new LeveledAbilityField<float> { Base = 5, PerLevel = 5 },
      Duration = 15,
      TickPeriod = 0.25f,
      VisionRadius = 250,
      TreantUnitTypeId = UNIT_EFON_TREANT_DRUIDS_SUMMONED,
      BuffApplicatorId = ABILITY_A15P_SEED_OF_REBIRTH_BUFF_APPLICATOR,
      SeedEffectPath = @"Abilities\Spells\NightElf\EntanglingRoots\EntanglingRootsTarget.mdl",
      SeedEffectScale = 0.6f,
      SproutEffectPath = @"Objects\Spawnmodels\NightElf\EntBirthTarget\EntBirthTarget.mdl"
    });

    SpellRegistry.Register(new LivingWallSpell(ABILITY_A14X_LIVING_WALL_KEEPER_OF_THE_GROVE)
    {
      ChannelDuration = 20,
      TreeUnitTypeId = UNIT_E10A_LIVING_WALL_DRUIDS
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
