using MacroTools.DialogueSystem;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Dialogue
{
  /// <summary>
  /// Responsible for setting up all dialogue involving the <see cref="SentinelsSetup.Sentinels"/> faction.
  /// </summary>
  public static class SentinelsDialogueSetup
  {
    /// <summary>
    /// Sets up <see cref="SentinelsDialogueSetup"/>.
    /// </summary>
    public static void Setup()
    {
      TriggeredDialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev22",
        "Elune be praised! I knew you would come, Shan'do Stormrage.",
        "Illidan Stormrage"));
      
      TriggeredDialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev24",
        "Priestess Tyrande. I'm surprised you came in person. Are you here to absolve your guilty conscience?",
        "Maiev Shadowsong"));
      
      TriggeredDialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\NightElfExpCamp\NightElf05x\S05Maiev37",
        "I am the hand of justice, Illidan. Long ago, I swore an oath to keep you chained, and by all the gods, I shall.",
        "Maiev Shadowsong"));
    }
  }
}