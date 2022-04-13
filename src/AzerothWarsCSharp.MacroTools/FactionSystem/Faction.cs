using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Events;
using static War3Api.Common;
using static War3Api.Blizzard;
using static AzerothWarsCSharp.MacroTools.Libraries.GeneralHelpers;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  /// <summary>
  ///   Represents a faction in the Azeroth Wars universe, such as Lordaeron, Stormwind, or the Frostwolf Clan.
  ///   Governs techtrees and quests.
  /// </summary>
  public sealed class Faction
  {
    /// <summary>
    ///   Signifies unlimited unit production.
    /// </summary>
    public const int UNLIMITED = 200;

    /// <summary>
    ///   The gold cost value of a hero.
    /// </summary>
    private const int HERO_COST = 100; //For refunding

    /// <summary>
    ///   How much gold and lumber is refunded from units that get refunded when a player leaves.
    /// </summary>
    private const float REFUND_PERCENT = 100;

    /// <summary>
    ///   How much experience is transferred from heroes that leave the game.
    /// </summary>
    private const float XP_TRANSFER_PERCENT = 100;

    private readonly int _defeatedResearch;

    private readonly Dictionary<int, int> _objectLevels = new();

    private readonly Dictionary<int, int> _objectLimits = new();
    private readonly List<Power> _powers = new();
    private readonly List<QuestData> _quests = new();

    private readonly Dictionary<int, int> _unitTypeByCategory = new();

    private string _icon;

    private string _name;

    private Person? _person;

    private string _prefixCol;

    private ScoreStatus _scoreStatus = ScoreStatus.Undefeated;
    private Team? _team;

    private int _undefeatedResearch;

    private int _xp; //Stored by DistributeUnits and given out again by DistributeResources

    /// <summary>
    ///   Fired when the <see cref="Faction" /> gains a <see cref="Power" />.
    /// </summary>
    public EventHandler<FactionPowerEventArgs>? PowerAdded;

    public EventHandler<Faction> ScoreStatusChanged;

    public Faction(string name, playercolor playerColor, string prefixCol, string icon)
    {
      _name = name;
      PlayerColor = playerColor;
      _prefixCol = prefixCol;
      _icon = icon;
    }

    public int StartingGold { get; set; }

    public int StartingLumber { get; set; }

    public playercolor PlayerColor { get; }

    public float Gold
    {
      get => I2R(GetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD));
      set => SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD, R2I(value));
    }

    public float Lumber
    {
      get => I2R(GetPlayerState(Player, PLAYER_STATE_RESOURCE_LUMBER));
      set => SetPlayerState(Player, PLAYER_STATE_RESOURCE_LUMBER, R2I(value));
    }

    public ScoreStatus ScoreStatus
    {
      get => _scoreStatus;
      set
      {
        var i = 0;
        //Change defeated/undefeated researches
        if (value == ScoreStatus.Defeated)
          while (true)
          {
            if (i == bj_MAX_PLAYERS) break;

            SetPlayerTechResearched(Player(i), _defeatedResearch, 1);
            SetPlayerTechResearched(Player(i), _undefeatedResearch, 0);
            i += 1;
          }

        //Remove player from game if necessary
        if (value == ScoreStatus.Defeated && Player != null)
        {
          RemovePlayer(Player, PLAYER_GAME_RESULT_DEFEAT);
          SetPlayerState(Player, PLAYER_STATE_OBSERVER, 1);
          Leave();
        }

        _scoreStatus = value;
        StatusChanged?.Invoke(this, this);
        ScoreStatusChanged?.Invoke(this, this);
      }
    }

    /// <summary>
    ///   Which <see cref="Team" /> this <see cref="Faction" /> belongs to.
    /// </summary>
    public Team? Team
    {
      get => _team;
      set
      {
        if (_team != null)
        {
          var previousTeam = _team;
          _team.RemoveFaction(this);
          _team = null;
          TeamLeft?.Invoke(this, new FactionChangeTeamEventArgs(this, previousTeam));
        }

        if (value != null)
        {
          value.AddFaction(this);
          _team = value;
          TeamJoin?.Invoke(this, this);
          JoinedTeam?.Invoke(this, this);
        }
      }
    }

    /// <summary>
    ///   How much gold this <see cref="Faction" /> receives per minute if occupied by a player.
    /// </summary>
    public float Income => _person.ControlPointValue;

    public string ColoredName => PrefixCol + _name + "|r";

    public string PrefixCol
    {
      get => _prefixCol;
      set
      {
        _prefixCol = value;
        NameChanged?.Invoke(this, new FactionNameChangeEventArgs(this, null));
      }
    }

    public string Name
    {
      get => _name;
      set
      {
        var formerName = _name;
        _name = value;
        NameChanged?.Invoke(this, new FactionNameChangeEventArgs(this, formerName));
      }
    }

    public string Icon
    {
      get => _icon;
      set
      {
        _icon = value;
        IconChanged?.Invoke(this, this);
      }
    }

    /// <summary>
    ///   The <see cref="player" /> currently occupying this <see cref="Faction" />.
    /// </summary>
    public player? Player => _person?.Player;

    public Person? Person
    {
      get => _person;
      set
      {
        if (Player != null)
        {
          Team?.UnallyPlayer(Player);
          HideAllQuests();
          UnapplyObjects();
        }

        _person = value;
        //Maintain referential integrity
        //Todo: this seems a bit silly
        if (value == null) return;

        if (value.Faction != this) value.Faction = this;

        Team?.AllyPlayer(value.Player);
        ApplyObjects();
        ShowAllQuests();
      }
    }

    public QuestData? StartingQuest { get; set; }

    /// <summary>
    ///   This research is enabled for every player while this <see cref="Faction" /> is not defeated.
    /// </summary>
    public int UndefeatedResearch
    {
      set
      {
        if (_undefeatedResearch == 0)
        {
          _undefeatedResearch = value;
          foreach (var player in GetAllPlayers()) SetPlayerTechResearched(player, _undefeatedResearch, 1);
        }
      }
      get => _undefeatedResearch;
    }

    /// <summary>
    ///   This research is enabled for every player while this <see cref="Faction" /> is defeated.
    /// </summary>
    public int DefeatedResearch
    {
      init
      {
        if (_defeatedResearch == 0)
        {
          _defeatedResearch = value;
          foreach (var player in GetAllPlayers()) SetPlayerTechResearched(player, _defeatedResearch, 0);
        }
      }
    }

    /// <summary>
    ///   Fires when the <see cref="Faction" /> joins a new <see cref="Team" />.
    /// </summary>
    public event EventHandler<Faction>? JoinedTeam;

    /// <summary>
    ///   Fires when the <see cref="Faction" /> changes its name.
    /// </summary>
    public event EventHandler<FactionNameChangeEventArgs>? NameChanged;

    public static event EventHandler<FactionChangeTeamEventArgs>? TeamLeft;
    public static event EventHandler<Faction>? TeamJoin;
    public static event EventHandler<Faction>? GameLeave;
    public static event EventHandler<Faction>? IconChanged;
    public static event EventHandler<Faction>? StatusChanged;

    /// <summary>
    ///   Returns all unit types which this <see cref="Faction" /> can only train a limited number of.
    /// </summary>
    public IEnumerable<int> GetLimitedObjects()
    {
      return _objectLimits.Keys;
    }

    /// <summary>
    ///   Returns the maximum number of times the Faction can train a unit, build a building, or research a research.
    /// </summary>
    /// <param name="whichObject">The object ID of a unit, building, or research.</param>
    public int GetObjectLimit(int whichObject)
    {
      return _objectLimits[whichObject];
    }

    //Adds this Faction's object limits and levels to its active Person
    private void ApplyObjects()
    {
      foreach (var (key, value) in _objectLimits) Person?.ModObjectLimit(key, value);

      foreach (var (key, value) in _objectLevels) Person?.SetObjectLevel(key, value);
    }

    //Removes this Faction's object limits and levels from its active Person
    private void UnapplyObjects()
    {
      foreach (var (key, value) in _objectLimits) Person?.ModObjectLimit(key, -value);

      foreach (var (key, value) in _objectLevels) Person?.SetObjectLevel(key, 0);
    }

    /// <summary>
    ///   Adds a <see cref="Power" /> to this <see cref="Faction" />.
    /// </summary>
    public void AddPower(Power power)
    {
      _powers.Add(power);
      PowerAdded?.Invoke(this, new FactionPowerEventArgs(this, power));
    }

    /// <summary>
    ///   Unallies the <see cref="Faction" /> from all of its allies, creating a new <see cref="Team" />
    ///   based on its name.
    /// </summary>
    public void Unally()
    {
      if (Team.PlayerCount > 1)
      {
        string newTeamName = Name + " Pact";
        if (FactionManager.TeamWithNameExists(newTeamName))
        {
          Team = FactionManager.GetTeamByName(newTeamName);
          return;
        }

        var newTeam = new Team(newTeamName);
        FactionManager.Register(newTeam);
        Team = newTeam;
      }
    }

    public int GetUnitTypeByCategory(int unitCategory)
    {
      return _unitTypeByCategory[unitCategory];
    }

    //Shows all of the Faction)s quest, rendering them in the quest log,
    //showing them on the minimap, and showing them on the map.
    private void ShowAllQuests()
    {
      foreach (var quest in _quests)
      {
        if (GetLocalPlayer() == Player) quest.ShowLocal();

        quest.ShowSync();
      }
    }

    //Hides all of the Faction)s quests.
    private void HideAllQuests()
    {
      foreach (var quest in _quests)
      {
        if (GetLocalPlayer() == Player) quest.HideLocal();

        quest.HideSync();
      }
    }

    public QuestData AddQuest(QuestData questData)
    {
      questData.Holder = this;
      _quests.Add(questData);
      if (GetLocalPlayer() == Player) questData.ShowLocal();
      questData.ShowSync();
      return questData;
    }

    public int GetObjectLevel(int obj)
    {
      return _objectLevels[obj];
    }

    public void SetObjectLevel(int obj, int level)
    {
      _objectLevels[obj] = level;
      Person?.SetObjectLevel(obj, level);
    }

    public bool HasObjectLimit(int objectId)
    {
      return _objectLimits.ContainsKey(objectId);
    }

    public void ModObjectLimit(int id, int limit)
    {
      if (HasObjectLimit(id))
      {
        _objectLimits[id] += limit;
      }
      else
      {
        _objectLimits[id] = limit;
        ;
      }

      //If a Person has this Faction, adjust their techtree as well
      Person?.ModObjectLimit(id, limit);

      if (_objectLimits[id] == 0) _objectLimits.Remove(id);

      //Index the unit type to a unit category if possible and necessary
      _unitTypeByCategory[UnitType.GetFromId(id).UnitCategory] = id;
    }

    /// <summary>
    ///   Causes the <see cref="Faction" />'s <see cref="player" /> to lose everything they control,
    ///   without distributing it to members of their <see cref="Team" />.
    /// </summary>
    public void Obliterate()
    {
      group tempGroup = CreateGroup();

      //Take away resources
      SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD, 0);
      SetPlayerState(Player, PLAYER_STATE_RESOURCE_LUMBER, 0);

      //Give all units to Neutral Victim
      GroupEnumUnitsOfPlayer(tempGroup, Player, null);
      while (true)
      {
        unit u = FirstOfGroup(tempGroup);
        if (u == null) break;

        UnitType tempUnitType = UnitType.GetFromHandle(u);
        if (!UnitAlive(u)) RemoveUnit(u);

        if (!tempUnitType.Meta) SetUnitOwner(u, Player(bj_PLAYER_NEUTRAL_VICTIM), false);

        GroupRemoveUnit(tempGroup, u);
      }

      DestroyGroup(tempGroup);
    }

    /// <summary>
    ///   Returns all <see cref="Power" />s this <see cref="Faction" /> has.
    /// </summary>
    public IEnumerable<Power> GetAllPowers()
    {
      foreach (var power in _powers) yield return power;
    }

    private void DistributeExperience()
    {
      if (_team == null) return;
      foreach (var ally in _team.GetAllFactions())
      {
        var allyHeroes = new GroupWrapper().EnumUnitsOfPlayer(ally.Player).EmptyToList()
          .FindAll(unit => IsUnitType(unit, UNIT_TYPE_HERO));
        foreach (var hero in allyHeroes)
          AddHeroXP(hero, R2I(_xp / (_team.PlayerCount - 1) / allyHeroes.Count * XP_TRANSFER_PERCENT), true);
      }

      _xp = 0;
    }

    private void DistributeResources()
    {
      if (_team == null) return;
      foreach (var faction in _team.GetAllFactions())
        if (faction.Person != null)
        {
          faction.Gold = faction.Gold + Gold / _team.PlayerCount - 1;
          faction.Lumber = faction.Lumber + Lumber / _team.PlayerCount - 1;
        }

      Gold = 0;
      Lumber = 0;
    }

    private void DistributeUnits()
    {
      if (_team == null) return;
      force eligiblePlayers = Team.CreateForceFromPlayers();

      ForceRemovePlayer(eligiblePlayers, Player);

      var playerUnits = new GroupWrapper().EmptyToList();

      foreach (var unit in playerUnits)
      {
        UnitType loopUnitType = UnitType.GetFromHandle(unit);
        //Refund gold and experience of heroes
        if (IsUnitType(unit, UNIT_TYPE_HERO))
        {
          Person.AddGold(HERO_COST);
          _xp += GetHeroXP(unit);
          //Subtract hero's starting XP from refunded XP
          if (Legend.GetFromUnit(unit) != null) _xp -= Legend.GetFromUnit(unit)!.StartingXp;

          UnitDropAllItems(unit);
          RemoveUnit(unit);
          //Refund gold and lumber of refundable units
        }
        else if (loopUnitType.Refund)
        {
          Gold += loopUnitType.GoldCost * REFUND_PERCENT;
          Lumber += loopUnitType.LumberCost * REFUND_PERCENT;
          UnitDropAllItems(unit);
          RemoveUnit(unit);
        }
        //Transfer the ownership of everything else
        else if (UnitType.GetFromHandle(unit).Meta == false)
        {
          SetUnitOwner(unit,
            Team.PlayerCount > 1 ? ForcePickRandomPlayer(eligiblePlayers) : Player(bj_PLAYER_NEUTRAL_VICTIM), false);
        }
      }

      //Cleanup
      DestroyForce(eligiblePlayers);
    }

    /// <summary>
    ///   This should get used any time a player exits the game without being defeated;
    ///   IE they left, went afk, became an observer, or triggered an event that causes this.
    /// </summary>
    private void Leave()
    {
      if (_team.PlayerCount > 1 && GameTime.GetGameTime() > 60)
      {
        DistributeUnits();
        DistributeResources();
        DistributeExperience();
      }
      else
      {
        Obliterate();
      }

      GameLeave?.Invoke(this, this);
    }

    private static void OnAnyResearch()
    {
      var faction = FactionManager.GetFromPlayer(GetTriggerPlayer());
      faction?.SetObjectLevel(GetResearched(), GetPlayerTechCount(GetTriggerPlayer(), GetResearched(), false));
    }

    public static void Setup()
    {
      PlayerUnitEvents.Register(PlayerUnitEvent.ResearchIsFinished, OnAnyResearch);
    }
  }
}