
namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatGod{

  
    private const string COMMAND     = "-god ";
    private bool[] Toggle;
  

    private static void Damage( ){
      if (Toggle[GetPlayerId(GetTriggerPlayer())]){
        BlzSetEventDamage(0);
      }else if (Toggle[GetPlayerId(GetOwningPlayer(GetEventDamageSource()))]){
        BlzSetEventDamage(GetEventDamage() * 100);
      }
    }

    private static void Actions( ){
      if (!TestSafety.CheatCondition())
      {
        return;
      }
      var i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      var pId = GetPlayerId(p);
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (parameter == "on"){
        Toggle[pId] = true;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r God mod activated. Your units will deal 100x damage && take no damage.");
      }else if (parameter == "off"){
        Toggle[pId] = false;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r God mode deactivated.");
      }
    }

    public static void Setup( ){
      trigger trig = CreateTrigger();
      foreach (var player in GetAllPlayers())
      {
        TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      }
      TriggerAddAction(trig, Actions);

      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DAMAGED,  Damage);
    }

  }
}
