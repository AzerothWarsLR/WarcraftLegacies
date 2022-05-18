using System;
using AzerothWarsCSharp.MacroTools.ArtifactSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class QuestItemArtifactInRect : QuestItemData
  {
    private readonly TriggerWrapper _entersRect = new();
    private readonly TriggerWrapper _exitsRect = new();

    private readonly Artifact _targetArtifact;
    private readonly rect _targetRect;

    public QuestItemArtifactInRect(Artifact targetArtifact, Rectangle targetRect, string rectName)
    {
      _targetArtifact = targetArtifact;
      _targetRect = targetRect.Rect;
      region targetRegion = RectToRegion(_targetRect);
      Description = "Bring " + GetItemName(targetArtifact.Item) + " to " + rectName;

      TriggerRegisterEnterRegion(_entersRect.Trigger, targetRegion, null);
      TriggerAddAction(_entersRect.Trigger, OnRegionEnter);
      TriggerRegisterLeaveRegion(_exitsRect.Trigger, targetRegion, null);
      TriggerAddAction(_exitsRect.Trigger, OnRegionExit);

      DisplaysPosition = true;
    }

    public override Point Position => new(GetRectCenterX(_targetRect), GetRectCenterY(_targetRect));

    private static region RectToRegion(rect whichRect)
    {
      region rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    private bool IsArtifactInRect()
    {
      if (_targetArtifact.OwningUnit != null && RectContainsCoords(_targetRect, GetUnitX(_targetArtifact.OwningUnit),
        GetUnitY(_targetArtifact.OwningUnit)))
        return true;

      if (_targetArtifact.OwningUnit == null &&
          RectContainsCoords(_targetRect, GetItemX(_targetArtifact.Item), GetItemY(_targetArtifact.Item)))
        return true;

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