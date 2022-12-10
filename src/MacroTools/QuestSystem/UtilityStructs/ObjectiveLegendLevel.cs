using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
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