using System;
using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class WarsongDialogueSetup
  {
    public static void Setup()
    {
      try
      {
        var gromObjectives = new List<Objective>();
        gromObjectives.Add(new ObjectiveControlLegend(LegendWarsong.GromHellscream, false)
        {
          EligibleFactions = new List<Faction>
          {
            WarsongSetup.WarsongClan
          }
        });
        gromObjectives.Add(new ObjectiveControlCapital(LegendNeutral.FountainOfBlood, false)
        {
          EligibleFactions = new List<Faction>
          {
            WarsongSetup.WarsongClan
          }
        });
        TriggeredDialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(soundFile: @"Sound\Dialogue\OrcCampaign\Orc05\O05Grom26.flac",
          caption:
          "Yes! I feel the power once again! Come, my warriors; drink from the dark waters, and you will be reborn!",
          speaker: "Grom Hellscream"
        ));
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}