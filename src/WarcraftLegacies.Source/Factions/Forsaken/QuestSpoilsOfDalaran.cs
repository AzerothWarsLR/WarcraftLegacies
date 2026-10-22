using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Forsaken;

/// <summary>Destroy the Violet Citadel to recover the rites that bind the Val'kyr.</summary>
public sealed class QuestSpoilsOfDalaran : QuestData
{
  public QuestSpoilsOfDalaran(Capital violetCitadel) : base("Spoils of Dalaran",
    "The Kirin Tor locked away every secret they ever took from the Scourge, the Lich King's soul-binding rites among them. Bring down the Violet Citadel, and Sylvanas will have what she needs to raise the Val'kyr as her own.",
    @"ReplaceableTextures\CommandButtons\BTNPaleValkyr.blp")
  {
    AddObjective(new ObjectiveCapitalDead(violetCitadel));
    ResearchId = UPGRADE_R10E_QUEST_COMPLETED_SPOILS_OF_DALARAN_FORSAKEN;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "From the ruins of Dalaran, Sylvanas's agents carry off the rites of soul-binding. The first of the Val'kyr rise, sworn to the Dark Lady.";

  /// <inheritdoc />
  protected override string RewardDescription => "Learn to train Val'kyr from the Forbidden Archive";
}
