using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.TurnBased;

namespace WarcraftLegacies.Source.Factions.Quelthalas.Quests;

/// <summary>Roleplay replacement for <see cref="QuestForgottenKnowledge"/>, told from the high elves' side.</summary>
public sealed class QuestRuinsOfSuramar : QuestData
{
  public QuestRuinsOfSuramar() : base("The Ruins of Suramar",
    "Long before Quel'thalas was founded, the high elves' Highborne ancestors ruled from Suramar. Its ruins still hold the arcane constructs of that age. Reclaim them, and the artificers of Silvermoon can rebuild what was lost.",
    @"ReplaceableTextures\CommandButtons\BTNBloodelf_Arcane_Annihilator.blp")
  {
    AddObjective(new ObjectiveControlLevel(UNIT_N032_SURAMAR, 10));
    AddObjective(new ObjectiveTurn(18));
    ResearchId = UPGRADE_R08Z_QUEST_COMPLETED_FORGOTTEN_KNOWLEDGE_OR_THE_RUINS_OF_SURAMAR;
  }

  /// <inheritdoc />
  protected override string RewardDescription =>
    Loc.Format("Learn to train {unit}s from the {building}",
      ("{unit}", GetObjectName(UNIT_E024_ARCANE_ANNIHILATOR_QUELTHALAS)),
      ("{building}", GetObjectName(UNIT_H03J_ACADEMY_QUELTHALAS_SPECIALIST)));
}
