using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.GameTime;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Stormwind;

public sealed class QuestStromgarde : QuestData
{
  private readonly List<unit> _rescueUnits = new();

  public QuestStromgarde(Rectangle rescueRect) : base("Stromgarde",
    "Although Stromgarde's strength has dwindled since the days of the Arathorian Empire, it remains a significant bastion of humanity. They could be convinced to mobilize their forces for Stormwind.",
    @"ReplaceableTextures\CommandButtons\BTNTheCaptain.blp")
  {
    var objectiveAnyUnitInRect = new ObjectiveAnyUnitInRect(Regions.Stromgarde, "Stromgarde", true);
    AddObjective(objectiveAnyUnitInRect);
    AddObjective(new ObjectiveTurn(GameTimeManager.ConvertGameTimeToTurn(900)));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R01M_QUEST_COMPLETED_STROMGARDE_STORMWIND;
    foreach (var unit in GlobalGroup.EnumUnitsInRect(rescueRect))
    {
      if (unit.Owner == player.NeutralPassive)
      {
        unit.IsInvulnerable = true;
        _rescueUnits.Add(unit);
      }
    }
  }

  /// <inheritdoc />
  public override string RewardFlavour => "Galen Trollbane has pledged his forces to Stormwind's cause.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Control of all units at Stromgarde, the artifact Trol'kalar, and you can summon the hero Galen Trollbane from the Altar of Kings";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(player.NeutralAggressive);
    }
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.SetTechResearched(ResearchId, 1);
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(completingFaction.Player);
    }
  }

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
  }
}
