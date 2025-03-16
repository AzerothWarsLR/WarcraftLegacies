﻿using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Scarlet
{
  /// <summary>
  /// rebuild Hearthglen and control the monastery to train Sally.
  /// </summary>
  public sealed class QuestRebuildHearthglen : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestRebuildHearthglen"/> class.
    /// </summary>
    public QuestRebuildHearthglen(Rectangle questRect, Capital monastery) : base(
      "Hearthglen",
      "Though the town of Hearthglen fell to the Scourge just as easily as any other, the Silver Hand Monastery there makes it a key strategic objective for the Scarlet Crusade.",
      @"ReplaceableTextures\CommandButtons\BTNAlteracWizardTower.blp")
    {
      
      AddObjective(new ObjectiveBuildUniqueBuildingsInRect(questRect, "in Hearthglen", 3));
      AddObjective(new ObjectiveControlCapital(monastery, false));
      AddObjective(new ObjectiveControlLevel(UNIT_N044_HEARTHGLEN, 2));
      ResearchId = UPGRADE_R026_QUEST_COMPLETED_HEARTHGLEN;
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "With the Monastery under Scarlet control, Sally Whitemane can be brought into the fold of the Crusade's leadership in earnest.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Learn to train Sally Whitemane from the {GetObjectName(UNIT_H0BQ_ALTAR_OF_CRUSADERS_CRUSADE_ALTAR)}";
  }
}