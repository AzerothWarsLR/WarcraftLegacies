//using AzerothWarsCSharp.Common.Constants;
//using AzerothWarsCSharp.Source.Libraries;
//using System.Collections.Generic;
//using WCSharp.Events;
//using static War3Api.Common;

//namespace AzerothWarsCSharp.Source.Commands
//{
//  /// <summary>
//  /// A cheat that causes the player's spells to have their cooldown reset on cast.
//  /// </summary>
//  public static class CheatNoCD
//  {
//    public static void Initialize()
//    {
//      //Create cheat
//      CheatCommand.Register("nocd", (player triggerPlayer, string[] arguments) =>
//      {
//        var toggleArg = arguments[1];
//        if (toggleArg == "on")
//        {
//          _enabledPlayers.Add(triggerPlayer);
//          CheatCommand.Display(triggerPlayer, "No cooldowns activated.");
//        }
//        else if (toggleArg == "off")
//        {
//          _enabledPlayers.Remove(triggerPlayer);
//          CheatCommand.Display(triggerPlayer, "No cooldowns deactivated.");
//        }
//      }
//      );
//      //Create trigger
//      for (int i = 0; i < PlayerConstants.PlayerSlotCount; i++)
//      {
//        PlayerUnitEvents.Register(PlayerUnitEvent.SpellFinish, OnAnyUnitFinishesSpell);
//      }
//    }

//    private static void OnAnyUnitFinishesSpell()
//    {
//      if (_enabledPlayers.Count > 0)
//      {
//        if (_enabledPlayers.Contains(GetOwningPlayer(GetTriggerUnit())))
//        {
//          BlzEndUnitAbilityCooldown(GetTriggerUnit(), GetSpellAbilityId());
//        }
//      }
//    }

//    private static readonly HashSet<player> _enabledPlayers = new();
//  }
//}