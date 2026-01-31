using MacroTools.Legends;
using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

public sealed class ObjectiveLegendLevel : Objective
{
  private readonly int _level;

  private readonly Legend _target;

  public ObjectiveLegendLevel(LegendaryHero target, int level)
  {
    Description = $"{target.Name} is level {level}";
    _target = target;
    _level = level;
    PlayerUnitEvents.Register(HeroTypeEvent.Levels, OnLevel);
  }

  private void OnLevel()
  {
    if (_target.Unit.HeroLevel >= _level)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
