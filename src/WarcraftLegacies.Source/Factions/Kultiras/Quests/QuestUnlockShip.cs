using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Factions.Kultiras.Mechanics;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Kultiras.Quests;

/// <summary>
/// Take control of Kul Tiras to teleport to Stranglethorn.
/// </summary>
public sealed class QuestStranglethornExpedition : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestStranglethornExpedition"/> class.
  /// </summary>
  public QuestStranglethornExpedition(Rectangle rescueRect, LegendaryHero daelinProudmoore,
    QuestData prerequisite) : base("Stranglethorn Expedition",
    "The Stranglethorn vale is still infested with trolls and pirates. If peace is to be brought back to the South Alliance, it needs to be purged",
    @"ReplaceableTextures\CommandButtons\BTNGalleonIcon.blp")
  {
    AddObjective(new ObjectiveQuestComplete(prerequisite));
    AddObjective(new ObjectiveControlLegend(daelinProudmoore, false));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  protected override string RewardDescription =>
    "Optionally move all of your non-worker units to Stranglethorn Vale";

  protected override void OnComplete(Faction completingFaction)
  {
    if (completingFaction.Player != null)
    {
      var dialogPresenter = new UnlockShipDialogPresenter(
        completingFaction.Player,
        _rescueUnits
      );
      dialogPresenter.Run(completingFaction.Player);
    }
  }
}
