using System;
using AzerothWarsCSharp.MacroTools.DialogueSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.TestSource.Setup
{
  public static class DialogueSetup
  {
    public static void Setup()
    {
      try
      {
        DialogueManager.Add(new Dialogue(
          new[]
          {
            new ObjectiveLegendDead(LegendSetup.Kael)
          }
          , @"Sound\Dialogue\HumanCampaign\Human04\H04Kelthuzad28.flac",
          "Naive fool. My death will make little difference in the long run. For now, the scourging of this land... begins.",
          "Kel'thuzad"
        ));
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}