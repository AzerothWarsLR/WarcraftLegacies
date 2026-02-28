using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Skywall;

public sealed class QuestShimmering : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestShimmering"/> class.
  /// </summary>
  public QuestShimmering(Rectangle shimmering) : base("Shimmering Flats",
    "With our lands secured we must establish a forward base.",
    @"ReplaceableTextures\CommandButtons\BTNPavilion.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N0BN_SHIMMERING_FLATS));
    AddObjective(new ObjectiveExpire(11, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = shimmering.PrepareUnitsForRescue(RescuePreparationMode.HideAll);

  }

  /// <inheritdoc />
  protected override string RewardDescription => "Gain Control all buildings in Shimmering Flats";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction) =>
    completingFaction.Player.RescueGroup(_rescueUnits);
}
