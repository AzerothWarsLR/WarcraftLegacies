using MacroTools.CommandSystem;
using MacroTools.Extensions;

namespace MacroTools.Cheats;

/// <summary>
/// Increases the player's food cap by the specified amount.
/// </summary>
public sealed class CheatFood : Command
{

  /// <inheritdoc />
  public override string CommandText => "food";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Increases the player's food cap by the specified amount.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    cheater.AdjustPlayerState(PLAYER_STATE_RESOURCE_FOOD_CAP, S2I(parameters[0]));
    return "Granted " + parameters[0] + " food.";
  }
}
