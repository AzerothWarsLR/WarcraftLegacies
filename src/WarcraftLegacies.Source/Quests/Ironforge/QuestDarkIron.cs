using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Ironforge;

/// <summary>
/// Ironforge allies with the Dark Iron and gets cool stuff.
/// </summary>
public sealed class QuestDarkIron : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestDarkIron"/> class.
  /// </summary>
  public QuestDarkIron(Rectangle shadowforgeCity, Capital blackTemple, LegendaryHero magni) : base("Dark Iron Alliance",
    "The Dark Iron dwarves are renegades. Bring Magni to their capital to open negotiations for an alliance.",
    @"ReplaceableTextures\CommandButtons\BTNRPGDarkIron.blp")
  {
    Knowledge = 25;

    AddObjective(new ObjectiveCapitalDead(blackTemple));
    AddObjective(new ObjectiveLegendInRect(magni, shadowforgeCity, "Shadowforge City"));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R01A_QUEST_COMPLETED_DARK_IRON_ALLIANCE;
    _rescueUnits = shadowforgeCity.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  /// <inheritdoc />
  protected override string RewardDescription =>
    "You gain control of Shadowforge City and can train the hero Dagran Thaurassian from the Altar of Fortitude";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnFail(Faction failingFaction)
  {
    player.NeutralAggressive.RescueGroup(_rescueUnits);
  }
}
