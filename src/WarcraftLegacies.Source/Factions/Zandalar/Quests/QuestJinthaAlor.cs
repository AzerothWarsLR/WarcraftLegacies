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
  /// Capture <see cref="LegendNeutral.Jinthaalor"/> to unlock a new unit
  /// </summary>
  public sealed class QuestJinthaAlor : QuestData
  {
    private const int _jinthaalorResearch = UPGRADE_MD37_QUEST_COMPLETED_THE_ANCIENT_EGG;
    private const int _bearRiderId = UNIT_MD45_BEAR_RIDER_ZANDALAR;
    private const int _trollShrineId = UNIT_O043_SPIRIT_SPIRE_CREEP_MAGIC;
    private int goldReward { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestJinthaAlor"/> class
    /// </summary>
    public QuestJinthaAlor(Capital Jinthaalor) : base("The Ancient Egg",
      "The Vilebranch trolls of Jintha'Alor are controlled by their fear of the Soulflayer's egg, hidden within their shrine. Smash it to gain their loyalty.",
      @"ReplaceableTextures\CommandButtons\BTNForestTrollShadowPriest.blp")
    {
      AddObjective(new ObjectiveControlCapital(Jinthaalor, false));
      goldReward = 250;
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "Jintha'Alor has fallen. The Vilebranch trolls lend their might to the Zandalari";

    /// <inheritdoc/>>
    protected override string RewardDescription =>
      $"Control of Jintha'Alor, {goldReward} gold tribute and the ability to train {GetObjectName(_bearRiderId)}s from the {GetObjectName(_trollShrineId)}";

    /// <inheritdoc/>
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
        whichFaction.ModObjectLimit(_jinthaalorResearch, Faction.Unlimited);
      }
  }
