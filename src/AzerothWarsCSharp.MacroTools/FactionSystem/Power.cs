namespace AzerothWarsCSharp.MacroTools.FactionSystem
{
  /// <summary>
  /// An ability that can be bestowed on a Faction.
  /// </summary>
  public class Power
  {
    public string IconName { get; protected init; }
    public string IconPath => $@"ReplaceableTextures\CommandButtons\BTN{IconName}.blp";
    public string Name { get; protected init; }
    public string Description { get; protected init; }
  }
}