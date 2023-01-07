using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives;
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
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\OrcCampaign\Orc05\O05Cenarius01",
          "Who dares defile this ancient land? Who dares the wrath of Cenarius and the Night Elves?",
          "Cenarius"), new[]
        {
          SentinelsSetup.Sentinels,
          DruidsSetup.Druids,
          FrostwolfSetup.Frostwolf,
          WarsongSetup.WarsongClan
        }, new[]
        {
          new ObjectiveControlLegend(LegendDruids.LegendCenarius, false)
          {
            EligibleFactions = new List<Faction>
            {
              DruidsSetup.Druids
            }
          }
        }));
    }
  }
}