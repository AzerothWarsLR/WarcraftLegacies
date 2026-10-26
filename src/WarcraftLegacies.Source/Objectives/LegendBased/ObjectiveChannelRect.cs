using System;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Objectives.LegendBased;

/// <summary>
///   Bring a unit to a location, where they will channel for some period of time. When it's over, the
///   <see cref="Objective" /> is completed.
/// </summary>
public sealed class ObjectiveChannelRect : Objective
{
  private const string TargetEffect = "war3mapImported\\Fortitude Rune Aura.mdx";

  private readonly int _duration;
  private readonly TriggerWrapper _entersRectTrig = new();
  private readonly float _facing;
  private readonly string? _timerDialogTitle;
  private readonly Legend _targetLegend;

  private readonly rect _targetRect;
  private Channel? _channel;
  private bool _closed;
  private timer? _conditionTimer;

  /// <summary>Fired when the hero starts channeling.</summary>
  public event Action? ChannelStarted;

  /// <summary>Fired when the channel ends, finished or not.</summary>
  public event Action? ChannelEnded;

  /// <summary>
  /// If set, the channel only starts while this is true and is interrupted when it stops being true; the hero can
  /// already be waiting at the location.
  /// </summary>
  public Func<bool>? StartCondition { get; init; }

  /// <summary>Stops the current channel and prevents any new one from starting.</summary>
  public void Close()
  {
    _closed = true;
    if (_channel != null)
    {
      _channel.Interrupt();
    }
  }

  /// <summary>
  /// Initializes a new instance of the <see cref="ObjectiveChannelRect"/> class.
  /// </summary>
  /// <param name="targetRect">Where the channeling must be done.</param>
  /// <param name="rectName">A user-friendly name for the location the channeling must be done.</param>
  /// <param name="legendaryHero"></param>
  /// <param name="duration">How long the channel lasts.</param>
  /// <param name="facing">Which way the unit faces while channeling.</param>
  /// <param name="timerDialogTitle">If set, any <see cref="Channel"/> created by the <see cref="ObjectiveChannelRect"/>
  /// displays a countdown timer to all players with this title. If null, no timer is displayed.</param>
  public ObjectiveChannelRect(Rectangle targetRect, string rectName, LegendaryHero legendaryHero, int duration,
    float facing, string? timerDialogTitle = null)
  {
    _targetRect = targetRect.Rect;
    var target = RectToRegion(_targetRect);
    _targetLegend = legendaryHero;
    _duration = duration;
    SetDescription(
      "Have {hero} channel at {rect} for {duration} seconds",
      ("{hero}", legendaryHero.Name),
      ("{rect}", Loc.Get(rectName)),
      ("{duration}", duration.ToString()));
    _facing = facing;
    _timerDialogTitle = timerDialogTitle;

    MapEffectPath = TargetEffect;

    _entersRectTrig.Trigger.RegisterEnterRegion(target);
    _entersRectTrig.Trigger.AddAction(OnRegionEnter);
    DisplaysPosition = true;
    Position = new(_targetRect.CenterX, _targetRect.CenterY);
  }

  /// <inheritdoc />
  public override void OnAdd(Faction whichFaction)
  {
    if (StartCondition == null)
    {
      return;
    }

    _conditionTimer = timer.Create();
    _conditionTimer.Start(1, true, CheckCondition);
  }

  private void CheckCondition()
  {
    if (ProgressLocked)
    {
      _conditionTimer?.Dispose();
      _conditionTimer = null;
      return;
    }

    if (_channel != null)
    {
      if (!StartCondition!())
      {
        _channel.Interrupt();
      }

      return;
    }

    var whichUnit = _targetLegend.Unit;
    if (whichUnit != null && whichUnit.X >= _targetRect.MinX && whichUnit.X <= _targetRect.MaxX &&
        whichUnit.Y >= _targetRect.MinY && whichUnit.Y <= _targetRect.MaxY)
    {
      TryStartChannel(whichUnit);
    }
  }

  private void OnRegionEnter()
  {
    var whichUnit = @event.EnteringUnit;
    if (LegendaryHeroManager.GetFromUnit(@event.Unit) != _targetLegend)
    {
      return;
    }

    TryStartChannel(whichUnit);
  }

  private void TryStartChannel(unit whichUnit)
  {
    if (_closed || !EligibleFactions.Contains(whichUnit.Owner) || !whichUnit.Alive || _channel != null ||
        Progress != QuestProgress.Incomplete || StartCondition != null && !StartCondition())
    {
      return;
    }

    _channel = new Channel(whichUnit, _duration, _facing, Position, _timerDialogTitle);
    _channel.Finished += OnChannelEnd;
    ChannelStarted?.Invoke();
  }

  private void OnChannelEnd(Channel channel)
  {
    if (channel.FinishedWithoutInterruption)
    {
      Progress = QuestProgress.Complete;
    }

    channel.Finished -= OnChannelEnd;
    channel.Dispose();
    _channel = null;
    ChannelEnded?.Invoke();
  }
}
