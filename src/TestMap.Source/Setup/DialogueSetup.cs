using System;
using System.Collections.Generic;
using MacroTools.DialogueSystem;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem;
using MacroTools.QuestSystem;

namespace TestMap.Source.Setup
{
  public static class DialogueSetup
  {
    public static void Setup()
    {
      try
      {
        TriggeredDialogueManager.Add(new Dialogue(soundFile: @"Sound\Dialogue\OrcCampaign\Orc05\O05Cenarius01",
          caption: "Who dares defile this ancient land? Who dares the wrath of Cenarius and the Night Elves?",
          speaker: "Cenarius"
        ));
        TriggeredDialogueManager.Add(new Dialogue(@"Sound\Dialogue\UndeadCampaign\Undead08\U08Kelthuzad18.flac",
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