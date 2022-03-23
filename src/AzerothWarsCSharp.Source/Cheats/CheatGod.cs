using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatGod
  {
    private const string COMMAND = "-god ";
    private static bool[] Toggle;


    private static void Damage()
    {
      if (Toggle[GetPlayerId(GetTriggerPlayer())])
        BlzSetEventDamage(0);
      else if (Toggle[GetPlayerId(GetOwningPlayer(GetEventDamageSource()))]) BlzSetEventDamage(GetEventDamage() * 100);
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
          Toggle[pId] = true;
          DisplayTextToPlayer(p, 0, 0,
            "|cffD27575CHEAT:|r God mod activated. Your units will deal 100x damage && take no damage.");
          break;
        case "off":
          Toggle[pId] = false;
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