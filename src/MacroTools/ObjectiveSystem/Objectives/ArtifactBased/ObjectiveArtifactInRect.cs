using System;
using MacroTools.QuestSystem;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;


namespace MacroTools.ObjectiveSystem.Objectives.ArtifactBased;

public sealed class ObjectiveArtifactInRect : Objective
{
  private readonly TriggerWrapper _entersRect = new();
  private readonly TriggerWrapper _exitsRect = new();

  private readonly ArtifactSystem.Artifact _targetArtifact;
  private readonly Rectangle _targetRect;

  public ObjectiveArtifactInRect(ArtifactSystem.Artifact targetArtifact, Rectangle targetRect, string rectName)
  {
    _targetArtifact = targetArtifact;
    _targetRect = targetRect;
    var targetRegion = RectToRegion(_targetRect.Rect);
    Description = "Bring " + targetArtifact.Item.Name + " to " + rectName;

    _entersRect.Trigger.RegisterEnterRegion(targetRegion);
    _entersRect.Trigger.AddAction(OnRegionEnter);
    _exitsRect.Trigger.RegisterLeaveRegion(targetRegion);
    _exitsRect.Trigger.AddAction(OnRegionExit);

    DisplaysPosition = true;
    Position = new(_targetRect.Center.X, _targetRect.Center.Y);
  }

  private static region RectToRegion(rect whichRect)
  {
    var rectRegion = region.Create();
    rectRegion.AddRect(whichRect);
    return rectRegion;
  }

  private bool IsArtifactInRect()
  {
    if (_targetArtifact.OwningUnit != null &&
        _targetRect.Contains(_targetArtifact.OwningUnit.X, _targetArtifact.OwningUnit.Y))
    {
      return true;
    }

    if (_targetArtifact.OwningUnit == null &&
        _targetRect.Contains(_targetArtifact.Item.X, _targetArtifact.Item.Y))
    {
      return true;
    }

    return false;
  }

  private void OnRegionEnter()
  {
    try
    {
      Progress = _targetArtifact.OwningUnit == @event.EnteringUnit ? QuestProgress.Complete : QuestProgress.Incomplete;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }

  private void OnRegionExit()
  {
    try
    {
      Progress = IsArtifactInRect() ? QuestProgress.Complete : QuestProgress.Incomplete;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex);
    }
  }
}
