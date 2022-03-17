using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemAcquireArtifact{


    private static int count = 0;
    private static thistype[] byIndex;
    private Artifact target;

    private void OnAdd( ){
      if (this.target.owningPerson == this.Holder.Person){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }
    }

    private void OnAcquired( ){
      if (this.target.owningPerson == this.Holder.Person){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }else {
        this.Progress = QUEST_PROGRESS_INCOMPLETE;
      }
    }

    static void OnAnyArtifactAcquired( ){
      int i = 0;
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

    thistype (Artifact target ){

      this.Description = "Acquire " + GetItemName(target.item);
      this.target = target;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }


    private static void OnInit( ){
      trigger trig = CreateTrigger();
      OnArtifactOwnerChange.register(trig);
      TriggerAddAction(trig,  QuestItemAcquireArtifact.OnAnyArtifactAcquired);
    }

  }
}
