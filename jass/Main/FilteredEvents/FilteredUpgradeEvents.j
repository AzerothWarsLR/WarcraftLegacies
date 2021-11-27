library FilteredUpgradeEvents initializer OnInit requires PlayerUnitEventFilterManager

  globals
    private FilteredEventType FILTEREDEVENTTYPE_UPGRADEFINISH
    private FilteredEventType FILTEREDEVENTTYPE_UPGRADESTART
    private FilteredEventType FILTEREDEVENTTYPE_UPGRADECANCEL
  endglobals

  function RegisterUpgradeFinishedAction takes integer UPGRADEId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_UPGRADE_FINISH, whichTriggerAction, FILTEREDEVENTTYPE_UPGRADEFINISH, UPGRADEId)
  endfunction

  function RegisterUpgradeStartedAction takes integer UPGRADEId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_UPGRADE_START, whichTriggerAction, FILTEREDEVENTTYPE_UPGRADESTART, UPGRADEId)
  endfunction

  function RegisterUpgradeCancelledAction takes integer UPGRADEId, code whichTriggerAction returns nothing
    call PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_UPGRADE_CANCEL, whichTriggerAction, FILTEREDEVENTTYPE_UPGRADECANCEL, UPGRADEId)
  endfunction

  private function OnAnyUnitFinishedUpgrade takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_UPGRADE_FINISH, FILTEREDEVENTTYPE_UPGRADEFINISH, GetUnitTypeId(GetTriggerUnit()))
  endfunction

  private function OnAnyUnitStartedUpgrade takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_UPGRADE_START, FILTEREDEVENTTYPE_UPGRADESTART, GetUnitTypeId(GetTriggerUnit()))
  endfunction

  private function OnAnyUnitCancelledUpgrade takes nothing returns nothing
    call PlayerUnitEventExecute(EVENT_PLAYER_UNIT_UPGRADE_CANCEL, FILTEREDEVENTTYPE_UPGRADECANCEL, GetUnitTypeId(GetTriggerUnit()))
  endfunction

  private function OnInit takes nothing returns nothing
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_UPGRADE_FINISH, function OnAnyUnitFinishedUpgrade)
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_UPGRADE_START, function OnAnyUnitStartedUpgrade)
    call PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_UPGRADE_CANCEL, function OnAnyUnitCancelledUpgrade)
    set FILTEREDEVENTTYPE_UPGRADEFINISH = FilteredEventType.create()
    set FILTEREDEVENTTYPE_UPGRADESTART = FilteredEventType.create()
    set FILTEREDEVENTTYPE_UPGRADECANCEL = FilteredEventType.create()
  endfunction

endlibrary