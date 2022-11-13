using MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveHeroWithLevelReachRect : Objective
  {
    private readonly TriggerWrapper _entersRect = new();

    private readonly rect _targetRect;
    private readonly int _targetLevel;

    public ObjectiveHeroWithLevelReachRect(int targetLevel, Rectangle targetRect, string rectName)
    {
      _targetRect = targetRect.Rect;
      _targetLevel = targetLevel;
      region target = RectToRegion(_targetRect);
      Description = $"Any hero that is atleast level {targetLevel} reaches {rectName}";
      TriggerRegisterEnterRegion(_entersRect.Trigger, target, null);
      TriggerAddAction(_entersRect.Trigger, OnRegionEnter);
      PingPath = "MinimapQuestTurnIn";
      DisplaysPosition = true;
    }

    public override Point Position => new(GetRectCenterX(_targetRect), GetRectCenterY(_targetRect));

    private static region RectToRegion(rect whichRect)
    {
      region rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    private void OnRegionEnter()
    {
      if (UnitAlive(GetTriggerUnit()) && GetHeroLevel(GetTriggerUnit()) >= _targetLevel)
        Progress = QuestProgress.Complete;
    }
  }
}