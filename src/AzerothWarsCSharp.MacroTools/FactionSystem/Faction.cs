using System;
using System.Collections.Generic;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Events;
using static War3Api.Common;
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
    private readonly Dictionary<string, QuestData> _questsByName = new();
    private string _icon;
    private string _name;
    private player? _player;
    private ScoreStatus _scoreStatus = ScoreStatus.Undefeated;
    private Team? _team;
    private int _undefeatedResearch;
    private int _xp; //Stored by DistributeUnits and given out again by DistributeResources

    /// <summary>
    ///   Fired when the <see cref="Faction" /> gains a <see cref="Power" />.
    /// </summary>
    public EventHandler<FactionPowerEventArgs>? PowerAdded;

    /// <summary>
    ///   Fired when the <see cref="Faction" /> loses a <see cref="Power" />.
    /// </summary>
    public EventHandler<FactionPowerEventArgs>? PowerRemoved;

    public EventHandler<Faction>? ScoreStatusChanged;

    public Faction(string name, playercolor playerColor, string prefixCol, string icon)
    {
      _name = name;
      PlayerColor = playerColor;
      PrefixCol = prefixCol;
      _icon = icon;
    }

    public int StartingGold { get; set; }

    public int StartingLumber { get; set; }

    public playercolor PlayerColor { get; }

    private float Gold
    {
      get => I2R(GetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD));
      set => SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD, R2I(value));
    }

    private float Lumber
    {
      get => I2R(GetPlayerState(Player, PLAYER_STATE_RESOURCE_LUMBER));
      set => SetPlayerState(Player, PLAYER_STATE_RESOURCE_LUMBER, R2I(value));
    }

    public ScoreStatus ScoreStatus
    {
      get => _scoreStatus;
      set
      {
        //Change defeated/undefeated researches
        foreach (var player in GetAllPlayers())
          if (value == ScoreStatus.Defeated)
          {
            SetPlayerTechResearched(player, _defeatedResearch, 1);
            SetPlayerTechResearched(player, _undefeatedResearch, 0);
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
    public float Income => _player?.GetControlPointValue() ?? 0;

    public string ColoredName => PrefixCol + _name + "|r";

    public string PrefixCol { get; init; }

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
    public player? Player
    {
      get => _player;
      set
      {
        if (Player != null)
        {
          Team?.UnallyPlayer(Player);
          HideAllQuests();
          UnapplyObjects();
          UnapplyPowers();
        }

        _player = value;
        //Maintain referential integrity
        //Todo: this seems a bit silly
        if (value == null) return;

        if (value.GetFaction() != this)
          value.SetFaction(this);

        Team?.AllyPlayer(value);
        ApplyObjects();
        ApplyPowers();
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

    private void ApplyPowers()
    {
      if (Player != null)
        foreach (var power in _powers)
          power.OnAdd(Player);
    }

    private void UnapplyPowers()
    {
      if (Player != null)
        foreach (var power in _powers)
          power.OnRemove(Player);
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
      foreach (var (key, value) in _objectLimits)
        Player?.ModObjectLimit(key, value);

      foreach (var (key, value) in _objectLevels)
        Player?.SetObjectLevel(key, value);
    }

    //Removes this Faction's object limits and levels from its active Person
    private void UnapplyObjects()
    {
      foreach (var (key, value) in _objectLimits)
        Player?.ModObjectLimit(key, -value);

      foreach (var (key, _) in _objectLevels)
        Player?.SetObjectLevel(key, 0);
    }

    /// <summary>
    ///   Adds a <see cref="Power" /> to this <see cref="Faction" />.
    /// </summary>
    public void AddPower(Power power)
    {
      _powers.Add(power);
      if (Player != null) power.OnAdd(Player);
      PowerAdded?.Invoke(this, new FactionPowerEventArgs(this, power));
    }

    /// <summary>
    ///   Removes a <see cref="Power" /> from this <see cref="Faction" />.
    /// </summary>
    public void RemovePower(Power power)
    {
      _powers.Remove(power);
      if (Player != null) power.OnRemove(Player);
      PowerRemoved?.Invoke(this, new FactionPowerEventArgs(this, power));
    }

    /// <summary>
    ///   Unallies the <see cref="Faction" /> from all of its allies, creating a new <see cref="Team" />
    ///   based on its name.
    /// </summary>
    public void Unally()
    {
      if (Team?.PlayerCount > 1)
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

    /// <summary>
    ///   Shows all of the Faction's quest, rendering them in the quest log,
    ///   showing them on the minimap, and showing them on the map.
    /// </summary>
    private void ShowAllQuests()
    {
      foreach (var quest in _questsByName.Values)
      {
        if (GetLocalPlayer() == Player) quest.ShowLocal();

        quest.ShowSync();
      }
    }

    //Hides all of the Faction)s quests.
    private void HideAllQuests()
    {
      foreach (var quest in _questsByName.Values)
      {
        if (GetLocalPlayer() == Player) quest.HideLocal();

        quest.HideSync();
      }
    }

    private void OnQuestProgressChanged(object? sender, QuestProgressChangedEventArgs args)
    {
      args.Quest.ApplyFactionProgress(this, args.Quest.Progress, args.FormerProgress);
    }

    public QuestData AddQuest(QuestData questData)
    {
      questData.Add(this);
      _questsByName.Add(questData.Title, questData);
      if (GetLocalPlayer() == Player)
        questData.ShowLocal();
      questData.ShowSync();
      questData.ProgressChanged += OnQuestProgressChanged;
      return questData;
    }

    public int GetObjectLevel(int obj)
    {
      return _objectLevels[obj];
    }

    public void SetObjectLevel(int obj, int level)
    {
      _objectLevels[obj] = level;
      Player?.SetObjectLevel(obj, level);
    }

    /// <summary>
    ///   Changes the limit of the given object that the <see cref="Faction" /> can train, build, or research.
    /// </summary>
    /// <param name="objectId">The object ID to modify the limit of.</param>
    /// <param name="limit">The amount to adjust the limit by.</param>
    public void ModObjectLimit(int objectId, int limit)
    {
      if (_objectLimits.ContainsKey(objectId))
        _objectLimits[objectId] += limit;
      else
        _objectLimits.Add(objectId, limit);

      //If a player has this Faction, adjust their techtree as well
      Player?.ModObjectLimit(objectId, limit);

      if (_objectLimits[objectId] == 0)
        _objectLimits.Remove(objectId);
    }

    /// <summary>
    ///   Causes the <see cref="Faction" />'s <see cref="player" /> to lose everything they control,
    ///   without distributing it to members of their <see cref="Team" />.
    /// </summary>
    public void Obliterate()
    {
      //Take away resources
      SetPlayerState(Player, PLAYER_STATE_RESOURCE_GOLD, 0);
      SetPlayerState(Player, PLAYER_STATE_RESOURCE_LUMBER, 0);

      //Give all units to Neutral Victim
      foreach (var unit in new GroupWrapper().EnumUnitsOfPlayer(Player).EmptyToList())
      {
        UnitType tempUnitType = UnitType.GetFromHandle(unit);
        if (!UnitAlive(unit))
          RemoveUnit(unit);

        if (!tempUnitType?.Meta == true)
          SetUnitOwner(unit, Player(GetBJPlayerNeutralVictim()), false);
      }
    }

    /// <summary>
    ///   Returns all <see cref="Power" />s this <see cref="Faction" /> has.
    /// </summary>
    public IEnumerable<Power> GetAllPowers()
    {
      foreach (var power in _powers) yield return power;
    }

    private void DistributeExperience(IEnumerable<player> playersToDistributeTo)
    {
      if (_team == null) return;
      foreach (var ally in playersToDistributeTo)
      {
        var allyHeroes = new GroupWrapper().EnumUnitsOfPlayer(ally).EmptyToList()
          .FindAll(unit => IsUnitType(unit, UNIT_TYPE_HERO));
        foreach (var hero in allyHeroes)
          AddHeroXP(hero, R2I(_xp / (_team.PlayerCount - 1) / allyHeroes.Count * XP_TRANSFER_PERCENT), true);
      }

      _xp = 0;
    }

    private void DistributeResources(List<player> playersToDistributeTo)
    {
      foreach (var player in playersToDistributeTo)
      {
        player.AdjustPlayerState(PLAYER_STATE_RESOURCE_GOLD, (int) (Gold / playersToDistributeTo.Count));
        player.AdjustPlayerState(PLAYER_STATE_RESOURCE_LUMBER, (int) (Lumber / playersToDistributeTo.Count));
      }

      Gold = 0;
      Lumber = 0;
    }

    private void DistributeUnits(IReadOnlyList<player> playersToDistributeTo)
    {
      if (_team == null) return;
      var playerUnits = new GroupWrapper().EnumUnitsOfPlayer(Player).EmptyToList();

      foreach (var unit in playerUnits)
      {
        UnitType loopUnitType = UnitType.GetFromHandle(unit);
        //Refund gold and experience of heroes
        if (IsUnitType(unit, UNIT_TYPE_HERO))
        {
          Player?.AddGold(HERO_COST);
          _xp += GetHeroXP(unit);
          //Subtract hero's starting XP from refunded XP
          if (Legend.GetFromUnit(unit) != null) _xp -= Legend.GetFromUnit(unit)!.StartingXp;

          unit.DropAllItems();
          RemoveUnit(unit);
          //Refund gold and lumber of refundable units
        }
        else if (loopUnitType.Refund)
        {
          Gold += loopUnitType.GoldCost * REFUND_PERCENT;
          Lumber += loopUnitType.LumberCost * REFUND_PERCENT;
          unit.DropAllItems();
          RemoveUnit(unit);
        }
        //Transfer the ownership of everything else
        else if (loopUnitType.Meta == false)
        {
          SetUnitOwner(unit,
            Team.PlayerCount > 1
              ? playersToDistributeTo[GetRandomInt(0, playersToDistributeTo.Count)]
              : Player(GetBJPlayerNeutralVictim()), false);
        }
      }
    }

    /// <summary>
    ///   This should get used any time a player exits the game without being defeated;
    ///   IE they left, went afk, became an observer, or triggered an event that causes this.
    /// </summary>
    private void Leave()
    {
      if (Team?.PlayerCount > 1 && GameTime.GetGameTime() > 60)
      {
        List<player> eligiblePlayers = Team.GetAllPlayers();
        eligiblePlayers.Remove(Player);
        DistributeUnits(eligiblePlayers);
        DistributeResources(eligiblePlayers);
        DistributeExperience(eligiblePlayers);
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

    /// <summary>
    ///   Attempts to retrieve a <see cref="QuestData" /> belonging to this <see cref="Faction" /> with the given title.
    /// </summary>
    public QuestData GetQuestByTitle(string parameter)
    {
      return _questsByName[parameter];
    }
  }
}