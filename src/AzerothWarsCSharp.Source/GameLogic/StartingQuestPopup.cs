using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.GameLogic
{
  /// <summary>
  /// Displays each Faction's starting quest after the cinematic phase ends.
  /// </summary>
  public static class StartingQuestPopup
  {
    private static void Popup()
    {
      Faction.ByPlayerHandle(GetLocalPlayer()).StartingQuest.MessageByProgress(QuestProgress.Incomplete).Display();
    }

    public static void Initialize()
    {
      var trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 63, false);
      TriggerAddAction(trig, Popup);
    }
  }
}