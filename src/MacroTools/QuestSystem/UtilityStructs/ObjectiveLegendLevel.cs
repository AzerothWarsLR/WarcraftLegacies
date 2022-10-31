using MacroTools.FactionSystem;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveLegendLevel : Objective
  {
    private readonly int _level;

    private readonly Legend _target;

    public ObjectiveLegendLevel(Legend target, int level)
    {
      Description = target.Name + " is level " + I2S(level);
      _target = target;
      _level = level;
      PlayerUnitEvents.Register(PlayerUnitEvent.HeroTypeLevels, OnLevel);
    }

    private void OnLevel()
    {
      if (GetHeroLevel(_target.Unit) >= _level) Progress = QuestProgress.Complete;
    }
  }
}