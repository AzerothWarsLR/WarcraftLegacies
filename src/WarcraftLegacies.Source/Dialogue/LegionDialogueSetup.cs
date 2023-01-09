using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives;
using WarcraftLegacies.Source.Quests.Legion;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class LegionDialogueSeup
  {
    public static void Setup()
    {
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf06\N06Tichondrius21.flac",
            "What? Who are... you?",
            "Tichondrius"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf06\N06Illidan22.flac",
            "Let's see how confident you are against one of your own kind, dreadlord!",
            "Illidan Stormrage"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf06\N06Tichondrius20.flac",
            "I'm through toying with you, night elf! Begone from my sight!",
            "Tichondrius")
        )
        , new[]
        {
          LegionSetup.Legion,
          IllidariSetup.Illidari
        }, new List<Objective>
        {
          new ObjectiveLegendMeetsLegend(LegendLegion.LEGEND_TICHONDRIUS, LegendNaga.LegendIllidan)
        }
      ));

      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf07\N07Archimonde14.flac",
            "You orcs are weak, and hardly worth the effort. I wonder why Mannoroth even bothered with you.",
            "Archimonde"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf07\N07Thrall15.flac",
            "Our spirit is stronger than you know, demon! If we are to fall, then so be it! At least now... we are free!",
            "Thrall")
        )
        , new[]
        {
          LegionSetup.Legion,
          FrostwolfSetup.Frostwolf
        }, new List<Objective>
        {
          new ObjectiveLegendMeetsLegend(LegendLegion.LEGEND_ARCHIMONDE, LegendFrostwolf.LegendThrall)
        }
      ));

      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf07\N07Archimonde21.flac",
            "You are very brave to stand against me, little human. If only your countrymen had been as bold, I would have had more fun scouring your wretched nations from the world!",
            "Archimonde"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf07\N07Jaina22.flac",
            "Is talking all you demons do?",
            "Jaina Proudmoore")
        )
        , new[]
        {
          LegionSetup.Legion,
          DalaranSetup.Dalaran
        }, new List<Objective>
        {
          new ObjectiveLegendMeetsLegend(LegendLegion.LEGEND_ARCHIMONDE, LegendDalaran.LegendJaina)
        }
      ));

      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf07\N07Archimonde28.flac",
          "At last, the way to the World Tree is clear! Witness the end, you mortals! The final hour has come.",
          "Archimonde")
        , null, new List<Objective>
        {
          new ObjectiveCompleteQuest(LegionSetup.Legion.GetQuestByType(typeof(QuestConsumeTree)))
        }
      ));
      
      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new DialogueSequence(
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead06\U06KelThuzad21.flac",
            "You called my name, puny lich, and I have come. You are Kel'Thuzad, are you not?",
            "Archimonde"),
          new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead06\U06Archimonde22.flac",
            "Yes, great one. I am the summoner.",
            "Kel'thuzad")
        ), new[]
        {
          LegionSetup.Legion,
          ScourgeSetup.Scourge
        }, new List<Objective>
        {
          new ObjectiveLegendMeetsLegend(LegendLegion.LEGEND_ARCHIMONDE, LegendScourge.LegendKelthuzad)
        }
      ));
    }
  }
}