namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public class QuestItemTime : QuestItemData {


    private timer timer;

    private static Table byTimer;
    private static int count = 0;
    private static thistype[] byIndex;

    private void OnExpire( ){
      DestroyTimer(timer);
      this.Progress = QUEST_PROGRESS_COMPLETE;
    }

    private static void OnAnyTimerExpires( ){
      if (thistype.byTimer[GetHandleId(GetExpiredTimer())] != 0){
        QuestItemTime(thistype.byTimer[GetHandleId(GetExpiredTimer())]).OnExpire();
      }
    }

    public QuestItemTime(int duration ){

      this.Description = I2S(duration) + " seconds have elapsed";
      timer = CreateTimer();
      TimerStart(timer, duration, false,  thistype.OnAnyTimerExpires);
      thistype.byTimer[GetHandleId(timer)] = this;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      
    }

    private static void onInit( ){
      thistype.byTimer = Table.create();
    }


  }
}
