using System;
using MacroTools.DialogueSystem;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class ScourgeDialogueSetup
  {
    public static void Setup()
    {
      try
      {
        TriggeredDialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(soundFile: @"Sound\Dialogue\HumanCampaign\Human04\H04Kelthuzad28.flac",
          caption:
          "Naive fool. My death will make little difference in the long run. For now, the scourging of this land... begins.",
          speaker: "Kel'thuzad"
        ));

        TriggeredDialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(soundFile: @"Sound\Dialogue\UndeadCampaign\Undead08\U08Kelthuzad18.flac",
          caption: "Come forth, Lord Archimonde! Enter this world, and let us bask in your power!",
          speaker: "Kel'thuzad"
        ));
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}