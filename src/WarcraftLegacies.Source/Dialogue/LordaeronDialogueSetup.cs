using System.Collections.Generic;
using MacroTools;
using MacroTools.DialogueSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives;
using WarcraftLegacies.Source.Quests.Scourge;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class LordaeronDialogueSetup
  {
    public static void Setup(PreplacedUnitSystem preplacedUnitSystem)
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\HumanCampaign\Human01\H01Uther01",
            "Welcome, Prince Arthas. The men and I are honored by your presence.",
            "Uther the Lightbringer"), 
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human01\H01Arthas02",
              "Can the formalities, Uther. I'm not king yet. It's good to see you.",
              "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human01\H01Uther03",
              "You too, lad. I'm pleased that King Terenas sent you to help me.",
              "Uther the Lightbringer"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human01\H01Arthas04",
              "Father still hopes your patience and experience might rub off on me.",
              "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human01\H01Uther05",
              "It is a father's right to dream, isn't it?",
              "Uther the Lightbringer")
            ), 
          new[]
        {
          LordaeronSetup.Lordaeron
        }, new Objective[]
        {
          new ObjectiveLegendMeetsLegend(LegendLordaeron.Arthas, LegendLordaeron.Uther)
        }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human02\H02Blademaster11",
              "Paladin fool! The warlocks of the Blackrock clan have spoken! Soon, demons will rain from the sky, and this wretched world will burn!",
              "Jubei'thos"), 
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human02\H02Uther12",
              "Yes, I've heard this rhetoric before. You orcs will never learn!",
              "Uther the Lightbringer")
          ), 
          new[]
          {
            LordaeronSetup.Lordaeron
          }, new Objective[]
          {
            new ObjectiveLegendInRect(LegendLordaeron.Uther, Regions.AlteracAmbient, "Alterac"),
            new ObjectiveUnitAlive(preplacedUnitSystem.GetUnit(Constants.UNIT_O00B_JUBEI_THOS_LEGION_DEMI, new Point(11066, 6291)))
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\HumanCampaign\Human07\H07Captain01",
          "This is a Light-forsaken land, isn't it? You can barely even see the sun! This howling wind cuts to the bone and you're not even shaking. Mi'lord, are you alright?",
          "Captain Falric"),
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\HumanCampaign\Human07\H07Arthas02",
            "Captain, are all my forces accounted for?",
            "Arthas Menethil"),
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\HumanCampaign\Human07\H07Captain03",
            "Nearly. There are only a few ships that--",
            "Captain Falric"),
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\HumanCampaign\Human07\H07Arthas04",
            "Very well. Our first priority is to set up a base camp with proper defenses. There's no telling what's waiting for us out there in the shadows.",
            "Arthas Menethil")
          ), new[]
        {
          LordaeronSetup.Lordaeron
        }, new Objective[]
        {
          new ObjectiveLegendReachRect(LegendLordaeron.Arthas, Regions.Central_Northrend, "central Northrend")
        }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human03\H03Arthas06",
              "Looks like you haven't lost your touch. It's good to see you again, Jaina.",
              "Arthas Menethil"), 
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human03\H03Jaina07",
              "You too, Arthas. It's been awhile since a prince escorted me anywhere.",
              "Jaina Proudmoore"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human03\H03Arthas08",
              "Yes, it has. Well, I guess we should get underway.",
              "Arthas Menethil")
          ), 
          new[]
          {
            LordaeronSetup.Lordaeron
          }, new Objective[]
          {
            new ObjectiveLegendMeetsLegend(LegendLordaeron.Arthas, LegendDalaran.LegendJaina)
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human03\H03Arthas12",
              "This must be the shrine that the old man spoke of. Any man who drinks from these Light-blessed waters will be healed.",
              "Arthas Menethil")
          ), 
          new[]
          {
            LordaeronSetup.Lordaeron
          }, new Objective[]
          {
            new ObjectiveLegendInRect(LegendLordaeron.Arthas, Regions.FountainOfHealthAlterac, "Fountain of Health in Alterac")
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new DialogueSequence(
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human09\H09MalGanis23",
              "So, you've taken up Frostmourne at the expense of your comrades' lives, just as the Dark Lord said you would. You're stronger than I thought.",
              "Mal'ganis"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human09\H09Arthas24",
              "You waste your breath, Mal'Ganis. I heed only the voice of Frostmourne now.",
              "Arthas Menethil"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human09\H09MalGanis25",
              "You hear the voice of the Dark Lord. He whispers to you through the blade you wield. What does he say, young human? What does the Dark Lord of the Dead tell you now?",
              "Mal'ganis"),
            new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human09\H09Arthas26",
              "He tells me that the time for my vengeance has come.",
              "Arthas Menethil")
          ), 
          new[]
          {
            LordaeronSetup.Lordaeron,
            ScourgeSetup.Scourge,
            LegionSetup.Legion
          }, new Objective[]
          {
            new ObjectiveCompleteQuest(ScourgeSetup.Scourge.GetQuestByType(typeof(QuestCorruptArthas)))
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new MacroTools.DialogueSystem.Dialogue(
              @"Sound\Dialogue\HumanCampaign\Human07\H07Arthas26",
              "That has to be where Mal'Ganis is hiding! I want that base leveled!",
              "Arthas Menethil"),
            new[]
          {
            LordaeronSetup.Lordaeron,
            LegionSetup.Legion
          }, new Objective[]
          {
            new ObjectiveLegendInRect(LegendLordaeron.Arthas, Regions.DrakUnlock, ""),
          }));
      
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(
          new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\HumanCampaign\Human09\H09MalGanis03",
            "The Dark Lord said you would come. This is where your journey ends, boy. Trapped and freezing at the roof of the world, with only death to sing the tale of your doom.",
            "Mal'ganis"),
          new[]
          {
            LordaeronSetup.Lordaeron,
            LegionSetup.Legion
          }, new Objective[]
          {
            new ObjectiveLegendMeetsLegend(LegendLegion.LEGEND_MALGANIS, LegendLordaeron.Arthas),
            new ObjectiveLegendInRect(LegendLordaeron.Arthas, Regions.Central_Northrend, ""), //Todo: make this work in any region of Northrend
            new ObjectiveLegendInRect(LegendLegion.LEGEND_MALGANIS, Regions.Central_Northrend, "")
          }));
      
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead02\U02Uther21.flac",
            "Your father ruled this land for seventy years, and you've ground it to dust in a matter of days.",
            "Uther the Lightbringer")
        )
        , new[]
        {
          ScourgeSetup.Scourge,
          LordaeronSetup.Lordaeron
        }, new List<Objective>
        {
          new ObjectiveLegendMeetsLegend(LegendLordaeron.Uther, LegendLordaeron.Arthas)
        }
      ));
    }
  }
}