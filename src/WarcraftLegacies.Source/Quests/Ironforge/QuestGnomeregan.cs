using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Ironforge;

/// <summary>
/// Kill a specific to unlock Gnomeregan
/// </summary>
public sealed class QuestGnomeregan : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestGnomeregan"/> class.
  /// </summary>
  /// <param name="rescueRect"></param>
  public QuestGnomeregan(Rectangle rescueRect) : base("The City of Invention",
    "The people of Gnomeregan have long been unable to assist the Alliance in its wars due an infestation of troggs and Ice Trolls. Resolve their conflicts for them to gain their services.",
    @"ReplaceableTextures\CommandButtons\BTNFlyingMachine.blp")
  {
    Knowledge = 5;

    AddObjective(new ObjectiveHostilesInAreaAreDead(new[] { Regions.Gnomergan }, "near Gnomeregan"));
    AddObjective(new ObjectiveExpire(8, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    ResearchId = UPGRADE_R05Q_QUEST_COMPLETED_THE_CITY_OF_INVENTION_IRONFORGE;
  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all units in Gnomeregan";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
  }
}
