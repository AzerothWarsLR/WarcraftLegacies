using System;
using System.Collections.Generic;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  public sealed class Person
  {
    public static event EventHandler<PersonFactionChangeEventArgs>? FactionChange;
    private static readonly Dictionary<int, Person> ById = new();

    private Faction? _faction;
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

    /// <summary>
    /// Controls name, available objects, color, and icon.
    /// </summary>
    public Faction? Faction
    {
      get => _faction;
      set
      {
        Faction prevFaction = Faction;
        
        //Unapply old faction
        if (_faction != null)
        {
          _faction = null;
          if (prevFaction != null)
          {
            prevFaction.Person = null; //Referential integrity
          }
        }

        //Apply new faction
        if (value != null)
        {
          if (value.Person == null)
          {
            SetPlayerColorBJ(Player, value.PlayerColor, true);
            _faction = value;
            //Enforce referential integrity
            if (value.Person != this)
            {
              value.Person = this;
            }
          }
          else
          {
            BJDebugMsg("Error: attempted to Person " + GetPlayerName(Player) +
                       " to already occupied faction with name " + value.Name);
          }
        }

        FactionChange?.Invoke(this, new PersonFactionChangeEventArgs(this, prevFaction));
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
            $"Tried to assign a negative ControlPointValue value to + {GetPlayerName(this.Player)}");
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
          throw new ArgumentOutOfRangeException(
            $"Tried to assign a negative {nameof(ControlPointCount)} to + {GetPlayerName(Player)}");
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

    public void SetObjectLimit(int id, int limit)
    {
      _objectLimits[id] = limit;
      SetObjectLevel(id, IMinBJ(GetPlayerTechCount(Player, id, true), limit));
      switch (limit)
      {
        case >= Faction.UNLIMITED:
          SetPlayerTechMaxAllowed(Player, id, -1);
          break;
        case <= 0:
          SetPlayerTechMaxAllowed(Player, id, 0);
          break;
        default:
          SetPlayerTechMaxAllowed(Player, id, limit);
          break;
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
      return ById[id];
    }

    public static Person ByHandle(player whichPlayer)
    {
      return ById[GetPlayerId(whichPlayer)];
    }

    /// <summary>
    /// Register a <see cref="Person"/> to the Person system.
    /// </summary>
    public static void Register(Person person)
    {
      ById[GetPlayerId(person.Player)] = person;
    }
    
    public Person(player player)
    {
      Player = player;
    }
  }
}