using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class ObjectiveAnyUnitInRect : Objective
  {
    private static readonly trigger EntersRectTrig = CreateTrigger();
    private static readonly trigger ExitsRectTrig = CreateTrigger();
    private readonly bool _heroOnly;
    private readonly rect _targetRect;

    public ObjectiveAnyUnitInRect(Rectangle targetRect, string rectName, bool heroOnly)
    {
      _targetRect = targetRect.Rect;
      if (heroOnly)
        Description = "You have a hero at " + rectName;
      else
        Description = "You have a unit at " + rectName;
      region target = RectToRegion(_targetRect);
      _heroOnly = heroOnly;
      DisplaysPosition = true;
      TriggerRegisterEnterRegion(EntersRectTrig, target, null);
      TriggerRegisterLeaveRegion(ExitsRectTrig, target, null);
      PingPath = "MinimapQuestTurnIn";
    }

    public override Point Position => new(GetRectCenterX(_targetRect), GetRectCenterY(_targetRect));

    /// <summary>
    ///   The <see cref="unit" /> that completed this objective.
    /// </summary>
    public unit? TriggerUnit { get; private set; }

    private static region RectToRegion(rect whichRect)
    {
      region rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    private bool IsValidUnitInRect()
    {
      foreach (var unit in new GroupWrapper().EnumUnitsInRect(_targetRect).EmptyToList())
        if (EligibleFactions.Contains(GetOwningPlayer(unit)) && UnitAlive(unit) &&
            (IsUnitType(unit, UNIT_TYPE_HERO) || !_heroOnly))
          return true;
      return false;
    }

    private void OnRegionEnter()
    {
      var triggerUnit = GetTriggerUnit();
      if (EligibleFactions.Contains(GetOwningPlayer(triggerUnit)) && UnitAlive(triggerUnit) &&
        (IsUnitType(triggerUnit, UNIT_TYPE_HERO) || !_heroOnly) || IsValidUnitInRect())
      {
        TriggerUnit = triggerUnit;
        Progress = QuestProgress.Complete;
      }
      else
      {
        Progress = QuestProgress.Incomplete;
      }
    }

    private void OnRegionExit()
    {
      Progress = IsValidUnitInRect() ? QuestProgress.Complete : QuestProgress.Incomplete;
    }

    internal override void OnAdd(Faction whichFaction)
    {
      Progress = IsValidUnitInRect() ? QuestProgress.Complete : QuestProgress.Incomplete;
      TriggerAddAction(EntersRectTrig, OnRegionEnter);
      TriggerAddAction(ExitsRectTrig, OnRegionExit);
    }
  }
}