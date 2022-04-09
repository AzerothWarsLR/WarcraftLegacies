using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemLegendHasArtifact : QuestItemData{


    private static int count = 0;
    private static thistype[] byIndex;
    private Artifact targetArtifact;
    private Legend targetLegend;

    private void OnAdd( ){
      if (targetArtifact.OwningUnit == targetLegend.Unit){
        this.Progress = QUEST_PROGRESS_COMPLETE;
      }
    }

    private void OnAcquired( ){
      if (targetArtifact.OwningUnit == targetLegend.Unit){
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
        if (loopItem.targetArtifact == GetTriggerArtifact()){
          loopItem.OnAcquired();
        }
        i = i + 1;
      }
    }

    public QuestItemLegendHasArtifact(Legend targetLegend, Artifact targetArtifact ){

      this.Description = targetLegend.Name + " has " + GetItemName(targetArtifact.Item);
      this.targetLegend = targetLegend;
      this.targetArtifact = targetArtifact;
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
