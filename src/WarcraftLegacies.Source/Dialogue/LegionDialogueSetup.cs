using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using WarcraftLegacies.Source.Factions;
using WarcraftLegacies.Source.Quests.Legion;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class LegionDialogueSeup
  {
    public static void Setup(AllLegendSetup legendSetup)
    {
      var dalaran = FactionManager.GetFactionByType<Dalaran>();
      
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
          new ObjectiveLegendMeetsLegend(legendSetup.Legion.Tichondrius, legendSetup.Naga.Illidan)
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
          new ObjectiveLegendMeetsLegend(legendSetup.Legion.Archimonde, legendSetup.Frostwolf.Thrall)
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
          dalaran
        }, new List<Objective>
        {
          new ObjectiveLegendMeetsLegend(legendSetup.Legion.Archimonde, legendSetup.Dalaran.Jaina)
        }
      ));

      TriggeredDialogueManager.Add(new TriggeredDialogue(
        new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfCampaign\NightElf07\N07Archimonde28.flac",
          "At last, the way to the World Tree is clear! Witness the end, you mortals! The final hour has come.",
          "Archimonde")
        , null, new List<Objective>
        {
          new ObjectiveQuestComplete(LegionSetup.Legion.GetQuestByType<QuestConsumeTree>())
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
          new ObjectiveLegendMeetsLegend(legendSetup.Legion.Archimonde, legendSetup.Scourge.Kelthuzad)
        }
      ));
    }
  }
}