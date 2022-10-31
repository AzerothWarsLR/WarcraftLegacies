using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.Wrappers;
using WCSharp.Shared.Data;

using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveLegendInRect : Objective
  {
    private readonly TriggerWrapper _entersRect = new();
    private readonly TriggerWrapper _exitsRect = new();

    private readonly Legend _legend;
    private readonly region _target;
    private readonly rect _targetRect;

    public ObjectiveLegendInRect(Legend legend, Rectangle targetRect, string rectName)
    {
      _targetRect = targetRect.Rect;
      _target = RectToRegion(_targetRect);
      _legend = legend;
      Description = legend.Name + " is at " + rectName;
      TriggerRegisterEnterRegion(_entersRect.Trigger, _target, null);
      TriggerAddAction(_entersRect.Trigger, OnRegionEnter);
      TriggerRegisterLeaveRegion(_exitsRect.Trigger, _target, null);
      TriggerAddAction(_exitsRect.Trigger, OnRegionExit);
      PingPath = "MinimapQuestTurnIn";
      ShowsInQuestLog = true;
      DisplaysPosition = true;
    }

    public override Point Position => new(GetRectCenterX(_targetRect), GetRectCenterY(_targetRect));

    private static region RectToRegion(rect whichRect)
    {
      region rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    private void OnRegionExit()
    {
      if (UnitAlive(_legend.Unit) && IsUnitInRegion(_target, _legend.Unit))
        Progress = QuestProgress.Complete;
      else
        Progress = QuestProgress.Incomplete;
    }

    private void OnRegionEnter()
    {
      if (UnitAlive(_legend.Unit) && GetTriggerUnit() == _legend.Unit) Progress = QuestProgress.Complete;
    }
  }
}