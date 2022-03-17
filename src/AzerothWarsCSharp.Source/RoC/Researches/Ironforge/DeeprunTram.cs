public class DeeprunTram{

  
    private const int RESEARCH_ID = FourCC(R014);
  

  private static void Transfer( ){
    unit ironforgeTram = gg_unit_n03B_0010;
    unit stormwindTram = gg_unit_n03B_0037;
    Person recipient;

    recipient = FACTION_IRONFORGE.Person;
    if (recipient == 0){
      recipient = FACTION_STORMWIND.Person;
    }
    if (recipient == 0){
      KillUnit(gg_unit_n03B_0010);
      KillUnit(gg_unit_n03B_0037);
      return;
    }

    SetUnitOwner(ironforgeTram, recipient.Player, true);
    WaygateActivateBJ(true, ironforgeTram);
    WaygateSetDestination(ironforgeTram, GetRectCenterX(gg_rct_Stormwind), GetRectCenterY(gg_rct_Stormwind));
    SetUnitInvulnerable(ironforgeTram, false);

    SetUnitOwner(stormwindTram, recipient.Player, true);
    WaygateActivateBJ(true, stormwindTram);
    WaygateSetDestination(stormwindTram, GetRectCenterX(gg_rct_Ironforge), GetRectCenterY(gg_rct_Ironforge));
    SetUnitInvulnerable(stormwindTram, false);
  }

  private static void ResearchStart( ){
    int i = 0;
    while(true){
    if ( i > MAX_PLAYERS){ break; }
      Person.ById(i).SetObjectLimit(RESEARCH_ID, 0);
      i = i + 1;
    }
  }

  private static void ResearchCancel( ){
    int i = 0;
    while(true){
    if ( i > MAX_PLAYERS){ break; }
      Person.ById(i).SetObjectLimit(RESEARCH_ID, 1);
      i = i + 1;
    }
  }

  private static void OnInit( ){
    RegisterResearchFinishedAction(RESEARCH_ID,  Transfer);
    RegisterResearchStartedAction(RESEARCH_ID,  ResearchStart);
    RegisterResearchCancelledAction(RESEARCH_ID,  ResearchCancel);
  }

}
