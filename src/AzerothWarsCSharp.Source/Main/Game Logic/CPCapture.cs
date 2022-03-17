
public class CPCapture{

  
    private const float CAPTURE_THRESHOLD = 08   ;//Percentage of maximum HP; below this, the CP will go to the damager
  

  private static void Actions( ){
    unit attacker = GetEventDamageSource();
    unit attacked = GetTriggerUnit();
    float hp;

    if (IsUnitInGroup(GetTriggerUnit(), ControlPoints)){
      hp = (GetUnitState(attacked, UNIT_STATE_LIFE) - GetEventDamage()) / GetUnitState(attacked, UNIT_STATE_MAX_LIFE);
      if (hp < CAPTURE_THRESHOLD){
        BlzSetEventDamage(0);
        SetUnitOwner(attacked, GetOwningPlayer(attacker), true);
        SetUnitLifePercentBJ(attacked, 85);
      }
    }

    attacker = null;
    attacked = null;
  }

  private static void OnInit( ){
    trigger trig = CreateTrigger();
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DAMAGED,  Actions) ;//TODO: use filtered events, since all Control Points identities are known
    TriggerAddCondition(trig,( Actions));
  }

}
