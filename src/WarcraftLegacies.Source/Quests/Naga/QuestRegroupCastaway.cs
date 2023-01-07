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
  {
    /// <inheritdoc/>
    public QuestRegroupCastaway() : base("The Splintered People",
      "The Naga scattered across Azeroth are waiting for their Master's return. If Illidan manages to reunite them, they will aid him well in his endeavours.",
      "ReplaceableTextures\\CommandButtons\\BTNNagaSeaWitch.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N03O_RANAZJAR_ISLE_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N05Y_AZSUNA_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N04Y_NAZJATAR_ROYAL_COURT_25GOLD_MIN)));
      ResearchId = Constants.UPGRADE_R093_QUEST_COMPLETED_SPLINTERED_PEOPLE;
      Required = true;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup => "The Naga are serving their Master once again!";

    /// <inheritdoc/>
    protected override string RewardDescription => "The powerful Sea Witches are now trainable at the Betrayer's Citadel.";
  }
}