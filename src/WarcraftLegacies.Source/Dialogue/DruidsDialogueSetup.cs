using System;
using MacroTools.DialogueSystem;

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
        TriggeredDialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(soundFile: @"Sound\Dialogue\OrcCampaign\Orc05\O05Cenarius01",
          caption: "Who dares defile this ancient land? Who dares the wrath of Cenarius and the Night Elves?",
          speaker: "Cenarius"
        ));
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}