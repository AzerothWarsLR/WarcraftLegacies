namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemTime{


    private timer timer;

    private static Table byTimer;
    private static int count = 0;
    private static thistype[] byIndex;

    private void OnExpire( ){
      DestroyTimer(this.timer);
      this.Progress = QUEST_PROGRESS_COMPLETE;
    }

    private static void OnAnyTimerExpires( ){
      if (thistype.byTimer[GetHandleId(GetExpiredTimer())] != 0){
        QuestItemTime(thistype.byTimer[GetHandleId(GetExpiredTimer())]).OnExpire();
      }
    }

    thistype (int duration ){

      this.Description = I2S(duration) + " seconds have elapsed";
      this.timer = CreateTimer();
      TimerStart(this.timer, duration, false,  thistype.OnAnyTimerExpires);
      thistype.byTimer[GetHandleId(this.timer)] = this;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private static void onInit( ){
      thistype.byTimer = Table.create();
    }


  }
}
