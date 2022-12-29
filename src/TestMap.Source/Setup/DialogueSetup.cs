using System;
using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using TestMap.Source.Setup.FactionSetup.FactionSetup;
using static War3Api.Common;

namespace TestMap.Source.Setup
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
            DalaranSetup.Dalaran
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
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}