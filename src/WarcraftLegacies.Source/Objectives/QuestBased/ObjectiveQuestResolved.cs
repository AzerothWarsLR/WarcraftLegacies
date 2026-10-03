using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;

namespace WarcraftLegacies.Source.Objectives.QuestBased;

/// <summary>
/// Completes when the target quest is either completed or failed by the same faction.
/// </summary>
public sealed class ObjectiveQuestResolved : Objective
{
  private readonly QuestData _target;

  public ObjectiveQuestResolved(QuestData target)
  {
    _target = target;
    SetDescription("Resolve the quest {quest}", ("{quest}", Loc.Get(target.Title)));
  }

  /// <inheritdoc />
  public override void OnAdd(Faction faction) => faction.QuestProgressChanged += OnQuestProgressChanged;

  private void OnQuestProgressChanged(FactionQuestProgressChangedEventArgs args)
  {
    if (args.Quest != _target)
    {
      return;
    }

    if (args.Quest.Progress is QuestProgress.Complete or QuestProgress.Failed)
    {
      Progress = QuestProgress.Complete;
    }
  }
}
