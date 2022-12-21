using MacroTools.QuestSystem;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives
{
  public sealed class ObjectiveTimeRandom : Objective
  {
    private readonly timer _timer;

    public ObjectiveTimeRandom(int minDuration, int maxDuration)
    {
      Description = $"Somewhere between {minDuration} and {maxDuration} seconds have elapsed";
      _timer = CreateTimer();
      TimerStart(_timer, GetRandomInt(minDuration, maxDuration), false, OnExpire);
    }

    private void OnExpire()
    {
      DestroyTimer(_timer);
      Progress = QuestProgress.Complete;
    }
  }
}