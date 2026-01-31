using System.Collections.Generic;
using MacroTools.Dialogues;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.Quests;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.FactionMechanics.Druids;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WarcraftLegacies.Source.Powers;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Druids;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions;

public sealed class Druids : Faction
{
  /// <inheritdoc />
  public Druids() :
    base("Druids", playercolor.Brown, @"ReplaceableTextures\CommandButtons\BTNFurion.blp")
  {
    TraditionalTeam = TeamSetup.Kalimdor;
    UndefeatedResearch = UPGRADE_R06E_DRUIDS_EXISTS;
    StartingGold = 200;
    CinematicMusic = "DarkAgents";
    ControlPointDefenderUnitTypeId = UNIT_E01Y_CONTROL_POINT_DEFENDER_DRUIDS;
    IntroText = $"You are playing as the ancient {PrefixCol}Druids of the Cenarion Circle|r.\n\n" +
                "You begin isolated in the deepest parts of Mount Hyjal near the World Tree.\n\n" +
                "The Old Gods are gathering to burn Ashenvale forest and the World Tree. Cenarius has emerged from his seclusion to stop them. " +
                "Use him to awaken Malfurion from his slumber as soon as possible.\n\n" +
                "Gather your forces and strike before the Old Gods can organize their efforts.";

    GoldMines = new List<unit>
    {
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), -9200, 10742),
      PreplacedWidgets.Units.GetClosest(FourCC("ngol"), -17545, 15856)
    };
    Nicknames = new List<string>
    {
      "druid"
    };
    RegisterFactionDependentInitializer<Sentinels>(RegisterSentinelsDialogue);
    RegisterFactionDependentInitializer<Scourge>(RegisterScourgeQuests);
    ProcessObjectInfo(DruidsObjectInfo.GetAllObjectLimits());
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
    RegisterDialogue();
    RegisterPowers();
    CenariusGhost.Setup(AllLegends.Druids.Cenarius, this);
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }

  private void RegisterQuests()
  {
    var newQuest = AddQuest(new QuestMalfurionAwakens(Regions.MoongladeVillage, Regions.TeldrassilUnlock,
      AllLegends.Druids.Nordrassil.Unit, Artifacts.HornOfCenarius,
      AllLegends.Druids.Malfurion));
    StartingQuest = newQuest;
    AddQuest(new QuestShrineBase(Regions.ShrineBaseUnlock));
    AddQuest(new QuestRiseBase(Regions.RiseBaseUnlock));
    AddQuest(new QuestAshenvale(Regions.AshenvaleUnlock));
    AddQuest(new QuestDruidsKillElemental(AllLegends.Skywall.Vortex));
    AddQuest(new QuestDruidsKillCthun(AllLegends.Ahnqiraj.Cthun));
    AddQuest(new QuestShaladrassil(AllLegends.Neutral.Shaladrassil));
    AddQuest(new QuestTortolla(AllLegends.Druids.Tortolla));
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quelthalas.Sunwell, Artifacts.SunwellVial));
  }

  private void RegisterDialogue()
  {
    TriggeredDialogueManager.Add(new TriggeredDialogue(new DialogueSequence(
        new Dialogue(
          @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Satyr29",
          "Come no further, weakling!  Lord Tichondrius commanded us to kill anyone attempting to enter this place, and we shall.",
          "Satyr"),
        new Dialogue(
          @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Furion30",
          "Patches wretches! It pains me that you once called yourselves Night Elves.",
          "Malfurion Stormrage")
      ),
      new[] { this },
      new Objective[]
      {
        new ObjectiveUnitAlive(PreplacedWidgets.Units.GetClosest(UNIT_NSTH_SATYR_HELLCALLER, Regions.SatyrCamp.Center)),
        new ObjectiveLegendInRect(AllLegends.Druids.Malfurion, Regions.SatyrCamp, "Satyr camp")
      }));

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(
        @"Sound\Dialogue\NightElfCampaign\NightElf03\N03Furion22",
        "The horn has sounded, and I have come as promised! I smell the stench of decay and corruption in our land. That angers me greatly.",
        "Malfurion Stormrage"),
      new[] { this },
      new Objective[]
      {
        new ObjectiveControlLegend(AllLegends.Druids.Malfurion, false)
        {
          EligibleFactions = new List<Faction>
          {
            this
          }
        }
      }));
  }

  private void RegisterPowers()
  {
    var worldTrees = new List<Capital>
    {
      AllLegends.Druids.Nordrassil,
      AllLegends.Neutral.Shaladrassil,
      AllLegends.Druids.Vordrassil
    };
    AddPower(new Immortality(20, 40, worldTrees)
    {
      IconName = "ArcaneRessurection",
      Name = "Immortality",
      Effect = @"Abilities\Spells\Human\Heal\HealTarget.mdl",
      ResearchId = UPGRADE_YB01_IMMORTALITY_POWER_IS_ACTIVE
    });
  }

  private void RegisterSentinelsDialogue(Sentinels sentinels)
  {
    TriggeredDialogueManager.Add(new TriggeredDialogue(new DialogueSequence(
        new Dialogue(
          @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Furion01",
          "It has been a thousand years since I last looked up you, Tyrande. I thought of you every moment I roamed through the Emerald Dream.",
          "Malfurion Stormrage"),
        new Dialogue(
          @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Tyrande02",
          "My heart rejoices to see you again, Furion. But I would not have awakened you unless the need was urgent.",
          "Tyrande Whisperwind"),
        new Dialogue(
          @"Sound\Dialogue\NightElfCampaign\NightElf04\N04Furion03",
          "In the Dream, I felt our land being corrupted, just as if it were my own body. You were right to awaken me.",
          "Malfurion Stormrage")
      ),
      new Faction[] { this, sentinels },
      new[] { new ObjectiveLegendMeetsLegend(AllLegends.Druids.Malfurion, AllLegends.Sentinels.Tyrande) }));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new Dialogue(
        @"Sound\Dialogue\OrcCampaign\Orc05\O05Cenarius01",
        "Who dares defile this ancient land? Who dares the wrath of Cenarius and the Night Elves?",
        "Cenarius"), new Faction[]
      {
        sentinels,
        this
      }, new[]
      {
        new ObjectiveControlLegend(AllLegends.Druids.Cenarius, false)
        {
          EligibleFactions = new List<Faction>
          {
            this
          }
        }
      }));
  }

  private void RegisterScourgeQuests(Scourge scourge)
  {
    AddQuest(new QuestAndrassil(AllLegends.Druids.Vordrassil, AllLegends.Druids.Ursoc, scourge));
  }
}
