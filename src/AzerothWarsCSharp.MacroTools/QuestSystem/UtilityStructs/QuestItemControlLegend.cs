using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemControlLegend : QuestItemData{


    private Legend target = 0;
    private static int count = 0;
    private static thistype[] byIndex;
    private bool canFail;

    float operator X( ){
      if (IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE) || IsPlayerNeutralHostile(GetOwningPlayer(target.Unit))){
        return GetUnitX(target.Unit);
      }
      return 0;
    }

    float operator Y( ){
      if (IsUnitType(target.Unit, UNIT_TYPE_STRUCTURE) || IsPlayerNeutralHostile(GetOwningPlayer(target.Unit))){
        return GetUnitY(target.Unit);
      }
      return 0;
    }

    private void OnAdd( ){
      if (this.Holder.Team.ContainsPlayer(GetOwningPlayer(target.Unit))){
        this.Progress = QuestProgress.Complete;
      }
    }

    private void OnTargetChangeOwner( ){
      if (this.Holder.Team.ContainsPlayer(GetOwningPlayer(target.Unit))){
        this.Progress = QuestProgress.Complete;
      }else {
        if (canFail){
          this.Progress = QuestProgress.Failed;
        }else {
          this.Progress = QuestProgress.Incomplete;
        }
      }
    }

    public static void OnAnyUnitDeath( ){
      var i = 0;
      thistype loopItem;
      Legend triggerLegend = GetTriggerLegend();
      while(true){
        if ( i == thistype.count){ break; }
        loopItem = thistype.byIndex[i];
        if (loopItem.target == triggerLegend && loopItem.canFail == true){
          loopItem.Progress = QuestProgress.Failed;
        }
        i = i + 1;
      }
    }

    public static void OnAnyLegendChangeOwner( ){
      var i = 0;
      thistype loopItem;
      while(true){
        if ( i == thistype.count){ break; }
        loopItem = thistype.byIndex[i];
        if (loopItem.target == GetTriggerLegend()){
          loopItem.OnTargetChangeOwner();
        }
        i = i + 1;
      }
    }

    public QuestItemControlLegend(Legend target, bool canFail ){

      this.target = target;
      this.Description = "Your team controls " + target.Name;
      this.canFail = canFail;
      this.targetWidget = target.Unit;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      
    }



    public static void Setup( ){
      trigger trig = CreateTrigger();
      OnLegendChangeOwner.register(trig);
      TriggerAddAction(trig,  OnAnyLegendChangeOwner);

      trig = CreateTrigger();
      OnLegendPermaDeath.register(trig);
      TriggerAddAction(trig,  OnAnyUnitDeath);
    }

  }
}
