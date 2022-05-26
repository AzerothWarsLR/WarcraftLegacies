using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  /// <summary>
  ///   Starts completed, then fails when the specified amount of time has elapsed.
  /// </summary>
  public class ObjectiveExpire : Objective
  {
    private readonly timer _timer;

    public ObjectiveExpire(int duration)
    {
      Description = "Complete this quest before " + I2S(duration) + " seconds have elapsed";
      _timer = CreateTimer();
      TimerStart(_timer, duration, false, OnExpire);
      ShowsInQuestLog = false;
    }

    internal override void OnAdd(Faction whichFaction)
    {
      Progress = QuestProgress.Complete;
    }

    private void OnExpire()
    {
      DestroyTimer(_timer);
      Progress = QuestProgress.Failed;
    }
  }
}