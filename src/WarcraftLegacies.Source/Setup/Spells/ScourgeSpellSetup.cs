using System.Collections.Generic;
using MacroTools.Data;
using MacroTools.PassiveAbilitySystem;
using MacroTools.SpellSystem;
using WarcraftLegacies.Source.FactionMechanics.Scourge;
using WarcraftLegacies.Source.PassiveAbilities;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.IceBlock;
using WarcraftLegacies.Source.Spells.Reap;

namespace WarcraftLegacies.Source.Setup.Spells;

/// <summary>
/// Responsible for setting up all Scourge <see cref="Spell"/>s.
/// </summary>
public static class ScourgeSpellSetup
{
  /// <summary>
  /// Sets up all Scourge <see cref="Spell"/>s.
  /// </summary>
  public static void Setup()
  {
    SpellSystem.Register(new SingleTargetRecall(ABILITY_A0W8_RECALL_FROZEN_THRONE));

    PassiveAbilityManager.Register(new PersistentSoul(UNIT_N009_REVENANT_SCOURGE,
      ABILITY_A05L_PERSISTENT_SOUL_SCOURGE_REVENANT)
    {
      ReanimationCountLevel = 1,
      Duration = 40,
      BuffId = BUFF_B069_PERSISTENT_SOUL_FORSAKEN_PLAGUE_REVENANT,
      Radius = 700
    });
    Plagueling.Setup(); //Todo: convert this into being a proper passive ability

    var massUnholyFrenzy = new MassAnySpell(ABILITY_A02W_MASS_UNHOLY_FRENZY_SCOURGE)
    {
      DummyAbilityId = ABILITY_ACUF_UNHOLY_FRENZY_DUMMY,
      DummyAbilityOrderId = ORDER_UNHOLY_FRENZY,
      Radius = 250,
      CastFilter = CastFilters.IsTargetOrganicAndAlive,
      TargetType = SpellTargetType.Point
    };
    SpellSystem.Register(massUnholyFrenzy);

    var massFrostArmor = new MassAnySpell(ABILITY_A13R_MASS_FROST_ARMOR_KEL_THUZAD)
    {
      DummyAbilityId = ABILITY_A13S_MASS_FROST_ARMOUR_KEL_THUZAD_DUMMY,
      DummyAbilityOrderId = ORDER_FROST_ARMOR,
      Radius = 200,
      CastFilter = CastFilters.IsTargetOrganicAndAlive,
      TargetType = SpellTargetType.Point
    };
    SpellSystem.Register(massFrostArmor);

    var rendSoul = new RendSoul(ABILITY_ZB01_REND_SOUL_KEL_THUZAD_LICH)
    {
      HitPointsPerTargetMaximumHitPoints = 0.25f,
      ManaPointsPerTargetMaximumHitPoints = 0.35f,
      UnitTypeSummoned = UNIT_N009_REVENANT_SCOURGE,
      EffectTarget = @"Abilities\Spells\Undead\DarkRitual\DarkRitualTarget.mdl",
      EffectCaster = @"Abilities\Spells\Undead\DarkRitual\DarkRitualCaster.mdl",
      Duration = 45
    };
    SpellSystem.Register(rendSoul);

    PassiveAbilityManager.Register(new RemoveOnDeath(UNIT_N094_ICECROWN_OBELISK_SCOURGE)
    {
      DeathEffectPath = @"Objects\Spawnmodels\Undead\UDeathSmall\UDeathSmall.mdl"
    });

    PassiveAbilityManager.Register(new CreateUnitOnDeath(UNIT_UGHO_GHOUL_SCOURGE)
    {
      Duration = 30,
      CreateUnitTypeId = UNIT_U012_HALF_GHOUL_SCOURGE,
      CreateCount = 1,
      SpecialEffectPath = @"Objects\Spawnmodels\Human\HumanBlood\HumanBloodLarge0.mdl",
      RequiredResearch = UPGRADE_R008_DOMINATION_POWER
    });

    PassiveAbilityManager.Register(new CreateCorpseOnDeath(UNIT_U012_HALF_GHOUL_SCOURGE)
    {
      CorpseUnitTypeId = UNIT_UGHO_GHOUL_SCOURGE,
      CorpseCount = 1
    });

    SpellSystem.Register(new DeathPact(ABILITY_A0WP_DARK_RITUAL_ICON)
    {
      Radius = 900.0f,
      KillEffect = @"Abilities\Spells\Undead\DarkRitual\DarkRitualTarget.mdl",
      HealEffect = @"Abilities\Spells\Undead\ReplenishMana\SpiritTouchTarget.mdl",
      HealthRestorePercent = 0.25f,
      ManaRestorePercent = 0.36f
    });

    PassiveAbilityManager.Register(new SummonUnitOnCast(UNIT_U00A_SCOURGE_COMMANDER_SCOURGE, ABILITY_ST52_ARMY_OF_THE_DEAD_SCOURGE)
    {
      Duration = 45,
      SummonUnitTypeId = UNIT_NDR2_DARK_MINION_SCOURGE_DEATH_KNIGHT,
      SummonCount = new LeveledAbilityField<int>
      {
        Base = 0,
        PerLevel = 1
      },
      SpecialEffectPath = @"Abilities\Spells\Undead\RaiseSkeletonWarrior\RaiseSkeleton.mdl",
      ProcChance = 1.0f,
      AbilityWhitelist = new List<int>
      {
        ABILITY_AUDC_DEATH_COIL_RED_BARON_RIVENDARE,
        ABILITY_A10S_SUMMON_RAMSTEIN_RED_BARON_RIVENDARE,
        ABILITY_A09Y_DEATH_S_ADVANCE_SCOURGE_RIVENDARE,
        ABILITY_A07R_UNIVERSAL_SHACKLES_KARGATH
      }
    });

    var kelthuzadIds = new[]
    {
      UNIT_U00M_MASTER_OF_THE_CULT_OF_THE_DAMNED_SCOURGE_GHOST,
      UNIT_U001_MASTER_OF_THE_CULT_OF_THE_DAMNED_SCOURGE_NECROMANCER,
      UNIT_UKTL_ARCHLICH_OF_THE_SCOURGE_SCOURGE_LICH
    };
    PassiveAbilityManager.Register(new SummoningMastery(kelthuzadIds, ABILITY_AUAN_ANIMATE_DEAD_KEL_THUZAD)
    {
      HitPointPercentageBonus = new LeveledAbilityField<float>
      {
        Base = -0.3f,
        PerLevel = 0.3f
      },
      AttackDamagePercentageBonus = new LeveledAbilityField<float>
      {
        Base = -0.3f,
        PerLevel = 0.3f
      }
    });

    SpellSystem.Register(new DeathPact(ABILITY_A0W9_DEATH_PACT_ICON)
    {
      Radius = 700.0f,
      KillEffect = @"Abilities\Spells\Undead\DeathPact\DeathPactTarget.mdl",
      HealEffect = @"Abilities\Spells\Human\Heal\HealTarget.mdl",
      HealthRestorePercent = 1.25f,
      ManaRestorePercent = 0.10f
    });

    SpellSystem.Register(new IceBlockSpell(ABILITY_ZBIB_ICE_BLOCK_SCOURGE_LICH)
    {
      DummyUnitTypeId = UNIT_ZBDF_ICE_BLOCK_DISPELLABLE_DUMMY,
      CastEffectPath = @"Abilities\Spells\Undead\FrostNova\FrostNovaTarget.mdl",
      IceBlockEffectPath = @"Doodads\Icecrown\Rocks\Icecrown_Crystal\Icecrown_Crystal0.mdl",
      BuffApplicatorTypeId = ABILITY_ZBRP_ICE_BLOCK_BUFF_APPLICATOR,
      BuffTypeId = BUFF_ZB3F_ICE_BLOCK
    });

    RegisterArthasSpells();
  }

  private static void RegisterArthasSpells()
  {
    SpellSystem.Register(new Reap(ABILITY_ZB02_REAP_UNDEAD_ARTHAS)
    {
      UnitsSlain = new()
      {
        Base = 1,
        PerLevel = 2
      },
      StrengthPerUnit = new()
      {
        Base = 5
      },
      StrengthPerUnitUpgraded = new LeveledAbilityField<int>
      {
        Base = 7
      },
      Radius = new()
      {
        Base = 500
      },
      Duration = 30,
      UpgradeCondition = unit => unit.UnitType == UNIT_N023_LORD_OF_THE_SCOURGE_SCOURGE,
      KillEffect = @"Objects\Spawnmodels\Undead\UndeadDissipate\UndeadDissipate.mdl",
      BuffEffect = @"Abilities\Spells\Items\AIso\BIsvTarget.mdl",
    });

    SpellSystem.Register(new MassDeathCoil(ABILITY_ZB06_MASS_DEATH_COIL_ARTHAS_TERON_GOREFIEND)
    {
      DummyAbilityId = ABILITY_ZB05_MASS_DEATH_COIL_ARTHAS_DUMMY,
      DummyAbilityOrderId = ORDER_DEATH_COIL,
      Radius = 250,
      CasterHealPerTargetUpgraded = 25,
      UpgradeCondition = unit => unit.UnitType == UNIT_N023_LORD_OF_THE_SCOURGE_SCOURGE
    });

    SpellSystem.Register(new Apocalypse(ABILITY_A10N_APOCALYPSE_DEATH_KNIGHT_ARTHAS)
    {
      Range = 900,
      Width = 700,
      WidthUpgraded = 1000,
      ProjectileVelocity = 250,
      ProjectileRadius = 50,
      ProjectileCount = 7,
      ProjectileCountUpgraded = 9,
      Damage = new LeveledAbilityField<int>
      {
        Base = 35,
        PerLevel = 35
      },
      ProjectileModel = @"units\undead\HeroDeathKnight\HeroDeathKnight.mdl",
      ProjectileScale = 0.7f,
      EffectOnHitModel = @"Objects\Spawnmodels\Undead\UndeadDissipate\UndeadDissipate.mdl",
      EffectOnHitScale = 0.7f,
      EffectOnProjectileSpawn = @"Abilities\Spells\Items\AIil\AIilTarget.mdl",
      EffectOnProjectileSpawnScale = 0.5f,
      DummyAbilityId = ABILITY_A0YD_APOCALYPSE_DUMMY_CASTER,
      DummyAbilityOrderId = ORDER_PARASITE,
      UpgradeCondition = unit => unit.UnitType == UNIT_N023_LORD_OF_THE_SCOURGE_SCOURGE
    });

    SpellSystem.Register(new DeathPact(ABILITY_A10C_DEATH_PACT_ICON_ARTHAS)
    {
      Radius = 700.0f,
      KillEffect = @"Abilities\Spells\Undead\DeathPact\DeathPactTarget.mdl",
      HealEffect = @"Abilities\Spells\Human\Heal\HealTarget.mdl",
      HealthRestorePercent = 1.5f,
      ManaRestorePercent = 0.20f
    });
  }
}
