using System;
using System.Collections.Generic;
using WarcraftLegacies.MacroTools.DialogueSystem;
using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.TestSource.Setup.FactionSetup.FactionSetup;
using static War3Api.Common;

namespace WarcraftLegacies.TestSource.Setup
{
  public static class DialogueSetup
  {
    public static void Setup()
    {
      try
      {
        DialogueManager.Add(new Dialogue(
          objectives: new[]
          {
            new ObjectiveLegendDead(LegendSetup.Kael)
          },
          soundFile: @"Sound\Dialogue\OrcCampaign\Orc05\O05Cenarius01",
          caption: "Who dares defile this ancient land? Who dares the wrath of Cenarius and the Night Elves?",
          speaker: "Cenarius",
          audience: new[]
          {
            DalaranSetup.Dalaran,
            BlackEmpireSetup.BlackEmpire
          }
        ));
        DialogueManager.Add(new Dialogue(
          objectives: new[]
          {
            new ObjectiveStartSpell(FourCC("AHfs"), false, LegendSetup.Kael)
          }
          , @"Sound\Dialogue\UndeadCampaign\Undead08\U08Kelthuzad18.flac",
          "Come forth, Lord Archimonde! Enter this world, and let us bask in your power!",
          "Kel'thuzad"
        ));
        var gromObjectives = new List<Objective>();
        gromObjectives.Add(new ObjectiveControlLegend(LegendSetup.Kael, false)
        {
          EligibleFactions = new List<Faction>
          {
            BlackEmpireSetup.BlackEmpire
          }
        });
        gromObjectives.Add(new ObjectiveControlLegend(LegendSetup.Uther, false)
        {
          EligibleFactions = new List<Faction>
          {
            BlackEmpireSetup.BlackEmpire
          }
        });
        DialogueManager.Add(new Dialogue(
          objectives: gromObjectives,
          soundFile: @"Sound\Dialogue\OrcCampaign\Orc05\O05Grom26.flac",
          caption:
          "Yes! I feel the power once again! Come, my warriors; drink from the dark waters, and you will be reborn!",
          speaker: "Grom Hellscream",
          audience: new[]
          {
            BlackEmpireSetup.BlackEmpire
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