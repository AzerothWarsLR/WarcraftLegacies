using MacroTools.QuestSystem;
using static War3Api.Common;

namespace MacroTools.ObjectiveSystem.Objectives.TimeBased
{
  /// <summary>
  ///   Starts completed, then fails when the specified amount of time has elapsed.
  /// </summary>
  public sealed class ObjectiveExpire : Objective
  {
    private readonly timer _timer;

    public ObjectiveExpire(int duration)
    {
      Description = $"Complete this quest before {duration} seconds have elapsed";
      _timer = CreateTimer();
      TimerStart(_timer, duration, false, OnExpire);
    }

    internal override void OnAdd(FactionSystem.Faction whichFaction)
    {
      Progress = QuestProgress.Complete;
    }

    private void OnExpire()
    {
      DestroyTimer(_timer);
      Progress = QuestProgress.Failed;
    }
  }
}