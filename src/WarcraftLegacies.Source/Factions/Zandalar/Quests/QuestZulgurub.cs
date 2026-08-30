using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.GameLogic.Rocks;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Zandalar.Quests;
  /// <summary>
  /// Capture <see cref="LegendNeutral.Zulgurub"/> to unlock a new unit
  /// </summary>
  public sealed class QuestZulgurub : QuestData
  {
    private const int _zulgurubResearch = UPGRADE_MD36_QUEST_COMPLETED_ZULGURUB; //Add research for quest
    private const int _trollShrineId = UNIT_O043_SPIRIT_SPIRE_CREEP_MAGIC; // add the shrine for the new unit
    private const int _ravagerId = UNIT_MD44_RAVAGER_ZANDALAR; //make the unit
    private int goldReward { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestZulgurub"/> class
    /// </summary>
    public QuestZulgurub (Capital Zulgurub): base("Heart of Hakkar",
        "The Gurubashi trolls of Zul'Gurub follow the sacred Heart of Hakkar, hidden within their shrine. Capture it to gain their loyalty.",
        @"ReplaceableTextures\CommandButtons\BTNTrollRavager.blp")
      {
        AddObjective(new ObjectiveControlCapital(Zulgurub, false));
        goldReward = 250;
    }




    /// <inheritdoc/>
    public override string RewardFlavour =>
      "Zul'gurub has fallen. The Gurubashi trolls lend their might to the Zandalari.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"{goldReward} gold and the ability to train {GetObjectName(_ravagerId)}s from the {GetObjectName(_trollShrineId)}";

    /// <inheritdoc/>>
    protected override void OnComplete(Faction completingFaction)
    {
      if (completingFaction == null || completingFaction.Player == null)
      {
        Console.WriteLine("Invalid faction or player; cannot complete the quest.");
        return;
      }
    }

    /// <inheritdoc/>
    protected override void OnAdd(Faction whichFaction)
      {
        whichFaction.ModObjectLimit(_zulgurubResearch, Faction.Unlimited);
      }
    }
