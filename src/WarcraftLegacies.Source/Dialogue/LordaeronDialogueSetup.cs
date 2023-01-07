using MacroTools.DialogueSystem;

namespace WarcraftLegacies.Source.Dialogue
{
  public static class LordaeronDialogueSetup
  {
    public static void Setup()
    {
      TriggeredDialogueManager.Add(new MacroTools.DialogueSystem.Dialogue(@"Sound\Dialogue\HumanCampaign\Human07\H07Captain01",
        "This is a Light-forsaken land, isn't it? You can barely even see the sun! this howling wind cuts to the bone and you're not even shaking. Milord, are you alright?",
        "Captain"));
    }
  }
}