using MacroTools.Commands;
using MacroTools.Extensions;

namespace WarcraftLegacies.Source.Cheats;

public sealed class CheatPingGoldMines : Command
{
  /// <inheritdoc />
  public override string CommandText => "goldmines";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description => "Pings all of your faction's registered gold mines.";

  /// <inheritdoc />
  public override string Execute(player commandUser, params string[] parameters)
  {
    var faction = commandUser.GetPlayerData().Faction;
    if (faction == null)
    {
      return "You don't have a Faction.";
    }

    foreach (var goldMine in faction.GoldMines)
    {
      PingMinimap(goldMine.X, goldMine.Y, 10);
    }

    return "Pinging all of your Faction's registered gold mines.";
  }
}
