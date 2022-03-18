namespace AzerothWarsCSharp.Source.Main.Libraries.MacroTools
{
  public static class ControlPoint{

  
    public static group ControlPoints = CreateGroup();
    ControlPoint[] CPData
    Event OnControlPointLoss
    Event OnControlPointOwnerChange

    private const int REGENERATION_ABILITY = FourCC(A0UT) ;//An ability that increases hit point regeneration
    private const int MAX_HITPOINTS = 10000 ;//All Control Points get given this many hitpoints
  


    private static thistype[] byIndex;
    private static Table byUnitType;
    private static Table byHandle;
    private static int count = 0;
    static thistype triggerControlPoint = 0;
    static player controlPointFormerOwner = null;

    float x
    float y
    float value;
    unit u
    player owner

    integer operator UnitType( ){
      return GetUnitTypeId(this.u);
    }

    string operator Name( ){
      return GetUnitName(this.u);
    }

    float operator X( ){
      return GetUnitX(this.u);
    }

    float operator Y( ){
      return GetUnitY(this.u);
    }

    unit operator Unit( ){
      ;.u;
    }

    Person operator OwningPerson( ){
      return Person.ByHandle(this.owner);
    }

    void changeOwner(player p ){
      Person person = Person.ByHandle(this.owner);

      if (person != 0){
        person.ControlPointValue = person.ControlPointValue - value;
        person.ControlPointCount = person.ControlPointCount - 1;
        GroupRemoveUnit(person.cpGroup, this.u);
      }

      thistype.triggerControlPoint = this;
      OnControlPointLoss.fire();

      thistype.controlPointFormerOwner = this.owner;
      this.owner = p;
      person = Person.ByHandle(this.owner);

      if (person != 0){
        person.ControlPointValue = person.ControlPointValue + value;
        person.ControlPointCount = person.ControlPointCount + 1;
        GroupAddUnit(person.cpGroup, this.u);
      }

      thistype.triggerControlPoint = this;
      OnControlPointOwnerChange.fire();
    }

    static thistype ByHandle(unit whichUnit ){
      ;type.byHandle[GetHandleId(whichUnit)];
    }

    static thistype ByUnitType(int unitType ){
      ;type.byUnitType[unitType];
    }

    static thistype GetHighestValueCP(Person person ){
      var i = 0;
      ControlPoint highestValueCP = 0;
      while(true){
        if ( i == thistype.count){ break; }
        if (thistype.byIndex[i].OwningPerson == person && thistype.byIndex[i].value > highestValueCP.value){
          highestValueCP = thistype.byIndex[i];
        }
        i = i + 1;
      }
      return highestValueCP;
    }

    ControlPoint (unit u, float value ){

      Person person = Person.ByHandle(GetOwningPlayer(u));

      this.x = GetUnitX(u);
      this.y = GetUnitY(u);
      this.u = u;
      this.owner = GetOwningPlayer(u);
      this.value = value;

      CPData[GetUnitId(u)] = this;

      GroupAddUnit(ControlPoints,u);
      GroupAddUnit(person.cpGroup, u);

      BlzSetUnitMaxHP(u, MAX_HITPOINTS);
      //call UnitAddAbility(u, REGENERATION_ABILITY)
      SetUnitLifePercentBJ(u, 80);

      OwningPerson.ControlPointValue = OwningPerson.ControlPointValue + this.value;
      OwningPerson.ControlPointCount = OwningPerson.ControlPointCount + 1;

      thistype.byUnitType[GetUnitTypeId(u)] = this;
      thistype.byHandle[GetHandleId(u)] = this;
      thistype.byIndex[thistype.count] = this;
      thistype.count = count + 1;

      ;;
    }

    private static void onInit( ){
      thistype.byUnitType = Table.create();
      thistype.byHandle = Table.create();
    }

    void destroy( ){
      RemoveUnit(this.u);
      OwningPerson.ControlPointValue = OwningPerson.ControlPointValue - value*-1;
      OwningPerson.ControlPointCount = OwningPerson.ControlPointCount - 1;
      this.deallocate();
    }


    static player GetControlPointPreviousOwner( ){
      return controlPointFormerOwner;
    }

    static ControlPoint GetTriggerControlPoint( ){
      return triggerControlPoint;
    }


    private static void CPChangesOwner( ){
      unit u = GetTriggerUnit();
      var ui = GetUnitUserData(u);
      player p = GetTriggerPlayer();

      if (CPData[ui] != 0){
        CPData[ui].changeOwner(p);
      }

      u = null;
      p = null;
    }

    //Note that the Init function currently enumerates across every single unit on the map, then checks them for a Control Point buff before initializing them as a CP
    //This is not a good way to do this, considering that we know which units are CPs before the map is even compiled
    public static void Setup( ){
      group g;
      trigger trig = CreateTrigger();

      PlayerUnitEventAddAction(EVENT_PLAYER_UNIT_CHANGE_OWNER,  CPChangesOwner) ;//TODO: use filtered events

      OnControlPointLoss = Event.create();
      OnControlPointOwnerChange = Event.create();
    }

  }
}
