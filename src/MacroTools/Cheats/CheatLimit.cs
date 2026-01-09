using MacroTools.CommandSystem;
using MacroTools.Extensions;

namespace MacroTools.Cheats;

/// <summary>
/// Displays the limit of an object.
/// </summary>
public sealed class CheatLimit : Command
{
  /// <inheritdoc />
  public override string CommandText => "limit";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Displays the current limit of a unit or research.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var objectTypeId = FourCC(parameters[0]);
    if (objectTypeId == 0)
    {
      return "You must specify a valid object type ID as the first parameter.";
    }

    var playerData = cheater.GetPlayerData();
    var message = $"Your limits for {GetObjectName(objectTypeId)} are as follows.";
    message += $"\nPlayer: {cheater.GetTechMaxAllowed(objectTypeId)}";
    message += $"\nPlayer Data: {playerData.GetObjectLimit(objectTypeId)}";

    if (playerData.Faction != null)
    {
      message += $"\nFaction: {playerData.Faction.GetObjectLimit(objectTypeId)}";
    }

    return message;
  }
}
