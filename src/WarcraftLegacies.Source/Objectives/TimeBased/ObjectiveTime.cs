using MacroTools.GameTime;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.TimeBased;

public sealed class ObjectiveTime : Objective
{
  private readonly timer _timer;

  private void OnExpire()
  {
    _timer.Dispose();
    Progress = QuestProgress.Complete;
  }

  public ObjectiveTime(int duration)
  {
    var turn = GameTimeManager.ConvertGameTimeToTurn(duration);
    Description = $"Turn {turn} has started";
    _timer = timer.Create();
    _timer.Start(duration, false, OnExpire);
  }
}
