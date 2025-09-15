using System;
using MacroTools.QuestSystem;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;


namespace MacroTools.ObjectiveSystem.Objectives.ArtifactBased
{
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
      Description = "Bring " + GetItemName(targetArtifact.Item) + " to " + rectName;

      TriggerRegisterEnterRegion(_entersRect.Trigger, targetRegion, null);
      TriggerAddAction(_entersRect.Trigger, OnRegionEnter);
      TriggerRegisterLeaveRegion(_exitsRect.Trigger, targetRegion, null);
      TriggerAddAction(_exitsRect.Trigger, OnRegionExit);

      DisplaysPosition = true;
      Position = new(_targetRect.Center.X, _targetRect.Center.Y);
    }

    private static region RectToRegion(rect whichRect)
    {
      var rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    private bool IsArtifactInRect()
    {
      if (_targetArtifact.OwningUnit != null &&
          _targetRect.Contains(GetUnitX(_targetArtifact.OwningUnit), GetUnitY(_targetArtifact.OwningUnit)))
      {
        return true;
      }

      if (_targetArtifact.OwningUnit == null &&
          _targetRect.Contains(GetItemX(_targetArtifact.Item), GetItemY(_targetArtifact.Item)))
      {
        return true;
      }

      return false;
    }

    private void OnRegionEnter()
    {
      try
      {
        Progress = _targetArtifact.OwningUnit == GetEnteringUnit() ? QuestProgress.Complete : QuestProgress.Incomplete;
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
}