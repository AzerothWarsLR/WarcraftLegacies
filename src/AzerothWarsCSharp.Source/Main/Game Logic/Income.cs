using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;

namespace AzerothWarsCSharp.Source.Main.Game_Logic
{
  public class Income{

    //**CONFIG**
  
    public const float PERIOD = 1           ;//Note that changing this will not change the amount of gold players receive over time
  
    //**ENDCONFIG

    private static void AddPersonIncome(Person whichPerson ){
      float goldPerSecond = whichPerson.Faction.Income * PERIOD / 60;
      Faction personFaction = whichPerson.Faction;

      if (whichPerson == 0){
        BJDebugMsg("ERROR: Person of 0 given to function AddPersonIncome");
      }

      whichPerson.addGold(goldPerSecond);
    }

    private static void IncomeTimer( ){
      int i = 0;
      Person loopPerson;
      while(true){
        if ( i > MAX_PLAYERS){ break; }
        loopPerson = Person.ById(i);
        if (loopPerson != 0){
          AddPersonIncome(loopPerson);
        }
        i = i + 1;
      }
    }

    private static void OnInit( ){
      timer incomeTimer = CreateTimer();
      TimerStart(incomeTimer, PERIOD, true,  IncomeTimer);
    }

  }
}
