public class SilvermoonDies{

  private static void Dies( ){
    SetUnitInvulnerable(LEGEND_SUNWELL.Unit, false);
  }

  private static void OnInit( ){
    trigger trig = CreateTrigger();
    TriggerRegisterUnitEvent(trig, LEGEND_SILVERMOON.Unit, EVENT_UNIT_DEATH);
    TriggerAddCondition(trig, ( Dies));
  }

}
