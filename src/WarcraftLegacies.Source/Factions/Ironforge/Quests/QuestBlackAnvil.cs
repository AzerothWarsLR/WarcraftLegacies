using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>Bring Dagran to Shadowforge City to rekindle the Black Anvil.</summary>
public sealed class QuestBlackAnvil : QuestData
{
  private const int RequiredLevel = 6;

  public QuestBlackAnvil(LegendaryHero dagran) : base("The Black Anvil",
    "Deep within Shadowforge City lies the Black Anvil, where the Sorcerer-Thane Thaurissan worked the spells that first called Ragnaros into Azeroth. Bring Dagran there to rekindle it.",
    @"ReplaceableTextures\CommandButtons\BTNDarkIronForge.blp")
  {
    AddObjective(new ObjectiveLegendLevel(dagran, RequiredLevel));
    AddObjective(new ObjectiveLegendInRect(dagran, Regions.Shadowforge_City, "Shadowforge City"));
    ResearchId = UPGRADE_R10O_QUEST_COMPLETED_THE_BLACK_ANVIL;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The Black Anvil burns once more, and its flames reach into the Firelands.";

  /// <inheritdoc />
  protected override string RewardDescription => "Unlocks the quest The Firelord Unbound";

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
}
