using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>Completed while a channel has been going for at least a number of seconds.</summary>
public sealed class ObjectiveChannelTime : Objective
{
  private readonly float _seconds;
  private timer? _timer;

  public ObjectiveChannelTime(ObjectiveChannelRect channel, float seconds, string description)
  {
    _seconds = seconds;
    SetDescription(description);
    channel.ChannelStarted += OnChannelStarted;
    channel.ChannelEnded += OnChannelEnded;
  }

  private void OnChannelStarted()
  {
    StopTimer();
    _timer = timer.Create();
    _timer.Start(_seconds, false, () =>
    {
      StopTimer();
      Progress = QuestProgress.Complete;
    });
  }

  private void OnChannelEnded()
  {
    StopTimer();
    Progress = QuestProgress.Incomplete;
  }

  private void StopTimer()
  {
    if (_timer == null)
    {
      return;
    }

    _timer.Dispose();
    _timer = null;
  }
}
