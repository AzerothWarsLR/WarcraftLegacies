
using MacroTools.ControlPointSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Quelthalas
{
  /// <summary>
  /// Wait long enough, get Tyr Hand.
  /// </summary>
  public sealed class QuestQueensArchive : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestForgottenKnowledge"/> class.
    /// </summary>
    public QuestQueensArchive() : base("The Queen's Archive",
      "Queen Azshara studied many forms of arcane knowledge, some darker than others. With access to her library and enough time, the highborn scholares could uncover her secrets",
      "ReplaceableTextures\\CommandButtons\\BTNBloodElfWizard.blp")
    {
      AddObjective(new ObjectiveControlLevel(
        ControlPointManager.Instance.GetFromUnitType(Constants.UNIT_N04Y_NAZJATAR_ROYAL_COURT_25GOLD_MIN), 10));
      AddObjective(new ObjectiveChannelRect(Regions.Nazjatar, "Nazjatar", LegendQuelthalas.LegendKael, 60, 270));
      ResearchId = Constants.UPGRADE_R075_QUEST_COMPLETED_THE_QUEEN_S_ARCHIVE;
    }

    /// <inheritdoc />
    protected override string CompletionPopup => "We have uncovered the secrets to Warlock magic";

    /// <inheritdoc />
    protected override string RewardDescription => "You can now train Warlocks at the Consortium";

  }
}