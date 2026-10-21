using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.WorldEvents;
using WarcraftLegacies.Source.Objectives.MetaBased;

namespace WarcraftLegacies.Source.GameLogic;

/// <summary>A world event that happens as soon as a faction completes a particular quest.</summary>
public sealed class QuestCompletedEvent : WorldEvent
{
  private readonly Faction _faction;
  private readonly QuestData _quest;
  private readonly ObjectiveTriggered _questCompleted;

  public QuestCompletedEvent(Faction faction, QuestData quest, string requirement)
  {
    _faction = faction;
    _quest = quest;
    _questCompleted = new ObjectiveTriggered(requirement);
    AddRequirement(_questCompleted);
    faction.QuestProgressChanged += OnQuestProgressChanged;
  }

  /// <inheritdoc />
  protected override void OnHappened()
  {
  }

  private void OnQuestProgressChanged(FactionQuestProgressChangedEventArgs args)
  {
    if (args.Quest != _quest)
    {
      return;
    }

    if (_quest.Progress == QuestProgress.Complete)
    {
      Instigator = _faction.ColoredName;
      _questCompleted.Trigger();
    }
    else if (_quest.Progress == QuestProgress.Failed)
    {
      Cancel();
    }
  }
}
