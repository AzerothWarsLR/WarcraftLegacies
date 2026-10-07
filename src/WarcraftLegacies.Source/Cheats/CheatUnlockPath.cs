using MacroTools.Commands;
using MacroTools.Extensions;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Makes one of the player's locked paths available straight away, so paths can be tested without meeting their
/// requirements.
/// </summary>
public sealed class CheatUnlockPath : Command
{
  /// <inheritdoc />
  public override string CommandText => "unlockpath";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Unlocks the first of your paths whose name contains the given word.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var faction = cheater.GetPlayerData().Faction;
    if (faction == null)
    {
      return "You don't have a faction.";
    }

    var search = parameters[0].ToLower();
    foreach (var path in faction.GetAllPaths())
    {
      if (path.Name.ToLower().Contains(search))
      {
        path.ForceAvailable();
        return $"Unlocked {path.Name}.";
      }
    }

    return $"{faction.Name} has no path matching {parameters[0]}.";
  }
}
