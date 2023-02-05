using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <summary>
  /// Various control points must be captured.
  /// </summary>
  public sealed class QuestWestfallOutpost : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestWestfallOutpost"/> class.
    /// </summary>
    public QuestWestfallOutpost(Rectangle questRect) : base("Westfall Outpost",
      "The Kul'tiran military will need a solid foothold to help Stormwind in their fight against the Outland invaders!", "ReplaceableTextures\\CommandButtons\\BTNKultirasGryphonAviary.blp")
    {
      Required = true;
      AddObjective(new ObjectiveBuildInRect(questRect, "in Westfall", Constants.UNIT_H06R_GARRISON_KUL_TIRAS_BARRACKS, 2));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Westfall", Constants.UNIT_H07Q_SCHOOL_OF_THE_TIDES_KUL_TIRAS_MAGIC));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Westfall", Constants.UNIT_H062_TOWN_HALL_KUL_TIRAS_T1));
      AddObjective(new ObjectiveBuildInRect(questRect, "in Westfall", Constants.UNIT_H07P_WORKSHOP_KUL_TIRAS_SIEGE));
      ResearchId = Constants.UPGRADE_R06T_QUEST_COMPLETED_WESTFALL_OUTPOST;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour =>
      "While the outpost was built, the Ember Order has finished saving house Waycrest from the Drust influence. Meredith Waycrest is rid of the corruption and will join the war effort of the Kul'tiras ";

    /// <inheritdoc/>
    protected override string RewardDescription => "You can now build Order Chapter House and Meredith Waycrest is trainable";
  }
}