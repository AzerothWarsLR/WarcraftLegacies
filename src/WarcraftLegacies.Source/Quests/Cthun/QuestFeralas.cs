using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Cthun;

public sealed class QuestFeralas : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestFeralas"/> class.
  /// </summary>
  public QuestFeralas(Rectangle feralas) : base("Feralas",
    "With our hives restored we can establish a forward one in Feralas.",
    @"ReplaceableTextures\CommandButtons\BTNJungleBeast.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N00Q_SPINEBARK_GROVE));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = feralas.PrepareUnitsForRescue(RescuePreparationMode.HideAll);

  }

  /// <inheritdoc />
  public override string RewardFlavour => "With the local wildlife destroyed we can establish a forward outpost.";

  /// <inheritdoc />
  protected override string RewardDescription => "Gain control off all buildings in Feralas";

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
