//Provides a single trigger for each generic event.
//"Filtered" events can then be registered against each trigger.
//For example, you can create an event for "A Footman attacks", and only actions registered against that filtered event will fire.
//This is a substantial performance boost.
namespace AzerothWarsCSharp.Source.Main.Libraries
{
  public class PlayerUnitEventFilterManager{

  
    private hashtable[] Triggers;
  

    //Try to execute all actions registered to an event that match a given filteredEventType and filterValue
    static void PlayerUnitEventExecute(playerunitevent whichPlayerUnitEvent, FilteredEventType filteredEventType, int filterValue ){
      hashtable hashTable = Triggers[GetHandleId(whichPlayerUnitEvent)];
      trigger trig = LoadTriggerHandle(hashTable, filteredEventType, filterValue);
      if (trig != null){
        TriggerExecute(trig);
      }
    }

    //Register an action against an event, filtered by a filteredEventType and an expected filterValue
    static void PlayerUnitEventAddFilteredAction(playerunitevent whichPlayerUnitEvent, code whichTriggerAction, FilteredEventType filteredEventType, int filterValue ){
      hashtable hashTable = Triggers[GetHandleId(whichPlayerUnitEvent)];
      trigger trig = LoadTriggerHandle(hashTable, filteredEventType, filterValue);
      if (trig == null){
        trig = CreateTrigger();
        SaveTriggerHandle(hashTable, filteredEventType, filterValue, trig);
      }
      TriggerAddAction(trig, whichTriggerAction);
    }

    //Register a generic trigger, like you would with TriggerRegisterAnyUnitEventBJ
    static void PlayerUnitEventAddAction(playerunitevent whichPlayerUnitEvent, code whichTriggerAction ){
      trigger trig;
      //There is one hashtable per playerunitevent
      hashtable hashTable = Triggers[GetHandleId(whichPlayerUnitEvent)];
      if (hashTable == null){
        hashTable = InitHashtable();
        Triggers[GetHandleId(whichPlayerUnitEvent)] = hashTable;
      }
      //Each hashtable maintains a list of triggers indexed by a filterValue and a filteredEventType, but [0,0] is reserved for the unfiltered event
      trig = LoadTriggerHandle(hashTable, 0, 0);
      if (trig == null){
        trig = CreateTrigger();
        TriggerRegisterAnyUnitEventBJ(trig, whichPlayerUnitEvent);
        SaveTriggerHandle(hashTable, 0, 0, trig);
      }
      TriggerAddAction(trig, whichTriggerAction);
    }

    //Used to index filtered events. For example, you might have a type for a unit type being attacked, and another type for a unit type attacking.




  }
}
