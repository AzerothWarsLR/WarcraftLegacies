using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Localization;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// A <see cref="Command"/> that sets the specified research to the specified level for the cheater.
/// </summary>
public sealed class CheatSetResearchLevel : Command
{
  /// <inheritdoc />
  public override string CommandText => "setresearchlevel";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(2);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Sets the specified research to the specified level.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var research = parameters[0];

    if (research.Length != 4)
    {
      return "You must specify a research ID of exactly 4 characters.";
    }

    var researchId = FourCC(research);
    var objectName = GetObjectName(researchId);

    if (!int.TryParse(parameters[1], out var level))
    {
      return "You must specify a valid research level as the second parameter.";
    }

    var faction = cheater.GetPlayerData().Faction;
    if (faction == null)
    {
      return Loc.Get("You need to have a valid Faction to use this Command.");
    }

    faction.SetObjectLevel(researchId, level);
    return Loc.Format("Setting research {research} to level {level}.",
      ("{research}", objectName), ("{level}", level.ToString()));
  }
}
