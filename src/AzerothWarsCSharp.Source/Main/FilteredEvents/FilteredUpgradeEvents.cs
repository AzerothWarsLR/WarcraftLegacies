namespace AzerothWarsCSharp.Source.Main.FilteredEvents
{
  public class FilteredUpgradeEvents{

  
    private FilteredEventType FILTEREDEVENTTYPE_UPGRADEFINISH;
    private FilteredEventType FILTEREDEVENTTYPE_UPGRADESTART;
    private FilteredEventType FILTEREDEVENTTYPE_UPGRADECANCEL;
  

    static void RegisterUpgradeFinishedAction(int UPGRADEId, code whichTriggerAction ){
      PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_UPGRADE_FINISH, whichTriggerAction, FILTEREDEVENTTYPE_UPGRADEFINISH, UPGRADEId);
    }

    static void RegisterUpgradeStartedAction(int UPGRADEId, code whichTriggerAction ){
      PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_UPGRADE_START, whichTriggerAction, FILTEREDEVENTTYPE_UPGRADESTART, UPGRADEId);
    }

    static void RegisterUpgradeCancelledAction(int UPGRADEId, code whichTriggerAction ){
      PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_UPGRADE_CANCEL, whichTriggerAction, FILTEREDEVENTTYPE_UPGRADECANCEL, UPGRADEId);
    }

    private static void OnAnyUnitFinishedUpgrade( ){
      PlayerUnitEventExecute(EVENT_PLAYER_UNIT_UPGRADE_FINISH, FILTEREDEVENTTYPE_UPGRADEFINISH, GetUnitTypeId(GetTriggerUnit()));
    }

    private static void OnAnyUnitStartedUpgrade( ){
      PlayerUnitEventExecute(EVENT_PLAYER_UNIT_UPGRADE_START, FILTEREDEVENTTYPE_UPGRADESTART, GetUnitTypeId(GetTriggerUnit()));
    }

    private static void OnAnyUnitCancelledUpgrade( ){
      PlayerUnitEventExecute(EVENT_PLAYER_UNIT_UPGRADE_CANCEL, FILTEREDEVENTTYPE_UPGRADECANCEL, GetUnitTypeId(GetTriggerUnit()));
    }

    private static void OnInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_UPGRADE_FINISH,  OnAnyUnitFinishedUpgrade);
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_UPGRADE_START,  OnAnyUnitStartedUpgrade);
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_UPGRADE_CANCEL,  OnAnyUnitCancelledUpgrade);
      FILTEREDEVENTTYPE_UPGRADEFINISH = FilteredEventType.create();
      FILTEREDEVENTTYPE_UPGRADESTART = FilteredEventType.create();
      FILTEREDEVENTTYPE_UPGRADECANCEL = FilteredEventType.create();
    }

  }
}
