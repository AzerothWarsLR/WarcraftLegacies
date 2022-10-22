using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using War3Api;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  /// <summary>
  /// A cheat that completes a specified <see cref="QuestData"/>.
  /// </summary>
  public static class CheatCompleteQuest
  {
    private const string Command = "-complete ";

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      var enteredString = GetEventPlayerChatString();
      var triggerPlayer = GetTriggerPlayer();
      var parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));

      var quest = triggerPlayer.GetFaction()?.GetQuestByTitle(parameter);
      if (quest != null) 
        quest.Progress = QuestProgress.Complete;
      
      DisplayTextToPlayer(triggerPlayer, 0, 0, $"|cffD27575CHEAT:|r Attempted to complete quest {parameter}.");
    }

    /// <summary>
    /// Registers the command which allows players to execute the <see cref="CheatCompleteQuest"/> cheat.
    /// </summary>
    public static void Setup()
    {
      var trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) 
        TriggerRegisterPlayerChatEvent(trig, player, Command, false);
      TriggerAddAction(trig, Actions);
    }
  }
}