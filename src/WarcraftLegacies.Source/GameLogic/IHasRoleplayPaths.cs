namespace WarcraftLegacies.Source.GameLogic;

/// <summary>
/// A faction that has <see cref="MacroTools.Paths.FactionPath"/>s it can take in Roleplay mode.
/// </summary>
public interface IHasRoleplayPaths
{
  /// <summary>Adds the faction's Roleplay paths. Only called once, and only in Roleplay mode.</summary>
  void AddRoleplayPaths();
}
