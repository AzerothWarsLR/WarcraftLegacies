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
  /// Zandalar can acquire Hakkar as a hero.
  /// </summary>
  public sealed class QuestHakkar : QuestData
{
  /// <summary>
  /// Initializes a new instance of the <see cref="QuestHakkar"/> class.
  /// </summary>
  public QuestHakkar(Capital Zulgurub,Capital Nordrassil) : base("The Binding of the Soulflayer",
    "Hakkar is the most dangerous and powerful of the Troll gods. Only by using the waters from the World Tree would the Zandalari be able to control Hakkar and bind him to their will.",
    @"ReplaceableTextures\CommandButtons\BTNWindSerpent2.blp")
  {
    AddObjective(new ObjectiveControlCapital(Zulgurub, false));
    AddObjective(new ObjectiveControlCapital(Nordrassil, false));
    ResearchId = UPGRADE_MD60_QUEST_COMPLETED_THE_BINDING_OF_THE_SOULFLAYER;
  }

  /// <inheritdoc/>
  public override string RewardFlavour => "Hakkar has emerged from the Zul'gurub";

  /// <inheritdoc/>
  protected override string RewardDescription => "Gain the demigod Hakkar";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    if (completingFaction == null || completingFaction.Player == null)
    {
      Console.WriteLine("Invalid faction or player; cannot complete the quest.");
      return;
    }
  }
}
