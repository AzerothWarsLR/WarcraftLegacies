using static War3Api.Common;  using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatUncontrol
  {
    private const string COMMAND = "-uncontrol ";

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (parameter == "all")
      {
        var i = 0;
        while (true)
        {
          if (i > bj_MAX_PLAYERS) break;

          SetPlayerAlliance(Player(i), GetTriggerPlayer(), ALLIANCE_SHARED_CONTROL, false);
          SetPlayerAlliance(Player(i), GetTriggerPlayer(), ALLIANCE_SHARED_ADVANCED_CONTROL, false);
          i += 1;
        }

        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Revoked control of all players.");
      }
      else
      {
        SetPlayerAlliance(Player(S2I(parameter)), GetTriggerPlayer(), ALLIANCE_SHARED_CONTROL, false);
        SetPlayerAlliance(Player(S2I(parameter)), GetTriggerPlayer(), ALLIANCE_SHARED_ADVANCED_CONTROL, false);
        DisplayTextToPlayer(p, 0, 0,
          "|cffD27575CHEAT:|r Revoked control of player " + GetPlayerName(Player(S2I(parameter))) + ".");
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);

      TriggerAddAction(trig, Actions);
    }
  }
}