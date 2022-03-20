
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatVision{

    //**CONFIG
  
    private const string COMMAND     = "-vision ";
    private fogmodifier[] fogs;
  
    //*ENDCONFIG

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
        fogs[pId] = CreateFogModifierRectBJ( true, p, FOG_OF_WAR_VISIBLE, GetPlayableMapRect() );
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Whole map revealed.");
      }else if (parameter == "off"){
        DestroyFogModifier(fogs[pId]);
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Whole map unrevealed.");
      }
    }

    public static void Setup( ){
      trigger trig = CreateTrigger();
      foreach (var player in GeneralHelpers.GetAllPlayers())
      {
        TriggerRegisterPlayerChatEvent(trig, player, COMMAND, false);
      }
      TriggerAddAction(trig, Actions);
    }

  }
}
