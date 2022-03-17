public class FilteredDeathEvents{

  
    private FilteredEventType FILTEREDEVENTTYPE_DIES;
    private FilteredEventType FILTEREDEVENTTYPE_KILLS;
  

  static void RegisterUnitTypeDiesAction(int unitTypeId, code whichTriggerAction ){
    PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_DEATH, whichTriggerAction, FILTEREDEVENTTYPE_DIES, unitTypeId);
  }

  static void RegisterUnitTypeKillsAction(int unitTypeId, code whichTriggerAction ){
    PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_DEATH, whichTriggerAction, FILTEREDEVENTTYPE_KILLS, unitTypeId);
  }

  private static void OnAnyUnitDeath( ){
    PlayerUnitEventExecute(EVENT_PLAYER_UNIT_DEATH, FILTEREDEVENTTYPE_DIES, GetUnitTypeId(GetTriggerUnit()));
    PlayerUnitEventExecute(EVENT_PLAYER_UNIT_DEATH, FILTEREDEVENTTYPE_KILLS, GetUnitTypeId(GetKillingUnit()));
  }

  private static void OnInit( ){
    PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_DEATH,  OnAnyUnitDeath);
    FILTEREDEVENTTYPE_DIES = FilteredEventType.create();
    FILTEREDEVENTTYPE_KILLS = FilteredEventType.create();
  }

}
