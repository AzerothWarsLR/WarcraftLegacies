using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;


namespace WarcraftLegacies.Source.Quests.Naga
{
  //todo: fix incorrect grammar
  /// <summary>
  /// Caputre various control points to unlock Sea Witches
  /// </summary>
  public sealed class QuestRegroupCastaway : QuestData

  {    /// <inheritdoc/>
    public QuestRegroupCastaway() : base("The Splintered People",
      "The Naga are scattered across the worlds, if Illidan manages to reunite them, they will become powerful allies.",
      "ReplaceableTextures\\CommandButtons\\BTNNagaSeaWitch.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N03O_RANAZJAR_ISLE_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N05Y_AZSUNA_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N04Y_NAZJATAR_ROYAL_COURT_25GOLD_MIN)));
      ResearchId = Constants.UPGRADE_R093_QUEST_COMPLETED_SPLINTERED_PEOPLE;
    }

 
    /// <inheritdoc/>
    protected override string CompletionPopup => "All the Naga have been reunited!";

    /// <inheritdoc/>
    protected override string RewardDescription => "The powerful Sea Witches are now trainable at the Betrayer's Citadel.";
  }
}