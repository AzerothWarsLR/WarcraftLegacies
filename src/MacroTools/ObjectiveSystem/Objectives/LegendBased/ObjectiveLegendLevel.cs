using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using WCSharp.Events;


namespace MacroTools.ObjectiveSystem.Objectives.LegendBased
{
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
      if (GetHeroLevel(_target.Unit) >= _level) Progress = QuestProgress.Complete;
    }
  }
}