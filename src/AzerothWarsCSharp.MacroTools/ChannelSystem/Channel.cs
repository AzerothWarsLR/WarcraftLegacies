using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.ChannelSystem
{
  public abstract class Channel
  {
    public bool Active { get; set; }
    public unit Caster { get; }
    public int SpellId { get; }

    protected Channel(unit caster, int spellId)
    {
      Caster = caster;
      SpellId = spellId;
    }

    /// <summary>
    ///   Called by the system. Do not call yourself.
    /// </summary>
    public abstract void Apply();

    /// <summary>
    ///   Called by the system. Do not call yourself.
    /// </summary>
    public abstract void Action();

    /// <summary>
    ///   Executes immediately upon registry of the Channel.
    /// </summary>
    public virtual void OnApply()
    {
    }

    /// <summary>
    ///   Executes when the buff is removed for any reason whatsoever.
    /// </summary>
    public virtual void OnDispose()
    {
    }

    /// <summary>
    ///   Executes when the Channel expires by reaching the end of its duration. Does not trigger when the buff is removed via
    ///   a dispel or target dies.
    /// </summary>
    public virtual void OnExpire()
    {
    }

    /// <summary>
    ///   Executes immediately after <see cref="Caster" /> dies.
    ///   <para>
    ///     Note: <paramref name="killingBlow" /> will be true if the unit dies while the buffs actions are being evaluated.
    ///     It may not be directly responsible for the death due to asynchronous events.
    ///   </para>
    /// </summary>
    /// <param name="killingBlow"></param>
    public virtual void OnDeath(bool killingBlow)
    {
    }

    /// <summary>
    ///   Automatically called after <see cref="Active" /> is set to false.
    ///   <para>Automatically called by the system. Do not call yourself.</para>
    /// </summary>
    public abstract void Dispose();
  }
}