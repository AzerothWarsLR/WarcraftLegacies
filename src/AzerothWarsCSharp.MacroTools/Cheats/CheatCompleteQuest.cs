using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatCompleteQuest
  {
    private const string COMMAND = "-completequest ";

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player triggerPlayer = GetTriggerPlayer();
      GetPlayerId(triggerPlayer);
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      triggerPlayer.GetFaction().GetQuestByTitle(parameter).Progress = QuestProgress.Complete;
      DisplayTextToPlayer(triggerPlayer, 0, 0, $"|cffD27575CHEAT:|r Attempted to complete quest {parameter}.");
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);

      TriggerAddAction(trig, Actions);
    }
  }
}