using System.Linq;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Ironforge;
using WarcraftLegacies.Source.Factions.Ironforge.Paths;
using WarcraftLegacies.Source.Factions.Ironforge.Quests;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Completes the Dark Iron Alliance quest so the Dark Iron paths open. Run by anyone but Ironforge, it also makes Ironforge take one.
/// </summary>
public sealed class CheatTestDarkIron : Command
{
  /// <inheritdoc />
  public override string CommandText => "testdarkiron";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0, 1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description =>
    "Completes the Dark Iron Alliance quest so the Dark Iron paths open. Run as another faction, Ironforge also takes The Dark Iron: The Burning Legion, or Alone with \"alone\".";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    if (!FactionManager.TryGetFactionByType<IronforgeFaction>(out var ironforge) || ironforge.Player == null)
    {
      return "Ironforge isn't in the game.";
    }

    var darkIronAlliance = ironforge.GetQuestByType<QuestDarkIron>();
    if (darkIronAlliance.Progress != QuestProgress.Complete)
    {
      darkIronAlliance.Progress = QuestProgress.Complete;
    }

    if (cheater.GetPlayerData().Faction == ironforge)
    {
      return "The Dark Iron Alliance is complete. Open the Paths book.";
    }

    var goAlone = parameters.Length > 0 && parameters[0] == "alone";
    PathDarkIron? path = goAlone
      ? ironforge.GetAllPaths().OfType<PathDarkIronAlone>().FirstOrDefault()
      : ironforge.GetAllPaths().OfType<PathDarkIronLegion>().FirstOrDefault();
    if (path == null)
    {
      return "Ironforge has no Dark Iron path. Is this Roleplay mode?";
    }

    path.ForceAvailable();
    path.Accept(ironforge.Player);
    return $"Ironforge is taking {path.Name}. It goes through in about 30 seconds.";
  }
}
