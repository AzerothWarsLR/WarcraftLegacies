using System.Collections.Generic;
using MacroTools;
using System;
using MacroTools.DialogueSystem;
using MacroTools.Extensions;
using MacroTools.FactionChoices;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.Powers;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Powers;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Sentinels;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Factions
{
  public sealed class Sentinels : Faction
  {
<<<<<<< Updated upstream
    private readonly SharedGoldMineManager _sharedGoldMineManager;
=======
    private const int replacementUnitTypeId = Constants.UNIT_EWSP_WISP_DRUIDS_SENTINELS_WORKER;
>>>>>>> Stashed changes
    private readonly AllLegendSetup _allLegendSetup;
    private readonly ArtifactSetup _artifactSetup;
    private SharedStartLocationManager _sharedStartLocationManager;

<<<<<<< Updated upstream

    public Sentinels(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup, SharedStartLocationManager sharedStartLocationManager)
        : base("Sentinels", PLAYER_COLOR_MINT, "|CFFBFFF80", @"ReplaceableTextures\CommandButtons\BTNPriestessOfTheMoon.blp")
=======
    /// <inheritdoc />

    public Sentinels(PreplacedUnitSystem preplacedUnitSystem, AllLegendSetup allLegendSetup, ArtifactSetup artifactSetup) : base("Sentinels", PLAYER_COLOR_MINT, "|CFFBFFF80",
      @"ReplaceableTextures\CommandButtons\BTNPriestessOfTheMoon.blp")
>>>>>>> Stashed changes
    {
      TraditionalTeam = TeamSetup.Kalimdor;
      _allLegendSetup = allLegendSetup;
      _artifactSetup = artifactSetup;
      _sharedStartLocationManager = sharedStartLocationManager;
      UndefeatedResearch = FourCC("R05Y");
      StartingGold = 200;
      CinematicMusic = "Comradeship";
      ControlPointDefenderUnitTypeId = UNIT_H03F_CONTROL_POINT_DEFENDER_SENTINELS;
      StartingCameraPosition = Regions.SentStartPos.Center;
      StartingUnits = Regions.SentStartPos.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
      LearningDifficulty = FactionLearningDifficulty.Basic;

      GoldMines = new List<unit>
            {
                preplacedUnitSystem.GetUnit(FourCC("ngol"), new Point(-21300, 8400))
            };
      Nicknames = new List<string>
      RegisterFactionDependentInitializer<Druids>(RegisterDruidsDialogue);
      RegisterFactionDependentInitializer<Illidari>(RegisterIllidariQuestsAndDialogue);
      RegisterFactionDependentInitializer<Legion>(RegisterLegionDialogue);

      _sharedStartLocationManager.RegisterFactionWorkerUnitType(this, UNIT_EWSP_WISP_DRUIDS_SENTINELS_WORKER);
    }

    public Point GetStartLocation()
    {
      return Regions.SentStartPos.Center;
    }

    public override void PrepareStartingUnits()
    {
      StartingUnits = Regions.SentStartPos.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
    }

    public override void OnNotPicked()
    {
      if (GoldMines != null)
      {
        foreach (var goldMine in GoldMines)
        {
          if (_sharedGoldMineManager.IsSharedGoldMine(goldMine))
          {
            _sharedGoldMineManager.TransferGoldMineOwnership(goldMine, this);
          }
        }
      }
    }

<<<<<<< Updated upstream
=======
    public override void OnNotPicked()
    {
      ReplaceWorkersInRectangle(Regions.SentStartPos, replacementUnitTypeId);
      base.OnNotPicked();
    }

    public void ReplaceWorkersInRectangle(Rectangle rectangle, int replacementUnitTypeId)
    {
      Func<unit, bool> condition = unit => IsUnitType(unit, UNIT_TYPE_PEON);
      var replacedUnits = rectangle.ReplaceWorkers(replacementUnitTypeId, condition);

      foreach (var unit in replacedUnits)
      {
        SetUnitOwner(unit, Player(18), true);
      }
    }

    /// <inheritdoc />
>>>>>>> Stashed changes
    public override void OnRegistered()
    {
      RegisterObjectLimits();
      RegisterQuests();
      RegisterDialogue();
      RegisterPowers();
      SharedFactionConfigSetup.AddSharedFactionConfig(this);
    }

    private void RegisterObjectLimits()
    {
      foreach (var (objectTypeId, objectLimit) in SentinelsObjectLimitData.GetAllObjectLimits())
        ModObjectLimit(FourCC(objectTypeId), objectLimit.Limit);
    }

    private void RegisterQuests()
    {
      var questAstranaar = AddQuest(new QuestAstranaar(new List<Rectangle> { Regions.AstranaarUnlock, Regions.AuberdineUnlock }));
      StartingQuest = questAstranaar;

      var questFeathermoon = AddQuest(new QuestFeathermoon(_allLegendSetup.Sentinels.Feathermoon));

      AddQuest(new QuestSentinelsKillBlackEmpire(_allLegendSetup.BlackEmpire.Nzoth));
      AddQuest(new QuestSentinelsKillCthun(_allLegendSetup.Ahnqiraj.Cthun));
      AddQuest(new QuestScepterOfTheQueenSentinels(questFeathermoon, Regions.TheAthenaeum, _artifactSetup.ScepterOfTheQueen));
      AddQuest(new QuestVaultoftheWardens(_allLegendSetup.Sentinels.Maiev, _allLegendSetup.Sentinels.VaultOfTheWardens));
      AddQuest(new QuestExtractSunwellVial(_allLegendSetup.Quelthalas.Sunwell, _artifactSetup.SunwellVial));
    }

    private void RegisterDialogue()
    {
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new DialogueSequence(
          new Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf02x\S02Maiev02.flac",
            "I suspected as much. These islands must have been formed only recently.",
            "Maiev Shadowsong"),
          new Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf02x\S02Naisha03.flac",
            "What makes you say that?",
            "Naisha"),
          new Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf02x\S02Maiev04.flac",
            "The ruins all around us, Naisha... I recognize them.",
            "Maiev Shadowsong"),
          new Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf02x\S02Maiev05.flac",
            "This was once the great city of Suramar, built before our civilization was blasted beneath the sea ten thousand years ago.",
            "Maiev Shadowsong")
        )
        , new[]
        {
          this
        }, new List<Objective>
        {
          new ObjectiveLegendReachRect(_allLegendSetup.Sentinels.Maiev, Regions.BrokenIslesA, "the Broken Isles")
        }
      ));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new Dialogue(
          @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev24",
          "Priestess Tyrande. I'm surprised you came in person. Are you here to absolve your guilty conscience?",
          "Maiev Shadowsong"), new[]
        {
          this
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(_allLegendSetup.Sentinels.Maiev, _allLegendSetup.Sentinels.Tyrande)
        }));
    }
    
    private void RegisterPowers()
    {
      AddPower(new DummyPower("Unspoiled Wilderness",
        "Your Control Points increase your units' movement speed by 15% in a large radius.",
        "ANA_HealingButterfliesFixed"));
      
      var worldTrees = new List<Capital>
      {
        _allLegendSetup.Druids.Nordrassil,
        _allLegendSetup.Neutral.Shaladrassil,
        _allLegendSetup.Druids.Vordrassil
      };
      AddPower(new Immortality(25, 45, worldTrees)
      {
        IconName = "ArcaneRessurection",
        Name = "Immortality",
        Effect = @"Abilities\Spells\Human\Heal\HealTarget.mdl",
        ResearchId = UPGRADE_YB01_IMMORTALITY_POWER_IS_ACTIVE
      });
    }
    
    private void RegisterDruidsDialogue(Druids druids)
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new Dialogue(
          @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev22",
          "Elune be praised! I knew you would come, Shan'do Stormrage.",
          "Illidan Stormrage"), new Faction[]
        {
          this,
          druids
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(_allLegendSetup.Sentinels.Maiev, _allLegendSetup.Druids.Malfurion)
        }));
    }

    private void RegisterIllidariQuestsAndDialogue(Illidari illidari)
    {
      AddQuest(new QuestMaievOutland(Regions.MaievStartUnlock, _allLegendSetup.Sentinels.Maiev, _allLegendSetup.Sentinels.VaultOfTheWardens));
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new Dialogue(
          @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev37",
          "I am the hand of justice, Illidan. Long ago, I swore an oath to keep you chained, and by all the gods, I shall.",
          "Maiev Shadowsong"), new Faction[]
        {
          this,
          illidari
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(_allLegendSetup.Sentinels.Maiev, _allLegendSetup.Naga.Illidan)
        }));
    }

    private void RegisterLegionDialogue(Legion legion)
    {
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new DialogueSequence(
          new Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf02\N02Tyrande03.flac",
            "Archimonde... After ten thousand years, how is it possible?",
            "Tyrande Whisperwind"),
          new Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf02\N02Archimonde04.flac",
            "The Legion has returned to consume this world, woman. And this time, your troublesome race will not stop us.",
            "Archimonde")
        )
        , new Faction[]
        {
          legion,
          this
        }, new List<Objective>
        {
          new ObjectiveLegendMeetsLegend(_allLegendSetup.Sentinels.Tyrande, _allLegendSetup.Legion.Archimonde)
        }
      ));
    }
  }
}