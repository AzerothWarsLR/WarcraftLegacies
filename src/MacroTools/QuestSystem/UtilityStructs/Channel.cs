using System;
using MacroTools.Extensions;
using MacroTools.Libraries;
using WCSharp.Shared.Data;
using static War3Api.Common;
using Environment = MacroTools.Libraries.Environment;

namespace MacroTools.QuestSystem.UtilityStructs
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
    /// <param name="global">If true, all players are alerted to the channel by a timer.</param>
    /// <param name="title">The name of the timer to use when alerting all players.</param>
    public Channel(unit caster, int duration, float facing, Point position, bool global = false, string title = "")
    {
      _caster = caster;
      _elapsedDuration = 0;
      _maxDuration = duration;

      _position = position;

      caster.SetPosition(_position)
        .Pause(true)
        .SetAnimation("channel")
        .SetFacingEx(facing);
      _sfxProgress = AddSpecialEffect(ProgressEffect, GetUnitX(caster), GetUnitY(caster))
        .SetTimeScale(10 / (float)duration)
        .SetColor(caster.OwningPlayer())
        .SetScale(ProgressScale)
        .SetHeight(ProgressHeight + Environment.GetPositionZ(position));
      _sfx = AddSpecialEffect(Effect, GetUnitX(caster), GetUnitY(caster));

      if (global)
      {
        _channelingTimer = CreateTimer();
        TimerStart(_channelingTimer, _maxDuration, false, null);
        _channelingDialog = CreateTimerDialog(_channelingTimer);
        TimerDialogSetTitle(_channelingDialog, title);
        TimerDialogDisplay(_channelingDialog, true);
      }

      _periodictimer = CreateTimer().Start(Period, true, Periodic);
    }

    /// <inheritdoc />
    public void Dispose()
    {
      _sfxProgress
        .SetPosition(new Point(-100000, -100000)) //Has no death animation so needs to be moved off the map
        .Destroy();
      _sfx.Destroy();
      _channelingTimer?.Destroy();
      _periodictimer.Destroy();
      DestroyTimerDialog(_channelingDialog);
    }
    
    private void End(bool finishedWithoutInterruption)
    {
      PauseUnit(_caster, false);
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