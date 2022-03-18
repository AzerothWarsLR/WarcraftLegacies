namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemResearch{


    private static int count = 0;
    private static thistype[] byIndex;
    private int researchId;




      this.researchId = researchId;
    thistype.byIndex[thistype.count] = this;
    thistype.count = thistype.count + 1;
    ;;
  }
}

    private static void OnAnyResearch( ){
      var i = 0;
      thistype loopQuestItem;
      var researched = GetResearched();
      while(true){
        if ( i == thistype.count){ break; }
        loopQuestItem = thistype.byIndex[i];
        if (loopQuestItem.researchId == researched && loopQuestItem.Holder.Player == GetOwningPlayer(GetTriggerUnit())){
          loopQuestItem.Progress = QUEST_PROGRESS_COMPLETE;
        }
        i = i + 1;
      }
    }

    private static void onInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_FINISH,  thistype.OnAnyResearch) ;//TODO: use filtered events
    }


}
