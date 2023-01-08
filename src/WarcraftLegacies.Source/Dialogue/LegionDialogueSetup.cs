using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives;
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
    }
  }
}