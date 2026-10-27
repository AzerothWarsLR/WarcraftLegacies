using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.GameTime;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Sounds;
using MacroTools.UserInterface;

namespace MacroTools.WorldEvents;

/// <summary>
/// Something that happens to the whole world once its requirements are met, such as a betrayal or an invasion.
/// <para>Once every requirement is complete the event becomes <see cref="WorldEventState.Imminent"/> and counts down for
/// <see cref="WarningDuration"/> seconds, so everyone can prepare, then it happens.</para>
/// </summary>
public abstract class WorldEvent
{
  private const float TickInterval = 0.25f;

  private readonly List<Objective> _requirements = new();
  private WorldEventState _state = WorldEventState.Upcoming;
  private timer? _ticker;

  /// <summary>The name shown on the event's card and banner.</summary>
  public string Name { get; init; } = "";

  /// <summary>The icon name, without the BTN prefix or file extension.</summary>
  public string IconName { get; init; } = "";

  public string IconPath => $@"ReplaceableTextures\CommandButtons\BTN{IconName}.blp";

  /// <summary>What happens when the event fires.</summary>
  public string Description { get; init; } = "";

  /// <summary>The earliest turn the event can happen on, or 0 if it doesn't depend on the turn.</summary>
  public int EarliestTurn { get; init; }

  /// <summary>How many seconds of warning everyone gets between the requirements being met and the event happening.</summary>
  public float WarningDuration { get; init; }

  /// <summary>Seconds left before an imminent event happens.</summary>
  public float WarningTimeRemaining { get; private set; }

  /// <summary>The turn the event happened on, or 0 if it hasn't happened.</summary>
  public int HappenedOnTurn { get; private set; }

  /// <summary>Everything that needs to happen before the event fires.</summary>
  public IReadOnlyList<Objective> Requirements => _requirements;

  public WorldEventState State
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
  public event Action<WorldEvent>? StateChanged;

  /// <summary>Fired when anything shown on the event's card changes, like a countdown or a requirement.</summary>
  public event Action<WorldEvent>? Updated;

  /// <summary>Adds something that must be completed before the event fires.</summary>
  protected void AddRequirement(Objective requirement) => _requirements.Add(requirement);

  /// <summary>Runs when the event happens.</summary>
  protected abstract void OnHappened();

  /// <summary>What the event led to, like who changed team. Shown on its card once it has happened.</summary>
  public string? Outcome { get; protected set; }

  /// <summary>Who or what set the event off, like a faction's name, if known.</summary>
  public string? Instigator { get; protected set; }

  /// <summary>Makes the event happen straight away, skipping any warning, as long as it hasn't happened yet.</summary>
  /// <param name="instigator">Who set the event off, shown in the Events menu.</param>
  public void HappenNow(string? instigator = null)
  {
    if (State != WorldEventState.Upcoming && State != WorldEventState.Imminent)
    {
      return;
    }

    if (instigator != null)
    {
      Instigator = instigator;
    }

    Happen();
  }

  /// <summary>Marks the event as happened without announcing it, for history records.</summary>
  public void RecordAsHappened()
  {
    HappenedOnTurn = GameTimeManager.Turn;
    State = WorldEventState.Happened;
  }

  /// <summary>Stops the event from ever happening.</summary>
  public void Cancel()
  {
    if (State != WorldEventState.Upcoming && State != WorldEventState.Imminent)
    {
      return;
    }

    StopTicking();
    State = WorldEventState.Cancelled;
  }

  internal void OnRegistered()
  {
    foreach (var requirement in _requirements)
    {
      requirement.ProgressChanged += OnRequirementProgressChanged;
    }

    RefreshReadiness();
  }

  private void OnRequirementProgressChanged(Objective objective)
  {
    RefreshReadiness();
    Updated?.Invoke(this);
  }

  private void RefreshReadiness()
  {
    if (State != WorldEventState.Upcoming)
    {
      return;
    }

    if (_requirements.Any(x => x.Progress == QuestProgress.Failed))
    {
      Cancel();
      return;
    }

    if (_requirements.Any(x => x.Progress != QuestProgress.Complete))
    {
      return;
    }

    if (WarningDuration <= 0)
    {
      Happen();
      return;
    }

    WarningTimeRemaining = WarningDuration;
    State = WorldEventState.Imminent;
    AnnounceImminent();
    StartTicking();
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
    if (State != WorldEventState.Imminent)
    {
      StopTicking();
      return;
    }

    WarningTimeRemaining = Math.Max(0, WarningTimeRemaining - TickInterval);
    if (WarningTimeRemaining <= 0)
    {
      Happen();
      return;
    }

    Updated?.Invoke(this);
  }

  private void Happen()
  {
    StopTicking();
    HappenedOnTurn = GameTimeManager.Turn;
    State = WorldEventState.Happened;

    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo($"\n|cffffcc00{Loc.Get("EVENT")}|r - {Loc.Get(Name)}\n{Loc.Get(Description)}");
    }

    EventBanner.Show(IconPath, Loc.Get(Name), Loc.Get(Description));
    SoundLibrary.Warning.Start();
    OnHappened();
  }

  private void AnnounceImminent()
  {
    var message = Loc.Format("{event} will happen in {seconds} seconds. See the Events menu.",
      ("{event}", Loc.Get(Name)), ("{seconds}", ((int)WarningDuration).ToString()));
    foreach (var whichPlayer in WCSharp.Shared.Util.EnumeratePlayers())
    {
      whichPlayer.DisplayTextTo($"\n|cffff8800{Loc.Get("EVENT APPROACHING")}|r - {message}");
    }

    SoundLibrary.Discovered.Start();
  }
}
