using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;
using static War3Api.Common;
namespace WarcraftLegacies.Source.Quests.Naga
{

  /// <summary>
  /// Caputre various control points to unlock Sea Witches
  /// </summary>
  public sealed class QuestRegroupCastaway : QuestData
  {
    /// <inheritdoc/>
    public QuestRegroupCastaway() : base("Ancient Libraries",
      "Illidan will need to collect more lost knowledge to be form a new generation of Naga Sea Witch",
      "ReplaceableTextures\\CommandButtons\\BTNNagaSeaWitch.blp")
    {
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N00W_ZUL_GURUB_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N00Y_DEADWIND_PASS_10GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N00U_SWAMP_OF_SORROWS_10GOLD_MIN)));
      ResearchId = Constants.UPGRADE_R093_QUEST_COMPLETED_ANCIENT_LIBRARIES;
      Required = true;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour => "The powerful Sea Witches are serving their Master once again.";

    /// <inheritdoc/>
    protected override string RewardDescription => $"Sea Witches can be trained from the {GetObjectName(Constants.UNIT_N055_BETRAYER_S_CITADEL_ILLIDARI_T3)}";
  }
}