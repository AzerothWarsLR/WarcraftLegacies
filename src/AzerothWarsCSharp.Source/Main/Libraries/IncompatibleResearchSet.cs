namespace AzerothWarsCSharp.Source.Main.Libraries
{
  public class IncompatibleResearchSet{

    //An IncompatibleResearchSet is a list of Researchs which are mutually exclusive with each other
    //This means that if one of these Researchs is started, the other 2 are disabled
    //and only re-enabled if the first research is cancelled

  
    private const int BIG_NUMBER = 5000  ;//This is here to disable and enable techs via addition and subtraction
  


    private static IncompatibleResearchSet[] setList;
    private static int setCount = 0;

    private int[] researches[10];
    private int researchCount;

    void add(int researchId ){
      this.researches[researchCount] = researchId;
      this.researchCount = this.researchCount + 1;
    }

    void disableResearches( ){
      int i = 0;
      Person p = Person.ByHandle(GetTriggerPlayer());
      while(true){
        if ( this.researches[i] == 0){ break; }
        if (this.researches[i] != GetResearched()){
          p.ModObjectLimit(this.researches[i], -BIG_NUMBER);
        }
        i = i + 1;
      }
    }

    void enableResearches( ){
      int i = 0;
      Person p = Person.ByHandle(GetTriggerPlayer());
      while(true){
        if ( this.researches[i] == 0){ break; }
        if (this.researches[i] != GetResearched()){
          p.ModObjectLimit(this.researches[i], BIG_NUMBER);
        }
        i = i + 1;
      }
    }

    //Flag is true for START, and false for CANCEL
    static void doResearch(boolean flag ){
      int i = 0;
      int j = 0;
      int research = GetResearched();
      while(true){
        if ( thistype.setList[i] == 0){ break; }
        j = 0;
        while(true){
          if ( thistype.setList[i].researches[j] == 0){ break; }
          if (thistype.setList[i].researches[j] == research){
            if (flag == true){
              thistype.setList[i].disableResearches();
            }else {
              thistype.setList[i].enableResearches();
            }
          }
          j = j + 1;
        }
        i = i + 1;
      }
    }

    IncompatibleResearchSet ( ){

      thistype.setList[thistype.setCount] = this;
      thistype.setCount = thistype.setCount + 1;
      ;;
    }


    private static void ResearchStart( ){
      IncompatibleResearchSet.doResearch(true);
    }

    private static void ResearchCancel( ){
      IncompatibleResearchSet.doResearch(false);
    }

    private static void OnInit( ){
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_START,  ResearchStart) ;//TODO: use filtered events
      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_RESEARCH_CANCEL,  ResearchCancel) ;//TODO: use filtered events
    }

  }
}
