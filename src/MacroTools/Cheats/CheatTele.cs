using System.Collections.Generic;
using MacroTools.CommandSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public sealed class CheatTele : Command
  {
    /// <inheritdoc />
    public override string CommandText => "tele";
    
    /// <inheritdoc />
    public override int ParameterCount => 1;
    
    /// <inheritdoc />
    public override CommandType Type => CommandType.Cheat;
    
    private static readonly Dictionary<player, bool> TeleToggle = new();

    private static void Patrol()
    {
      if (GetIssuedOrderId() == 851990 && TeleToggle[GetTriggerPlayer()])
      {
        SetUnitX(GetTriggerUnit(), GetOrderPointX());
        SetUnitY(GetTriggerUnit(), GetOrderPointY());
      }
    }

    /// <inheritdoc />
    public override string Execute(player cheater, params string[] parameters)
    {
      if (!TestMode.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      string parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));

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
      PlayerUnitEvents.Register(UnitTypeEvent.ReceivesPointOrder, Patrol);
    }
  }
}