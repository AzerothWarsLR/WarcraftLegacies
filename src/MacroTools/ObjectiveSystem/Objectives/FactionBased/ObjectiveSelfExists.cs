using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;

namespace MacroTools.ObjectiveSystem.Objectives.FactionBased
{
  /// <summary>
  /// An <see cref="Objective"/> that starts <see cref="QuestProgress.Complete"/> and fails any time the owning
  /// <see cref="Faction"/> does not have its <see cref="player"/> slot filled.
  /// </summary>
  public sealed class ObjectiveSelfExists : Objective
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectiveSelfExists"/> class.
    /// </summary>
    public ObjectiveSelfExists()
    {
      Progress = QuestProgress.Complete;
      ShowsInQuestLog = false;
    }

    public override void OnAdd(Faction whichFaction)
    {
      Progress = QuestProgress.Complete;
      whichFaction.ScoreStatusChanged += OnAnyFactionScoreStatusChanged;
      CreateTimer().Start(55, false, () =>
      {
        if (whichFaction.Player == null)
          Progress = QuestProgress.Failed;
      });
    }

    private void OnAnyFactionScoreStatusChanged(object? sender, Faction faction)
    {
      if (faction.ScoreStatus == ScoreStatus.Defeated) 
        Progress = QuestProgress.Failed;
    }
  }
}