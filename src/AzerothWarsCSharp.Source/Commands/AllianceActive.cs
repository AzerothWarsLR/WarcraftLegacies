using AzerothWarsCSharp.Source.Game_Logic.GameEnd;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Commands
{
  public class AllianceActive
  {
    public const bool ARE_ALLIANCE_ACTIVE = true;

    private static void Actions()
    {
      if (ARE_ALLIANCE_ACTIVE) ControlPointVictory.SetCpsVictory(120);
    }

    public static void Setup()
    {
      trigger trig = CreateTrigger();
      TriggerRegisterTimerEvent(trig, 8000, false);
      TriggerAddAction(trig, Actions);
    }
  }
}