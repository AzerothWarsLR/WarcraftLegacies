using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Sounds;
using MacroTools.Utils;
using MacroTools.WorldEvents;

namespace MacroTools.Paths;

/// <summary>
/// A story branch a <see cref="Faction"/> can choose to take, such as turning into a new faction or betraying its allies.
/// <para>Once every requirement is complete the path becomes <see cref="PathState.Available"/>. Accepting it starts a
/// countdown that can still be cancelled; when the countdown ends the path is taken.</para>
/// </summary>
public abstract class FactionPath
{
  private const float TickInterval = 0.25f;

  private static int _takenCount;

  private readonly List<Objective> _requirements = new();
  private readonly List<Objective> _mustStayTrueRequirements = new();
  private readonly List<Objective> _metRequirements = new();
  private PathState _state = PathState.Locked;
  private timer? _ticker;

  /// <summary>The name shown on the path's card.</summary>
  public string Name { get; init; } = "";

  /// <summary>The icon name, without the BTN prefix or file extension.</summary>
  public string IconName { get; init; } = "";

  public string IconPath => $@"ReplaceableTextures\CommandButtons\BTN{IconName}.blp";

  /// <summary>What happens if the path is taken.</summary>
  public string Description { get; init; } = "";

  /// <summary>What happens if the path is declined. Only paths with one can be declined.</summary>
  public string? DeclineDescription { get; init; }

  /// <summary>What taking the path did to others, shown on its Events card.</summary>
  public string? TakenOutcome { get; protected set; }

  /// <summary>Whether the path is a vote, which doesn't close other paths or get announced when taken.</summary>
  public bool IsVote { get; init; }

  /// <summary>Whether the path can be turned down.</summary>
  public bool CanDecline => DeclineDescription != null;

  /// <summary>How many seconds the path stays available before it closes. Zero means it never closes on its own.</summary>
  public float OfferDuration { get; init; }

  /// <summary>How many seconds it takes for the path to go through after it's accepted.</summary>
  public float CommitDuration { get; init; } = 30;

  /// <summary>Seconds left before an available path closes, if it has an <see cref="OfferDuration"/>.</summary>
  public float OfferTimeRemaining { get; private set; }

  /// <summary>Seconds left before a committing path is taken.</summary>
  public float CommitTimeRemaining { get; private set; }

  /// <summary>How far through the commit countdown the path is, from 0 to 1.</summary>
  public float CommitProgress => CommitDuration <= 0 ? 1 : 1 - CommitTimeRemaining / CommitDuration;

  /// <summary>Everything that needs to happen before the path becomes available.</summary>
  public IReadOnlyList<Objective> Requirements => _requirements;

  /// <summary>
  /// Whether the path can send the faction off on a team of its own when the team it would join is full, instead of
  /// waiting for a slot to open up.
  /// </summary>
  public bool CanGoSolo { get; init; }

  /// <summary>Whether taking the path moves the faction to another <see cref="Team"/>.</summary>
  public virtual bool ChangesTeam => false;

  /// <summary>Whether the path can move the faction even while its team-change cooldown is running.</summary>
  public virtual bool IgnoresTeamChangeCooldown => false;

  /// <summary>Whether taking the path closes the faction's other paths.</summary>
  public virtual bool ClosesOtherPaths => true;

  /// <summary>
  /// Why the path can't be accepted right now even though its requirements are met, like the team it joins being
  /// full. Null if nothing is in the way.
  /// </summary>
  public string? BlockedReason
  {
    get
    {
      var owner = Faction?.Player;
      if (!ChangesTeam || owner == null)
      {
        return null;
      }

      var cooldown = IgnoresTeamChangeCooldown ? 0 : TeamChanges.GetCooldownRemaining(owner);
      if (cooldown > 0)
      {
        return Loc.Format("You changed teams recently and can change again in {time}", ("{time}", FormatTime(cooldown)));
      }

      var destination = GetDestinationTeam(Faction!);
      if (destination != null && !TeamChanges.HasRoomFor(destination, owner) && !CanGoSolo)
      {
        return Loc.Format("Team full: the {team} has no room for you yet", ("{team}", destination.LocalizedName));
      }

      return null;
    }
  }

  /// <summary>Goes up each time any path is taken, so later paths have a higher number. Zero if not taken.</summary>
  public int TakenOrder { get; private set; }

  /// <summary>The <see cref="Faction"/> this path belongs to.</summary>
  public Faction? Faction { get; private set; }

  public PathState State
  {
    get => _state;
    private set
    {
      if (_state == value)
      {
        return;
      }

      _state = value;
      StateChanged?.Invoke(this);
    }
  }

  /// <summary>Fired when <see cref="State"/> changes.</summary>
  public event Action<FactionPath>? StateChanged;

  /// <summary>Fired when anything shown on the path's card changes, like a countdown or a requirement.</summary>
  public event Action<FactionPath>? Updated;

  /// <summary>Adds something that must be completed before the path becomes available.</summary>
  protected void AddRequirement(Objective requirement) => _requirements.Add(requirement);

  /// <summary>
  /// Adds something that has to stay true for the path to be available, like controlling a city. If it stops being
  /// true the path goes back to <see cref="PathState.Locked"/> until it's true again, rather than closing.
  /// </summary>
  protected void AddMustStayTrueRequirement(Objective requirement)
  {
    _requirements.Add(requirement);
    _mustStayTrueRequirements.Add(requirement);
  }

  /// <summary>
  /// Whether <paramref name="requirement"/> counts as met. Most requirements stay met once they've been met; ones that
  /// must stay true only count while they're complete.
  /// </summary>
  public bool IsRequirementMet(Objective requirement) =>
    requirement.Progress == QuestProgress.Complete ||
    (!_mustStayTrueRequirements.Contains(requirement) && _metRequirements.Contains(requirement));

  /// <summary>
  /// The <see cref="Team"/> the faction moves to when the path is taken, if <see cref="ChangesTeam"/> is true.
  /// Null sends the faction off on a team of its own.
  /// </summary>
  protected virtual Team? GetDestinationTeam(Faction faction) => null;

  /// <summary>Runs when the commit countdown finishes and the path is taken.</summary>
  protected abstract void OnTaken(Faction faction);

  /// <summary>Runs when the player declines the path.</summary>
  protected virtual void OnDeclined(Faction faction)
  {
  }

  /// <summary>Runs when the offer runs out without the path being accepted or declined.</summary>
  protected virtual void OnExpired(Faction faction)
  {
  }

  /// <summary>Whether <paramref name="whichPlayer"/> controls the faction this path belongs to.</summary>
  public bool IsOwnedBy(player whichPlayer) => Faction != null && Faction.Player == whichPlayer;

  /// <summary>Starts the commit countdown.</summary>
  public void Accept(player whichPlayer)
  {
    if (State != PathState.Available || !IsOwnedBy(whichPlayer))
    {
      return;
    }

    var blockedReason = BlockedReason;
    if (blockedReason != null)
    {
      whichPlayer.DisplayTextTo($"\n|cffff0000{Loc.Get("PATH ON HOLD")}|r - {Loc.Get(Name)}\n{blockedReason}");
      Updated?.Invoke(this);
      return;
    }

    CommitTimeRemaining = CommitDuration;
    State = PathState.Committing;
    StartTicking();
    Updated?.Invoke(this);
  }

  /// <summary>Stops the commit countdown and makes the path available again.</summary>
  public void Cancel(player whichPlayer)
  {
    if (State != PathState.Committing || !IsOwnedBy(whichPlayer))
    {
      return;
    }

    CommitTimeRemaining = 0;
    State = PathState.Available;
    Updated?.Invoke(this);
  }

  /// <summary>Turns the path down for good.</summary>
  public void Decline(player whichPlayer)
  {
    if (State != PathState.Available || !IsOwnedBy(whichPlayer) || !CanDecline)
    {
      return;
    }

    StopTicking();
    State = PathState.Declined;
    OnDeclined(Faction!);
  }

  /// <summary>Makes a locked path available straight away, ignoring its requirements. Meant for testing.</summary>
  public void ForceAvailable()
  {
    if (State != PathState.Locked)
    {
      return;
    }

    OfferTimeRemaining = OfferDuration;
    State = PathState.Available;
    if (OfferDuration > 0 || BlockedReason != null)
    {
      StartTicking();
    }

    AnnounceAvailable();
  }

  /// <summary>Closes the path so it can no longer be taken.</summary>
  public void Close()
  {
    if (State != PathState.Locked && State != PathState.Available && State != PathState.Committing)
    {
      return;
    }

    StopTicking();
    State = PathState.Closed;
  }

  internal void OnAdd(Faction faction)
  {
    Faction = faction;
    foreach (var requirement in _requirements)
    {
      requirement.EligibleFactions.Add(faction);
      requirement.OnAdd(faction);
      requirement.ProgressChanged += OnRequirementProgressChanged;
    }

    if (ChangesTeam)
    {
      TeamChanges.OnAnyTeamChanged(OnTeamsChanged);
    }

    RefreshAvailability();
  }

  private void OnRequirementProgressChanged(Objective objective)
  {
    if (State == PathState.Available || State == PathState.Committing)
    {
      RelockIfConditionLost();
    }

    RefreshAvailability();
    Updated?.Invoke(this);
  }

  private void OnTeamsChanged()
  {
    if (State == PathState.Available || State == PathState.Committing)
    {
      StartTicking();
      Updated?.Invoke(this);
    }
  }

  private void RelockIfConditionLost()
  {
    if (_mustStayTrueRequirements.All(x => x.Progress == QuestProgress.Complete))
    {
      return;
    }

    StopTicking();
    CommitTimeRemaining = 0;
    State = PathState.Locked;
    AnnounceLocked();
  }

  private void RefreshAvailability()
  {
    foreach (var requirement in _requirements)
    {
      if (requirement.Progress == QuestProgress.Complete && !_metRequirements.Contains(requirement))
      {
        _metRequirements.Add(requirement);
      }
    }

    if (State != PathState.Locked)
    {
      return;
    }

    if (_requirements.Any(x => x.Progress == QuestProgress.Failed && !_mustStayTrueRequirements.Contains(x)))
    {
      Close();
      return;
    }

    if (_requirements.Any(x => !IsRequirementMet(x)))
    {
      return;
    }

    OfferTimeRemaining = OfferDuration;
    State = PathState.Available;
    if (OfferDuration > 0 || BlockedReason != null)
    {
      StartTicking();
    }

    AnnounceAvailable();
  }

  private void StartTicking()
  {
    if (_ticker != null)
    {
      return;
    }

    _ticker = timer.Create();
    _ticker.Start(TickInterval, true, Tick);
  }

  private void StopTicking()
  {
    if (_ticker == null)
    {
      return;
    }

    _ticker.Dispose();
    _ticker = null;
  }

  private void Tick()
  {
    switch (State)
    {
      case PathState.Committing:
        CommitTimeRemaining = Math.Max(0, CommitTimeRemaining - TickInterval);
        if (CommitTimeRemaining <= 0)
        {
          Take();
          return;
        }

        break;
      case PathState.Available when OfferDuration > 0:
        OfferTimeRemaining = Math.Max(0, OfferTimeRemaining - TickInterval);
        if (OfferTimeRemaining <= 0)
        {
          Close();
          AnnounceExpired();
          OnExpired(Faction!);
          return;
        }

        break;
      case PathState.Available when BlockedReason == null:
        StopTicking();
        break;
    }

    Updated?.Invoke(this);
  }

  private void Take()
  {
    var faction = Faction!;
    var blockedReason = BlockedReason;
    if (blockedReason != null)
    {
      CommitTimeRemaining = 0;
      State = PathState.Available;
      faction.Player?.DisplayTextTo($"\n|cffff0000{Loc.Get("PATH ON HOLD")}|r - {Loc.Get(Name)}\n{blockedReason}");
      return;
    }

    StopTicking();
    var owner = faction.Player;
    var destination = ChangesTeam ? GetDestinationTeam(faction) : null;
    _takenCount++;
    TakenOrder = _takenCount;
    State = PathState.Taken;

    if (IsVote)
    {
      OnTaken(faction);
      return;
    }

    foreach (var otherPath in faction.GetAllPaths())
    {
      if (otherPath != this && ClosesOtherPaths)
      {
        otherPath.Close();
      }
    }

    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo($"\n|cffffcc00{Loc.Get("PATH CHOSEN")}|r - {Loc.Format("{faction} has taken the path of {path}.", ("{faction}", faction.ColoredName), ("{path}", Loc.Get(Name)))}");
    }

    SoundLibrary.Completed.Start();
    var factionName = faction.ColoredName;
    var formerTeam = owner?.GetPlayerData().Team;
    try
    {
      OnTaken(faction);
    }
    catch (Exception ex)
    {
      Logger.LogError($"Taking the path {Name} failed: {ex.Message}");
    }

    if (ChangesTeam && owner != null)
    {
      if (destination == null || !TeamChanges.HasRoomFor(destination, owner))
      {
        TeamChanges.MoveSolo(owner);
      }
      else
      {
        TeamChanges.Move(owner, destination);
      }
    }

    var takenEvent = new PathTakenEvent(this, factionName, owner, owner != null && owner.GetPlayerData().Team != formerTeam);
    takenEvent.RecordAsHappened();
    WorldEventManager.Register(takenEvent);
  }

  private static string FormatTime(float seconds)
  {
    var wholeSeconds = (int)Math.Ceiling(seconds);
    var remainder = wholeSeconds % 60;
    return $"{wholeSeconds / 60}:{(remainder < 10 ? "0" : "")}{remainder}";
  }

  private void AnnounceAvailable()
  {
    if (Faction == null || Faction.Player == null)
    {
      return;
    }

    var owner = Faction.Player;

    owner.DisplayTextTo($"\n|cff00ff00{Loc.Get("NEW PATH AVAILABLE")}|r - {Loc.Get(Name)}\n{Loc.Get("Open the Paths menu to accept or decline it.")}");
    if (player.LocalPlayer == owner)
    {
      SoundLibrary.Discovered.Start();
    }
  }

  private void AnnounceLocked()
  {
    if (Faction == null || Faction.Player == null)
    {
      return;
    }

    var owner = Faction.Player;
    owner.DisplayTextTo($"\n|cffff8800{Loc.Get("PATH LOCKED")}|r - {Loc.Get(Name)}\n{Loc.Get("You no longer meet its requirements. It will open again if you do.")}");
    if (player.LocalPlayer == owner)
    {
      SoundLibrary.Failed.Start();
    }
  }

  private void AnnounceExpired()
  {
    if (Faction == null || Faction.Player == null)
    {
      return;
    }

    var owner = Faction.Player;

    owner.DisplayTextTo($"\n|cffff0000{Loc.Get("PATH CLOSED")}|r - {Loc.Get(Name)}\n{Loc.Get("The chance to take this path has passed.")}");
    if (player.LocalPlayer == owner)
    {
      SoundLibrary.Failed.Start();
    }
  }
}
