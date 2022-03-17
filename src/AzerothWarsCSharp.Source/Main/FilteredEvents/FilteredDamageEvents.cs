public class FilteredDamageEvents{

  
    private FilteredEventType FILTEREDEVENTTYPE_UNITTYPE_TAKESDAMAGE;
    private FilteredEventType FILTEREDEVENTTYPE_UNITTYPE_INFLICTSDAMAGE;
  

  static void RegisterUnitTypeTakesDamageAction(int unitTypeId, code whichTriggerAction ){
    PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_DAMAGED, whichTriggerAction, FILTEREDEVENTTYPE_UNITTYPE_TAKESDAMAGE, unitTypeId);
  }

  static void RegisterUnitTypeInflictsDamageAction(int unitTypeId, code whichTriggerAction ){
    PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_DAMAGED, whichTriggerAction, FILTEREDEVENTTYPE_UNITTYPE_INFLICTSDAMAGE, unitTypeId);
  }

  private static void OnAnyUnitDamaged( ){
    PlayerUnitEventExecute(EVENT_PLAYER_UNIT_DAMAGED, FILTEREDEVENTTYPE_UNITTYPE_TAKESDAMAGE, GetUnitTypeId(GetTriggerUnit()));
    PlayerUnitEventExecute(EVENT_PLAYER_UNIT_DAMAGED, FILTEREDEVENTTYPE_UNITTYPE_INFLICTSDAMAGE, GetUnitTypeId(GetEventDamageSource()));
  }

  private static void OnInit( ){
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DAMAGED,  OnAnyUnitDamaged);
    FILTEREDEVENTTYPE_UNITTYPE_TAKESDAMAGE = FilteredEventType.create();
    FILTEREDEVENTTYPE_UNITTYPE_INFLICTSDAMAGE = FilteredEventType.create();
  }

}
