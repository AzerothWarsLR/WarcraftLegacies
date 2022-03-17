public class ObserverCommand{

  //**CONFIG
  
      private const string COMMAND     = "-obs";
  
  //*ENDCONFIG

  private static void Actions( ){
    Person triggerPerson = Person.ByHandle(GetTriggerPlayer());
    group tempGroup = CreateGroup();
    fogmodifier = ObsFogModifier;

    if (triggerPerson != 0){
      triggerPerson.Faction.ScoreStatus = SCORESTATUS_DEFEATED;
      ObsFogModifier = CreateFogModifierRect(GetTriggerPlayer(), FOG_OF_WAR_VISIBLE, GetPlayableMapRect(), false, false);
      FogModifierStart(ObsFogModifier);
    }
  }

  private static void OnInit( ){
    trigger trig = CreateTrigger(  );
    int i = 0;

    while(true){
    if ( i > MAX_PLAYERS){ break; }
      TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND, true );
      i = i + 1;
    }

    TriggerAddCondition( trig, ( Actions) );
  }

}
