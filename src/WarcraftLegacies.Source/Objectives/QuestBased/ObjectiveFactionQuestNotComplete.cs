using MacroTools.FactionSystem;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.QuestBased;

/// <summary>
/// An <see cref="Objective"/> that starts completed, and is failed if a specific <see cref="Faction"/> completes a
/// specific <see cref="QuestData"/>.
/// </summary>
public sealed class ObjectiveFactionQuestNotComplete : Objective
{
  private readonly QuestData _target;

  public ObjectiveFactionQuestNotComplete(QuestData target, Faction faction)
  {
    _target = target;
    Description = $"{faction.Name} has not completed the quest {target.Title}";
    faction.QuestProgressChanged += OnQuestProgressChanged;
    Progress = QuestProgress.Complete;
  }

  private void OnQuestProgressChanged(object? sender, FactionQuestProgressChangedEventArgs args)
  {
    if (args.Quest == _target && args.Quest.Progress == QuestProgress.Complete)
    {
      Progress = QuestProgress.Failed;
    }
  }
}
