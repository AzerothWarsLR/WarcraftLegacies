using System;
using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.Cheats
{
  public static class CheatGod
  {
    private const string Command = "-god ";
    private static readonly List<player> PlayersWithCheat = new();

    private static bool IsCheatActive(player whichPlayer)
    {
      return PlayersWithCheat.Contains(whichPlayer);
    }

    private static void SetCheatActive(player whichPlayer, bool isActive)
    {
      if (isActive && !PlayersWithCheat.Contains(whichPlayer))
      {
        PlayersWithCheat.Add(whichPlayer);
        return;
      }

      if (!isActive && PlayersWithCheat.Contains(whichPlayer)) PlayersWithCheat.Remove(whichPlayer);
    }

    private static void Damage()
    {
      try
      {
        if (IsCheatActive(GetTriggerPlayer()))
          BlzSetEventDamage(0);
        else if (IsCheatActive(GetOwningPlayer(GetEventDamageSource())))
          BlzSetEventDamage(GetEventDamage() * 100);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
      }
    }

    private static void Actions()
    {
      if (!TestMode.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player triggerPlayer = GetTriggerPlayer();
      string parameter = SubString(enteredString, StringLength(Command), StringLength(enteredString));

      if (parameter == "on")
      {
        SetCheatActive(triggerPlayer, true);
        DisplayTextToPlayer(triggerPlayer, 0, 0,
          "|cffD27575CHEAT:|r God mod activated. Your units will deal 100x damage and take no damage.");
      }
      else if (parameter == "off")
      {
        SetCheatActive(triggerPlayer, true);
        DisplayTextToPlayer(triggerPlayer, 0, 0, "|cffD27575CHEAT:|r God mode deactivated.");
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers()) TriggerRegisterPlayerChatEvent(trig, player, Command, false);

      TriggerAddAction(trig, Actions);

      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeIsDamaged, Damage);
    }
  }
}