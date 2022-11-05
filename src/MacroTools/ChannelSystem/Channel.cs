using System;
using WCSharp.Events;
using static War3Api.Common;

namespace MacroTools.ChannelSystem
{
  /// <summary>
  /// A spell effect which has to be continually maintained by a caster. If the caster is interrupted, the effect ends.
  /// </summary>
  public abstract class Channel : IPeriodicDisposableAction
  {
    /// <summary>
    /// The unit that is maintaining the channel. If it dies or is interrupted, the channel ends.
    /// </summary>
    public unit Caster { get; }
    
    /// <summary>
    /// The spell being used to represent the channel.
    /// The duration for it is used to determine the duration of this custom effect.
    /// </summary>
    public int SpellId { get; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Channel"/> class.
    /// </summary>
    /// <param name="caster">The unit maintaining the <see cref="Channel"/>.</param>
    /// <param name="spellId">The spell ID representing the <see cref="Channel"/>.</param>
    protected Channel(unit caster, int spellId)
    {
      Caster = caster;
      SpellId = spellId;
      var ability = BlzGetUnitAbility(Caster, SpellId);
      Duration = BlzGetAbilityRealLevelField(ability, ABILITY_RLF_DURATION_NORMAL,
        GetUnitAbilityLevel(Caster, SpellId));
    }
    
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
    ///   How long until the <see cref="Channel"/> disappears.
    /// </summary>
    public float Duration { get; private set; }

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
      Active = false;
      OnDispose();
    }

    /// <summary>
    /// When false, the <see cref="Channel"/> should be disposed of.
    /// </summary>
    public abstract bool Active { get; set; }

    /// <summary>
    /// Fired when the <see cref="Channel"/> is initially registered.
    /// </summary>
    public virtual void OnCreate()
    {
    }

    /// <summary>
    ///   <para>Override this method if your <see cref="Channel"/> has a periodic effect.</para>
    ///   <para>For this to be active, <see cref="Interval" /> must be greater than 0.</para>
    /// </summary>
    protected virtual void OnPeriodic()
    {
    }

    /// <summary>
    ///   Override this method if your <see cref="Channel"/> has an effect that should trigger when it ends.
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