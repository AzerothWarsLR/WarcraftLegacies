using System;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using WCSharp.Shared.Data;
using static War3Api.Common;
using Environment = MacroTools.Libraries.Environment;

namespace MacroTools.ObjectiveSystem
{
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

      caster.SetPosition(_position);
      BlzPauseUnitEx(caster, true);
      SetUnitAnimation(caster, "channel");
      BlzSetUnitFacingEx(caster, facing);
      SetUnitInvulnerable(caster, false);
      _sfxProgress = AddSpecialEffect(ProgressEffect, GetUnitX(caster), GetUnitY(caster));
      BlzSetSpecialEffectTimeScale(_sfxProgress, 10 / (float)duration);
      BlzSetSpecialEffectColorByPlayer(_sfxProgress, caster.OwningPlayer());
      BlzSetSpecialEffectScale(_sfxProgress, ProgressScale);
      BlzSetSpecialEffectHeight(_sfxProgress, ProgressHeight + Environment.GetPositionZ(position));
      _sfx = AddSpecialEffect(Effect, GetUnitX(caster), GetUnitY(caster));

      if (timerDialogTitle != null)
      {
        _channelingTimer = CreateTimer();
        TimerStart(_channelingTimer, _maxDuration, false, null);
        _channelingDialog = CreateTimerDialog(_channelingTimer);
        TimerDialogSetTitle(_channelingDialog, timerDialogTitle);
        TimerDialogDisplay(_channelingDialog, true);
      }

      _periodictimer = CreateTimer().Start(Period, true, Periodic);
    }

    /// <inheritdoc />
    public void Dispose()
    {
      BlzSetSpecialEffectPosition(_sfxProgress, -100000, -100000, 0); //Has no death animation so needs to be moved off the map
      DestroyEffect(_sfxProgress);
      DestroyEffect(_sfx);
      _channelingTimer?.Destroy();
      _periodictimer.Destroy();
      DestroyTimerDialog(_channelingDialog);
    }
    
    private void End(bool finishedWithoutInterruption)
    {
      BlzPauseUnitEx(_caster, false);
      if (finishedWithoutInterruption) 
        SetUnitAnimation(_caster, "spell");

      if (UnitAlive(_caster)) 
        QueueUnitAnimation(_caster, "stand");

      FinishedWithoutInterruption = finishedWithoutInterruption;
      Finished?.Invoke(this, this);
    }

    private void Periodic()
    {
      if (!UnitAlive(_caster) || MathEx.GetDistanceBetweenPoints(new Point(GetUnitX(_caster), GetUnitY(_caster)),
        _position) > 100) 
        End(false);

      _elapsedDuration += Period;
      if (_elapsedDuration >= _maxDuration) 
        End(true);
    }
  }
}