using WCSharp.Events;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class QuestItemControlUnit : QuestItemData
  {
    private readonly unit _target;

    public QuestItemControlUnit(unit target)
    {
      Description = "Your team controls " + GetUnitName(target);
      TargetWidget = target;
      _target = target;
      DisplaysPosition = true;

      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeChangesOwner, OnUnitChangeOwner);
    }

    public override Point Position => new(GetUnitX(_target), GetUnitY(_target));

    private void OnUnitChangeOwner()
    {
      if (Holder.Team.ContainsPlayer(GetOwningPlayer(_target))) Progress = QuestProgress.Complete;
    }
  }
}