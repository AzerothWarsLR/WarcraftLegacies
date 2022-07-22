using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.DialogueSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Dialogue
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
            WarsongSetup.FACTION_WARSONG
          }
        });
        gromObjectives.Add(new ObjectiveControlLegend(LegendNeutral.LegendFountainofblood, false)
        {
          EligibleFactions = new List<Faction>
          {
            WarsongSetup.FACTION_WARSONG
          }
        });
        DialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(
          objectives: gromObjectives,
          soundFile: @"Sound\Dialogue\OrcCampaign\Orc05\O05Grom26.flac",
          caption:
          "Yes! I feel the power once again! Come, my warriors; drink from the dark waters, and you will be reborn!",
          speaker: "Grom Hellscream",
          audience: new[]
          {
            WarsongSetup.FACTION_WARSONG
          }
        ));
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}