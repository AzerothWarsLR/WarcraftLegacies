using System.Linq;
using MacroTools.Commands;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Dalaran;
using WarcraftLegacies.Source.Factions.Dalaran.Paths;
using WarcraftLegacies.Source.Factions.Dalaran.Quests;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// Completes The Greymane Wall so the Gilneas paths open. Run by anyone but Dalaran, it also makes Dalaran take one.
/// </summary>
public sealed class CheatTestGilneas : Command
{
  /// <inheritdoc />
  public override string CommandText => "testgilneas";

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0, 1);

  /// <inheritdoc />
  public override CommandType Type => CommandType.Cheat;

  /// <inheritdoc />
  public override string Description =>
    "Gives Dalaran Gilneas City so the Gilneas paths open. Run as another faction, Dalaran also takes The Greymane Wall, or The Night Elves with \"elves\".";

  /// <inheritdoc />
  public override string Execute(player cheater, params string[] parameters)
  {
    if (!FactionManager.TryGetFactionByType<DalaranFaction>(out var dalaran) || dalaran.Player == null)
    {
      return "Dalaran isn't in the game.";
    }

    var quest = dalaran.GetQuestByType<QuestGilneas>();
    if (quest.Progress != QuestProgress.Complete)
    {
      quest.Progress = QuestProgress.Complete;
    }

    if (cheater.GetPlayerData().Faction == dalaran)
    {
      return "Gilneas City is yours. Open the Paths book.";
    }

    var joinNightElves = parameters.Length > 0 && parameters[0] == "elves";
    PathGilneas? path = joinNightElves
      ? dalaran.GetAllPaths().OfType<PathGilneasNightElves>().FirstOrDefault()
      : dalaran.GetAllPaths().OfType<PathGilneasGreymaneWall>().FirstOrDefault();
    if (path == null)
    {
      return "Dalaran has no Gilneas path. Is this Roleplay mode?";
    }

    path.ForceAvailable();
    path.Accept(dalaran.Player);
    return $"Dalaran is taking {path.Name}. It goes through in about 30 seconds.";
  }
}
