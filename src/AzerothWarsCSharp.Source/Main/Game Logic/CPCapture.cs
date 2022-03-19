using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using WCSharp.Events;

namespace AzerothWarsCSharp.Source.Main.Game_Logic
{
  public class CPCapture
  {
    private const float CAPTURE_THRESHOLD = 08; //Percentage of maximum HP; below this, the CP will go to the damager
    
    private static void Actions()
    {
      unit attacker = GetEventDamageSource();
      unit attacked = GetTriggerUnit();

      if (IsUnitInGroup(GetTriggerUnit(), ControlPoint.AllControlPointUnits))
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