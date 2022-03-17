
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
    int i = 0;
    string enteredString = GetEventPlayerChatString();
    player p = GetTriggerPlayer();
    int pId = GetPlayerId(p);
    string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

    UnlockUpgrade(p, UPGRADE_A);
    UnlockUpgrade(p, UPGRADE_B);
    UnlockUpgrade(p, UPGRADE_C);
    UnlockUpgrade(p, UPGRADE_D);
  }

  private static void OnInit( ){
    trigger trig = CreateTrigger(  );
    int i = 0;
    while(true){
    if ( i > MAX_PLAYERS){ break; }
      TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, false );
      i = i + 1;
    }
    TriggerAddCondition(trig, ( CheatCondition));
    TriggerAddAction( trig,  Actions );
  }

}
