using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>Raise Falstad and Kurdran to level 10 to make Master of Lightning strike more often.</summary>
public sealed class QuestWrathOfTheThunderaan : QuestData
{
  public QuestWrathOfTheThunderaan(LegendaryHero falstad, LegendaryHero kurdran) : base("Wrath of the Thunderaan",
    "The Wildhammer draw their storms from the spirits of the sky. When the clan's greatest riders reach the height of their power, the storm answers every gryphon rider.",
    @"ReplaceableTextures\CommandButtons\BTNZeusStrike.blp")
  {
    AddObjective(new ObjectiveLegendLevel(falstad, 10));
    AddObjective(new ObjectiveLegendLevel(kurdran, 10));
    ResearchId = UPGRADE_R11C_WRATH_OF_THE_THUNDERAAN_WILDHAMMER;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Falstad and Kurdran ride with the storm, and lightning answers every Wildhammer rider.";

  /// <inheritdoc />
  protected override string RewardDescription => "Master of Lightning is 5% more likely to strike";

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
}
