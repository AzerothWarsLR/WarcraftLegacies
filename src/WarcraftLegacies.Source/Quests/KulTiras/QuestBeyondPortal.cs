using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.KulTiras;

/// <summary>
/// Varuious Fel Horde buildings must be destroyed or controlled to unlock Fusillier.
/// </summary>
public sealed class QuestBeyondPortal : QuestData
{
  /// <summary>
  /// Initializes a new instance of the <see cref="QuestBeyondPortal"/> class.
  /// </summary>
  public QuestBeyondPortal(Capital hellfireCitadel, Capital kilsorrowFortress) : base("Beyond the Dark Portal",
    "The Orc threat from Draenor still looms over all. Eliminate every trace of the Orcs and their bases.",
    @"ReplaceableTextures\CommandButtons\BTNDarkPortal.blp")
  {
    AddObjective(new ObjectiveCapitalDead(hellfireCitadel));
    AddObjective(new ObjectiveCapitalDead(kilsorrowFortress));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R085_QUEST_COMPLETED_BEYOND_THE_DARK_PORTAL;
  }

  /// <inheritdoc/>
  protected override string RewardDescription => "You will be able to train Fusillier from the Chapter House and to launch the Kalimdor Expedition";
}
