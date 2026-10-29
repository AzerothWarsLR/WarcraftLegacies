using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>Destroy Stormwind Keep to stoke the Dark Iron war machines with the Molten Core.</summary>
public sealed class QuestThaurissansVengeance : QuestData
{
  public QuestThaurissansVengeance(Capital stormwindKeep) : base("Thaurissan's Vengeance",
    "The Dark Iron have long coveted the wealth of the human kingdoms. Raze Stormwind Keep, and its plundered steel will feed the fires of the Molten Core.",
    @"ReplaceableTextures\CommandButtons\BTNThaurissan.blp")
  {
    AddObjective(new ObjectiveCapitalDead(stormwindKeep));
    ResearchId = UPGRADE_R10M_MOLTEN_CORE_DARKIRON;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Stormwind burns, and its steel is hauled down into the forges beneath Blackrock Mountain. Our war machines run hotter than ever.";

  /// <inheritdoc />
  protected override string RewardDescription => Loc.Format(
    "{magma}s, {flame}s and {war}s gain 300 hit points, 15 attack damage and 3 armor",
    ("{magma}", GetObjectName(UNIT_H0AA_MAGMA_TANK_DARKIRON)),
    ("{flame}", GetObjectName(UNIT_H0EC_FLAME_TANK_DARKIRON)),
    ("{war}", GetObjectName(UNIT_H0ED_WAR_TANK_DARKIRON)));

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
}
