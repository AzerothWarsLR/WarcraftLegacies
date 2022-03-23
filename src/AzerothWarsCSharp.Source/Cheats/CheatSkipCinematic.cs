namespace AzerothWarsCSharp.Source.Cheats
{
  public static class CheatSkipCinematic
  {
    private static void Actions()
    {
      if (!TestSafety.CheatCondition()) return;
      CinematicModeBJ(false, GetPlayersAll());
      DestroyTrigger(GetTriggeringTrigger());
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      var i = 0;
      while (true)
      {
        if (i > bj_MAX_PLAYERS) break;
        TriggerRegisterPlayerEventEndCinematic(trig, Player(i));
        i += 1;
      }

      TriggerAddAction(trig, Actions);
    }
  }
}