public class CheatSkipCinematic{

    private static void Actions( ){
      CinematicModeBJ(false, GetPlayersAll());
      DestroyTrigger(GetTriggeringTrigger());
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger(  );
      int i = 0;
      while(true){
      if ( i > MAX_PLAYERS){ break; }
        TriggerRegisterPlayerEventEndCinematic(trig, Player(i));
        i = i + 1;
      }
      TriggerAddCondition(trig, ( CheatCondition));
      TriggerAddAction( trig,  Actions );
    }

}
