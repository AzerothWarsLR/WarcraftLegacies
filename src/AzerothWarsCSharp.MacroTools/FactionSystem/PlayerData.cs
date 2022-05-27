using System;
using System.Collections.Generic;
using static War3Api.Common;


namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  /// <summary>
  /// Provides extra information about players that is not already tracked by the Warcraft 3 engine.
  /// </summary>
  internal sealed class PlayerData
  {
    private static readonly Dictionary<int, PlayerData> ById = new();
    private readonly Dictionary<int, int> _objectLevels = new();

    private readonly Dictionary<int, int> _objectLimits = new();
    private int _controlPointCount;
    private float _baseIncome; //Gold per minute

    private Faction? _faction;

    private float _partialGold; //Just used for income calculations

    public PlayerData(player player)
    {
      Player = player;
    }

    public player Player { get; }

    /// <summary>
    ///   Controls name, available objects, color, and icon.
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
            prevFaction.Player = null; //Referential integrity
        }

        //Apply new faction
        if (value != null)
        {
          if (value.Player == null)
          {
            Player.SetColor(value.PlayerColor, true);
            _faction = value;
            //Enforce referential integrity
            if (value.Player != Player) 
              value.Player = Player;
          }
          else
          {
            throw new Exception("Attempted to Person " + GetPlayerName(Player) +
                       " to already occupied faction with name " + value.Name);
          }
        }

        FactionChange?.Invoke(this, new PlayerFactionChangeEventArgs(Player, prevFaction));
      }
    }

    /// <summary>
    ///   Gold per second gained from all sources.
    /// </summary>
    public float TotalIncome => BaseIncome + BonusIncome;

    /// <summary>
    ///   Gold per second gained from secondary sources like Forsaken's plagued buildings.
    /// </summary>
    public float BonusIncome { get; set; }

    /// <summary>
    ///   Gold per second gained from primary sources like Control Points.
    /// </summary>
    public float BaseIncome
    {
      get => _baseIncome;
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(
            $"Tried to assign a negative {nameof(BaseIncome)} value to {GetPlayerName(Player)}.");

        _baseIncome = value;
      }
    }

    public int ControlPointCount
    {
      get => _controlPointCount;
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(
            $"Tried to assign a negative {nameof(ControlPointCount)} to + {GetPlayerName(Player)}");

        _controlPointCount = value;
      }
    }

    public static event EventHandler<PlayerFactionChangeEventArgs>? FactionChange;

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
      return _objectLimits.TryGetValue(id, out var limit) ? limit : 0;
    }

    private void SetObjectLimit(int id, int limit)
    {
      _objectLimits[id] = limit;
      SetObjectLevel(id, Math.Min(GetPlayerTechCount(Player, id, true), limit));
      if (limit >= Faction.UNLIMITED)
        SetPlayerTechMaxAllowed(Player, id, -1);
      else if (limit <= 0)
        SetPlayerTechMaxAllowed(Player, id, 0);
      else
        SetPlayerTechMaxAllowed(Player, id, limit);
    }

    public void ModObjectLimit(int id, int limit)
    {
      SetObjectLimit(id, GetObjectLimit(id) + limit);
    }

    public void AddGold(float x)
    {
      var fullGold = (float) Math.Floor(x);
      var remainderGold = x - fullGold;

      SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD,
        GetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD) + R2I(fullGold));
      _partialGold += remainderGold;

      while (true)
      {
        if (_partialGold < 1) break;

        _partialGold -= 1;
        SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD, GetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD) + 1);
      }
    }

    /// <summary>
    ///   Retrieves the <see cref="PlayerData" /> object which contains information about the given <see cref="player" />.
    /// </summary>
    public static PlayerData ByHandle(player whichPlayer)
    {
      if (ById.TryGetValue(GetPlayerId(whichPlayer), out var person)) return person;

      var newPerson = new PlayerData(whichPlayer);
      Register(newPerson);
      return newPerson;
    }

    /// <summary>
    ///   Register a <see cref="PlayerData" /> to the Person system.
    /// </summary>
    public static void Register(PlayerData playerData)
    {
      ById.Add(GetPlayerId(playerData.Player), playerData);
    }
  }
}