namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemAnyUnitInRect : QuestItemData
  {
    private static trigger entersRectTrig = CreateTrigger();
    private static trigger exitsRectTrig = CreateTrigger();
    private static int count = 0;
    private static thistype[] byIndex;
    private static group tempGroup = CreateGroup();
    private readonly bool heroOnly;


    private readonly region target;
    private readonly rect targetRect;

    private X()
    {
      return GetRectCenterX(targetRect);
    }

    private Y()
    {
      return GetRectCenterY(targetRect);
    }

    private PingPath()
    {
      return "MinimapQuestTurnIn";
    }

    public QuestItemAnyUnitInRect(rect targetRect, string rectName, bool heroOnly)
    {
      trigger trig = CreateTrigger();
      if (heroOnly)
        Description = "You have a hero at " + rectName;
      else
        Description = "You have a unit at " + rectName;
      target = RectToRegion(targetRect);
      this.targetRect = targetRect;
      this.heroOnly = heroOnly;
      TriggerRegisterEnterRegion(thistype.entersRectTrig, target, null);
      TriggerRegisterLeaveRegion(thistype.exitsRectTrig, target, null);
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
    }

    public unit TriggerUnit { get; private set; }

    private static region RectToRegion(rect whichRect)
    {
      region rectRegion = CreateRegion();
      RegionAddRect(rectRegion, whichRect);
      return rectRegion;
    }

    float operator

    float operator

    string operator

    private bool IsValidUnitInRect()
    {
      unit u;
      player holderPlayer = Holder.Player;
      GroupClear(thistype.tempGroup);
      GroupEnumUnitsInRect(thistype.tempGroup, targetRect, null);
      while (true)
      {
        u = FirstOfGroup(thistype.tempGroup);
        if (u == null) break;
        if (GetOwningPlayer(u) == Holder.Player && UnitAlive(u) &&
            (IsUnitType(u, UNIT_TYPE_HERO) || !heroOnly)) return true;
        GroupRemoveUnit(thistype.tempGroup, u);
      }

      return false;
    }

    private void OnRegionEnter(unit whichUnit)
    {
      if (GetOwningPlayer(whichUnit) == Holder.Player && UnitAlive(whichUnit) &&
        (IsUnitType(whichUnit, UNIT_TYPE_HERO) || !heroOnly) || IsValidUnitInRect())
      {
        TriggerUnit = whichUnit;
        Progress = QUEST_PROGRESS_COMPLETE;
      }
      else
      {
        Progress = QUEST_PROGRESS_INCOMPLETE;
      }
    }

    private void OnRegionExit()
    {
      if (IsValidUnitInRect())
        Progress = QUEST_PROGRESS_COMPLETE;
      else
        Progress = QUEST_PROGRESS_INCOMPLETE;
    }

    private static void OnAnyRegionExit()
    {
      var i = 0;
      while (true)
      {
        if (i == thistype.count) break;
        if (GetTriggeringRegion() == thistype.byIndex[i].target) thistype.byIndex[i].OnRegionExit();
        i = i + 1;
      }
    }

    private static void OnAnyRegionEnter()
    {
      var i = 0;
      while (true)
      {
        if (i == thistype.count) break;
        if (GetTriggeringRegion() == thistype.byIndex[i].target) thistype.byIndex[i].OnRegionEnter(GetEnteringUnit());
        i = i + 1;
      }
    }

    private static void onInit()
    {
      TriggerAddAction(thistype.entersRectTrig, thistype.OnAnyRegionEnter);
      TriggerAddAction(thistype.exitsRectTrig, thistype.OnAnyRegionExit);
    }
  }
}