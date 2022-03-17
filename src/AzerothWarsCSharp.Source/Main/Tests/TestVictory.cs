namespace AzerothWarsCSharp.Source.Main.Tests
{
  public class TestVictory{


    void Run( ){
      group tempGroup = CreateGroup();
      unit u;
      BlzGroupAddGroupFast(ControlPoints, tempGroup);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null || GameWon == true){ break; }
        SetUnitOwner(u, Player(0), true);
        GroupRemoveUnit(tempGroup, u);
      }
      u = null;
    }

    private static void onInit( ){
      thistype.create("victory");
    }


  }
}
