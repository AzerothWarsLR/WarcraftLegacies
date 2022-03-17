public class FilteredAttackEvents{

  
    private FilteredEventType FILTEREDEVENTTYPE_UNITTYPEATTACKED;
    private FilteredEventType FILTEREDEVENTTYPE_UNITTYPEATTACKS;
  

  static void RegisterUnitTypeAttackedAction(int unitTypeId, code whichTriggerAction ){
    PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_ATTACKED, whichTriggerAction, FILTEREDEVENTTYPE_UNITTYPEATTACKED, unitTypeId);
  }

  static void RegisterUnitTypeAttacksAction(int unitTypeId, code whichTriggerAction ){
    PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_ATTACKED, whichTriggerAction, FILTEREDEVENTTYPE_UNITTYPEATTACKS, unitTypeId);
  }

  private static void OnAnyUnitAttacked( ){
    PlayerUnitEventExecute(EVENT_PLAYER_UNIT_ATTACKED, FILTEREDEVENTTYPE_UNITTYPEATTACKED, GetUnitTypeId(GetTriggerUnit()));
    PlayerUnitEventExecute(EVENT_PLAYER_UNIT_ATTACKED, FILTEREDEVENTTYPE_UNITTYPEATTACKS, GetUnitTypeId(GetAttacker()));
  }

  private static void OnInit( ){
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_ATTACKED,  OnAnyUnitAttacked);
    FILTEREDEVENTTYPE_UNITTYPEATTACKED = FilteredEventType.create();
    FILTEREDEVENTTYPE_UNITTYPEATTACKS = FilteredEventType.create();
  }

}
