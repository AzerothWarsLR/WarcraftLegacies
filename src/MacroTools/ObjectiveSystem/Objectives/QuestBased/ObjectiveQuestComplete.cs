using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.QuestBased
{
  public sealed class ObjectiveQuestComplete : Objective
  {
    private readonly QuestData _target;

    public ObjectiveQuestComplete(QuestData target)
    {
      _target = target;
      Description = $"Complete the quest {target.Title}";
    }

    /// <inheritdoc />
    public override void OnAdd(Faction faction) => faction.QuestProgressChanged += OnQuestProgressChanged;

    private void OnQuestProgressChanged(object? sender, FactionQuestProgressChangedEventArgs args)
    {
      if (args.Quest != _target)
        return;

      Progress = args.Quest.Progress switch
      {
        QuestProgress.Complete => QuestProgress.Complete,
        QuestProgress.Failed => QuestProgress.Failed,
        _ => Progress
      };
    }
  }
}