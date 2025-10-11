using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Stormwind;

public sealed class QuestDarkshire : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestDarkshire() : base("Gnoll Troubles",
    "The town of Darkshire is under attack by Gnoll's, clear them out!",
    @"ReplaceableTextures\CommandButtons\BTNGnollArcher.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N00V_DUSKWOOD));
    AddObjective(new ObjectiveExpire(600, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = Regions.DarkshireUnlock.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all units in Darkshire";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction) => completingFaction.Player.RescueGroup(_rescueUnits);
}
