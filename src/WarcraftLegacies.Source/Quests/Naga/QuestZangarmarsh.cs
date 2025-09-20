using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Naga;

/// <summary>
/// </summary>
public sealed class QuestZangarmarsh : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestZangarmarsh(Rectangle rescueRect, LegendaryHero vashj) : base("Coilfang Reservoir",
    "Lady Vashj and here Naga were instrumental in securing Outland, and for their deeds received the swamp of Zangarmarsh. It has become overrun in recent times, and must be reclaimed if the Naga are to aid in the fight against the Alliance.",
    @"ReplaceableTextures\CommandButtons\BTNIllidariDemonGate.blp")
  {
    AddObjective(new ObjectiveLegendInRect(vashj, rescueRect, "Zangarmarsh"));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R03B_QUEST_COMPLETED_COILFANG_RESERVOIR;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
  }

  /// <inheritdoc />
  public override string RewardFlavour => "With the swamps of Zangarmarsh secured, Lady Vashj and her Naga begin the work of rebuilding their clutcheries.";

  /// <inheritdoc />
  protected override string RewardDescription => $"Gain control of the Zangarmarsh Outpost and learn to build {GetObjectName(UNIT_NNSA_CLUTCHERY_ILLIDARI_SPECIALIST)}s";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
  }
}
