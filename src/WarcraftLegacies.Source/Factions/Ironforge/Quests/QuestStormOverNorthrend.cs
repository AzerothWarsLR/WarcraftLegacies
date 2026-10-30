using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.MetaBased;
using WarcraftLegacies.Source.Objectives.QuestBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>Once the Lich King is crowned, destroy or capture Utgarde Keep to call more riders to Kurdran's side.</summary>
public sealed class QuestStormOverNorthrend : QuestData
{
  public QuestStormOverNorthrend(Capital utgarde, QuestData lichKingCrowned) : base("Storm over Northrend",
    "The Lich King has risen, and the vrykul of Utgarde Keep now serve the Scourge. The gryphons of Aerie Peak can reach the fjords of Northrend. Bring the keep down from the sky.",
    @"ReplaceableTextures\CommandButtons\BTNGryphonRider.blp")
  {
    AddObjective(new ObjectiveQuestComplete(lichKingCrowned)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
    AddObjective(new ObjectiveEitherOf(new ObjectiveCapitalDead(utgarde), new ObjectiveControlCapital(utgarde, false)));
    ResearchId = UPGRADE_R11B_STORM_OVER_NORTHREND_WILDHAMMER;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Utgarde Keep has fallen, and more riders answer when Kurdran calls.";

  /// <inheritdoc />
  protected override string RewardDescription => "Call of the Aerie calls 1 more Aerie Rider";

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
}
