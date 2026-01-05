using System.Collections.Generic;

using MacroTools.Data;
using MacroTools.FactionSystem;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.ResearchSystems;
using MacroTools.Spells;
using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Quests.Cthun;
using WarcraftLegacies.Source.Researches;
using WarcraftLegacies.Source.Researches.Ahnqiraj;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Spells;
using WarcraftLegacies.Source.Spells.MassiveAttack;
using WarcraftLegacies.Source.UnitTypeTraits;
using WarcraftLegacies.Source.UnitTypeTraits.DefensiveCocoon;
using WarcraftLegacies.Source.UnitTypeTraits.Incubate;
using WarcraftLegacies.Source.UnitTypeTraits.SpellConduction;

namespace WarcraftLegacies.Source.Factions;

public sealed class Ahnqiraj : Faction
{
  private readonly unit _gateAhnQiraj;

  /// <inheritdoc />
  public Ahnqiraj() : base("Ahn'qiraj",
    playercolor.Wheat, @"ReplaceableTextures\CommandButtons\BTNCthunIcon.blp")
  {
    _gateAhnQiraj = PreplacedWidgets.Units.Get(UNIT_H02U_GATES_OF_AHN_QIRAJ_GATE_CLOSED);
    ControlPointDefenderUnitTypeId = UNIT_N0DW_CONTROL_POINT_DEFENDER_CTHUN_TOWER;
    TraditionalTeam = TeamSetup.OldGods;
    StartingGold = 200;
    IntroText = $"You are playing as {PrefixCol}C'thun and his Qiraji followers|r.\n\n" +
                "You start deep in the tunnels of Ahn'qiraj. You will need to awaken C'thun and free yourself from the Titan Guardians.\n\n" +
                "Then, quickly start making your move north, coordinate with your elemental ally to attack Kalimdor.\n\n" +
                "You do not possess boats, but your workers can burrow through water, use them to outmaneuver your enemies.";

    Nicknames = new List<string>
    {
      "aq",
      "ahnqiraj",
      "ahn'qiraj",
      "cthun",
      "c'thun"
    };
    ProcessObjectInfo(AhnqirajObjectInfo.GetAllObjectInfos());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterResearches();
    RegisterUnitTypeTraits();
    RegisterSpells();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    RegisterQuests();
  }

  private void RegisterQuests()
  {
    var newQuest = AddQuest(new QuestTitanJailors(Regions.QirajInsideUnlock));
    StartingQuest = newQuest;
    AddQuest(new QuestRebuildAhnqiraj(Regions.QirajOutsideUnlock, _gateAhnQiraj));
    AddQuest(new QuestSlitheringForward(Regions.QirajOutpost1, Regions.QirajOutpost2, Regions.QirajOutpost3));
    AddQuest(new QuestTanarisOutpost(Regions.QirajOutpost5));
    AddQuest(new QuestFeralas(Regions.AQFeralasUnlock));
    AddQuest(new QuestEmperorConstruct());
    AddQuest(new QuestMockeryOfLife());
    AddQuest(new QuestDesolation(AllLegends.Ahnqiraj.Cthun));
    AddQuest(new QuestFreshMeat(AllLegends.Ahnqiraj.Cthun));
    AddQuest(new QuestAwakening(AllLegends.Ahnqiraj.Cthun));
    AddQuest(new QuestWarOfTheShiftingSand(AllLegends.Ahnqiraj.Cthun, AllLegends.Druids.Nordrassil));
    AddQuest(new QuestFiendThousandFaces(AllLegends.Neutral.YoggSaron));
  }

  private static void RegisterResearches()
  {
    ResearchManager.Register(new Progenesis(UPGRADE_R003_PROGENESIS_C_THUN, 20)
    {
      TransformableUnitTypeIds = new int[]
      {
        UNIT_U019_WORKER_CTHUN_WORKER,
        UNIT_UCBD_BURROWED_WORKER_CTHUN_WORKER
      },
      TransformedUnitTypeId = UNIT_N06I_SOLDIER_CTHUN_SILITHID_WARRIOR
    });
    ResearchManager.RegisterIncompatibleSet(new BasicResearch(UPGRADE_ZBML_SPELL_CONDUCTION_C_THUN, 170),
      new RemoveAbilityResearch(UPGRADE_ZBHS_SHAPED_OBSIDIAN_C_THUN, 100)
      {
        RemovedAbility = ABILITY_A13J_SPELL_RESISTANCE_RIFLEMAN_OBSIDIAN_ERADICATOR_ANIMATED_ARMOR
      });
  }

  private static void RegisterUnitTypeTraits()
  {
    UnitTypeTraitRegistry.Register(new DefensiveCocoonTrait(ABILITY_ZBEG_DEFENSIVE_COCOON_AHN_QIRAJ)
    {
      MaximumHealthPercentage = 0.5f,
      Duration = 45,
      EggId = UNIT_ZBBG_COCOON_CTHUN_DEFENSIVE_COCOON,
      ReviveEffect = @"Abilities\Spells\Undead\RaiseSkeletonWarrior\RaiseSkeleton.mdl",
      RequiredResearch = UPGRADE_ZBEH_DEFENSIVE_COCOOON_AHN_QIRAJ
    }, new int[]
    {
      UNIT_U02S_ANCIENT_SAND_WORM,
      UNIT_E005_THE_PROPHET,
      UNIT_U00Z_OBSIDIAN_DESTROYER
    });

    UnitTypeTraitRegistry.Register(new Incubate(ABILITY_ZBRD_INCUBATE_VILE_CORRUPTOR)
    {
      HatchedUnitTypeId = UNIT_N06I_SOLDIER_CTHUN_SILITHID_WARRIOR,
      MaturationDuration = new LeveledAbilityField<float>
      {
        Base = 315f,
        PerLevel = -135f
      }
    }, UNIT_H01N_VILE_CORRUPTER_CTHUN);

    UnitTypeTraitRegistry.Register(new SpellConductionTrait
    {
      RedirectionPercentage = 0.40f,
      RedirectableAttackTypes = new attacktype[]
      {
        attacktype.Normal,
        attacktype.Magic
      },
      RequiredResearch = UPGRADE_ZBML_SPELL_CONDUCTION_C_THUN,
      Radius = 500
    }, UNIT_SL2O_OBSIDIAN_ERADICATOR_CTHUN);

    UnitTypeTraitRegistry.Register(new HideousAppendages
    {
      TentacleUnitTypeId = UNIT_N073_TENTACLE_HIDEOUS_APPENDAGES_C_THUN,
      TentacleCount = 9,
      RadiusOffset = 520
    }, UNIT_U00R_OLD_GOD_CTHUN);

    UnitTypeTraitRegistry.Register(new InfiniteInfluence
    {
      Radius = 800
    }, UNIT_U00R_OLD_GOD_CTHUN);

    UnitTypeTraitRegistry.Register(new MassiveAttackAbility
    {
      AttackDamagePercentage = 1,
      Distance = 400,
      IgnoreAttackTarget = true
    }, UNIT_ZBTH_TENTACLE_SPAWN_TENTACLE_C_THUN);
  }

  private static void RegisterSpells()
  {
    SpellRegistry.Register(new InstantKill(ABILITY_ZBBS_HATCH_INCUBATE)
    {
      Target = InstantKill.KillTarget.Self
    });

    SpellRegistry.Register(new InspireMadness(ABILITY_ZBIM_INSPIRE_MADNESS_C_THUN)
    {
      Radius = 300,
      CountBase = 14,
      Duration = 30,
      EffectTarget = @"Abilities\Spells\Other\Charm\CharmTarget.mdl",
      EffectScaleTarget = 0.5f
    });

    SpellRegistry.Register(new UnstableEvolution(ABILITY_ZBUE_UNSTABLE_EVOLUTION_C_THUN)
    {
      Radius = 300,
      Duration = 30,
      AttackDamageMultiplier = new LeveledAbilityField<float>
      {
        Base = 1.5f,
        PerLevel = 0.5f
      },
      AttackSpeedMultiplier = new LeveledAbilityField<float>
      {
        Base = 2
      },
      MaxHealthMultiplier = new LeveledAbilityField<float>
      {
        Base = 1.25f,
        PerLevel = 0.25f
      },
      EffectTarget = @"Abilities\Spells\Human\Feedback\ArcaneTowerAttack.mdl",
      EffectScaleTarget = 1
    });

    SpellRegistry.Register(new SpawnTentacle(ABILITY_ZBST_SPAWN_TENTACLE_C_THUN)
    {
      HitPoints = new LeveledAbilityField<int>
      {
        Base = 500,
        PerLevel = 100
      },
      AttackDamageBase = new LeveledAbilityField<int>
      {
        Base = 20,
        PerLevel = 20
      },
      UnitTypeId = UNIT_ZBTH_TENTACLE_SPAWN_TENTACLE_C_THUN,
      Duration = new LeveledAbilityField<float>
      {
        Base = 30
      }
    });
  }
}
