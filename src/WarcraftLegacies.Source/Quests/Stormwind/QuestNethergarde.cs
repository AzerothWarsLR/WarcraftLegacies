using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.TimeBased;

namespace WarcraftLegacies.Source.Quests.Stormwind;

public sealed class QuestNethergarde : QuestData
{
  private readonly List<unit> _rescueUnits;
  private readonly unit _gate;

  public QuestNethergarde(LegendaryHero varian) : base("Nethergarde Relief",
    "Nethergarde Keep fort is holding down the Dark Portal, they will need to be reinforced soon!",
    @"ReplaceableTextures\CommandButtons\BTNStormwindGuardTower.blp")
  {
    AddObjective(new ObjectiveLegendInRect(varian, Regions.NethergardeUnlock, "Nethergarde"));
    AddObjective(new ObjectiveExpire(600, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = Regions.NethergardeUnlock.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    _gate = PreplacedWidgets.Units.GetClosest(UNIT_H00L_HORIZONTAL_WOODEN_GATE_GATE_OPEN, 17140, -18000);
  }

  /// <inheritdoc />
  public override string RewardFlavour => "Varian has come to relieve the Nethergarde garrison.";

  /// <inheritdoc />
  protected override string RewardDescription => "You gain control of Nethergarde";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
    _gate.SetOwner(completingFaction.Player);
  }
}
