using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WCSharp.Shared;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// Responsible for displaying each <see cref="Faction"/>'s starting <see cref="QuestData"/>.
/// </summary>
public static class StartingQuestPopup
{
  /// <summary>
  /// Displays each <see cref="Faction"/>'s starting <see cref="QuestData"/> to the occupying player
  /// after a period of time has elapsed.
  /// </summary>
  /// <param name="timeToDisplay">Number of seconds after which to display the quests.</param>
  public static void Setup(float timeToDisplay)
  {
    var trig = trigger.Create();
    trig.RegisterTimerEvent(timeToDisplay, false);
    trig.AddAction(() =>
    {
      foreach (var player in Util.EnumeratePlayers(playerslotstate.Playing, mapcontrol.User))
      {
        var playerFaction = player.GetPlayerData().Faction;
        if (playerFaction?.StartingQuest != null)
        {
          playerFaction.DisplayDiscovered(playerFaction.StartingQuest, true);
        }
      }
    });
  }
}
