using MacroTools.FactionSystem;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  /// Completed when an eligible player moves a unit into the specified <see cref="Rectangle"/>.
  /// </summary>
  public sealed class ObjectiveAnyUnitInRect : Objective
  {
    private static readonly trigger EntersRectTrig = CreateTrigger();
    private static readonly trigger ExitsRectTrig = CreateTrigger();
    private readonly bool _heroOnly;
    private readonly rect _targetRect;

    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveAnyUnitInRect"/> class.
    /// </summary>
    /// <param name="targetRect">Where the player has to move a unit.</param>
    /// <param name="rectName">A user-friendly name for the area.</param>
    /// <param name="heroOnly">If true, can only be completed with a hero.</param>
    public ObjectiveAnyUnitInRect(Rectangle targetRect, string rectName, bool heroOnly)
    {
      _targetRect = targetRect.Rect;
      if (heroOnly)
        Description = "You have a hero at " + rectName;
      else
        Description = "You have a unit at " + rectName;
      var target = RectToRegion(_targetRect);
      _heroOnly = heroOnly;
      DisplaysPosition = true;
      TriggerRegisterEnterRegion(EntersRectTrig, target, null);
      TriggerRegisterLeaveRegion(ExitsRectTrig, target, null);
      PingPath = "MinimapQuestTurnIn";
    }

    /// <inheritdoc />
    public override Point Position => new(GetRectCenterX(_targetRect), GetRectCenterY(_targetRect));

    /// <summary>
    ///   The <see cref="unit" /> that completed this objective.
    /// </summary>
    public unit? TriggerUnit { get; private set; }

    private static region RectToRegion(rect whichRect)
    {
      var rectRegion = CreateRegion();
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