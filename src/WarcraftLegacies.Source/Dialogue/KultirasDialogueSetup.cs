using MacroTools.DialogueSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class KultirasDialogueSetup
  {
    /// <summary>
    /// Sets up <see cref="KultirasDialogueSetup"/>.
    /// </summary>
    public static void Setup()
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest20x\D20Proudmoore05",
            "I must admit, you orcs are more tenacious than I remembered. I thought you savages would have turned on each other by now.",
            "Daelin Proudmoore"), 
            new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest20x\D20Thrall06",
            "This is not the Horde you remember, old man. We have no interest in conquest or murder. We have paid for our sins of our forebears in blood.",
            "Thrall"), 
            new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\OrcExpCamp\OrcQuest20x\D20Proudmoore07",
            "Can your blood atone for genocide, orc? Your Horde killed countless innocents with its rampage across Stormwind and Lordaeron. Do you really think you can just sweep all that away and cast aside your guilt so easily? No, your kind will never change, and I will never stop fighting you.",
            "Daelin Proudmoore"))
          , new[]
          {
            KultirasSetup.Kultiras,
            FrostwolfSetup.Frostwolf
          }, new[]
          {
            new ObjectiveLegendMeetsLegend(LegendKultiras.LegendAdmiral, LegendFrostwolf.LegendThrall)
          }));
    }
  }
}