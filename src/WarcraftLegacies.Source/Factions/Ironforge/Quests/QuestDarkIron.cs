using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>
/// Ironforge allies with the Dark Iron and gets cool stuff.
/// </summary>
public sealed class QuestDarkIron : QuestData
{
  private readonly List<unit> _rescueUnitsShadowforge;
  private readonly List<unit> _rescueUnitsShadowforgeBase;
  private readonly ObjectiveAnyUnitInRect _heroEnteringShadowforge;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestDarkIron"/> class.
  /// </summary>
  public QuestDarkIron(Rectangle shadowforgeCity, Rectangle shadowforgeCityBase, Capital blackrockSpire) : base("Dark Iron Alliance",
    "Despite our strained past relations with the Dark Iron dwarves, we could reforge an alliance with them if we clear out the fel orcs from Blackrock Spire.",
    @"ReplaceableTextures\CommandButtons\BTNRPGDarkIron.blp")
  {
    Knowledge = 20;

    AddObjective(new ObjectiveCapitalDead(blackrockSpire));
    _heroEnteringShadowforge = new ObjectiveAnyUnitInRect(shadowforgeCityBase, "Shadowforge City", true);
    AddObjective(_heroEnteringShadowforge);
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R01A_QUEST_COMPLETED_DARK_IRON_ALLIANCE;
    _rescueUnitsShadowforge = shadowforgeCity.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    _rescueUnitsShadowforgeBase = shadowforgeCityBase.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
  }

  /// <inheritdoc />
  protected override string RewardDescription =>
    $"You gain control of a small base in Shadowforge City and can train the hero Dagran Thaurassian from the Altar of Fortitude";

  /// <inheritdoc />
  public override string RewardFlavour =>
    $"The fel orcs have been vanquished from Blackrock Spire and {_heroEnteringShadowforge.CompletingUnitName} has convinced Dagran and his Dark Iron dwarves to join our cause.";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnitsShadowforge);
    completingFaction.Player.RescueGroup(_rescueUnitsShadowforgeBase);
  }

  /// <inheritdoc />
  protected override void OnFail(Faction failingFaction)
  {
    player.NeutralAggressive.RescueGroup(_rescueUnitsShadowforge);
  }
}
