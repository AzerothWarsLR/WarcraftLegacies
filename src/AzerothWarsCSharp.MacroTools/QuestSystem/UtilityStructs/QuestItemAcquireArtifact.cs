using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemAcquireArtifact : QuestItemData{


    private static int count = 0;
    private static thistype[] byIndex;
    private Artifact target;

    private void OnAdd( ){
      if (target.owningPerson == this.Holder.Person){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }
    }

    private void OnAcquired( ){
      if (target.owningPerson == this.Holder.Person){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }else {
        this.Progress = QUEST_PROGRESS_INCOMPLETE;
      }
    }

    static void OnAnyArtifactAcquired( ){
      var i = 0;
      thistype loopItem;
      while(true){
        if ( i == thistype.count){ break; }
        loopItem = thistype.byIndex[i];
        if (loopItem.target == GetTriggerArtifact()){
          loopItem.OnAcquired();
        }
        i = i + 1;
      }
    }

    public QuestItemAcquireArtifact (Artifact target ){

      this.Description = "Acquire " + GetItemName(target.item);
      this.target = target;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      
    }


    public static void Setup( ){
      trigger trig = CreateTrigger();
      OnArtifactOwnerChange.register(trig);
      TriggerAddAction(trig,  OnAnyArtifactAcquired);
    }

  }
}
