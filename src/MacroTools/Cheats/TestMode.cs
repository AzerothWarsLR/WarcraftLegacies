using System.Linq;
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
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "This map is in test mode and contains |cffD27575CHEATS|r.");
      DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "To use these |cffD27575CHEATS|r, refer to the Quest menu.");
    }

    private static void CreateInfoQuests()
    {
      var newQuest = CreateQuest();
      QuestSetTitle(newQuest, "Test Commands");
      QuestSetDescription(newQuest,
        " - gold x|n - lumber x|n - food x|n - tele on/off (use patrol to teleport anywhere on the map instantly)|n - build on/off (press cancel on a building to finish its progress instantly)|n - nocd on/off (instant refresh cds)|n - mana on/off (instant refund all mana)|n - unlock (unlocks all Path requirements)|n - god on/off (deal 100x damage, take no damage)|n - vision on/off (reveal entire map)|n - time xx (time of day)|n - control xx (take shared control of player xx)|n - uncontrol xx (revoke control of player xx)|n - level xx (level of selected units)|n - hp xx (health of selected units)|n - mp xx|n - remove (remove selected units)|n - faction <text> (change faction to entered string)|n - team <faction> <team> (change the specified faction's team)|n - owner xx (transfer selected units to player xx)|n - spawn yyyy xx (spawns xx instances of unit || item yyyy, uses rawcodes)|n - kick xx (causes player xx to psuedo-leave, and lose faction and team)|n");
      QuestSetDiscovered(newQuest, true);
      QuestSetRequired(newQuest, true);
      QuestSetIconPath(newQuest, "ReplaceableTextures\\CommandButtons\\BTNStaffOfTeleportation.blp");
      QuestSetCompleted(newQuest, false);
    }

    /// <summary>
    /// Sets up <see cref="TestMode"/>.
    /// </summary>
    public static void Setup()
    {
      AreCheatsActive = Util.EnumeratePlayers().Count(player =>
        GetPlayerSlotState(player) == PLAYER_SLOT_STATE_PLAYING && GetPlayerController(player) == MAP_CONTROL_USER) < 2;

      if (!AreCheatsActive) 
        return;
      CreateInfoQuests();
      var trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 200, true);
      TriggerAddAction(trig, Warning);
    }
  }
}