using MacroTools.CommandSystem;
using MacroTools.Extensions;
using MacroTools.FactionSystem;

namespace MacroTools.Cheats;

/// <summary>
/// A <see cref="CommandSystem.Command"/> that sets the specified research to the specified level for the cheater.
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

    var faction = cheater.GetFaction();
    if (faction == null)
    {
      return $"You need to have a valid {nameof(Faction)} to use this Command.";
    }

    faction.SetObjectLevel(researchId, level);
    return $"Setting research {objectName} to level {level}.";
  }
}
