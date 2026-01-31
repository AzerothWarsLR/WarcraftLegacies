using MacroTools.FactionSystem;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.QuestBased;

/// <summary>
/// An <see cref="Objective"/> that is completed when a specific <see cref="Faction"/> completes a specific
/// <see cref="QuestData"/>.
/// </summary>
public sealed class ObjectiveFactionQuestComplete : Objective
{
  private readonly QuestData _target;

  public ObjectiveFactionQuestComplete(QuestData target, Faction faction)
  {
    _target = target;
    Description = $"{faction.Name} has completed the quest {target.Title}";
    faction.QuestProgressChanged += OnQuestProgressChanged;
    Progress = QuestProgress.Incomplete;
  }

  private void OnQuestProgressChanged(object? sender, FactionQuestProgressChangedEventArgs args)
  {
    if (args.Quest == _target && args.Quest.Progress == QuestProgress.Complete)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
