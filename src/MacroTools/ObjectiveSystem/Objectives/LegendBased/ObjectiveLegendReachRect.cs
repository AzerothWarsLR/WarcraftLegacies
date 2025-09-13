using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;

namespace MacroTools.ObjectiveSystem.Objectives.LegendBased
{
  public sealed class ObjectiveLegendReachRect : Objective
  {
    private readonly TriggerWrapper _entersRect = new();

    private readonly Legend _legend;
    private readonly region _target;
    private readonly rect _targetRect;

    public ObjectiveLegendReachRect(LegendaryHero legendaryHero, Rectangle targetRect, string rectName)
    {
      _targetRect = targetRect.Rect;
      _target = RectToRegion(_targetRect);
      _legend = legendaryHero;
      Description = legendaryHero.Name + " reaches " + rectName;
      TriggerRegisterEnterRegion(_entersRect.Trigger, _target, null);
      TriggerAddAction(_entersRect.Trigger, OnRegionEnter);
      PingPath = "MinimapQuestTurnIn";
      DisplaysPosition = true;
      Position = new(GetRectCenterX(_targetRect), GetRectCenterY(_targetRect));
    }

    private static region RectToRegion(rect whichRect)
    {
      var rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    private void OnRegionEnter()
    {
      if (GetTriggeringRegion() == _target && UnitAlive(_legend.Unit) && GetTriggerUnit() == _legend.Unit)
        Progress = QuestProgress.Complete;
    }
  }
}