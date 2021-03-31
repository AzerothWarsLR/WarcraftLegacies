using AzerothWarsCSharp.Common.Constants;
using AzerothWarsCSharp.Source.Libraries;
using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Commands
{
  /// <summary>
  /// A cheat that causes the player's units to be fully refunded in mana whenever they cast a spell.
  /// </summary>
  public static class CheatUnlimitedMana
  {
    public static void Initialize()
    {
      //Create cheat
      CheatCommand.Register("infinitemana", (player triggerPlayer, string[] arguments) =>
      {
        var toggleArg = arguments[1];
        if (toggleArg == "on")
        {
          _enabledPlayers.Add(triggerPlayer);
          CheatCommand.Display(triggerPlayer, "Infinite mana activated.");
        }
        else if (toggleArg == "off")
        {
          _enabledPlayers.Remove(triggerPlayer);
          CheatCommand.Display(triggerPlayer, "Infinite mana deactivated.");
        }
      }
      );
      //Create trigger
      for (int i = 0; i < PlayerConstants.PlayerSlotCount; i++)
      {
        PlayerUnitEvents.Register(PlayerUnitEvent.SpellFinish, OnAnyUnitFinishesSpell);
      }
    }

    private static void OnAnyUnitFinishesSpell()
    {
      if (_enabledPlayers.Count > 0)
      {
        if (_enabledPlayers.Contains(GetOwningPlayer(GetTriggerUnit())))
        {
          SetUnitState(GetTriggerUnit(), UNIT_STATE_MANA, GetUnitState(GetTriggerUnit(), UNIT_STATE_MAX_MANA));
        }
      }
    }

    private static readonly HashSet<player> _enabledPlayers = new();
  }
}