using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.BlackEmpire
{
  /// <summary>
  /// Get to Ranazjar to unlock the Aqir
  /// </summary>
  public sealed class QuestGiftofFlesh : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestGiftofFlesh"/> class.
    /// </summary>
    public QuestGiftofFlesh() : base("Gift of Flesh",
      "The A'qir have always served me faithfully. They are probably buried deep in the ruins of their old city, Ahn'qiraj. I will need to awaken them once more.",
      @"ReplaceableTextures\CommandButtons\BTNCurse of Flesh.blp")
    {
      
      ResearchId = UPGRADE_RBCF_QUEST_COMPLETED_GIFT_OF_FLESH;
    }

    /// <inheritdoc />
    public override string RewardFlavour => "The Aqir have joined my ranks in glory again!";

    /// <inheritdoc />
    protected override string RewardDescription => $"Learn to train {GetObjectName(UNIT_SHZ5_AQIR_BLACK_EMPIRE)}s from the {GetObjectName(UNIT_ST5K_PIT_OF_TORMENT_YOGG_SPECIALIST)}";

  }
}