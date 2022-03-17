namespace AzerothWarsCSharp.Source.Main.Libraries
{
  public class Hint{

  
    private const float HINT_INTERVAL = 180;
  


    private static Set all;
    private static Set unread;
    private string msg;

    void display( ){
      DisplayHint(GetLocalPlayer(), msg);
      unread.remove(this);
    }

    static void displayRandom( ){
      if (unread.size > 0){
        thistype(unread[GetRandomInt(0, unread.size-1)]).display();
      }
    }

    thistype (string msg ){

      this.msg = msg;
      all.add(this);
      unread.add(this);
      ;;
    }

    static void onInit( ){
      all = Set.create("Hint all");
      unread = Set.create("Hint unread");
    }



    private static void DisplayRandomHints( ){
      int i = 0;
      while(true){
        if ( i == MAX_PLAYERS){ break; }
        if (GetLocalPlayer() == Player(i)){
          Hint.displayRandom();
        }
        i = i + 1;
      }
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger();
      TriggerRegisterTimerEventPeriodic(trig, HINT_INTERVAL);
      TriggerAddAction(trig,  DisplayRandomHints);
    }

  }
}
