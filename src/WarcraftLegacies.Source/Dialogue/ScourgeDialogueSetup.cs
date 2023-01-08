using MacroTools.DialogueSystem;
using MacroTools.ObjectiveSystem.Objectives;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class ScourgeDialogueSetup
  {
    public static void Setup()
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          soundFile: @"Sound\Dialogue\HumanCampaign\Human04\H04Kelthuzad28.flac",
          caption:
          "Naive fool. My death will make little difference in the long run. For now, the scourging of this land... begins.",
          speaker: "Kel'thuzad"), new[]
        {
          ScourgeSetup.Scourge,
          LordaeronSetup.Lordaeron,
        }, new[]
        {
          new ObjectiveLegendDead(LegendScourge.LegendKelthuzad)
        }));

      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          soundFile: @"Sound\Dialogue\UndeadCampaign\Undead08\U08Kelthuzad18.flac",
          caption: "Come forth, Lord Archimonde! Enter this world, and let us bask in your power!",
          speaker: "Kel'thuzad"), 
          null, 
          new[]
        {
          new ObjectiveStartSpell(Constants.ABILITY_A00J_SUMMON_THE_BURNING_LEGION_ALL_FACTIONS, false,
            LegendScourge.LegendKelthuzad)
        }));
    }
  }
}