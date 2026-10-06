using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Cheats;

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
    var message = Loc.Format("Your limits for {unit} are as follows.", ("{unit}", GetObjectName(objectTypeId)));
    message += Loc.Format("\nPlayer: {value}", ("{value}", cheater.GetTechMaxAllowed(objectTypeId).ToString()));
    message += Loc.Format("\nPlayer Data: {value}", ("{value}", playerData.GetObjectLimit(objectTypeId).ToString()));

    if (playerData.Faction != null)
    {
      message += Loc.Format("\nFaction: {value}",
        ("{value}", playerData.Faction.GetObjectLimit(objectTypeId).ToString()));
    }

    return message;
  }
}
