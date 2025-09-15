using MacroTools.CommandSystem;
using System.Linq;
using WCSharp.Shared;

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
    /// Returns true if <see cref="whichPlayer"/> has cheats enabled.
    /// </summary>
    public static bool CheatCondition(player whichPlayer)
    {
      var name = GetPlayerName(whichPlayer);
      return name is "YakaryBovine#6863" or "Lordsebas#11619" or "Technopig#2179" or "Vampirika#2506" or "zbovo2#1599" or "Madsen#21847" || AreCheatsActive;
    }

    private static void CreateInfoQuests(CommandManager commandManager)
    {
      var newQuest = CreateQuest();
      QuestSetTitle(newQuest, "Cheats");
      var description = commandManager.GetAllCommands().Aggregate("",
        (current, command) => $"{current} -{command.CommandText}: {command.Description}\n");
      QuestSetDescription(newQuest, description);
      QuestSetDiscovered(newQuest, true);
      QuestSetRequired(newQuest, false);
      QuestSetIconPath(newQuest, @"ReplaceableTextures\CommandButtons\BTNStaffOfTeleportation.blp");
      QuestSetCompleted(newQuest, false);
    }

    /// <summary>
    /// Sets up <see cref="TestMode"/>.
    /// </summary>
    public static void Setup(CommandManager commandManager)
    {
      AreCheatsActive = Util.EnumeratePlayers().Count(player =>
        GetPlayerSlotState(player) == PLAYER_SLOT_STATE_PLAYING && GetPlayerController(player) == MAP_CONTROL_USER) < 2;

      if (AreCheatsActive)
        CreateInfoQuests(commandManager);
    }
  }
}
