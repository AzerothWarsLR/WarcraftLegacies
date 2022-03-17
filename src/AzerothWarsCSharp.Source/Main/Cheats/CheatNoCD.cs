namespace AzerothWarsCSharp.Source.Main.Cheats
{
  public class CheatNocd{

    //**CONFIG
  
    private const string COMMAND     = "-nocd ";
    private boolean[] Toggle;
  
    //*ENDCONFIG

    private static void Spell( ){
      if (Toggle[GetPlayerId(GetTriggerPlayer())]){
        BlzEndUnitAbilityCooldown(GetTriggerUnit(), GetSpellAbilityId());
      }
    }

    private static void Actions( ){
      int i = 0;
      string enteredString = GetEventPlayerChatString();
      player p = GetTriggerPlayer();
      int pId = GetPlayerId(p);
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));

      if (parameter == "on"){
        Toggle[pId] = true;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r No cooldowns activated.");
      }else if (parameter == "off"){
        Toggle[pId] = false;
        DisplayTextToPlayer(p, 0, 0, "|cffD27575CHEAT:|r No cooldowns deactivated.");
      }
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
      TriggerAddAction(trig,  Actions);

      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_ENDCAST,  Spell);
    }

  }
}
