﻿using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;

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
    public QuestForgottenKnowledge() : base("Forgotten Knowledge",
      "The Sunfury have a long, proud history, tracing all the way back to their status as the Highborne. We have forgotten more knowledge than other races have ever known. Perhaps some of it lies within the ruins of the old Highborne kingdom, Suramar.",
      @"ReplaceableTextures\CommandButtons\BTNBloodelf_Arcane_Annihilator.blp")
    {
      AddObjective(new ObjectiveControlLevel(UNIT_N032_SURAMAR, 10));
      AddObjective(new ObjectiveTime(1080));
      ResearchId = UPGRADE_R08Z_QUEST_COMPLETED_FORGOTTEN_KNOWLEDGE;
    }

    /// <inheritdoc />
    public override string RewardFlavour => "We have uncovered the technology to build arcane weaponry";

    /// <inheritdoc />
    protected override string RewardDescription =>
      $"Learn to train {GetObjectName(UNIT_E024_ARCANE_ANNIHILATOR_QUEL_THALAS)}s from the {GetObjectName(UNIT_H0CI_ARTIFICER_S_COURT_SUNFURY_SIEGE)}";
  }
}