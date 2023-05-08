using System.Linq;
using MacroTools.CommandSystem;
using WCSharp.Shared;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  /// <summary>
  /// Responsible for determining whether or not the map should be run in test mode.
  /// </summary>
  public static class TestMode
  {
    /// <summary>
    /// If true, cheats are active for all players.
    /// </summary>
    public static bool AreCheatsActive { get; private set; }

    /// <summary>
    /// Returns true if <see cref="GetTriggerPlayer"/> has cheats enabled.
    /// </summary>
    public static bool CheatCondition()
    {
      var triggerPlayerName = GetPlayerName(GetTriggerPlayer());
      return triggerPlayerName is "YakaryBovine#6863" or "Lordsebas#11619" || AreCheatsActive;
    }

    private static void Warning()
    {
      foreach (var player in Util.EnumeratePlayers())
      {
        DisplayTextToPlayer(player, 0, 0, "This map is in test mode and contains |cffD27575CHEATS|r.");
        DisplayTextToPlayer(player, 0, 0, "To use these |cffD27575CHEATS|r, refer to the Quest menu.");
      }
    }

    private static void CreateInfoQuests(CommandManager commandManager)
    {
      var newQuest = CreateQuest();
      QuestSetTitle(newQuest, "Test Commands");
      var description = commandManager.GetAllCommands().Aggregate("",
        (current, command) => $"{current} -{command.CommandText}: {command.Description}\n");
      QuestSetDescription(newQuest, description);
      QuestSetDiscovered(newQuest, true);
      QuestSetRequired(newQuest, true);
      QuestSetIconPath(newQuest, "ReplaceableTextures\\CommandButtons\\BTNStaffOfTeleportation.blp");
      QuestSetCompleted(newQuest, false);
    }

    /// <summary>
    /// Sets up <see cref="TestMode"/>.
    /// </summary>
    public static void Setup(CommandManager commandManager)
    {
      AreCheatsActive = Util.EnumeratePlayers().Count(player =>
        GetPlayerSlotState(player) == PLAYER_SLOT_STATE_PLAYING && GetPlayerController(player) == MAP_CONTROL_USER) < 2;

      if (!AreCheatsActive) 
        return;
      CreateInfoQuests(commandManager);
      var trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 200, true);
      TriggerAddAction(trig, Warning);
    }
  }
}