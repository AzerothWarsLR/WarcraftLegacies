using MacroTools.DialogueSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup;
using WarcraftLegacies.Source.Setup.FactionSetup;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Dialogue
{
  /// <summary>
  /// Responsible for setting up all dialogue involving <see cref="QuelthalasSetup.Quelthalas"/>.
  /// </summary>
  public static class QuelthalasDialogueSetup
  {
    /// <summary>
    /// Sets up <see cref="QuelthalasDialogueSetup"/>.
    /// </summary>
    public static void Setup(AllLegendSetup setup)
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new DialogueSequence(new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Arthas30",
            "Are you still upset that I stole Jaina from you, Kael?",
            "Illidan Stormrage"), new MacroTools.DialogueSystem.Dialogue(
            @"Sound\Dialogue\UndeadExpCamp\Undead08x\L08Kael31",
            "You've taken everything I ever cared for, Arthas. Vengeance is all I have left.",
            "Kael'thas Sunstrider"))
          , new[]
          {
            QuelthalasSetup.Quelthalas,
            ScourgeSetup.Scourge
          }, new[]
          {
            new ObjectiveLegendMeetsLegend(LegendScourge.Arthas, LegendQuelthalas.LegendKael)
          }));
    }
  }
}