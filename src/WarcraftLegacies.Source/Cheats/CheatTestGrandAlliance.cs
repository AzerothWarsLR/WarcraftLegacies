using MacroTools.Commands;
using MacroTools.Extensions;
using WarcraftLegacies.Source.GameLogic;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>Makes the Grand Alliance happen straight away.</summary>
public sealed class CheatTestGrandAlliance : Command
{
  /// <inheritdoc />
  public override string CommandText => "testgrandalliance";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Makes the Grand Alliance happen straight away.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var grandAlliance = RoleplaySetting.GrandAlliance;
    if (grandAlliance == null)
    {
      return "The Grand Alliance isn't set up. Is this Roleplay mode?";
    }

    grandAlliance.HappenNow(cheater.GetPlayerData().Faction?.ColoredName);
    return "The Grand Alliance has formed.";
  }
}
