using System.Collections.Generic;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Cheats
{
  public static class CheatNocd
  {
    private const string COMMAND = "-nocd ";
    private static readonly Dictionary<player, bool> Toggle = new();

    private static void Spell()
    {
      if (Toggle[GetTriggerPlayer()]) BlzEndUnitAbilityCooldown(GetTriggerUnit(), GetSpellAbilityId());
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      switch (parameter)
      {
        case "on":
          Toggle[p] = true;
          DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r No cooldowns activated.");
          break;
        case "off":
          Toggle[p] = false;
          DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r No cooldowns deactivated.");
          break;
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