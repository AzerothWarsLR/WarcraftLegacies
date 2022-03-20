namespace AzerothWarsCSharp.Source.Mechanics.Quelthalas
{
  public class SilvermoonDies{

    private static void Dies( ){
      SetUnitInvulnerable(LEGEND_SUNWELL.Unit, false);
    }

    public static void Setup( ){
      trigger trig = CreateTrigger();
      TriggerRegisterUnitEvent(trig, LEGEND_SILVERMOON.Unit, EVENT_UNIT_DEATH);
      TriggerAddCondition(trig, ( Dies));
    }

  }
}
