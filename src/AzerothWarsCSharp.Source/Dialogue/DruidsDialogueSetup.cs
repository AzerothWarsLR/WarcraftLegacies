using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.DialogueSystem;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Dialogue
{
  public static class DruidsDialogueSetup
  {
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
                DruidsSetup.factionDruids
              }
            }
          },
          soundFile: @"Sound\Dialogue\OrcCampaign\Orc05\O05Cenarius01",
          caption: "Who dares defile this ancient land? Who dares the wrath of Cenarius and the Night Elves?",
          speaker: "Cenarius",
          audience: new[]
          {
            SentinelsSetup.Sentinels,
            DruidsSetup.factionDruids,
            FrostwolfSetup.FACTION_FROSTWOLF,
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