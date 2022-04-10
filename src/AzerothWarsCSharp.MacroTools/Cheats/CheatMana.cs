using System.Collections.Generic;
using WCSharp.Events;
using static War3Api.Common; using static War3Api.Blizzard; using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.Cheats
{
  public static class CheatMana
  {
    private const string COMMAND = "-mana ";
    private static readonly Dictionary<player, bool> Toggle = new();

    private static void Spell()
    {
      if (Toggle[GetTriggerPlayer()]) SetUnitManaPercentBJ(GetTriggerUnit(), 100);
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (parameter == "on")
      {
        Toggle[p] = true;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Infinite mana activated.");
      }
      else if (parameter == "off")
      {
        Toggle[p] = false;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Infinite mana deactivated.");
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      TriggerAddAction(trig, Actions);

      PlayerUnitEvents.Register(PlayerUnitEvent.SpellEndCast, Spell);
    }
  }
}