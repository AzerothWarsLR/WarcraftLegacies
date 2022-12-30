using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Zandalar
{

  /// <summary>
  /// Train 5 Golden Vessels to unlock a hero and a unit
  /// </summary>
  public sealed class QuestGoldenFleet : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestConquerKul"/> class
    /// </summary>
    public QuestGoldenFleet() : base("The Golden Fleet",
      "The King has ordered for the greatest armada in the world. The construction of the Golden Fleet has begun!",
      "ReplaceableTextures\\CommandButtons\\BTNTrollConjurer.blp")
    {
      AddObjective(new ObjectiveTrain(Constants.UNIT_O04W_GOLDEN_VESSEL_ZANDALAR, Constants.UNIT_O049_GOLDEN_DOCK_ZANDALARI_SHIPYARD, 5));
      ResearchId = Constants.UPGRADE_R06W_QUEST_COMPLETED_THE_GOLDEN_FLEET;
      Required = true;
      
    }

    /// <inheritdoc/>>
    protected override string CompletionPopup => "Rastakhan is now trainable and Direhorn are available.";

    /// <inheritdoc/>
    protected override string RewardDescription => "Rastakhan is trainable at the altar and Direhorns are trainable";

  }
}