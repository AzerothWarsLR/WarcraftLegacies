using MacroTools.Commands;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Gives the player a specified amount of gold.
/// </summary>
public sealed class CheatGold : Command
{

  /// <inheritdoc />
  public override string CommandText => "addgold";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Gives the player a specified amount of gold.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    cheater.SetState(playerstate.ResourceGold, S2I(parameters[0]));
    return "Set to " + parameters[0] + " gold.";
  }
}
