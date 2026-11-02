using MacroTools.Factions;
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
    SetDescription("{faction} has completed the quest {quest}", ("{faction}", faction.Name), ("{quest}", target.Title));
    faction.QuestProgressChanged += OnQuestProgressChanged;
    Progress = QuestProgress.Incomplete;
  }

  /// <inheritdoc />
  public override void OnAdd(Faction whichFaction)
  {
    if (_target.Progress == QuestProgress.Complete)
    {
      Progress = QuestProgress.Complete;
    }
  }

  private void OnQuestProgressChanged(FactionQuestProgressChangedEventArgs args)
  {
    if (args.Quest == _target && args.Quest.Progress == QuestProgress.Complete)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
