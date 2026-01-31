using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.BlackEmpire;

public sealed class QuestDesolace : QuestData
{
  private readonly List<unit> _rescueUnits;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestDesolace"/> class.
  /// </summary>
  public QuestDesolace(Rectangle desolace) : base("Desolace",
    "We must establish a forward base in Desolace to stop Night elf incursions.",
    @"ReplaceableTextures\CommandButtons\BTNCentaurKhan.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N01Y_DESOLACE));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = desolace.PrepareUnitsForRescue(RescuePreparationMode.HideAll);

  }

  /// <inheritdoc />
  public override string RewardFlavour => "With the local centaurs destroyed we can establish an outpost.";

  /// <inheritdoc />
  protected override string RewardDescription => "Gain control of all buildings in Desolace";

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
