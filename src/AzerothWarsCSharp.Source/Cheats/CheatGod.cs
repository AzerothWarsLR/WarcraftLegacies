using AzerothWarsCSharp.Source.Libraries;
using static War3Api.Common;
using static War3Api.Blizzard;
using System.Collections.Generic;
using AzerothWarsCSharp.Common.Constants;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A cheat that causes the user's units to deal massive damage and take no damage.
  /// </summary>
  public static class CheatGod
  {
    public static void Initialize()
    {
      //Create cheat
      CheatCommand.Register("god", (player triggerPlayer, string[] arguments) =>
      {
        var toggleArg = arguments[1];
        if (toggleArg == "on")
        {
          _godPlayers.Add(triggerPlayer);
          CheatCommand.Display(triggerPlayer, "God mod activated. Your units will deal 100x damage and take no damage.");
        }
        else if (toggleArg == "off"){
          _godPlayers.Remove(triggerPlayer);
          CheatCommand.Display(triggerPlayer, "God mod deactivated.");
        }
      }
      );
      //Create trigger
      for (int i = 0; i < PlayerConstants.PlayerSlotCount; i++)
      {
        var trig = CreateTrigger();
        TriggerRegisterAnyUnitEventBJ(trig, EVENT_PLAYER_UNIT_DAMAGED);
        TriggerAddAction(trig, OnAnyUnitDamaged);
      }
    }

    private static void OnAnyUnitDamaged()
    {
      if (_godPlayers.Count > 0)
      {
        if (_godPlayers.Contains(GetTriggerPlayer()))
        {
          BlzSetEventDamage(0);
        }
        else if (_godPlayers.Contains(GetOwningPlayer(GetEventDamageSource())))
        {
          BlzSetEventDamage(GetEventDamage() * 100);
        }
      }
    }

    private static HashSet<player> _godPlayers = new ();
  }
}