namespace AzerothWarsCSharp.Source.Main.Tests
{
  public class Test{

  
    private const string COMMAND = "-test ";
  


    private static StringTable byName;
    private string name;

    private stub void Run( ){

    }

    void Assert(boolean bool, string errormsg ){
      if (!bool){
        BJDebugMsg("Test" + this.name + " failed. " + errormsg);
      }
    }

    static void ExecuteTestCommand( ){
      string enteredString = GetEventPlayerChatString();
      string parameter = SubString(enteredString, StringLength(COMMAND), StringLength(enteredString));
      if (!AreCheatsActive){
        return;
      }
      Test(thistype.byName[parameter]).Run();
    }

    thistype (string name ){

      trigger trig;
      int i = 0;
      this.name = name;

      trig = CreateTrigger();
      while(true){
        if ( i > MAX_PLAYERS){ break; }
        TriggerRegisterPlayerChatEvent( trig, Player(i), COMMAND + this.name, false );
        i = i + 1;
      }
      TriggerAddCondition( trig, ( thistype.ExecuteTestCommand) );
      thistype.byName[name] = this;

      ;;
    }

    private static void onInit( ){
      thistype.byName = StringTable.create();
    }


  }
}
