using AzerothWarsCSharp.MacroTools.Libraries;
using static War3Api.Common; using static War3Api.Blizzard;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class TestSafety
  {
    public static bool AreCheatsActive { get; private set; }

    public static bool CheatCondition()
    {
      var triggerPlayerName = GetPlayerName(GetTriggerPlayer());
      return triggerPlayerName is "YakaryBovine#6863" or "Lordsebas#11619" || AreCheatsActive;
    }

    private static void Warning()
    {
      DisplayTextToForce(GetPlayersAll(), "This map is in test mode and contains |cffD27575CHEATS|r.");
      DisplayTextToForce(GetPlayersAll(), "To use these |cffD27575CHEATS|r, refer to the Quest menu.");
    }

    private static void Quests()
    {
      CreateQuestBJ(bj_QUESTTYPE_REQ_DISCOVERED, "Test Commands",
        " - gold x|n - lumber x|n - food x|n - tele on/off (use patrol to teleport anywhere on the map instantly)|n - build on/off (press cancel on a building to finish its progress instantly)|n - nocd on/off (instant refresh cds)|n - mana on/off (instant refund all mana)|n - unlock (unlocks all Path requirements)|n - god on/off (deal 100x damage, take no damage)|n - vision on/off (reveal entire map)|n - time xx (time of day)|n - control xx (take shared control of player xx)|n - uncontrol xx (revoke control of player xx)|n - level xx (level of selected units)|n - hp xx (health of selected units)|n - mp xx|n - remove (remove selected units)|n - faction <text> (change faction to entered string)|n - team <text> (change team to entered string)|n - owner xx (transfer selected units to player xx)|n - spawn yyyy xx (spawns xx instances of unit || item yyyy, uses rawcodes)|n - kick xx (causes player xx to psuedo-leave, and lose faction and team)|n",
        "ReplaceableTextures\\CommandButtons\\BTNStaffOfTeleportation.blp");
    }

    public static void Setup()
    {
      var userCount = 0;

      AreCheatsActive = true;
      var i = 0;
      while (true)
      {
        if (i == Environment.MAX_PLAYERS || AreCheatsActive == false)
        {
          break;
        }

        if (GetPlayerSlotState(Player(i)) == PLAYER_SLOT_STATE_PLAYING &&
            GetPlayerController(Player(i)) == MAP_CONTROL_USER)
        {
          userCount += 1;
          if (userCount > 1)
          {
            AreCheatsActive = false;
          }
        }

        i += 1;
      }

      if (AreCheatsActive)
      {
        Quests();
        var trig = CreateTrigger();
        TriggerRegisterTimerEvent(trig, 200, true);
        TriggerAddAction(trig, Warning);
      }
    }
  }
}