using System;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.Wrappers;
using WCSharp.Shared.Data;

using static War3Api.Common;
using Environment = AzerothWarsCSharp.MacroTools.Libraries.Environment;

namespace AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs
{
  public sealed class Channel : IDisposable
  {
    private const string EFFECT = "Abilities\\Spells\\Other\\Drain\\ManaDrainCaster.mdl";
    private const string PROGRESS_EFFECT = "war3mapImported\\Progressbar10sec.mdx";
    private const float PROGRESS_SCALE = 1.5f;
    private const float PROGRESS_HEIGHT = 285f;
    private const float PERIOD = 0.15f;

    private bool _disposed;
    private readonly unit _caster;
    private readonly float _maxDuration;
    private float _elapsedDuration;
    private readonly effect _sfxProgress;
    private readonly effect _sfx;
    private readonly timer? _channelingTimer;
    private readonly timerdialog? _channelingDialog;
    private readonly Point _position;

    private readonly TimerWrapper _periodictimer = new();

    public event EventHandler<Channel>? Finished;

    /// <summary>
    /// If true, the caster finished the entire channel duration.
    /// </summary>
    public bool FinishedWithoutInterruption { get; private set; }

    private void End(bool finishedWithoutInterruption)
    {
      PauseUnit(_caster, false);
      if (finishedWithoutInterruption)
      {
        SetUnitAnimation(_caster, "spell");
      }

      if (UnitAlive(_caster))
      {
        QueueUnitAnimation(_caster, "stand");
      }

      FinishedWithoutInterruption = finishedWithoutInterruption;
      Finished?.Invoke(this, this);
    }

    private void Periodic()
    {
      if (!UnitAlive(_caster) || MathEx.GetDistanceBetweenPoints(new Point(GetUnitX(_caster), GetUnitY(_caster)),
        _position) > 100)
      {
        End(false);
      }

      _elapsedDuration += PERIOD;
      if (_elapsedDuration >= _maxDuration)
      {
        End(true);
      }
    }

    ~Channel()
    {
      Dispose(false);
    }

    public void Dispose()
    {
      Dispose(true);
    }

    private void Dispose(bool disposing)
    {
      if (_disposed)
      {
        return;
      }

      if (disposing)
      {
        _periodictimer.Dispose();
      }

      BlzSetSpecialEffectPosition(_sfxProgress, -100000, -100000,
        0); //Has no death animation so needs to be moved off the map
      DestroyEffect(_sfxProgress);
      DestroyEffect(_sfx);
      DestroyTimer(_channelingTimer);
      DestroyTimerDialog(_channelingDialog);

      _disposed = true;
    }

    public Channel(unit caster, float duration, float facing, Point position, bool global = false, string title = "")
    {
      _caster = caster;
      _elapsedDuration = 0;
      _maxDuration = duration;

      _position = position;

      SetUnitX(caster, position.X);
      SetUnitY(caster, position.Y);
      _sfxProgress = AddSpecialEffect(PROGRESS_EFFECT, GetUnitX(caster), GetUnitY(caster));
      BlzSetSpecialEffectTimeScale(_sfxProgress, 10 / duration);
      BlzSetSpecialEffectColorByPlayer(_sfxProgress, GetOwningPlayer(caster));
      BlzSetSpecialEffectScale(_sfxProgress, PROGRESS_SCALE);
      BlzSetSpecialEffectHeight(_sfxProgress,
        PROGRESS_HEIGHT + Environment.GetPositionZ(position.X, position.Y));
      _sfx = AddSpecialEffect(EFFECT, GetUnitX(caster), GetUnitY(caster));
      PauseUnit(caster, true);
      SetUnitAnimation(caster, "channel");
      BlzSetUnitFacingEx(caster, facing);

      if (global)
      {
        _channelingTimer = CreateTimer();
        TimerStart(_channelingTimer, _maxDuration, false, null);
        _channelingDialog = CreateTimerDialog(_channelingTimer);
        TimerDialogSetTitle(_channelingDialog, title);
        TimerDialogDisplay(_channelingDialog, true);
      }

      _periodictimer.Start(PERIOD, true, Periodic);
    }
  }
}