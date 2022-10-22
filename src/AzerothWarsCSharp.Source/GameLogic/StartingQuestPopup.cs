using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.Source.GameLogic
{
  /// <summary>
  /// Responsible for displaying each <see cref="Faction"/>'s starting <see cref="QuestData"/>.
  /// </summary>
  public static class StartingQuestPopup
  {
    /// <summary>
    /// Displays each <see cref="Faction"/>'s starting <see cref="QuestData"/> to the occupying <see cref="player"/>
    /// after a period of time has elapsed.
    /// </summary>
    /// <param name="timeToDisplay">Number of seconds after which to display the quests.</param>
    public static void Setup(float timeToDisplay)
    {
      var trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, timeToDisplay, false);
      TriggerAddAction(trig, () =>
      {
        foreach (var player in GetAllPlayers())
        {
          var playerFaction = player.GetFaction();
          if (playerFaction != null && player.GetFaction()?.StartingQuest != null && GetLocalPlayer() == player)
            playerFaction.StartingQuest?.DisplayDiscovered(playerFaction);
        }
      });
    }
  }
}