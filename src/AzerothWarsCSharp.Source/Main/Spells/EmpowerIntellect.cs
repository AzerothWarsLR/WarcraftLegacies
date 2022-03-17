namespace AzerothWarsCSharp.Source.Main.Spells
{
  public class EmpowerIntellect{

  
    private const int BUFF_ID = FourCC(B069);
    private const float REFUND_MULT = 075;
  

    private static void Cast( ){
      unit triggerUnit = null;
      if ((GetUnitAbilityLevel(GetTriggerUnit(), BUFF_ID) > 0)){
        triggerUnit = GetTriggerUnit();
        SetUnitState(triggerUnit, UNIT_STATE_MANA, GetUnitState(triggerUnit, UNIT_STATE_MANA) + I2R(BlzGetAbilityManaCost(GetSpellAbilityId(), GetUnitAbilityLevel(triggerUnit, BUFF_ID))) * REFUND_MULT);
        triggerUnit = null;
      }
    }

    private static void OnInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SPELL_EFFECT,  Cast);
    }

  }
}
