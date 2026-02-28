using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.TurnBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Ironforge;

public sealed class QuestThelsamar : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestThelsamar(Rectangle rescueRect) : base("Murloc Menace",
    "A vile group of Murloc is terrorizing Thelsamar. Destroy them!",
    @"ReplaceableTextures\CommandButtons\BTNMurlocNightCrawler.blp")
  {
    Knowledge = 5;

    AddObjective(new ObjectiveHostilesInAreaAreDead(new Rectangle[]
    {
      Regions.LochModanMurlocCreepCamp
    }, "north of Thelsamar"));
    AddObjective(new ObjectiveExpire(10, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);

  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all units in Thelsamar";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
  }
}
