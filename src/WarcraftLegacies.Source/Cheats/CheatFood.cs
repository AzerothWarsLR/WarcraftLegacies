using MacroTools.Commands;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Cheats;

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
    cheater.FoodCap += S2I(parameters[0]);
    return Loc.Format("Granted {amount} food.", ("{amount}", parameters[0]));
  }
}
