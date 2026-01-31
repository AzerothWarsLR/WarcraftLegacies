using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.Quests;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Powers;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Sentinels;
using WarcraftLegacies.Source.Setup;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions;

public sealed class Sentinels : Faction
{
  /// <inheritdoc />
  public Sentinels() : base("Sentinels", playercolor.Mint,
    @"ReplaceableTextures\CommandButtons\BTNPriestessOfTheMoon.blp")
  {
    TraditionalTeam = TeamSetup.Kalimdor;
    UndefeatedResearch = UPGRADE_R05Y_SENTINELS_EXISTS;
    StartingGold = 200;
    CinematicMusic = "Comradeship";
    ControlPointDefenderUnitTypeId = UNIT_H03F_CONTROL_POINT_DEFENDER_SENTINELS;
    IntroText = $"You are playing as the ever-watchful {PrefixCol}Sentinels|r.\n\n" +
               "The Druids are slowly waking from their slumber, and it falls to you to drive back the Old Gods' invaders from Kalimdor until then.\n\n" +
               "Your first mission is to race down the coast to Feathermoon Stronghold, a powerful Sentinel bastion on the southern half of the continent.\n\n" +
               "Once you have secured your holdings, gather your army and destroy the Old Gods. Be cautious—they will outnumber you if given time to establish a foothold in Azeroth.";

    GoldMines = new List<unit>
    {
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), -20780, 7860)
    };
    Nicknames = new List<string>
    {
      "sent",
      "sentinel",
      "elf",
      "elfs",
      "elves"
    };
    RegisterFactionDependentInitializer<Druids>(RegisterDruidsDialogue);
    RegisterFactionDependentInitializer<Illidari>(RegisterIllidariQuestsAndDialogue);
    RegisterFactionDependentInitializer<Legion>(RegisterLegionDialogue);
    ProcessObjectInfo(SentinelsObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
    RegisterDialogue();
    RegisterPowers();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
    Regions.AstranaarUnlock.CleanupHostileUnits();
    Regions.AuberdineUnlock.CleanupHostileUnits();
  }

  /// <inheritdoc />
  public override void OnNotPicked()
  {
    Regions.AuberdineUnlock.CleanupNeutralPassiveUnits();
    Regions.AstranaarUnlock.CleanupNeutralPassiveUnits();
    Regions.FeathermoonUnlock.CleanupNeutralPassiveUnits();
    base.OnNotPicked();
  }

  private void RegisterQuests()
  {
    var questAstranaar = AddQuest(new QuestAstranaar(new List<Rectangle> { Regions.AstranaarUnlock, Regions.AuberdineUnlock }));
    StartingQuest = questAstranaar;

    // Register the updated QuestFeathermoon
    var questFeathermoon = AddQuest(new QuestFeathermoon(AllLegends.Sentinels.Feathermoon, Regions.FeathermoonUnlock));

    AddQuest(new QuestSentinelsKillBlackEmpire(AllLegends.BlackEmpire.Nzoth));
    AddQuest(new QuestSentinelsKillCthun(AllLegends.Ahnqiraj.Cthun));
    AddQuest(new QuestScepterOfTheQueenSentinels(questFeathermoon, Regions.TheAthenaeum, Artifacts.ScepterOfTheQueen));
    AddQuest(new QuestVaultoftheWardens(AllLegends.Sentinels.Maiev, AllLegends.Sentinels.VaultOfTheWardens));
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quelthalas.Sunwell, Artifacts.SunwellVial));
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
        new ObjectiveLegendReachRect(AllLegends.Sentinels.Maiev, Regions.BrokenIslesA, "the Broken Isles")
      }
    ));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new Dialogue(
        @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S03Naisha39",
        "Look, mistress--more of Gul'dan's glyphs.",
        "Naisha"), new[]
      {
        this
      }, new[]
      {
        new ObjectiveLegendInRect(AllLegends.Sentinels.Naisha, Regions.TombOfSargerasInteriorB, "the Tomb of Sargeras")
      }));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new Dialogue(
        @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev24",
        "Priestess Tyrande. I'm surprised you came in person. Are you here to absolve your guilty conscience?",
        "Maiev Shadowsong"), new[]
      {
        this
      }, new[]
      {
        new ObjectiveLegendMeetsLegend(AllLegends.Sentinels.Maiev, AllLegends.Sentinels.Tyrande)
      }));
  }

  private void RegisterPowers()
  {
    AddPower(new DummyPower("Unspoiled Wilderness",
      "Your Control Points increase your units' movement speed by 15% in a large radius.",
      "ANA_HealingButterfliesFixed"));

    var worldTrees = new List<Capital>
    {
      AllLegends.Druids.Nordrassil,
      AllLegends.Neutral.Shaladrassil,
      AllLegends.Druids.Vordrassil
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
        new ObjectiveLegendMeetsLegend(AllLegends.Sentinels.Maiev, AllLegends.Druids.Malfurion)
      }));
  }

  private void RegisterIllidariQuestsAndDialogue(Illidari illidari)
  {
    AddQuest(new QuestMaievOutland(Regions.MaievStartUnlock, AllLegends.Sentinels.Maiev, AllLegends.Sentinels.VaultOfTheWardens));
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
        new ObjectiveLegendMeetsLegend(AllLegends.Sentinels.Maiev, AllLegends.Naga.Illidan)
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
        new ObjectiveLegendMeetsLegend(AllLegends.Sentinels.Tyrande, AllLegends.Legion.Archimonde)
      }
    ));
  }
}
