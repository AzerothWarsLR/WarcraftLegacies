using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Main.Game_Logic
{
  /// <summary>
  /// When a <see cref="ControlPoint"/> is reduced below a certain health threshold, it changes ownership to the attacker.
  /// </summary>
  public static class CpCapture
  {
    private const float CAPTURE_THRESHOLD = 0.8f; //Percentage of maximum HP; below this, the CP will go to the damager

    private static void Actions()
    {
      unit attacker = GetEventDamageSource();
      unit attacked = GetTriggerUnit();

      if (ControlPoint.UnitIsControlPoint(GetTriggerUnit()))
      {
        var hp = (GetUnitState(attacked, UNIT_STATE_LIFE) - GetEventDamage()) /
                 GetUnitState(attacked, UNIT_STATE_MAX_LIFE);
        if (hp < CAPTURE_THRESHOLD)
        {
          BlzSetEventDamage(0);
          SetUnitOwner(attacked, GetOwningPlayer(attacker), true);
          SetUnitLifePercentBJ(attacked, 85);
        }
      }
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.UnitTypeIsDamaged, Actions);
    }
  }
}