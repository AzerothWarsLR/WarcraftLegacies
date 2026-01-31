using MacroTools.Factions;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.QuestBased;

public sealed class ObjectiveQuestNotComplete : Objective
{
  private readonly QuestData _target;

  public ObjectiveQuestNotComplete(QuestData target)
  {
    Description = $"Do not complete the quest {target.Title}";
    Progress = QuestProgress.Complete;
    _target = target;
  }

  /// <inheritdoc />
  public override void OnAdd(Faction faction) => faction.QuestProgressChanged += OnQuestProgressChanged;

  private void OnQuestProgressChanged(object? sender, FactionQuestProgressChangedEventArgs args)
  {
    if (args.Quest != _target)
    {
      return;
    }

    if (args.Quest.Progress == QuestProgress.Complete)
    {
      Progress = QuestProgress.Failed;
    }
  }
}
