using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Sounds;

namespace MacroTools.Paths;

/// <summary>
/// A story branch a <see cref="Faction"/> can choose to take, such as turning into a new faction or betraying its allies.
/// <para>Once every requirement is complete the path becomes <see cref="PathState.Available"/>. Accepting it starts a
/// countdown that can still be cancelled; when the countdown ends the path is taken.</para>
/// </summary>
public abstract class FactionPath
{
  private const float TickInterval = 0.25f;

  private readonly List<Objective> _requirements = new();
  private PathState _state = PathState.Locked;
  private timer? _ticker;

  /// <summary>The name shown on the path's card.</summary>
  public string Name { get; init; } = "";

  /// <summary>The icon name, without the BTN prefix or file extension.</summary>
  public string IconName { get; init; } = "";

  public string IconPath => $@"ReplaceableTextures\CommandButtons\BTN{IconName}.blp";

  /// <summary>What happens if the path is taken.</summary>
  public string Description { get; init; } = "";

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

  /// <summary>Runs when the commit countdown finishes and the path is taken.</summary>
  protected abstract void OnTaken(Faction faction);

  /// <summary>Runs when the player declines the path.</summary>
  protected virtual void OnDeclined(Faction faction)
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
    if (State != PathState.Available || !IsOwnedBy(whichPlayer))
    {
      return;
    }

    StopTicking();
    State = PathState.Declined;
    OnDeclined(Faction!);
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
      requirement.OnAdd(faction);
      requirement.ProgressChanged += OnRequirementProgressChanged;
    }

    RefreshAvailability();
  }

  private void OnRequirementProgressChanged(Objective objective)
  {
    RefreshAvailability();
    Updated?.Invoke(this);
  }

  private void RefreshAvailability()
  {
    if (State != PathState.Locked)
    {
      return;
    }

    if (_requirements.Any(x => x.Progress == QuestProgress.Failed))
    {
      Close();
      return;
    }

    if (_requirements.Any(x => x.Progress != QuestProgress.Complete))
    {
      return;
    }

    OfferTimeRemaining = OfferDuration;
    State = PathState.Available;
    if (OfferDuration > 0)
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
          return;
        }

        break;
      case PathState.Available:
        StopTicking();
        break;
    }

    Updated?.Invoke(this);
  }

  private void Take()
  {
    StopTicking();
    var faction = Faction!;
    State = PathState.Taken;

    foreach (var otherPath in faction.GetAllPaths())
    {
      if (otherPath != this)
      {
        otherPath.Close();
      }
    }

    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo($"\n|cffffcc00{Loc.Get("PATH CHOSEN")}|r - {Loc.Format("{faction} has taken the path of {path}.", ("{faction}", faction.ColoredName), ("{path}", Loc.Get(Name)))}");
    }

    SoundLibrary.Completed.Start();
    OnTaken(faction);
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
