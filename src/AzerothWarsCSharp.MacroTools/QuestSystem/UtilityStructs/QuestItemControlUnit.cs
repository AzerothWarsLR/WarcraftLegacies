using WCSharp.Events;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class QuestItemControlUnit : QuestItemData, IHasPosition {
    
    private readonly unit _target;

    private void OnUnitChangeOwner( ){
      if (Holder.Team.ContainsPlayer(GetOwningPlayer(_target))){
        Progress = QuestProgress.Complete;
      }
    }

    public QuestItemControlUnit(unit target){
      Description = "Your team controls " + GetUnitName(target);
      TargetWidget = target;
      _target = target;

      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeChangesOwner, OnUnitChangeOwner);
    }

    public Point Position => new(GetUnitX(_target), GetUnitY(_target));

    public bool DisplaysPosition => true;
  }
}
