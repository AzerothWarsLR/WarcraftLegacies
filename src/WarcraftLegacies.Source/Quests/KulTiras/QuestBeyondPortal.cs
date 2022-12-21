using MacroTools.ObjectiveSystem.Objectives;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.KulTiras
{
  /// <summary>
  /// Varuious Fel Horde buildings must be destroyed or controlled to unlock Fusillier. 
  /// </summary>
  public sealed class QuestBeyondPortal : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestBeyondPortal"/> class.
    /// </summary>
    public QuestBeyondPortal() : base("Beyond the Dark Portal",
      "The Orc threat from Draenor still looms over all. Eliminate every trace of the Orcs and their bases.",
      "ReplaceableTextures\\CommandButtons\\BTNDarkPortal.blp")
    {
      AddObjective(new ObjectiveControlCapital(LegendFelHorde.LegendBlacktemple, false));
      AddObjective(new ObjectiveCapitalDead(LegendFelHorde.LegendHellfirecitadel));
      AddObjective(new ObjectiveCapitalDead(LegendFelHorde.LegendBlackrockspire));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R085_QUEST_COMPLETED_BEYOND_THE_DARK_PORTAL;
    }

    /// <inheritdoc/>
    protected override string CompletionPopup => "The orcs are no more and we can now train Fusillier.";

    /// <inheritdoc/>
    protected override string RewardDescription => "You will be able to train Fusillier from the Barrack";
  }
}