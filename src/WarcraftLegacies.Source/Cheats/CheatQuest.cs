using System.Linq;
using MacroTools.Commands;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Cheats;

/// <summary>
/// A <see cref="CompositeCommand"/> that manages a faction's quests.
/// </summary>
public sealed class CheatQuest : CompositeCommand
{
  public CheatQuest() : base("quest", "Manages faction quests.")
  {
  }

  /// <inheritdoc />
  public override ExpectedParameterCount ExpectedParameterCount => new(0, 3);

  protected override void ConfigureVerbs()
  {
    AddVerb("list", "<faction>", "lists a faction's quests", List);
    AddVerb("complete", "<faction> <key>", "completes a faction's quest", (_, args) => SetProgress(args, QuestProgress.Complete));
    AddVerb("fail", "<faction> <key>", "fails a faction's quest", (_, args) => SetProgress(args, QuestProgress.Failed));
    AddVerb("uncomplete", "<faction> <key>", "marks a faction's quest incomplete", (_, args) => SetProgress(args, QuestProgress.Incomplete));
    AddVerb("undiscover", "<faction> <key>", "marks a faction's quest undiscovered", (_, args) => SetProgress(args, QuestProgress.Undiscovered));
  }

  private static string List(player whichPlayer, string[] args)
  {
    if (args.Length < 1)
    {
      return "Usage: -quest list <faction>";
    }

    if (!CommandTargets.TryResolveFaction(args[0], out var faction, out var error))
    {
      return error;
    }

    return $"Quests for {faction.Name}:\n" + string.Join("\n", faction.GetAllQuests()
      .Select((quest, i) => $"[{i + 1}] [{CommandTargets.GetQuestKey(quest)}] {quest.Title} - {quest.Progress}")
      .ToList());
  }

  private static string SetProgress(string[] args, QuestProgress progress)
  {
    if (args.Length < 2)
    {
      return "Usage: -quest <complete|fail|uncomplete|undiscover> <faction> <key>";
    }

    if (!CommandTargets.TryResolveFaction(args[0], out var faction, out var error))
    {
      return error;
    }

    if (!CommandTargets.TryResolveQuest(faction, args[1], out var quest, out error))
    {
      return error;
    }

    quest.Progress = progress;
    return $"Set quest progress of {quest.Title} to {progress} for Faction {faction.Name}.";
  }
}
