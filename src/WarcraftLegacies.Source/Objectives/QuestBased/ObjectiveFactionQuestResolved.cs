using MacroTools.Factions;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.QuestBased;

/// <summary>
/// An <see cref="Objective"/> that is completed when a specific <see cref="Faction"/> either completes or fails a
/// specific <see cref="QuestData"/>.
/// </summary>
public sealed class ObjectiveFactionQuestResolved : Objective
{
  private readonly QuestData _target;

  public ObjectiveFactionQuestResolved(QuestData target, Faction faction)
  {
    _target = target;
    SetDescription("{faction} has resolved the quest {quest}", ("{faction}", faction.Name), ("{quest}", target.Title));
    faction.QuestProgressChanged += OnQuestProgressChanged;
    Progress = QuestProgress.Incomplete;
  }

  private void OnQuestProgressChanged(FactionQuestProgressChangedEventArgs args)
  {
    if (args.Quest == _target &&
        (args.Quest.Progress == QuestProgress.Complete || args.Quest.Progress == QuestProgress.Failed))
    {
      Progress = QuestProgress.Complete;
    }
  }
}
