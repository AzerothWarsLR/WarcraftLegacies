using MacroTools.DialogueSystem;

namespace WarcraftLegacies.Source.Dialogue
{
  /// <summary>
  /// Responsible for setting up all dialogue involving Illidan's faction.
  /// </summary>
  public static class IllidariDialogueSetup
  {
    /// <summary>
    /// Sets up <see cref="IllidariDialogueSetup"/>.
    /// </summary>
    public static void Setup()
    {
      TriggeredDialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Illidan31",
        "Tyrande, what are you doing here? This battle does not concern you.",
        "Illidan Stormrage"));
      
      TriggeredDialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Illidan38",
        "Brother? What are you doing here?",
        "Illidan Stormrage"));
      
      TriggeredDialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Naga08",
        "Wretched Night Elves. We are the Naga! We are the future!",
        "Myrmidon"));
    }
  }
}