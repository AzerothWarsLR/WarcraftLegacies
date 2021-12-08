using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestObjectives
{
  public class QuestObjectiveReachRect : QuestObjective
  {
    private readonly trigger _trigger;

    private void OnUnitEntersRegion()
    {
      if (ParentFaction != null && GetOwningPlayer(GetTriggerUnit()) == ParentFaction.Player)
      {
        Progress = QuestProgress.Complete;
      }
    }
    
    public QuestObjectiveReachRect(rect rect, string rectName) : base()
    {
      _trigger = CreateTrigger();
      TriggerRegisterEnterRegion(_trigger, GeneralHelpers.RectToRegion(rect), null);
      TriggerAddAction(_trigger, OnUnitEntersRegion);
      X = GetRectCenterX(rect);
      Y = GetRectCenterY(rect);
      HasLocation = true;
      Description = $"Bring a unit to {rectName}";
    }

    ~QuestObjectiveReachRect()
    {
      DestroyTrigger(_trigger);
    }
  }
}