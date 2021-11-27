library FilteredItemEvents initializer OnInit requires PlayerUnitEventFilterManager

  globals
    private FilteredEventType FILTEREDEVENTTYPE_ITEMPICKEDUP
  endglobals

  function RegisterItemTypePickupAction takes integer itemId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_PICKUP_ITEM, whichTriggerAction, FILTEREDEVENTTYPE_ITEMPICKEDUP, itemId)
  endfunction

  private function OnAnyUnitPicksUpItem takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_PICKUP_ITEM, FILTEREDEVENTTYPE_ITEMPICKEDUP, GetItemTypeId(GetManipulatedItem()))
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_PICKUP_ITEM, function OnAnyUnitPicksUpItem)
    set FILTEREDEVENTTYPE_ITEMPICKEDUP = FilteredEventType.create()
  endfunction

endlibrary