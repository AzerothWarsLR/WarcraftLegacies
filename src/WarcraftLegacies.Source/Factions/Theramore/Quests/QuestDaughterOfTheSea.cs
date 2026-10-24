using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Theramore.Quests;

/// <summary>Defeat Daelin Proudmoore after Jaina chooses Thrall over her father.</summary>
public sealed class QuestDaughterOfTheSea : QuestData
{
  public QuestDaughterOfTheSea(LegendaryHero daelin) : base("Daughter of the Sea",
    "Jaina has chosen Thrall over her own father. Daelin will not stop until the orcs are dead, and while Boralus stands he will always return. Theramore must stop him for good.",
    @"ReplaceableTextures\CommandButtons\BTNProudmoore.blp")
  {
    AddObjective(new ObjectiveLegendDead(daelin));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R10I_QUEST_COMPLETED_DAUGHTER_OF_THE_SEA_THERAMORE;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "Daelin Proudmoore has fallen at the hands of the people his daughter chose. Jaina grieves, but the people of Theramore stand with her more firmly than ever.";

  /// <inheritdoc />
  protected override string RewardDescription => "All of your units gain 100 hit points";

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction) => TheramoreDialogue.PlayDaelinDeath(completingFaction);
}
