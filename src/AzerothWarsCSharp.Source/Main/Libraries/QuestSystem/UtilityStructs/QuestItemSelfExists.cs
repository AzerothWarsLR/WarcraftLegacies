using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemSelfExists{


    private static int count = 0;
    private static thistype[] byIndex;

    boolean operator ShowsInQuestLog( ){
      return false;
    }

    void OnAdd( ){
      this.Progress = QUEST_PROGRESS_COMPLETE;
    }

    static void OnAnyFactionScoreStatusChanged( ){
      int i = 0;
      Faction triggerFaction = GetTriggerFaction();
      if (triggerFaction != 0 && triggerFaction.ScoreStatus == SCORESTATUS_DEFEATED){
        while(true){
          if ( i == thistype.count){ break; }
          if (thistype.byIndex[i].Holder == triggerFaction){
            thistype.byIndex[i].Progress = QUEST_PROGRESS_FAILED;
          }
          i = i + 1;
        }
      }
    }

    thistype ( ){

      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      this.Progress = QUEST_PROGRESS_COMPLETE;
      ;;
    }


    private static void OnInit( ){
      trigger trig = CreateTrigger();
      FactionScoreStatusChanged.register(trig);
      TriggerAddAction(trig,  QuestItemSelfExists.OnAnyFactionScoreStatusChanged);
    }

  }
}
