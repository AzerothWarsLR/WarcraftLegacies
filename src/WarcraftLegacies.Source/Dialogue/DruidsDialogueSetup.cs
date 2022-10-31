using System;
using System.Collections.Generic;
using WarcraftLegacies.MacroTools.DialogueSystem;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  /// <summary>
  /// Responsible for setting up all dialogue related to the Druids.
  /// </summary>
  public static class DruidsDialogueSetup
  {
    /// <summary>
    /// Sets up all dialogue related to the Druids.
    /// </summary>
    public static void Setup()
    {
      try
      {
        DialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(
          objectives: new[]
          {
            new ObjectiveControlLegend(LegendDruids.LegendCenarius, false)
            {
              EligibleFactions = new List<Faction>
              {
                DruidsSetup.Druids
              }
            }
          },
          soundFile: @"Sound\Dialogue\OrcCampaign\Orc05\O05Cenarius01",
          caption: "Who dares defile this ancient land? Who dares the wrath of Cenarius and the Night Elves?",
          speaker: "Cenarius",
          audience: new[]
          {
            SentinelsSetup.Sentinels,
            DruidsSetup.Druids,
            FrostwolfSetup.Frostwolf,
            WarsongSetup.WarsongClan
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