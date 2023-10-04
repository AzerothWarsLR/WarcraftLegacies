using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.QuestBased
{
  public sealed class ObjectiveCompleteQuest : Objective
  {
    public ObjectiveCompleteQuest(QuestData target)
    {
      Description = $"Complete the quest {target.Title}";
    }

    internal override void OnAdd(Faction faction) => faction.QuestProgressChanged += OnQuestProgressChanged;

    private void OnQuestProgressChanged(object? sender, FactionQuestProgressChangedEventArgs args)
    {
      Progress = args.Quest.Progress switch
      {
        QuestProgress.Complete => QuestProgress.Complete,
        QuestProgress.Failed => QuestProgress.Failed,
        _ => Progress
      };
    }
  }
}