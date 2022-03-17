namespace AzerothWarsCSharp.Source.RoC.Cinematics
{
  public class AllowCinematicSkip{

    private static void OnInit( ){
      TriggerSleepAction(0) ;//Just to make it load after GUI
      if (AreCheatsActive){
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "|cffD27575CHEAT:|r CinematicSkip enabled.");
      }else {
        bj_cineSceneBeingSkipped = CreateTrigger();
      }
    }

  }
}
