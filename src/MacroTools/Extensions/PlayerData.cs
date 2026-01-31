using System;
using System.Collections.Generic;
using MacroTools.ControlPoints;
using MacroTools.DialogueSystem;
using MacroTools.Factions;
using MacroTools.Save;

namespace MacroTools.Extensions;

/// <summary>
/// Provides extra information about players that is not already tracked by the Warcraft 3 engine.
/// </summary>
public sealed class PlayerData
{
  private static readonly Dictionary<int, PlayerData> _byId = new();

  private readonly Dictionary<int, int> _objectLimits = new();
  private int _goldPerMinute;
  private int _bonusGoldPerMinute;

  private readonly player _player;
  private Faction? _faction;

  private float _partialGold;

  private readonly Queue<IHasPlayableDialogue> _dialogueQueue = new();
  private bool _dialoguePlaying;

  public void UpdatePlayerSetting(string setting, int value)
  {
    switch (setting)
    {
      case "CamDistance":
        PlayerSettings.CamDistance = value;
        _player.ApplyCameraField(CAMERA_FIELD_TARGET_DISTANCE, PlayerSettings.CamDistance, 1);
        break;
    }
    SaveManager.Save(PlayerSettings);
  }

  public void UpdatePlayerSetting(string setting, bool value)
  {
    switch (setting)
    {
      case "PlayDialogue":
        PlayerSettings.PlayDialogue = value;
        break;
      case "ShowQuestText":
        PlayerSettings.ShowQuestText = value;
        break;
      case "ShowCaptions":
        PlayerSettings.ShowCaptions = value;
        break;
    }
    SaveManager.Save(PlayerSettings);
  }

  private PlayerSettings CreateNewPlayerSettings()
  {
    var newPlayerSettings = new PlayerSettings();
    newPlayerSettings.SetPlayer(_player);
    SaveManager.SavesByPlayer[_player] = newPlayerSettings;
    return newPlayerSettings;
  }

  /// <summary>
  /// Control points the player owns
  /// </summary>
  public List<ControlPoint> ControlPoints { get; } = new();

  /// <summary>The number of extra <see cref="ControlPoint.ControlLevel"/>s the player gets each turn.</summary>
  public float ControlLevelPerTurnBonus { get; set; }

  private PlayerData(player player)
  {
    _player = player;
    EliminationTurns = 0;
  }

  /// <summary>
  /// Fired when the player leaves a team.
  /// </summary>
  public event EventHandler<PlayerChangeTeamEventArgs>? PlayerLeftTeam;

  /// <summary>
  /// Fired when the player joins a team.
  /// </summary>
  public event EventHandler<PlayerChangeTeamEventArgs>? PlayerJoinedTeam;

  /// <summary>
  /// Fired when the player changes their <see cref="Faction"/>.
  /// </summary>
  public event EventHandler<PlayerFactionChangeEventArgs>? ChangedFaction;

  /// <summary>
  /// Fired when the player's income changes.
  /// </summary>
  public event EventHandler<PlayerData>? IncomeChanged;

  /// <summary>
  /// Fired when the <see cref="player" />'s <see cref="ControlPoint" />s change
  /// </summary>
  public event EventHandler<PlayerData>? ControlPointsChanged;

  /// <summary>
  /// Fired when any player changes <see cref="Faction"/>.
  /// Todo: remove this and use the instance version instead.
  /// </summary>
  public static event EventHandler<PlayerFactionChangeEventArgs>? FactionChange;

  /// <summary>
  /// Controls who the player is allied to.
  /// </summary>
  public Team? Team { get; private set; }

  public int EliminationTurns { get; set; }

  /// <summary>
  ///   Gold per second gained from all sources.
  /// </summary>
  public int TotalIncome => BaseIncome + BonusIncome;

  /// <summary>
  ///   Gold per second gained from secondary sources like Forsaken's plagued buildings.
  /// </summary>
  public int BonusIncome
  {
    get => _bonusGoldPerMinute;
    set
    {
      _bonusGoldPerMinute = value;
      IncomeChanged?.Invoke(this, this);
    }
  }

  /// <summary>
  ///   Gold per second gained from primary sources like Control Points.
  /// </summary>
  public int BaseIncome
  {
    get => _goldPerMinute;
    set
    {
      if (value < 0)
      {
        throw new ArgumentOutOfRangeException(
          $"Tried to assign a negative {nameof(BaseIncome)} value to {_player.Name}.");
      }

      _goldPerMinute = value;
      IncomeChanged?.Invoke(this, this);
    }
  }

  internal PlayerSettings PlayerSettings => SaveManager.SavesByPlayer.TryGetValue(_player, out var playerSettings)
    ? playerSettings
    : CreateNewPlayerSettings();

  /// <summary>
  ///   Controls name, available objects, color, and icon.
  /// </summary>
  public Faction? Faction
  {
    get => _faction;
    set
    {
      var prevFaction = Faction;

      //Unapply old faction
      if (_faction != null)
      {
        _faction = null;
        if (prevFaction != null)
        {
          prevFaction.Player = null; //Referential integrity
        }
      }

      //Apply new faction
      if (value != null)
      {
        if (value.Player == null)
        {
          _player.SetColorAndChangeExisting(value.PlayerColor);
          _faction = value;
          //Enforce referential integrity
          if (value.Player != _player)
          {
            value.Player = _player;
          }
        }
        else
        {
          throw new Exception("Attempted to Person " + _player.Name +
                              " to already occupied faction with name " + value.Name);
        }
      }

      FactionChange?.Invoke(this, new PlayerFactionChangeEventArgs(_player, prevFaction));
      ChangedFaction?.Invoke(this, new PlayerFactionChangeEventArgs(_player, prevFaction));
    }
  }

  /// <summary>
  /// Queues the <see cref="IHasPlayableDialogue"/> for this player, playing it the next time there is nothing else playing.
  /// </summary>
  internal void QueueDialogue(IHasPlayableDialogue dialogue)
  {
    _dialogueQueue.Enqueue(dialogue);

    if (_dialoguePlaying)
    {
      return;
    }

    _dialoguePlaying = true;
    var dialogueTrigger = trigger.Create();
    dialogueTrigger.AddAction(() =>
    {
      while (_dialogueQueue.Count != 0)
      {
        var nextDialogue = _dialogueQueue.Dequeue();
        nextDialogue.Play(_player);
        TriggerSleepAction(nextDialogue.Length);
        TriggerSleepAction(5f);
      }

      _dialoguePlaying = false;
      @event.Trigger.Dispose();
    });
    dialogueTrigger.Execute();
  }

  /// <summary>
  /// Changes the player's <see cref="PlayerData.Team"/> and updates their alliances to match.
  /// </summary>
  public void SetTeam(Team? newTeam)
  {
    if (newTeam == Team)
    {
      return;
    }

    if (Team != null)
    {
      Team?.RemovePlayer(_player);
      PlayerLeftTeam?.Invoke(this, new PlayerChangeTeamEventArgs(_player, Team));
    }

    if (newTeam == null)
    {
      return;
    }

    var prevTeam = Team;
    Team = newTeam;
    newTeam.AddPlayer(_player);
    PlayerJoinedTeam?.Invoke(this, new PlayerChangeTeamEventArgs(_player, prevTeam));
  }

  /// <summary>
  /// Adds <see cref="ControlPoint" /> to list of this <see cref="player" />'s controlpoints, updates the <see cref="Team" /> total and fires any events subscribed to ControlPointsChanged
  /// </summary>
  public void AddControlPoint(ControlPoint controlPoint)
  {
    ControlPoints.Add(controlPoint);
    ControlPointsChanged?.Invoke(this, this);
  }

  /// <summary>
  /// Removes <see cref="ControlPoint" /> from list of this <see cref="player" />'s controlpoints, updates the <see cref="Team" /> total and fires any events subscribed to ControlPointsChanged
  /// </summary>
  public void RemoveControlPoint(ControlPoint controlPoint)
  {
    ControlPoints.Remove(controlPoint);
    ControlPointsChanged?.Invoke(this, this);
  }

  public void SetObjectLevel(int obj, int level)
  {
    var objectLimit = GetObjectLimit(obj);

    if (level > objectLimit)
    {
      throw new ArgumentException(
        $"{nameof(level)} ({level}) cannot be higher than the object limit for {GetObjectName(obj)} ({objectLimit}).",
        $"{nameof(level)}");
    }

    //Object levels cannot be changed for objects with a limit of 0.
    //This works around it by increasing the limit to 1 before making the change, then reverting it back.
    var revertAfter = false;

    if (objectLimit < 1)
    {
      _player.SetTechMaxAllowed(obj, 100);
      revertAfter = true;
    }

    _player.SetTechResearched(obj, Math.Max(level, 0));

    if (revertAfter)
    {
      _player.SetTechMaxAllowed(obj, 0);
    }

    if (_player.GetTechResearched(obj, false) != Math.Max(level, 0))
    {
      throw new InvalidOperationException(
        $"Failed to set the object level of {GetObjectName(obj)} to {level}; it is {_player.GetTechResearched(obj, false)} instead.");
    }
  }

  public int GetObjectLimit(int id) => _objectLimits.TryGetValue(id, out var limit) ? limit : 0;

  public void SetObjectLimit(int id, int limit)
  {
    _objectLimits[id] = limit;

    if (limit >= Faction.Unlimited)
    {
      _player.SetTechMaxAllowed(id, -1);
    }
    else if (limit <= 0)
    {
      _player.SetTechMaxAllowed(id, 0);
    }
    else
    {
      _player.SetTechMaxAllowed(id, limit);
    }
  }

  public void ModObjectLimit(int id, int limit) =>
    SetObjectLimit(id, GetObjectLimit(id) + limit);

  /// <summary>
  /// Adds a fractional amount of gold to the player.
  ///
  /// <para>
  /// Takes the integer part to add to the player's gold and accumulates the remainder.
  /// </para>
  ///
  /// <para>
  /// Use for float income sources (e.g., tick-based or shared income).
  /// For integer amounts, modify <c>player.Gold</c> directly.
  /// </para>
  /// </summary>
  /// <param name="amount">The fractional amount of gold to add.</param>
  internal void AddFractionalGold(float amount)
  {
    _partialGold += amount;
    var wholeGold = (int)_partialGold;
    if (wholeGold > 0)
    {
      _partialGold -= wholeGold;
      _player.Gold += wholeGold;
    }
  }

  /// <summary>
  /// Signal that the player has had their alliances changed.
  /// </summary>
  internal void SignalAllianceChange()
  {
    foreach (var controlPoint in ControlPoints)
    {
      controlPoint.SignalOwnerAllianceChange();
    }
  }

  /// <summary>
  ///   Retrieves the <see cref="PlayerData" /> object which contains information about the given <see cref="player" />.
  /// </summary>
  public static PlayerData ByHandle(player whichPlayer)
  {
    if (_byId.TryGetValue(whichPlayer.Id, out var person))
    {
      return person;
    }

    var newPerson = new PlayerData(whichPlayer);
    Register(newPerson);
    return newPerson;
  }

  /// <summary>
  ///   Register a <see cref="PlayerData" /> to the Person system.
  /// </summary>
  private static void Register(PlayerData playerData) => _byId.Add(playerData._player.Id, playerData);
}
