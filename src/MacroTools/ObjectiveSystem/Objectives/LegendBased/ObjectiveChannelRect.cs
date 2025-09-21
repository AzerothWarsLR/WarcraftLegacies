using MacroTools.LegendSystem;
using MacroTools.QuestSystem;
using MacroTools.Wrappers;
using WCSharp.Shared.Data;
using static MacroTools.Libraries.GeneralHelpers;

namespace MacroTools.ObjectiveSystem.Objectives.LegendBased;

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
    Description = $"Have {legendaryHero.Name} channel at {rectName} for {duration} seconds";
    _facing = facing;
    _timerDialogTitle = timerDialogTitle;

    MapEffectPath = TargetEffect;

    _entersRectTrig.Trigger.RegisterEnterRegion(target, null);
    _entersRectTrig.Trigger.AddAction(OnRegionEnter);
    DisplaysPosition = true;
    Position = new(_targetRect.CenterX, _targetRect.CenterY);
  }

  private void OnRegionEnter()
  {
    var whichUnit = @event.EnteringUnit;
    if (!EligibleFactions.Contains(whichUnit.Owner) || !whichUnit.Alive ||
        LegendaryHeroManager.GetFromUnit(@event.Unit) != _targetLegend || _channel != null ||
        Progress != QuestProgress.Incomplete)
    {
      return;
    }

    _channel = new Channel(whichUnit, _duration, _facing, Position, _timerDialogTitle);
    _channel.Finished += OnChannelEnd;
  }

  private void OnChannelEnd(object? sender, Channel channel)
  {
    if (channel.FinishedWithoutInterruption)
    {
      Progress = QuestProgress.Complete;
    }

    channel.Finished -= OnChannelEnd;
    channel.Dispose();
    _channel = null;
  }
}
