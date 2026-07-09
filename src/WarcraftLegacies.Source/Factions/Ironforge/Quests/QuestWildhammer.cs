using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>
/// A quest for Ironforge to acquire Aerie Peak.
/// </summary>
public sealed class QuestWildhammer : QuestData
{
  private readonly List<unit> _rescueUnits;
  private readonly ObjectiveAnyUnitInRect _heroEnteringShadowforge;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestWildhammer"/> class.
  /// </summary>
  public QuestWildhammer() : base("Wildhammer Alliance",
    "The Wildhammer dwarves roam freely over the peaks of the Hinterlands. An audience with them might earn their cooperation.",
    @"ReplaceableTextures\CommandButtons\BTNHeroGriffonWarrior.blp")
  {
    Knowledge = 20;

    _heroEnteringShadowforge = new ObjectiveAnyUnitInRect(Regions.Aerie_Peak, "Aerie Peak", true);
    AddObjective(_heroEnteringShadowforge);
    AddObjective(new ObjectiveTurn(10));
    ResearchId = UPGRADE_R01C_QUEST_COMPLETED_WILDHAMMER_ALLIANCE;
    _rescueUnits = Regions.Aerie_Peak.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    Loc.Format("{hero} has spoken with Falstad Wildhammer and secured an alliance with the Wildhammer Clan.",
      ("{hero}", _heroEnteringShadowforge.CompletingUnitName));

  /// <inheritdoc />
  protected override string RewardDescription =>
    $"Gain control of Aerie Peak, learn to train Falstad Wildhammer from the {GetObjectName(UNIT_H07B_ALTAR_OF_FORTITUDE_IRONFORGE_ALTAR)}, and gain the ability to research {GetObjectName(UPGRADE_R02K_GRYPHON_SUPERIOR_BREED_KHAZ_MODAN)} at the {GetObjectName(UNIT_HGRA_GRYPHON_AVIARY_IRONFORGE_AIR)}";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var p = completingFaction.Player;
    if (p != null)
    {
      RefundSystem.RefundEnemyStructuresInRect(p, Regions.Aerie_Peak);
    }

    completingFaction.Player.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
  }
}
