using System;

namespace AzerothWarsCSharp.Source.Main.Libraries.MacroTools
{
  public class Person
  {
    public static force Observers;
    public static event EventHandler<Person>? OnPersonFactionChange;
    private static thistype[] byId;
    readonly static thistype triggerPerson = 0         ;//Used in event response triggers
    readonly static Faction prevFaction = 0            ;//Used in OnPersonFactionChange event response for the previous faction

    private Faction faction                  ;//Controls name, available objects, color, and icon
    private int controlPointCount;
    private float controlPointValue;//Gold per minute


    private float partialGold;//Just used for income calculations
    readonly group cpGroup                    ;//Group of control point units this person owns

    private Table objectLimits;
    private Table objectLevels;

    public player Player => Player;

    public Faction Faction
    {
      get
      {
        return faction;
      }
      public set
      {
        var i = 0;
        Faction prevFaction;

        this.prevFaction = faction;
        thistype.prevFaction = faction;

        //Unapply old faction
        if (faction != 0){
          faction = 0;
          if (this.prevFaction != 0){
            this.prevFaction.Person = 0 ;//Referential integrity
          }
        }

        //Apply new faction
        if (newFaction != 0){
          if (newFaction.Person == 0){
            SetPlayerColorBJ(this.p, newFaction.playCol, true);
            faction = newFaction;
            //Enforce referential integrity
            if (newFaction.Person != this){
              newFaction.Person = this;
            }
          } else {
            BJDebugMsg("Error: attempted to Person " + GetPlayerName(this.p) + " to already occupied faction with name " + newFaction.name);
          }
        }

        thistype.triggerPerson = this;
        OnPersonFactionChange.fire();
      }
    }

    public float ControlPointValue
    {
      get => controlPointValue;
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException($"Tried to assign a negative ControlPointValue value to + {GetPlayerName(this.p)}");
        }
        controlPointValue = value;
      }
    }

    integer operator ControlPointCount( ){
      ;.controlPointCount;
    }

    void operator ControlPointCount=(int value ){
      if ((value < 0)){
        BJDebugMsg("ERROR: Tried to assign a negative ControlPoint counter to " + GetPlayerName(this.p));
      }
      controlPointCount = value;
    }

    integer GetObjectLevel(int object ){
      ;.objectLevels[object];
    }

    public void SetObjectLevel(int obj, int level){
      objectLevels[obj] = level;
      SetPlayerTechResearched(Player, obj, level);
    }

    public int GetObjectLimit(int id ){
      ;.objectLimits[id];
    }

    void SetObjectLimit(int id, int limit ){
      objectLimits[id] = limit;
      this.SetObjectLevel(id, IMinBJ(GetPlayerTechCount(Player, id, true), limit));
      if (limit >= UNLIMITED){
        SetPlayerTechMaxAllowed(Player, id, -1);
      }else if (limit <= 0){
        SetPlayerTechMaxAllowed(Player, id, 0);
      }else {
        SetPlayerTechMaxAllowed(Player, id, limit);
      }
    }

    public void ModObjectLimit(int id, int limit ){
      SetObjectLimit(id, objectLimits[id] + limit);
    }

    public void AddGold(float x ){
      float fullGold = floor(x);
      var remainderGold = x - fullGold;

      SetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD) + R2I(fullGold));
      partialGold = partialGold + remainderGold;

      while(true){
        if ( partialGold < 1){ break; }
        partialGold = partialGold - 1;
        SetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(p, PLAYER_STATE_RESOURCE_GOLD) + 1);
      }
    }

    private void nullFaction( ){

    }

    void destroy( ){
      DestroyGroup(cpGroup);

      thistype.byId[GetPlayerId(this.p)] = 0;
      this.p = null;
      cpGroup = null;

      this.deallocate();
    }

    static thistype ById(int id ){
      ;type.byId[id];
    }

    public static Person? ByHandle(player whichPlayer ){
      ;type.byId[GetPlayerId(whichPlayer)];
    }

    Person (player p ){


      this.p = p;
      cpGroup = CreateGroup();
      thistype.byId[GetPlayerId(p)] = this;
      objectLimits = Table.create();
      objectLevels = Table.create();

      ;;
    }



    static Faction GetChangingPersonPrevFaction( ){
      return prevFaction;
    }

    static Person GetTriggerPerson( ){
      return triggerPerson;
    }

    public static void Setup( ){
      Observers = CreateForce();
      OnPersonFactionChange = Event.create();
    }

  }
}
