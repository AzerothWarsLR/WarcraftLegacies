using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <summary>
  /// Various control points must be captured.
  /// </summary>
  public sealed class QuestSafeSea : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestSafeSea"/> class.
    /// </summary>
    public QuestSafeSea() : base("Safe Sea Decree",
      "The seas must be secured and the Kul'tiras navy must be returned to its former glory!", @"ReplaceableTextures\CommandButtons\BTNKulTirasDreadnought.blp")
    {
      AddObjective(new ObjectiveTrain(Constants.UNIT_HDES_DESTROYER_ALLIANCE, Constants.UNIT_HSHY_ALLIANCE_SHIPYARD_LORDAERON, 2));
      AddObjective(new ObjectiveTrain(Constants.UNIT_H04J_WARSHIP_KUL_TIRAS, Constants.UNIT_HSHY_ALLIANCE_SHIPYARD_LORDAERON, 1));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N01W_BORALUS_25GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N07L_BALOR_15GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N08Q_TOL_BARAD_20GOLD_MIN)));
      AddObjective(new ObjectiveControlPoint(ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N09K_CRESTFALL_10GOLD_MIN)));
      ResearchId = Constants.UPGRADE_R06T_QUEST_COMPLETED_SAFE_SEA_DECREE;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup =>
      "With the seas now secure, the Ember Order can be reformed and Lucille Waycrest is trainable";

    /// <inheritdoc/>
    protected override string RewardDescription => "The Order of Embers is reborn and Lucille Waycrest is trainable";
  }
}