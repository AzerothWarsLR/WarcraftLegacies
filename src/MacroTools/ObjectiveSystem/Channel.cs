using System;
using MacroTools.Libraries;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using WCSharp.Shared.Data;
using Environment = MacroTools.Libraries.Environment;

namespace MacroTools.ObjectiveSystem;

/// <summary>
/// Used to immobilize a unit and force them to play their channeling animation for a duration.
/// <para>Used exclusively by <see cref="ObjectiveChannelRect"/>.</para>
/// </summary>
public sealed class Channel : IDisposable
{
  private const string Effect = "Abilities\\Spells\\Other\\Drain\\ManaDrainCaster.mdl";
  private const string ProgressEffect = "war3mapImported\\Progressbar10sec.mdx";
  private const float ProgressScale = 1.5f;
  private const float ProgressHeight = 285f;
  private const float Period = 0.15f;

  private readonly unit _caster;
  private readonly float _maxDuration;
  private float _elapsedDuration;
  private readonly effect _sfxProgress;
  private readonly effect _sfx;
  private readonly timer? _channelingTimer;
  private readonly timerdialog? _channelingDialog;
  private readonly Point _position;
  private readonly timer _periodictimer;

  /// <summary>
  /// Fired when the <see cref="Channel"/> ends, successfully or otherwise.
  /// </summary>
  public event EventHandler<Channel>? Finished;

  /// <summary>
  /// If true, the caster finished the entire channel duration.
  /// </summary>
  public bool FinishedWithoutInterruption { get; private set; }

  /// <summary>
  /// Initializes a new instance of the <see cref="Channel"/> class.
  /// </summary>
  /// <param name="caster">The caster to force to channel.</param>
  /// <param name="duration">How long the channel should last.</param>
  /// <param name="facing">Which way the caster should face while channeling.</param>
  /// <param name="position">Where the caster should channel from.</param>
  /// <param name="timerDialogTitle">If set, the <see cref="Channel"/> displays a countdown timer to all players with
  /// this title. If null, no timer is displayed.</param>
  public Channel(unit caster, int duration, float facing, Point position, string? timerDialogTitle = null)
  {
    _caster = caster;
    _elapsedDuration = 0;
    _maxDuration = duration;

    _position = position;

    caster.SetPosition(_position.X, _position.Y);
    caster.SetPausedEx(true);
    caster.SetAnimation("channel");
    caster.Facing = facing;
    caster.IsInvulnerable = false;
    _sfxProgress = effect.Create(ProgressEffect, caster.X, caster.Y);
    _sfxProgress.SetTimeScale(10 / (float)duration);
    _sfxProgress.SetColor(caster.Owner);
    _sfxProgress.Scale = ProgressScale;
    _sfxProgress.SetHeight(ProgressHeight + Environment.GetPositionZ(position));
    _sfx = effect.Create(Effect, caster.X, caster.Y);

    if (timerDialogTitle != null)
    {
      _channelingTimer = timer.Create();
      _channelingTimer.Start(_maxDuration, false, null);
      _channelingDialog = timerdialog.Create(_channelingTimer);
      _channelingDialog.SetTitle(timerDialogTitle);
      _channelingDialog.IsDisplayed = true;
    }

    _periodictimer = timer.Create();
    _periodictimer.Start(Period, true, Periodic);
  }

  /// <inheritdoc />
  public void Dispose()
  {
    _sfxProgress.SetPosition(-100000, -100000, 0); //Has no death animation so needs to be moved off the map
    _sfxProgress.Dispose();
    _sfx.Dispose();
    if (_channelingTimer != null)
    {
      _channelingTimer.Dispose();
    }

    _periodictimer.Dispose();
    _channelingDialog.Dispose();
  }

  private void End(bool finishedWithoutInterruption)
  {
    _caster.SetPausedEx(false);
    if (finishedWithoutInterruption)
    {
      _caster.SetAnimation("spell");
    }

    if (_caster.Alive)
    {
      _caster.QueueAnimation("stand");
    }

    FinishedWithoutInterruption = finishedWithoutInterruption;
    Finished?.Invoke(this, this);
  }

  private void Periodic()
  {
    if (!_caster.Alive || MathEx.GetDistanceBetweenPoints(new Point(_caster.X, _caster.Y),
      _position) > 100)
    {
      End(false);
    }

    _elapsedDuration += Period;
    if (_elapsedDuration >= _maxDuration)
    {
      End(true);
    }
  }
}
