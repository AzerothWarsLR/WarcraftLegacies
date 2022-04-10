using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatTele
  {
    private const string COMMAND = "-tele ";
    private static readonly Dictionary<player, bool> TeleToggle = new();

    private static void Patrol()
    {
      if (GetIssuedOrderId() == 851990 && TeleToggle[GetTriggerPlayer()])
      {
        SetUnitX(GetTriggerUnit(), GetOrderPointX());
        SetUnitY(GetTriggerUnit(), GetOrderPointY());
      }
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (parameter == "on")
      {
        TeleToggle[p] = true;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Teleport activated. Use patrol to move instantly.");
      }
      else if (parameter == "off")
      {
        TeleToggle[p] = false;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Teleport deactivated. Patrol works normally.");
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      TriggerAddAction(trig, Actions);
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeReceivesPointOrder, Patrol);
    }
  }
}