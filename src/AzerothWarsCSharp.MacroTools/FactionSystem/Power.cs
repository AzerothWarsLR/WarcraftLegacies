using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  /// <summary>
  ///   An ability that can be bestowed on a Faction.
  /// </summary>
  public abstract class Power
  {
    public string IconName { get; protected init; }
    public string IconPath => $@"ReplaceableTextures\CommandButtons\BTN{IconName}.blp";
    public string Name { get; protected init; }
    public string Description { get; protected init; }

    /// <summary>
    ///   Fired when the <see cref="Power" /> is added to a <see cref="player" />.
    /// </summary>
    public abstract void OnAdd(player whichPlayer);

    /// <summary>
    ///   Fired when the <see cref="Power" /> is added to a <see cref="player" />.
    /// </summary>
    public abstract void OnRemove(player whichPlayer);
  }
}