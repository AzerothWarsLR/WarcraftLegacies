using System.Collections.Generic;
using MacroTools.Dialogues;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.PreplacedWidgets;
using MacroTools.Quests;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WarcraftLegacies.Source.Quests;
using WarcraftLegacies.Source.Quests.Fel_Horde;
using WarcraftLegacies.Source.Quests.Naga;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Factions;

public sealed class Illidari : Faction
{
  /// <inheritdoc />
  public Illidari() : base("Illidan", playercolor.Violet,
    @"ReplaceableTextures\CommandButtons\BTNEvilIllidan.blp")
  {
    TraditionalTeam = TeamSetup.Outland;
    UndefeatedResearch = UPGRADE_R02L_ILLIDAN_EXISTS;
    StartingGold = 200;
    FoodMaximum = 250;
    ControlPointDefenderUnitTypeId = UNIT_N0BB_CONTROL_POINT_DEFENDER_ILLIDARI_TOWER;
    Nicknames = new List<string>
    {
      "illi",
      "illidan",
      "ill",
      "naga",
      "nagas",
      "fish"
    };
    RegisterFactionDependentInitializer<Sentinels>(RegisterSentinelsDialogue);
    RegisterFactionDependentInitializer<Druids>(RegisterDruidsDialogue);
    RegisterFactionDependentInitializer<Scourge>(RegisterScourgeDialogue);
    RegisterFactionDependentInitializer<Sentinels, Druids>(RegisterSentinelsDruidsDialogue);
    RegisterFactionDependentInitializer<FelHorde>(RegisterFelHordeQuests);
    RegisterFactionDependentInitializer<Scourge, Druids, Ahnqiraj>(RegisterScourgeDruidsAhnqirajQuests);
    RegisterFactionDependentInitializer<Sentinels>(RegisterSentinelsQuests);
    ProcessObjectInfo(IllidariObjectInfo.GetAllObjectLimits());
    GoldMines = new List<unit>
    {
      AllPreplacedWidgets.Units.GetClosest(FourCC("ngol"), 5467, -31440),
      AllPreplacedWidgets.Units.GetClosest(FourCC("ngol"), 5805, -31258),
      AllPreplacedWidgets.Units.GetClosest(FourCC("ngol"), 767, 6244),
    };
  }

  /// <inheritdoc />
  public override void OnRegistered()
  {
    RegisterQuests();
    RegisterDialogue();
    SharedFactionConfigSetup.AddSharedFactionConfig(this);
  }
  /// <inheritdoc />
  public override void OnNotPicked()
  {
    Regions.IllidanStartingPosition.CleanupNeutralPassiveUnits();
    Regions.IllidanBlackTempleUnlock.CleanupNeutralPassiveUnits();
    Regions.TelredorUnlock.CleanupNeutralPassiveUnits(NeutralPassiveCleanupType.TurnUnitsHostile);
    Regions.IllidariUnlockSA.CleanupNeutralPassiveUnits(NeutralPassiveCleanupType.TurnUnitsHostile);
    Regions.AkamaUnlock.CleanupNeutralPassiveUnits(NeutralPassiveCleanupType.TurnUnitsHostile);

    base.OnNotPicked();
  }
  private void RegisterQuests()
  {
    var flameAndSorrow = new QuestBrokenIsles(AllLegends.Naga.Illidan);
    StartingQuest = flameAndSorrow;
    AddQuest(flameAndSorrow);

    var questBlackTemple = new QuestBlackTemple(flameAndSorrow);
    AddQuest(questBlackTemple);


    var questZangarmarsh = new QuestZangarmarsh(Regions.TelredorUnlock, AllLegends.Naga.Vashj);
    questZangarmarsh.AddObjective(new ObjectiveQuestComplete(questBlackTemple)
    {
      ShowsInPopups = false,
      ShowsInQuestLog = false,
      Progress = QuestProgress.Undiscovered
    });
    AddQuest(questZangarmarsh);

    var questLostOnes = new QuestLostOnes(Regions.AkamaUnlock);
    questLostOnes.AddObjective(new ObjectiveQuestComplete(questBlackTemple)
    {
      ShowsInPopups = false,
      ShowsInQuestLog = false,
      Progress = QuestProgress.Undiscovered
    });
    AddQuest(questLostOnes);

    var questAzsharasVein = new QuestAzsharasVein(questZangarmarsh);
    AddQuest(questAzsharasVein);

    AddQuest(new QuestStranglethornOutpost(Regions.IllidariUnlockSA, AllLegends.Naga.Vashj));
    AddQuest(new QuestEyeofSargeras(Artifacts.EyeOfSargeras, AllLegends.Naga.Illidan));
    AddQuest(new QuestExtractSunwellVial(AllLegends.Quelthalas.Sunwell, Artifacts.SunwellVial));
    var questVestigesOfPower = new QuestVestigesOfPower(questBlackTemple);
    AddQuest(questVestigesOfPower);
  }

  private void RegisterDialogue()
  {
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf02x\S02Illidan45.flac",
        "At last! The Tomb of Sargeras is found!",
        "Illidan Stormrage")
      , new[]
      {
        this
      }, new List<Objective>
      {
        new ObjectiveLegendReachRect(AllLegends.Naga.Illidan, Regions.Sargeras_Entrance,
          "the Tomb of Sargeras' entrance")
      }
    ));

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human07x\A07Illidan24",
        "Hear me now, you trembling mortals! I am your lord and master! Illidan reigns supreme!",
        "Illidan Stormrage")
      , new[]
      {
        this
      }, new List<Objective>
      {
        new ObjectiveQuestComplete(GetQuestByType<QuestBlackTemple>())
        {
          EligibleFactions = new List<Faction>
          {
            this
          }
        }
      }
    ));

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human02x\A02LadyVashj17.flac",
        "Good, let's get to it then.",
        "Lady Vashj"),
      new[] { this },
      new List<Objective>
      {
        new ObjectiveQuestComplete(GetQuestByType<QuestAzsharasVein>())
        {
          EligibleFactions = new List<Faction> { this }
        }
      }
    ));

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\HumanExpCamp\Human07xInterlude\A07LadyVashj32.flac",
        "The naga are yours to command, Lord Illidan. Where you go, we follow.",
        "Lady Vashj")
      , new[]
      {
        this
      }, new List<Objective>
      {
        new ObjectiveControlLegend(AllLegends.Naga.Vashj, false)
        {
          EligibleFactions = new List<Faction>
          {
            this
          }
        }
      }
    ));

    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf06\N06Illidan17.flac",
        "Now I am complete!",
        "Illidan Stormrage")
      , new[]
      {
        this
      }, new List<Objective>
      {
        new ObjectiveQuestComplete(GetQuestByType<QuestEyeofSargeras>())
        {
          EligibleFactions = new List<Faction> { this }
        }
      }
    ));
  }

  private void RegisterSentinelsDialogue(Sentinels sentinels)
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf03x\S03LadyVashj31",
            "You've come far enough, little warden. Your vaunted night elf justice has no jurisdiction here.",
            "Lady Vashj"),
          new Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf03x\S03Maiev32",
            "What would you know of us or our justice, naga witch?",
            "Maiev Shadowsong")),
        new Faction[]
        {
          this,
          sentinels
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Naga.Vashj, AllLegends.Sentinels.Maiev)
        }));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf03x\S03Illidan45",
            "So, Warden Shadowsong, you've made it at last. I knew you would.",
            "Illidan Stormrage"),
          new Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf03x\S03Maiev46",
            "You have much to pay for, Illidan. I'm taking you back to your cell.",
            "Maiev Shadowsong")),
        new Faction[]
        {
          this,
          sentinels
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Naga.Illidan, AllLegends.Sentinels.Maiev)
        }));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
          @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Illidan31",
          "Tyrande! What are you doing here? This battle does not concern you.",
          "Illidan Stormrage"), new Dialogue(
          @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Tyrande32",
          "I was wrong to set you free, Illidan. I can see that now. You've become a monster.",
          "Tyrande Whisperwind"))
        , new Faction[]
        {
          this,
          sentinels
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Naga.Illidan, AllLegends.Sentinels.Tyrande)
        }));
  }

  private void RegisterDruidsDialogue(Druids druids)
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(
        new DialogueSequence(new Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Illidan38",
            "Brother? What are you doing here?",
            "Illidan Stormrage"),
          new Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Furion39",
            "I've come to stop you, Illidan. Instead of banishing you, I should have returned you to your cage when I had the chance! I was weak then--but no longer.",
            "Malfurion Stormrage")),
        new Faction[]
        {
          this,
          druids
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Naga.Illidan, AllLegends.Druids.Malfurion)
        }));
  }

  private void RegisterScourgeDialogue(Scourge scourge)
  {
    TriggeredDialogueManager.Add(new TriggeredDialogue(
      new Dialogue(@"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Illidan33.flac",
        "You're out of your league, old king. You should have stayed hidden underground.",
        "Illidan Stormrage")
      , new Faction[]
      {
        this,
        scourge
      }, new List<Objective>
      {
        new ObjectiveLegendMeetsLegend(AllLegends.Naga.Illidan, AllLegends.Scourge.Anubarak)
      }
    ));

    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
            @"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Illidan27",
            "Hello, Arthas.",
            "Illidan Stormrage"),
          new Dialogue(
            @"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Arthas28",
            "You look different, Illidan. I guess the Skull of Gul'dan didn't agree with you.",
            "Arthas Menethil")),
        new Faction[]
        {
          this,
          scourge
        }, new[]
        {
          new ObjectiveLegendMeetsLegend(AllLegends.Naga.Illidan, AllLegends.Scourge.Arthas)
        }));
  }

  private void RegisterSentinelsDruidsDialogue(Sentinels sentinels, Druids druids)
  {
    TriggeredDialogueManager.Add(
      new TriggeredDialogue(new DialogueSequence(new Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Tyrande06",
            "What are these vile serpents?",
            "Tyrande Whisperwind"),
          new Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Furion07",
            "I don't know, but these creatures feel familiar somehow.",
            "Malfurion Stormrage"),
          new Dialogue(
            @"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Naga08",
            "Wretched Night Elves. We are the Naga! We are the future!",
            "Myrmidon")),
        new Faction[]
        {
          this,
          druids
        }, new[]
        {
          new ObjectiveEitherOf(
            new ObjectiveDamagePlayer(sentinels.Player)
            {
              EligibleFactions = new List<Faction>
              {
                this
              }
            }, new ObjectiveDamagePlayer(druids.Player)
            {
              EligibleFactions = new List<Faction>
              {
                this
              }
            })
        }));
  }

  private void RegisterFelHordeQuests(FelHorde felHorde)
  {
    var questBurningCrusade = new QuestBurningCrusade(new[]
    {
      AllLegends.Stormwind.StormwindKeep,
      AllLegends.Ironforge.GreatForge
    });
    questBurningCrusade.AddObjective(new ObjectiveFactionQuestComplete(felHorde.GetQuestByType<QuestDarkPortal>(), felHorde)
    {
      ShowsInPopups = false,
      ShowsInQuestLog = false,
      Progress = QuestProgress.Undiscovered
    });
    AddQuest(questBurningCrusade);

    var theWaywardWell = new QuestTheWaywardWell(
      AllLegends.Quelthalas.Sunwell,
      AllLegends.Naga.Illidan,
      questBurningCrusade
    );
    AddQuest(theWaywardWell);
  }

  private void RegisterSentinelsQuests(Sentinels sentinels)
  {
    AddQuest(new QuestKillMaiev());
  }

  private void RegisterScourgeDruidsAhnqirajQuests(Scourge scourge, Druids druids, Ahnqiraj ahnqiraj)
  {
    var kiljaedenQuestTimer = timer.Create();
    kiljaedenQuestTimer.Start(1200, false, () =>
    {
      var kiljaedensCommand = AddQuest(new QuestKiljaedensCommand(scourge, druids, ahnqiraj, AllLegends.Ahnqiraj.Cthun,
        AllLegends.Druids.Nordrassil, AllLegends.Naga.Illidan));
      this.DisplayDiscovered(kiljaedensCommand, true);
    });
  }
}
