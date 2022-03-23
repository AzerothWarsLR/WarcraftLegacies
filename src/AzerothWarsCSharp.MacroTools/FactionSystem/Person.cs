using System;
using System.Collections.Generic;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  public sealed class Person
  {
    public static force Observers;
    public static event EventHandler<Person>? FactionChange;
    private static readonly Dictionary<int, Person> ById = new();

    private Faction? _faction; //Controls name, available objects, color, and icon
    private int _controlPointCount;
    private float _controlPointValue; //Gold per minute

    private float _partialGold; //Just used for income calculations

    private readonly Dictionary<int, int> _objectLimits = new();
    private readonly Dictionary<int, int> _objectLevels = new();

    public player Player
    {
      get;
      set;
    }

    public Faction Faction
    {
      get => _faction;
      set
      {
        Faction prevFaction;

        prevFaction = _faction;
        thistype.prevFaction = _faction;

        //Unapply old faction
        if (_faction != null)
        {
          _faction = 0;
          if (this.prevFaction != 0)
          {
            this.prevFaction.Person = 0; //Referential integrity
          }
        }

        //Apply new faction
        if (newFaction != 0)
        {
          if (newFaction.Person == 0)
          {
            SetPlayerColorBJ(this.p, newFaction.playCol, true);
            _faction = newFaction;
            //Enforce referential integrity
            if (newFaction.Person != this)
            {
              newFaction.Person = this;
            }
          }
          else
          {
            BJDebugMsg("Error: attempted to Person " + GetPlayerName(this.p) +
                       " to already occupied faction with name " + newFaction.name);
          }
        }

        thistype.triggerPerson = this;
        FactionChange.fire();
      }
    }

    public float ControlPointValue
    {
      get => _controlPointValue;
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException(
            $"Tried to assign a negative ControlPointValue value to + {GetPlayerName(this.p)}");
        }

        _controlPointValue = value;
      }
    }

    public int ControlPointCount
    {
      get => _controlPointCount;
      set
      {
        if (value < 0)
        {
          BJDebugMsg("ERROR: Tried to assign a negative ControlPoint counter to " + GetPlayerName(this.p));
        }

        _controlPointCount = value;
      }
    }

    public int GetObjectLevel(int obj)
    {
      return _objectLevels[obj];
    }

    public void SetObjectLevel(int obj, int level)
    {
      _objectLevels[obj] = level;
      SetPlayerTechResearched(Player, obj, level);
    }

    public int GetObjectLimit(int id)
    {
      return _objectLimits[id];
    }

    void SetObjectLimit(int id, int limit)
    {
      _objectLimits[id] = limit;
      this.SetObjectLevel(id, IMinBJ(GetPlayerTechCount(Player, id, true), limit));
      if (limit >= UNLIMITED)
      {
        SetPlayerTechMaxAllowed(Player, id, -1);
      }
      else if (limit <= 0)
      {
        SetPlayerTechMaxAllowed(Player, id, 0);
      }
      else
      {
        SetPlayerTechMaxAllowed(Player, id, limit);
      }
    }

    public void ModObjectLimit(int id, int limit)
    {
      SetObjectLimit(id, _objectLimits[id] + limit);
    }

    public void AddGold(float x)
    {
      var fullGold = (float)Math.Floor(x);
      var remainderGold = x - fullGold;

      SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD) + R2I(fullGold));
      _partialGold += remainderGold;

      while (true)
      {
        if (_partialGold < 1)
        {
          break;
        }

        _partialGold -= 1;
        SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD) + 1);
      }
    }

    public static Person GetFromId(int id)
    {
      type.byId[id];
    }

    public static Person ByHandle(player whichPlayer)
    {
      type.byId[GetPlayerId(whichPlayer)];
    }

    /// <summary>
    /// Register a <see cref="Person"/> to the Person system.
    /// </summary>
    public void Register(Person person)
    {
      ById[GetPlayerId(person.Player)] = person;
    }
    
    public Person(player player)
    {
      Player = player;
    }

    public static void Setup()
    {
      Observers = CreateForce();
    }
  }
}