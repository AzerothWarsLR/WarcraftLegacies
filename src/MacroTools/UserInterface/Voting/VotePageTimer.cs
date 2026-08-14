using System;

namespace MacroTools.UserInterface.Voting;

public static class VotePageTimer
{
  private const float PollInterval = 0.5f;

  public static void Start(float maxLength, VoteGroup[] groups, Action onConclude)
  {
    var concluded = false;
    var mainTimer = timer.Create();
    var pollTimer = timer.Create();

    void ConcludeOnce()
    {
      if (concluded)
      {
        return;
      }

      concluded = true;
      mainTimer.Dispose();
      pollTimer.Dispose();
      onConclude();
    }

    mainTimer.Start(maxLength, false, ConcludeOnce);
    pollTimer.Start(PollInterval, true, () =>
    {
      foreach (var group in groups)
      {
        if (!group.AllPlayersVoted())
        {
          return;
        }
      }

      ConcludeOnce();
    });
  }
}
