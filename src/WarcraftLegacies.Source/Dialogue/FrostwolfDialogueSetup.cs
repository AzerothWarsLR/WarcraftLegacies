using MacroTools.DialogueSystem;
using MacroTools.ObjectiveSystem.Objectives;
using WarcraftLegacies.Source.Quests.Warsong;
using WarcraftLegacies.Source.Setup.FactionSetup;

namespace WarcraftLegacies.Source.Dialogue
{
  /// <summary>
  /// Responsible for setting up all dialogue involving the <see cref="FrostwolfSetup.Frostwolf"/> faction.
  /// </summary>
  public static class FrostwolfDialogueSetup
  {
    /// <summary>
    /// Sets up <see cref="FrostwolfDialogueSetup"/>.
    /// </summary>
    public static void Setup()
    {
      TriggeredDialogueManager.Add(
        new TriggeredDialogue(new MacroTools.DialogueSystem.Dialogue(
          @"Sound\Dialogue\OrcCampaign\Orc08\O08Thrall07",
          "Hellscream is like a brother to me, Cairne. But he and his clan have fallen under the demon's influence. If I can't save him, then my people might be damned for all time.",
          "Thrall"), new[]
        {
          FrostwolfSetup.Frostwolf
        }, new[]
        {
          new ObjectiveCompleteQuest(WarsongSetup.WarsongClan.GetQuestByType(typeof(QuestFountainOfBlood)))
        }));
    }
  }
}