

namespace MacroTools.FactionSystem
{
  /// <summary>
  ///   An ability that can be bestowed on a Faction.
  /// </summary>
  public abstract class Power
  {
    public string Name { get; init; } = "";

    public string Description { get; protected set; } = "";

    /// <summary>
    ///   Fired when the <see cref="Power" /> is added to a <see cref="player" />.
    /// </summary>
    public virtual void OnAdd(player whichPlayer)
    {
    }

    /// <summary>
    ///   Fired when the <see cref="Power" /> is added to a <see cref="player" />.
    /// </summary>
    public virtual void OnRemove(player whichPlayer)
    {
    }

    /// <summary>
    ///   Fired when the <see cref="Power" /> is added to a <see cref="Faction" />.
    /// </summary>
    public virtual void OnAdd(Faction whichFaction)
    {
    }

    /// <summary>
    ///   Fired when the <see cref="Power" /> is added to a <see cref="Faction" />.
    /// </summary>
    public virtual void OnRemove(Faction whichFaction)
    {
    }
  }
}