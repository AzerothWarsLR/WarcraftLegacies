using System.Linq;
using WCSharp.Shared;

namespace MacroTools.Commands;

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
    var name = whichPlayer.Name;
    return name is "YakaryBovine#6863" or "Lordsebas#11619" or "Technopig#2179" or "Vampirika#2506" or "zbovo2#1599" or "Madsen#21847" || AreCheatsActive;
  }

  private static void CreateInfoQuests()
  {
    var newQuest = quest.Create();
    newQuest.SetTitle("Cheats");
    var description = CommandManager.GetAllCommands().Aggregate("",
      (current, command) => $"{current} -{command.CommandText}: {command.Description}\n");
    newQuest.SetDescription(description);
    newQuest.IsDiscovered = true;
    newQuest.IsRequired = false;
    newQuest.SetIcon(@"ReplaceableTextures\CommandButtons\BTNStaffOfTeleportation.blp");
    newQuest.IsCompleted = false;
  }

  /// <summary>
  /// Sets up <see cref="TestMode"/>.
  /// </summary>
  public static void Setup()
  {
    AreCheatsActive = Util.EnumeratePlayers().Count(player =>
      player.SlotState == playerslotstate.Playing && player.Controller == mapcontrol.User) < 2;

    if (AreCheatsActive)
    {
      CreateInfoQuests();
    }
  }
}
