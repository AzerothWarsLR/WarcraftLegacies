using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using MacroTools.Researches;
using WarcraftLegacies.Source.GameLogic.Rocks;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Zandalar.Quests;


/// <summary>
/// Capture <see cref="LegendNeutral.Gundrak"/> to unlock a new unit
/// </summary>
public sealed class QuestGundrak : QuestData
{
  private const int _gundrakResearch = UPGRADE_MD38_QUEST_COMPLETED_THE_DRAKKARI_FORTRESS;
  private const int _warlordId = UNIT_MD46_WARLORD_ZANDALAR;
  private const int _trollShrineId = UNIT_O043_SPIRIT_SPIRE_CREEP_MAGIC;
  private int goldReward { get; set; }
  /// <summary>
  /// Initializes a new instance of the <see cref="QuestGundrak"/> class
  /// </summary>
  public QuestGundrak(Capital Gundrak) : base("The Drakkari Fortress",
    "The Drakkari troll of Gundrak believe their fortress to be impregnable. Capture it to gain their loyalty.",
    @"ReplaceableTextures\CommandButtons\BTNTerrorTroll.blp")
  {
    AddObjective(new ObjectiveControlCapital(Gundrak, false));
    ResearchId = UPGRADE_MD38_QUEST_COMPLETED_THE_DRAKKARI_FORTRESS;
    goldReward = 250;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Gundrak has fallen. The Drakkari trolls lend their might to the Zandalari.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"{goldReward} gold and the ability to train {GetObjectName(_warlordId)}s from the {GetObjectName(_trollShrineId)}.";

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
    whichFaction.ModObjectLimit(_gundrakResearch, Faction.Unlimited);
  }
}
