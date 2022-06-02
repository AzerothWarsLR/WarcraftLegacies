using System;
using AzerothWarsCSharp.MacroTools.DialogueSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.FactionSetup;
using AzerothWarsCSharp.Source.Setup.Legends;

namespace AzerothWarsCSharp.Source.Setup
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
            new ObjectiveLegendDead(LegendScourge.LegendKelthuzad)
          },
          soundFile: @"Sound\Dialogue\HumanCampaign\Human04\H04Kelthuzad28.flac",
          caption:
          "Naive fool. My death will make little difference in the long run. For now, the scourging of this land... begins.",
          speaker: "Kel'thuzad",
          audience: new[]
          {
            ScourgeSetup.FactionScourge,
            LordaeronSetup.FactionLordaeron,
          }
        ));

        DialogueManager.Add(new Dialogue(
          objectives: new[]
          {
            new ObjectiveStartSpell(Constants.ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS, false,
              LegendScourge.LegendKelthuzad)
          },
          soundFile: @"Sound\Dialogue\UndeadCampaign\Undead08\U08Kelthuzad18.flac",
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