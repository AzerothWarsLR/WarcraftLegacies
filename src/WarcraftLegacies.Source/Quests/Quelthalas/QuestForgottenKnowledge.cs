
using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Quelthalas
{
  /// <summary>
  /// Wait long enough, get Tyr Hand.
  /// </summary>
  public sealed class QuestForgottenKnowledge : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestForgottenKnowledge"/> class.
    /// </summary>
    public QuestForgottenKnowledge(Rectangle questRect) : base("Forgotten Knowledge",
      "The Ruins of the City of Suramar might unveil some lost technologies from the highborne",
      "ReplaceableTextures\\CommandButtons\\BTNBloodelf_Arcane_Annihilator.blp")
    {
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N032_SURAMAR_20GOLD_MIN), 10));
      AddObjective(new ObjectiveTime(1080));
      ResearchId = Constants.UPGRADE_R08Z_QUEST_COMPLETED_FORGOTTEN_KNOWLEDGE;
    }

    /// <inheritdoc />
    protected override string RewardFlavour => "We have uncovered the technology to build arcane weaponry";

    /// <inheritdoc />
    protected override string RewardDescription => "You can now train Arcane Annihilators at the Academy";

  }
}