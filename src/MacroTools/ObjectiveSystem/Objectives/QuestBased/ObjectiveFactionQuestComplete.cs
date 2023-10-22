using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.QuestBased
{
  /// <summary>
  /// An <see cref="Objective"/> that is completed when a specific <see cref="Faction"/> completes a specific
  /// <see cref="QuestData"/>.
  /// </summary>
  public sealed class ObjectiveFactionQuestComplete : Objective
  {
    public ObjectiveFactionQuestComplete(QuestData target, Faction faction)
    {
      Description = $"{target.Faction.Name} has completed the quest {target.Title}";
      faction.QuestProgressChanged += OnQuestProgressChanged;
      Progress = QuestProgress.Incomplete;
    }

    private void OnQuestProgressChanged(object? sender, FactionQuestProgressChangedEventArgs args)
    {
      if (args.Quest.Progress == QuestProgress.Complete) 
        Progress = QuestProgress.Complete;
    }
  }
}