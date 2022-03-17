//Displays each Faction)s starting quest after the cinematic phase ends
public class StartingQuestPopup{

  private static void Actions( ){
    int i = 0;
    Person loopPerson;
    while(true){
    if ( i > MAX_PLAYERS){ break; }
      loopPerson = Person.ById(i);
      if (loopPerson.Faction.StartingQuest != 0){
        if (GetLocalPlayer() == loopPerson.Player){
          loopPerson.Faction.StartingQuest.DisplayDiscovered();
        }
      }
      i = i + 1;
    }
  }

  private static void OnInit( ){
    trigger trig = CreateTrigger();
    TriggerRegisterTimerEvent(trig, 63, false);
    TriggerAddCondition(trig, ( Actions));
  }

}
