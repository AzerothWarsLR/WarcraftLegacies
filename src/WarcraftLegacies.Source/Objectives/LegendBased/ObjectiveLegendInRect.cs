using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

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
    _entersRect.Trigger.RegisterEnterRegion(_target);
    _entersRect.Trigger.AddAction(OnRegionEnter);
    _exitsRect.Trigger.RegisterLeaveRegion(_target);
    _exitsRect.Trigger.AddAction(OnRegionExit);
    PingPath = "MinimapQuestTurnIn";
    ShowsInQuestLog = true;
    DisplaysPosition = true;
    Position = new(_targetRect.CenterX, _targetRect.CenterY);
  }

  private static region RectToRegion(rect whichRect)
  {
    var rectRegion = region.Create();
    rectRegion.AddRect(whichRect);
    return rectRegion;
  }

  private void OnRegionExit()
  {
    if (_legendaryHero.Unit.Alive && _target.Contains(_legendaryHero.Unit))
    {
      Progress = QuestProgress.Complete;
    }
    else
    {
      Progress = QuestProgress.Incomplete;
    }
  }

  private void OnRegionEnter()
  {
    if (_legendaryHero.Unit.Alive && @event.Unit == _legendaryHero.Unit)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
