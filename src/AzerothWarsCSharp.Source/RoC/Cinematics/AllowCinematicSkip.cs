using AzerothWarsCSharp.Source.Main.Cheats;

namespace AzerothWarsCSharp.Source.RoC.Cinematics
{
  public class AllowCinematicSkip
  {
    public static void Setup()
    {
      TriggerSleepAction(0); //Just to make it load after GUI
      if (TestSafety.AreCheatsActive)
      {
        DisplayTextToPlayer(GetLocalPlayer(), 0, 0, "|cffD27575CHEAT:|r CinematicSkip enabled.");
      }
      else
      {
        bj_cineSceneBeingSkipped = CreateTrigger();
      }
    }
  }
}