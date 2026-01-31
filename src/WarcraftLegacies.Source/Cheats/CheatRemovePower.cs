using MacroTools.Commands;
using MacroTools.Extensions;

namespace WarcraftLegacies.Source.Cheats;

public sealed class CheatRemovePower : Command
{
  /// <inheritdoc />
  public override string CommandText => "removepower";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Deletes the specified Power";

  /// <inheritdoc />
  public override string Execute(player commandUser, params string[] parameters)
  {
    var faction = commandUser.GetPlayerData().Faction;
    if (faction == null)
    {
      return "You have no faction so you can't have powers.";
    }

    if (!faction.TryGetPowerByName(parameters[0], out var power))
    {
      return $"You don't have a Power named {parameters[0]}.";
    }

    faction.RemovePower(power);

    return $"Removed Power {power.Name}.";
  }
}
