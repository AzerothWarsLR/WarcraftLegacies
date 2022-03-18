namespace AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs
{
  public class QuestItemExpire{


    private timer timer;

    private static Table byTimer;
    private static int count = 0;
    private static thistype[] byIndex;

    void OnAdd( ){
      this.Progress = QUEST_PROGRESS_COMPLETE;
    }

    private void OnExpire( ){
      DestroyTimer(timer);
      this.Progress = QUEST_PROGRESS_FAILED;
    }

    private static void OnAnyTimerExpires( ){
      if (thistype.byTimer[GetHandleId(GetExpiredTimer())] != 0){
        QuestItemExpire(thistype.byTimer[GetHandleId(GetExpiredTimer())]).OnExpire();
      }
    }

    thistype (int duration ){

      this.Description = " Complete this quest before " + I2S(duration) + " seconds have elapsed";
      timer = CreateTimer();
      TimerStart(timer, duration, false,  thistype.OnAnyTimerExpires);
      thistype.byTimer[GetHandleId(timer)] = this;
      thistype.byIndex[thistype.count] = this;
      thistype.count = thistype.count + 1;
      ;;
    }

    private static void onInit( ){
      thistype.byTimer = Table.create();
    }


  }
}
