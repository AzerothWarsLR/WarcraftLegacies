using System.Linq;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Stormwind;
using WarcraftLegacies.Source.Factions.Stormwind.Paths;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Destroys Stormwind Keep so the Stromgarde path opens. Run by anyone but Stormwind, it also makes Stormwind take it.
/// </summary>
public sealed class CheatTestStromgarde : Command
{
  /// <inheritdoc />
  public override string CommandText => "teststromgarde";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description =>
    "Destroys Stormwind Keep so the Stromgarde path opens. Run as another faction, Stormwind also takes it.";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    if (!FactionManager.TryGetFactionByType<StormwindFaction>(out var stormwind) || stormwind.Player == null)
    {
      return "Stormwind isn't in the game.";
    }

    var keep = AllLegends.Stormwind.StormwindKeep.Unit;
    if (keep != null && keep.Alive)
    {
      keep.Kill();
    }

    if (cheater.GetPlayerData().Faction == stormwind)
    {
      return "Stormwind Keep is destroyed. Open the Paths book.";
    }

    var path = stormwind.GetAllPaths().OfType<PathStromgarde>().FirstOrDefault();
    if (path == null)
    {
      return "Stormwind has no Stromgarde path. Is this Roleplay mode?";
    }

    path.ForceAvailable();
    path.Accept(stormwind.Player);
    return $"Stormwind is taking {path.Name}. It goes through in about 30 seconds.";
  }
}
