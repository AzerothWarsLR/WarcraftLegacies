using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.BlackEmpire
{
  /// <summary>
  /// Get to Ranazjar to unlock the Aqir
  /// </summary>
  public sealed class QuestGuestofFlesh : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestGuestofFlesh"/> class.
    /// </summary>
    public QuestGuestofFlesh() : base("Gift of Flesh",
      "The Aqir are one of the oldest followers of the Old Gods, by connecting to the sea again, N'zoth could call for their service once again",
      @"ReplaceableTextures\CommandButtons\BTNCurse of Flesh.blp")
    {
      AddObjective(new ObjectiveControlPoint(UNIT_N03O_RANAZJAR_ISLE));
      ResearchId = UPGRADE_RBCF_QUEST_COMPLETED_GIFT_OF_FLESH;
    }

    /// <inheritdoc />
    public override string RewardFlavour => "The Aqir have joined N'zoth in glory again!";

    /// <inheritdoc />
    protected override string RewardDescription => $"Learn to train {GetObjectName(UNIT_SHZ5_AQIR_BLACK_EMPIRE)}s from the {GetObjectName(UNIT_ST5K_PIT_OF_TORMENT_YOGG_SPECIALIST)}";

  }
}