using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatControl
  {
    private const string COMMAND = "-control ";

    private static void Actions()
    {
      if (!TestSafety.CheatCondition())
      {
        return;
      }

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      GetPlayerId(p);
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      if (parameter == "all")
      {
        foreach (var player in GetAllPlayers())
        {
          SetPlayerAllianceStateBJ(GetTriggerPlayer(), player, bj_ALLIANCE_ALLIED_ADVUNITS);
          SetPlayerAllianceStateBJ(player, GetTriggerPlayer(), bj_ALLIANCE_ALLIED_ADVUNITS);
        }

        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted control of all players.");
      }
      else
      {
        SetPlayerAllianceStateBJ(Player(S2I(parameter)), GetTriggerPlayer(), bj_ALLIANCE_ALLIED_ADVUNITS);
        SetPlayerAllianceStateBJ(GetTriggerPlayer(), Player(S2I(parameter)), bj_ALLIANCE_ALLIED_ADVUNITS);
        DisplayTextToPlayer(p, 0, 0,
          "|cffD27575CHEAT:|r Granted control of player " + GetPlayerName(Player(S2I(parameter))) + ".");
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers())
      {
        TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      }

      TriggerAddAction(trig, Actions);
    }
  }
}