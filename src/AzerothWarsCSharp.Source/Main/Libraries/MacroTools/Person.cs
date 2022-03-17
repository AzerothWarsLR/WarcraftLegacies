namespace AzerothWarsCSharp.Source.Main.Libraries.MacroTools
{
  public class Person
  {
    private force Observers;
    private Event OnPersonFactionChange;
    private static thistype[] byId;
    readonly static thistype triggerPerson = 0         ;//Used in event response triggers
    readonly static Faction prevFaction = 0            ;//Used in OnPersonFactionChange event response for the previous faction

    private Faction faction                  ;//Controls name, available objects, color, and icon
    private int controlPointCount = 0;
    private float controlPointValue = 0        ;//Gold per minute


    private float partialGold = 0              ;//Just used for income calculations
    readonly group cpGroup                    ;//Group of control point units this person owns

    private Table objectLimits;
    private Table objectLevels;

    public player Player => this.Player;

    public Faction Faction => this.faction;

    void operator Faction=(Faction newFaction ){
      int i = 0;
      Faction prevFaction;

      this.prevFaction = this.faction;
      thistype.prevFaction = this.faction;

      //Unapply old faction
      if (this.faction != 0){
        this.faction = 0;
        if (this.prevFaction != 0){
          this.prevFaction.Person = 0 ;//Referential integrity
        }
      }

      //Apply new faction
      if (newFaction != 0){
        if (newFaction.Person == 0){
          SetPlayerColorBJ(this.p, newFaction.playCol, true);
          this.faction = newFaction;
          //Enforce referential integrity
          if (newFaction.Person != this){
            newFaction.Person = this;
          }
        }else {
          BJDebugMsg("Error: attempted to Person " + GetPlayerName(this.p) + " to already occupied faction with name " + newFaction.name);
        }
      }

      thistype.triggerPerson = this;
      OnPersonFactionChange.fire();
    }

    float operator ControlPointValue( ){
      ;.controlPointValue;
    }

    void operator ControlPointValue=(float value ){
      if ((value < 0)){
        BJDebugMsg("ERROR: Tried to assign a negative ControlPointValue value to " + GetPlayerName(this.p));
      }
      this.controlPointValue = value;
    }

    integer operator ControlPointCount( ){
      ;.controlPointCount;
    }

    void operator ControlPointCount=(int value ){
      if ((value < 0)){
        BJDebugMsg("ERROR: Tried to assign a negative ControlPoint counter to " + GetPlayerName(this.p));
      }
      this.controlPointCount = value;
    }

    integer GetObjectLevel(int object ){
      ;.objectLevels[object];
    }

    void SetObjectLevel(int object, int level ){
      this.objectLevels[object] = level;
      SetPlayerTechResearched(this.Player, object, level);
    }

    integer GetObjectLimit(int id ){
      ;.objectLimits[id];
    }

    void SetObjectLimit(int id, int limit ){
      this.objectLimits[id] = limit;
      this.SetObjectLevel(id, IMinBJ(GetPlayerTechCount(this.Player, id, true), limit));
      if (limit >= UNLIMITED){
        SetPlayerTechMaxAllowed(this.Player, id, -1);
      }else if (limit <= 0){
        SetPlayerTechMaxAllowed(this.Player, id, 0);
      }else {
        SetPlayerTechMaxAllowed(this.Player, id, limit);
      }
    }

    public void ModObjectLimit(int id, int limit ){
      this.SetObjectLimit(id, this.objectLimits[id] + limit);
    }

    void addGold(float x ){
      float fullGold = floor(x);
      float remainderGold = x - fullGold;

      SetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD) + R2I(fullGold));
      this.partialGold = this.partialGold + remainderGold;

      while(true){
        if ( this.partialGold < 1){ break; }
        this.partialGold = this.partialGold - 1;
        SetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD) + 1);
      }
    }

    private void nullFaction( ){

    }

    void destroy( ){
      DestroyGroup(this.cpGroup);

      thistype.byId[GetPlayerId(this.p)] = 0;
      this.p = null;
      this.cpGroup = null;

      this.deallocate();
    }

    static thistype ById(int id ){
      ;type.byId[id];
    }

    public static Person ByHandle(player whichPlayer ){
      ;type.byId[GetPlayerId(whichPlayer)];
    }

    Person (player p ){


      this.p = p;
      this.cpGroup = CreateGroup();
      thistype.byId[GetPlayerId(p)] = this;
      this.objectLimits = Table.create();
      this.objectLevels = Table.create();

      ;;
    }



    static Faction GetChangingPersonPrevFaction( ){
      return Person.prevFaction;
    }

    static Person GetTriggerPerson( ){
      return Person.triggerPerson;
    }

    private static void OnInit( ){
      Observers = CreateForce();
      OnPersonFactionChange = Event.create();
    }

  }
}
