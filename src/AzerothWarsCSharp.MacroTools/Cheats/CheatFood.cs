using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatFood
  {
    private const string COMMAND = "-food ";


    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();

      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      p.AdjustPlayerState(PLAYER_STATE_RESOURCE_FOOD_CAP, S2I(parameter));
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted " + parameter + " food.");
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      TriggerAddAction(trig, Actions);
    }
  }
}