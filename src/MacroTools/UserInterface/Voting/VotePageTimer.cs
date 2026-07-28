using System;

namespace MacroTools.UserInterface.Voting;

/// <summary>
/// Concludes a vote page - one or more <see cref="VoteGroup"/>s shown together - either once every group on it
/// has a vote from every active player, or once <paramref name="maxLength"/> seconds pass, whichever happens
/// first. Saves a lobby that's already finished voting from having to sit through the rest of an idle timer.
/// </summary>
public static class VotePageTimer
{
  private const float PollInterval = 0.5f;

  /// <summary>
  /// Starts the timer(s). Calls <paramref name="onConclude"/> exactly once.
  /// </summary>
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
