namespace AzerothWarsCSharp.Source.Main.FilteredEvents
{
  public class FilteredResearchEvents{

  
    private FilteredEventType FILTEREDEVENTTYPE_RESEARCHFINISH;
    private FilteredEventType FILTEREDEVENTTYPE_RESEARCHSTART;
    private FilteredEventType FILTEREDEVENTTYPE_RESEARCHCANCEL;
  

    static void RegisterResearchFinishedAction(int researchId, code whichTriggerAction ){
      PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_RESEARCH_FINISH, whichTriggerAction, FILTEREDEVENTTYPE_RESEARCHFINISH, researchId);
    }

    static void RegisterResearchStartedAction(int researchId, code whichTriggerAction ){
      PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_RESEARCH_START, whichTriggerAction, FILTEREDEVENTTYPE_RESEARCHSTART, researchId);
    }

    static void RegisterResearchCancelledAction(int researchId, code whichTriggerAction ){
      PlayerUnitEventAddFilteredAction(EVENT_PLAYER_UNIT_RESEARCH_CANCEL, whichTriggerAction, FILTEREDEVENTTYPE_RESEARCHCANCEL, researchId);
    }

    private static void OnAnyUnitFinishedResearch( ){
      PlayerUnitEventExecute(EVENT_PLAYER_UNIT_RESEARCH_FINISH, FILTEREDEVENTTYPE_RESEARCHFINISH, GetResearched());
    }

    private static void OnAnyUnitStartedResearch( ){
      PlayerUnitEventExecute(EVENT_PLAYER_UNIT_RESEARCH_START, FILTEREDEVENTTYPE_RESEARCHSTART, GetResearched());
    }

    private static void OnAnyUnitCancelledResearch( ){
      PlayerUnitEventExecute(EVENT_PLAYER_UNIT_RESEARCH_CANCEL, FILTEREDEVENTTYPE_RESEARCHCANCEL, GetResearched());
    }

    private static void OnInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_FINISH,  OnAnyUnitFinishedResearch);
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_START,  OnAnyUnitStartedResearch);
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_CANCEL,  OnAnyUnitCancelledResearch);
      FILTEREDEVENTTYPE_RESEARCHFINISH = FilteredEventType.create();
      FILTEREDEVENTTYPE_RESEARCHSTART = FilteredEventType.create();
      FILTEREDEVENTTYPE_RESEARCHCANCEL = FilteredEventType.create();
    }

  }
}
