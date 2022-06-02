using System;
using AzerothWarsCSharp.MacroTools.DialogueSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.TestSource.Setup.FactionSetup.FactionSetup;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Setup
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
          soundFile: @"Sound\Dialogue\HumanCampaign\Human04\H04Kelthuzad28.flac",
          caption:
          "Naive fool. My death will make little difference in the long run. For now, the scourging of this land... begins.",
          speaker: "Kel'thuzad",
          audience: new[]
          {
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
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to run DialogueSetup: {ex}");
      }
    }
  }
}