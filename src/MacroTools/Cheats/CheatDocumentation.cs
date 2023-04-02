using System.Linq;
using MacroTools.CommandSystem;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public static partial class TestMode
  {
    /// <summary>
    /// Initializes all the cheat info in the F9 menu
    /// </summary>
    public static class CheatDocumentation
    {
      /// <summary>
      /// Sets up <see cref="CheatDocumentation"/>.
      /// </summary>
      public static void Setup(CommandManager commandManager)
      {
   
        CreateInfoQuests(commandManager);
        var trig = CreateTrigger();
        TriggerRegisterTimerEvent(trig, 200, true);
        TriggerAddAction(trig, Warning);
      }

      private static void Warning()
      {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "This map is in test mode and contains |cffD27575CHEATS|r.");
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "To use these |cffD27575CHEATS|r, refer to the Quest menu.");
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
    }
  }
}