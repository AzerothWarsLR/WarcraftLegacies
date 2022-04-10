using WCSharp.Events;

using static War3Api.Common;
using static AzerothWarsCSharp.MacroTools.GeneralHelpers;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatGod
  {
    private const string COMMAND = "-god ";
    private static bool[] _toggle;


    private static void Damage()
    {
      if (_toggle[GetPlayerId(GetTriggerPlayer())])
        BlzSetEventDamage(0);
      else if (_toggle[GetPlayerId(GetOwningPlayer(GetEventDamageSource()))]) BlzSetEventDamage(GetEventDamage() * 100);
    }

    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;

      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      var pId = GetPlayerId(p);
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      switch (parameter)
      {
        case "on":
          _toggle[pId] = true;
          DisplayTextToPlayer(p, 0, 0,
            "|cffD27575CHEAT:|r God mod activated. Your units will deal 100x damage && take no damage.");
          break;
        case "off":
          _toggle[pId] = false;
          DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r God mode deactivated.");
          break;
      }
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers()) TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);

      TriggerAddAction(trig, Actions);

      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeIsDamaged, Damage);
    }
  }
}