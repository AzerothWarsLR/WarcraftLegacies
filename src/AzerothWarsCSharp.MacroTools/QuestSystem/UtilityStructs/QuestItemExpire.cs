namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  /// Starts completed, then fails when the specified amount of time has elapsed.
  /// </summary>
  public class QuestItemExpire : QuestItemData
  {
    private readonly timer _timer;

    public override void OnAdd()
    {
      Progress = QuestProgress.Complete;
    }

    private void OnExpire()
    {
      DestroyTimer(_timer);
      Progress = QuestProgress.Failed;
    }

    public QuestItemExpire(int duration)
    {
      Description = "Complete this quest before " + I2S(duration) + " seconds have elapsed";
      _timer = CreateTimer();
      TimerStart(_timer, duration, false, OnExpire);
    }
  }
}