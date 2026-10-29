using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Factions.Ironforge.Quests;

/// <summary>Destroy Dalaran so Moira can learn the shadow lore hidden in its vaults.</summary>
public sealed class QuestShatterTheVioletCitadel : QuestData
{
  public QuestShatterTheVioletCitadel(Capital dalaran) : base("Shatter the Violet Citadel",
    "The magi of Dalaran have long hunted down the shadow sorcery of the Dark Iron. Destroy the Violet Citadel, and Moira will claim the secrets locked in its vaults.",
    @"ReplaceableTextures\CommandButtons\BTNSpellAura.blp")
  {
    AddObjective(new ObjectiveCapitalDead(dalaran));
    ResearchId = UPGRADE_R10N_QUEST_COMPLETED_SHATTER_THE_VIOLET_CITADEL;
  }

  /// <inheritdoc />
  public override string RewardFlavour =>
    "The Violet Citadel lies shattered, and Moira has claimed the shadow lore hidden in its vaults.";

  /// <inheritdoc />
  protected override string RewardDescription => Loc.Format(
    "Moira's {word} can jump to one more enemy",
    ("{word}", GetObjectName(ABILITY_A19U_SHADOWFLAME_WORD_DARKIRON_MOIRA)));

  /// <inheritdoc />
  protected override void OnAdd(Faction whichFaction) => whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
}
