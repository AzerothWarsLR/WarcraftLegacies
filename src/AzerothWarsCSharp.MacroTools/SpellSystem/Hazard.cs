using System;
using WCSharp.Events;

namespace AzerothWarsCSharp.MacroTools.SpellSystem
{
  /// <summary>
  ///   A visible but unselectabe effect on the map that causes some periodic effect around it,
  ///   like a tornado, volcano, or whirlpool.
  /// </summary>
  public abstract class Hazard : IPeriodicDisposableAction
  {
    protected Hazard(string effectPath, unit caster, float x, float y)
    {
      X = x;
      Y = y;
      Caster = caster;
      Effect = AddSpecialEffect(effectPath, x, y);
    }

    protected float X { get; }
    protected float Y { get; }
    protected unit Caster { get; }
    private effect Effect { get; }

    private readonly float _interval;

    /// <summary>
    ///   The interval at which the missile will call <see cref="OnPeriodic" />. Leave at default (0) to disable.
    /// </summary>
    public float Interval
    {
      get => _interval;
      init
      {
        _interval = value;
        _intervalLeft = Math.Max(_interval, _intervalLeft);
      }
    }

    /// <summary>
    ///   The time left until the next call to <see cref="OnPeriodic" />.
    /// </summary>
    private float _intervalLeft;

    /// <summary>
    ///   How long until the Hazard disappears.
    /// </summary>
    public float Duration { get; set; } = 1;

    /// <summary>
    ///   Called by the system. Do not call yourself.
    /// </summary>
    public void Action()
    {
      if (Interval > 0) RunInterval();
    }

    /// <inheritdoc />
    public void Dispose()
    {
      OnDispose();
      if (Effect != null) DestroyEffect(Effect);
    }

    public abstract bool Active { get; set; }

    /// <summary>
    /// Fired when the <see cref="Hazard"/> is initially registered.
    /// </summary>
    public virtual void OnCreate()
    {
    }

    /// <summary>
    ///   <para>Override this method if your Hazard has a periodic effect.</para>
    ///   <para>For this to be active, <see cref="Interval" /> must be greater than 0.</para>
    /// </summary>
    protected virtual void OnPeriodic()
    {
    }

    /// <summary>
    ///   Override this method if your hazard has an effect that should trigger when it is destroyed for any reason.
    /// </summary>
    protected virtual void OnDispose()
    {
    }

    /// <summary>
    ///   Retrieves the LocationZ at the given (X, Y) coordinates.
    /// </summary>
    protected static float GetZ(float x, float y)
    {
      var loc = Location(x, y);
      var z = GetLocationZ(loc);
      RemoveLocation(loc);
      return z;
    }

    /// <summary>
    ///   Runs the Interval related code. Do not call if <see cref="Interval" /> is 0.
    /// </summary>
    private void RunInterval()
    {
      _intervalLeft -= PeriodicEvents.SYSTEM_INTERVAL;
      if (_intervalLeft <= 0)
      {
        _intervalLeft += Interval;
        OnPeriodic();
      }

      Duration -= PeriodicEvents.SYSTEM_INTERVAL;
      if (Duration <= 0) Dispose();
    }
  }
}