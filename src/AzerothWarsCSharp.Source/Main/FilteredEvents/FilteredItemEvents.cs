namespace AzerothWarsCSharp.Source.Main.FilteredEvents
{
  public class FilteredItemEvents{

  
    private FilteredEventType FILTEREDEVENTTYPE_ITEMPICKEDUP;
  

    static void RegisterItemTypePickupAction(int itemId, code whichTriggerAction ){
      PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_PICKUP_ITEM, whichTriggerAction, FILTEREDEVENTTYPE_ITEMPICKEDUP, itemId);
    }

    private static void OnAnyUnitPicksUpItem( ){
      PlayerUnitEventExecute(EVENT_PLAYER_UNIT_PICKUP_ITEM, FILTEREDEVENTTYPE_ITEMPICKEDUP, GetItemTypeId(GetManipulatedItem()));
    }

    private static void OnInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_PICKUP_ITEM,  OnAnyUnitPicksUpItem);
      FILTEREDEVENTTYPE_ITEMPICKEDUP = FilteredEventType.create();
    }

  }
}
