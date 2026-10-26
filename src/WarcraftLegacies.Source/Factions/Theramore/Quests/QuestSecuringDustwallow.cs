using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;

namespace WarcraftLegacies.Source.Factions.Theramore.Quests;

/// <summary>Drive the dark trolls out of Dustwallow Marsh to unlock Garran Vimes.</summary>
public sealed class QuestSecuringDustwallow : QuestData
{
  public QuestSecuringDustwallow() : base("Securing Dustwallow",
    "Theramore sits on the edge of a marsh full of dark trolls, and Jaina's people cannot farm or build while the trolls hunt them. Drive the trolls out of Dustwallow.",
    @"ReplaceableTextures\CommandButtons\BTNFlibustierKulTiras.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N0AF_DUSTWALLOW_MARSH));
    ResearchId = UPGRADE_R10H_QUEST_COMPLETED_SECURING_DUSTWALLOW_THERAMORE;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The trolls have fled deeper into the marsh. Captain Garran Vimes and the Theramore Guard now keep watch over Dustwallow.";

  /// <inheritdoc />
  protected override string RewardDescription => "Learn to train Garran Vimes from the Altar of Knowledge";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var owner = completingFaction.Player;
    if (owner != null)
    {
      owner.DisplayUnitTypeAcquired(UNIT_H0D2_CAPTAIN_OF_THE_THERAMORE_GUARD_THERAMORE,
        "You can now train Garran Vimes from the Altar of Knowledge.");
    }
  }
}
