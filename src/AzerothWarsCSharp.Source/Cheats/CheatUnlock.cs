
using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Cheats
{
  public class CheatUnlock{

  
    private const string COMMAND     = "-unlock";
    private const int UPGRADE_A = FourCC(R04I);
    private const int UPGRADE_B = FourCC(R04J);
    private const int UPGRADE_C = FourCC(R04N);
    private const int UPGRADE_D = FourCC(R009);
  

    private static void UnlockUpgrade(player p, int i ){
      DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r Granted research " + GetObjectName(i) + ".");
      SetPlayerTechResearched(p, i, 1);
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

      UnlockUpgrade(p, UPGRADE_A);
      UnlockUpgrade(p, UPGRADE_B);
      UnlockUpgrade(p, UPGRADE_C);
      UnlockUpgrade(p, UPGRADE_D);
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
