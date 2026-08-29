using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.GameLogic.Rocks;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Zandalar.Quests;
{
  /// <summary>
  /// Zandalar can acquire Hakkar as a hero.
  /// </summary>
  public sealed class QuestHakkar : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestHakkar"/> class.
    /// </summary>
    public QuestHakkar(Artifact zinrokh) : base("The Binding of the Soulflayer",
      "Hakkar is the most dangerous and powerful of the Troll gods. Only by fusing the Demon Soul would the Zandalari be able to control Hakkar and bind him to their will.",
      @"ReplaceableTextures\CommandButtons\BTNWindSerpent2.blp")
    {
      AddObjective(new ObjectiveAcquireArtifact(zinrokh));
      AddObjective(new ObjectiveArtifactInRect(zinrokh, Regions.DrownedTemple,
        "The Drowned Temple"));
      AddObjective(new ObjectiveControlPoint(UNIT_N00U_SWAMP_OF_SORROWS));
      Global = true;
      ResearchId = UPGRADE_R06W_QUEST_COMPLETED_THE_BINDING_OF_THE_SOULFLAYER;
    }

    /// <inheritdoc/>
    public override string RewardFlavour => "Hakkar has emerged from the Drowned Temple";

    /// <inheritdoc/>
    protected override string RewardDescription => "Gain the demigod hero Hakkar";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
    }
  }
}
