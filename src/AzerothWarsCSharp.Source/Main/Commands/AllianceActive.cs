namespace AzerothWarsCSharp.Source.Main.Commands
{
  public class AllianceActive{

    private static void Actions( ){
      int victoryCpCount;

      if (AreAllianceActive == true){
        SetCpsVictory(120);
      }
    }

    private static void OnInit( ){
      trigger trig = CreateTrigger(  );
      TriggerRegisterTimerEventSingle( trig, 8000 );
      TriggerAddAction( trig,  Actions );
    }

  }
}
