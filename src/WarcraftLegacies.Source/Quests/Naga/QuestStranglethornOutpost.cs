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

public sealed class QuestStranglethornOutpost : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestStranglethornOutpost(Rectangle rescueRect, LegendaryHero vashj) : base("The Cape of Stranglethorn",
    "Some time ago, a group of Naga were sent to scout out the Cape of Stranglethorn. They should be brought back into the fold to aid in the war with Stormwind.",
    @"ReplaceableTextures\CommandButtons\BTNIllidariSpawningGrounds.blp")
  {
    AddObjective(new ObjectiveControlLegend(vashj, false)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInPopups = false,
      ShowsInQuestLog = false
    });
    AddObjective(new ObjectiveLegendInRect(vashj, rescueRect, "the Cape of Stranglethorn"));
    AddObjective(new ObjectiveExpire(660, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
  }

  public override string RewardFlavour => "The Naga explorers in the Cape of Stranglethorn are rejoined with the Illidari forces from Outland, and are eager to battle the Alliance.";

  protected override string RewardDescription => "Gain control of Naga units and buildings in the Cape of Stranglethorn";

  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.RescueGroup(_rescueUnits);
  }
}
