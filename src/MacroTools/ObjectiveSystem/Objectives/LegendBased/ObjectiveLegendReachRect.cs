using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;

namespace MacroTools.ObjectiveSystem.Objectives.LegendBased;

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
    _entersRect.Trigger.RegisterEnterRegion(_target, null);
    _entersRect.Trigger.AddAction(OnRegionEnter);
    PingPath = "MinimapQuestTurnIn";
    DisplaysPosition = true;
    Position = new(_targetRect.CenterX, _targetRect.CenterY);
  }

  private static region RectToRegion(rect whichRect)
  {
    var rectRegion = region.Create();
    rectRegion.AddRect(whichRect);
    return rectRegion;
  }

  private void OnRegionEnter()
  {
    if (@event.Region == _target && _legend.Unit.Alive && @event.Unit == _legend.Unit)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
