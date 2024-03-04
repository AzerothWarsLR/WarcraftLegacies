using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;


namespace MacroTools.ObjectiveSystem.Objectives.LegendBased
{
  public sealed class ObjectiveLegendInRect : Objective
  {
    private readonly TriggerWrapper _entersRect = new();
    private readonly TriggerWrapper _exitsRect = new();

    private readonly Legend _legendaryHero;
    private readonly region _target;
    private readonly rect _targetRect;

    public ObjectiveLegendInRect(LegendaryHero legendaryHero, Rectangle targetRect, string rectName)
    {
      _targetRect = targetRect.Rect;
      _target = RectToRegion(_targetRect);
      _legendaryHero = legendaryHero;
      Description = $"{legendaryHero.Name} is at {rectName}";
      TriggerRegisterEnterRegion(_entersRect.Trigger, _target, null);
      TriggerAddAction(_entersRect.Trigger, OnRegionEnter);
      TriggerRegisterLeaveRegion(_exitsRect.Trigger, _target, null);
      TriggerAddAction(_exitsRect.Trigger, OnRegionExit);
      PingPath = "MinimapQuestTurnIn";
      ShowsInQuestLog = true;
      DisplaysPosition = true;
      Position = new(GetRectCenterX(_targetRect), GetRectCenterY(_targetRect));
    }

    private static region RectToRegion(rect whichRect)
    {
      var rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    private void OnRegionExit()
    {
      if (UnitAlive(_legendaryHero.Unit) && IsUnitInRegion(_target, _legendaryHero.Unit))
        Progress = QuestProgress.Complete;
      else
        Progress = QuestProgress.Incomplete;
    }

    private void OnRegionEnter()
    {
      if (UnitAlive(_legendaryHero.Unit) && GetTriggerUnit() == _legendaryHero.Unit) Progress = QuestProgress.Complete;
    }
  }
}