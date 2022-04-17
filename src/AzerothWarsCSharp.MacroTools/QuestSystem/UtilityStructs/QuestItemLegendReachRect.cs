using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;

using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemLegendReachRect : QuestItemData
  {
    private readonly TriggerWrapper _entersRect = new();

    private readonly Legend _legend;
    private readonly region _target;
    private readonly rect _targetRect;

    public QuestItemLegendReachRect(Legend legend, Rectangle targetRect, string rectName)
    {
      _targetRect = targetRect.Rect;
      _target = RectToRegion(_targetRect);
      _legend = legend;
      Description = legend.Name + " reaches " + rectName;
      TriggerRegisterEnterRegion(_entersRect.Trigger, _target, null);
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
      if (GetTriggeringRegion() == _target && UnitAlive(_legend.Unit) && GetTriggerUnit() == _legend.Unit)
        Progress = QuestProgress.Complete;
    }
  }
}