using System;
using MacroTools.Localization;
using MacroTools.UserInterface.Frames;

namespace MacroTools.UserInterface.Voting;

public static class VotePageTimer
{
  private const float PollInterval = 0.5f;
  private const float CountdownHeight = 0.02f;
  private const float CountdownBottomOffset = 0.008f;

  /// <summary>Concludes the vote once everyone has voted or time runs out, showing a countdown along the bottom of <paramref name="root"/>.</summary>
  public static void Start(Frame root, float maxLength, VoteGroup[] groups, Action onConclude)
  {
    var concluded = false;
    var timeLeft = maxLength;
    var countdown = new TextFrame("ArtifactMenuTitle", root, 0)
    {
      Width = root.Width,
      Height = CountdownHeight
    };
    countdown.SetPoint(framepointtype.Bottom, root, framepointtype.Bottom, 0, CountdownBottomOffset);
    countdown.CenterText();
    root.AddFrame(countdown);
    UpdateCountdown(countdown, timeLeft);
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
      timeLeft -= PollInterval;
      UpdateCountdown(countdown, timeLeft);
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

  private static void UpdateCountdown(TextFrame countdown, float timeLeft) =>
    countdown.Text = "|cffaaaaaa" + Loc.Format("Voting closes in {seconds}s",
      ("{seconds}", ((int)Math.Ceiling(Math.Max(0, timeLeft))).ToString())) + "|r";
}
