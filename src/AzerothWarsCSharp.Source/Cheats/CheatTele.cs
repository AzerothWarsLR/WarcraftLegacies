//using AzerothWarsCSharp.Common.Constants;
//using AzerothWarsCSharp.Source.Libraries;
//using System.Collections.Generic;
//using WCSharp.Events;
//using static War3Api.Common;

//namespace AzerothWarsCSharp.Source.Commands
//{
//  /// <summary>
//  /// A cheat that causes the player's units to be teleported whenever they are given the patrol order.
//  /// </summary>
//  public static class CheatTele
//  {
//    public static void Initialize()
//    {
//      //Create cheat
//      CheatCommand.Register("tele", (player triggerPlayer, string[] arguments) =>
//      {
//        var toggleArg = arguments[1];
//        if (toggleArg == "on")
//        {
//          _enabledPlayers.Add(triggerPlayer);
//          CheatCommand.Display(triggerPlayer, "Teleport-on-patrol activated.");
//        }
//        else if (toggleArg == "off")
//        {
//          _enabledPlayers.Remove(triggerPlayer);
//          CheatCommand.Display(triggerPlayer, "Teleport-on-patrol deactivated.");
//        }
//      }
//      );
//      //Create trigger
//      for (int i = 0; i < PlayerConstants.PlayerSlotCount; i++)
//      {
//        PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeReceivesPointOrder, OnAnyUnitIssuedPointOrder);
//      }
//    }

//    private static void OnAnyUnitIssuedPointOrder()
//    {
//      if (_enabledPlayers.Count > 0)
//      {
//        if (_enabledPlayers.Contains(GetOwningPlayer(GetTriggerUnit())) && GetIssuedOrderId() == 851990)
//        {
//          SetUnitX(GetTriggerUnit(), GetOrderPointX());
//          SetUnitY(GetTriggerUnit(), GetOrderPointY());
//        }
//      }
//    }

//    private static readonly HashSet<player> _enabledPlayers = new();
//  }
//}