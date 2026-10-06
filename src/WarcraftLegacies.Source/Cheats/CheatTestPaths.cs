using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.GameTime;
using WarcraftLegacies.Source.Factions.Lordaeron;
using WarcraftLegacies.Source.Objectives.TurnBased;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Gives the player's faction some test paths so the Paths menu can be tried out.
/// </summary>
public sealed class CheatTestPaths : Command
{
  /// <inheritdoc />
  public override string CommandText => "testpaths";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Gives your faction some test paths to try out the Paths menu.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    var faction = cheater.GetPlayerData().Faction;
    if (faction == null)
    {
      return "You don't have a faction.";
    }

    if (faction is LordaeronFaction lordaeron)
    {
      lordaeron.AddRoleplayPaths();
    }

    faction.AddPath(new TestPath(500)
    {
      Name = "Path of Testing",
      IconName = "Sacrifice",
      Description = "Available straight away. Takes 15 seconds to go through once accepted, and gives 500 gold.",
      CommitDuration = 15
    });

    faction.AddPath(new TestPath(1000, new ObjectiveTurn(GameTimeManager.Turn + 1))
    {
      Name = "Path of Patience",
      IconName = "Charm",
      Description = "Unlocks next turn, then closes if it isn't accepted within 45 seconds. Gives 1000 gold.",
      OfferDuration = 45,
      CommitDuration = 10
    });

    return $"Added test paths to {faction.Name}.";
  }
}
