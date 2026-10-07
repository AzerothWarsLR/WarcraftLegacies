using MacroTools.Commands;
using MacroTools.Factions;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Changes how big teams can get and how long players wait between team changes, so team changes can be tested.
/// </summary>
public sealed class CheatTeamRules : Command
{
  /// <inheritdoc />
  public override string CommandText => "teamrules";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(2);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Sets the team size cap (0 keeps the current caps) and the team change cooldown in seconds.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var capacity = S2I(parameters[0]);
    var cooldown = S2I(parameters[1]);
    TeamChanges.Cooldown = cooldown;
    if (capacity <= 0)
    {
      return $"Team caps unchanged, with a {cooldown} second cooldown between team changes.";
    }

    TeamChanges.Capacity = _ => capacity;
    return $"Teams are now capped at {capacity} players, with a {cooldown} second cooldown between team changes.";
  }
}
