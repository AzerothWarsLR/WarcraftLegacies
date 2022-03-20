using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatHasResearch{

  
    private const string COMMAND     = "-hasresearch ";
  

    private static integer Char2Id(string c ){
      var i = 0;
      string abc = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
      string t;

      while(true){
        t = SubString(abc,i,i + 1);
        if ( t == null || t == c){ break; }
        i = i + 1;
      }
      if (i < 10){
        return i + 48;
      }
      if (i < 36){
        return i + 65 - 10;
      }
      return i + 97 - 36;
    }

    private static integer S2Raw(string s ){
      return ((Char2Id(SubString(s,0,1)) * 256 + Char2Id(SubString(s,1,2))) * 256 + Char2Id(SubString(s,2,3))) * 256 + Char2Id(SubString(s,3,4));
    }

    private static void CheckResearch(player p, string parameter ){
      int object = S2Raw(parameter);
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Level of research " + GetObjectName(object) + ": " + I2S(GetPlayerTechCount(p, object, true)));
    }

    private static void Actions( ){
      if (!TestSafety.CheatCondition())
      {
        return;
      }
      var i = 0;
      string enteredString = GetEventPlayerChatString();
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      CheckResearch(GetTriggerPlayer(), parameter);
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
