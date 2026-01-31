using MacroTools.Quests;
using MacroTools.Systems;

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
    var turn = GameTime.ConvertGameTimeToTurn(duration);
    Description = $"Turn {turn} has started";
    _timer = timer.Create();
    _timer.Start(duration, false, OnExpire);
  }
}
