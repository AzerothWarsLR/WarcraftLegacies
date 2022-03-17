namespace AzerothWarsCSharp.Source.Main.FilteredEvents
{
  public class FilteredSellEvents{

  
    private FilteredEventType FILTEREDEVENTTYPE_UNIT_SELLS_UNITTYPE ;//Any unit sells a specific unit type
    private FilteredEventType FILTEREDEVENTTYPE_UNITTYPE_SELLS_UNIT ;//A specific unit type sells any unit
  

    static void RegisterUnitSoldUnitTypeAction(int unitId, code whichTriggerAction ){
      PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SELL, whichTriggerAction, FILTEREDEVENTTYPE_UNIT_SELLS_UNITTYPE, unitId);
    }

    static void RegisterUnitTypeSoldUnitAction(int unitId, code whichTriggerAction ){
      PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_SELL, whichTriggerAction, FILTEREDEVENTTYPE_UNITTYPE_SELLS_UNIT, unitId);
    }

    private static void OnAnyUnitSold( ){
      PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SELL, FILTEREDEVENTTYPE_UNIT_SELLS_UNITTYPE, GetUnitTypeId(GetSoldUnit()));
      PlayerUnitEventExecute(EVENT_PLAYER_UNIT_SELL, FILTEREDEVENTTYPE_UNITTYPE_SELLS_UNIT, GetUnitTypeId(GetTriggerUnit()));
    }

    private static void OnInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_SELL,  OnAnyUnitSold);
      FILTEREDEVENTTYPE_UNIT_SELLS_UNITTYPE = FilteredEventType.create();
      FILTEREDEVENTTYPE_UNITTYPE_SELLS_UNIT = FilteredEventType.create();
    }

  }
}
