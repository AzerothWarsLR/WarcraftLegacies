using System;
using System.Collections.Generic;
using static War3Api.Common;
using static War3Api.Blizzard;

namespace AzerothWarsCSharp.Source.Libraries
{
  /// <summary>
  /// A collection of object limits, object limits, quests, etc.
  /// Players play the game by controlling a particular Faction.
  /// </summary>
  public class Faction
  {
    public static int UNLIMITED { get; } = 200;

    public event EventHandler<FactionTeamChangedEventArgs> TeamChanged;
    public event EventHandler<FactionEventArgs> ChangesPerson;
    public event EventHandler<FactionEventArgs> ObjectLevelChanged;
    public event EventHandler<FactionEventArgs> IncomeChanged;
    public event EventHandler<FactionEventArgs> WeightChanged;
    public event EventHandler<FactionEventArgs> Destroyed;
    public event EventHandler<FactionEventArgs> NameChanged;
    public event EventHandler<FactionEventArgs> IconChanged;
    public static event EventHandler<FactionEventArgs> FactionCreated;

    public Faction(
      string name, playercolor playercolor, string prefixColor, string icon, int weight,
      Dictionary<int, int> objectLevels = null, Dictionary<int, int> objectLimits = null)
    {
      Name = name;
      PlayerColor = playercolor;
      PrefixColor = prefixColor;
      Icon = icon;
      Weight = weight;
      _objectLimits = objectLimits ?? _objectLimits;
      _objectLevels = objectLevels ?? _objectLevels;
      _all.Add(this);
      FactionCreated?.Invoke(this, new FactionEventArgs(this));
    }

    /// <summary>
    /// Returns the Faction being controlled by this player.
    /// </summary>
    /// <param name="whichPlayer"></param>
    /// <returns></returns>
    public static Faction ByPlayerHandle(player whichPlayer)
    {
      throw new NotImplementedException();
    }
    /// <summary>
    /// Returns the faction with this name.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public static Faction ByName(string name)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// A list of all Factions in the game.
    /// </summary>
    /// <returns></returns>
    public static List<Faction> GetAll()
    {
      return new List<Faction>(_all);
    }

    /// <summary>
    /// A research that is enabled for all players whenever this Faction is occupied.
    /// </summary>
    public int PresenceResearch
    {
      get;
      set;
    }

    /// <summary>
    /// A research that is enabled for all players whenever this Faction is not occupied.
    /// </summary>
    public int AbsenceResearch
    {
      get;
      set;
    }

    /// <summary>
    /// Unlike native gold, this can be fractional.
    /// </summary>
    public double Gold
    {
      get
      {
        return GetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD) + _excessGold;
      }
      set
      {
        double newTotalGold = value + _excessGold;
        int truncatedGold = (int)Math.Truncate(newTotalGold);
        _excessGold = 1 - truncatedGold;
        SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD, truncatedGold);
      }
    }

    /// <summary>
    /// An estimation of this faction's techtree strength.
    /// </summary>
    public int Weight
    {
      get
      {
        return _weight;
      }
      set
      {
        _weight = value;
        WeightChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    /// <summary>
    /// Gold earned per second.
    /// </summary>
    /// <returns></returns>
    public double Income
    {
      get
      {
        return _income;
      }
      set
      {
        _income = value;
        IncomeChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    /// <summary>
    /// Which Team this Faction currently belongs to. Determines a player's allies.
    /// </summary>
    public Team Team
    {
      get
      {
        return _team;
      }
      set
      {
        _team = value;
        TeamChanged?.Invoke(this, new FactionTeamChangedEventArgs());
      }
    }

    /// <summary>
    /// Faction's name that appears in user interface.
    /// </summary>
    public string Name
    {
      get
      {
        return _name;
      }
      set
      {
        _name = value;
        NameChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }

    /// <summary>
    /// The string that goes before the faction's name to color it.
    /// </summary>
    public string PrefixColor
    {
      get;
    }

    /// <summary>
    /// Faction's name with a color prefix.
    /// </summary>
    public string ColoredName
    {
      get
      {
        return PrefixColor + Name;
      }
    }

    /// <summary>
    /// The icon that renders on the multiboard.
    /// </summary>
    public string Icon { 
      get {
        return _icon;
      } 
      set
      {
        _icon = value;
        IconChanged?.Invoke(this, new FactionEventArgs(this));
      }
    }
    
    /// <summary>
    /// Number of Control Points this player has.
    /// </summary>
    public int ControlPoints { get; private set; }

    /// <summary>
    /// Player currently occupying this Faction.
    /// </summary>
    public player Player
    {
      get
      {
        return _player;
      }
      set
      {
        //Unapply from previous player
        if (_player != null)
        {
          foreach (KeyValuePair<int, int> entry in _objectLimits)
          {
            SetPlayerTechMaxAllowed(_player, entry.Key, 0);
          }
        }
        _player = value;
        //Apply to new player
        SetPlayerColorBJ(value, PlayerColor, true);
        foreach(KeyValuePair<int, int> entry in _objectLimits)
        {
          SetPlayerTechMaxAllowed(value, entry.Key, entry.Value);
        }
      }
    }
    private player _player;

    /// <summary>
    /// Quest that pops up for this Faction early on as an introduction.
    /// </summary>
    public QuestEx StartingQuest
    {
      get;
      set;
    }

    /// <summary>
    /// Music that plays when this team wins the game.
    /// </summary>
    public string VictoryMusic { get; set; }

    /// <summary>
    /// Whether or not this Faction can voluntarily change teams.
    /// </summary>
    public virtual bool CanVoluntarilyChangeTeams {
      get
      {
        return true;
      }
    }

    /// <summary>
    /// The WC3 player color of this faction in-game.
    /// </summary>
    public playercolor PlayerColor
    {
      get
      {
        return _playercolor;
      }
      set
      {
        _playercolor = value;
        SetPlayerColor(Player, _playercolor);
      }
    }
    private playercolor _playercolor;

    /// <summary>
    /// A list of all of the units, heroes, structures, and researches this faction can do.
    /// </summary>
    public List<int> ObjectList { get; } = new();

    /// <summary>
    /// How many of this object this faction can train, build, or research.
    /// </summary>
    /// <param name="factionObject"></param>
    /// <returns></returns>
    public int GetObjectLimit(int id)
    {
      return _objectLimits[id];
    }

    /// <summary>
    /// Returns the level of a research.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public int GetObjectLevel(int id)
    {
      return _objectLevels[id];
    }

    /// <summary>
    /// Sets the research level of an object to a value.
    /// </summary>
    public void SetObjectLevel(int obj, int level)
    {
      _objectLevels[obj] = level;
    }

    /// <summary>
    /// Changes this Faction's research or unit limit by a provided value.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="limit"></param>
    public void ModObjectLimit(int obj, int limit)
    {
      _objectLimits[obj] = limit;
    }

    /// <summary>
    /// Causes a Faction's player to lose all units and resources.
    /// </summary>
    public void Obliterate()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Causes a Faction's player to distribute all units and resources amongst allies.
    /// </summary>
    public void Leave()
    {
      throw new NotImplementedException();
    }

    private double _excessGold = 0;
    private Team _team;
    private double _income = 0;
    private int _weight;
    private string _name;
    private string _icon;
    private static readonly HashSet<Faction> _all = new();
    private Dictionary<int, int> _objectLimits = new();
    private Dictionary<int, int> _objectLevels = new();
  }
}