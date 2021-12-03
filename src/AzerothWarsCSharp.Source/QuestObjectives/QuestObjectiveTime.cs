using System;
using AzerothWarsCSharp.MacroTools;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.QuestObjectives
{
  public class QuestObjectiveTime : QuestObjective
  {
    private readonly timer _timer;

    private void OnTimerExpired()
    {
      Progress = QuestProgress.Complete;
    }
    
    public QuestObjectiveTime(int duration)
    {
      Description = $"{duration} seconds have elapsed";
      _timer = CreateTimer();
      TimerStart(_timer, duration, false, OnTimerExpired);
    }

    ~QuestObjectiveTime()
    {
      DestroyTimer(_timer);
    }
  }
}