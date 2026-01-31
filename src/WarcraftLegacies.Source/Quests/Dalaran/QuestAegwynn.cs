using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Dalaran;

public sealed class QuestAegwynn : QuestData
{

  public QuestAegwynn(LegendaryHero jaina, LegendaryHero antonidas) : base("Return from Exile",
    "A new generation of Mages are in dire need of council. The exiled Aegwynn, used to be a Guardian of Tirisfal. Grabbing her attention will require powerful wizards.",
    @"ReplaceableTextures\CommandButtons\BTN.MagnaArchmage.blp")
  {
    AddObjective(new ObjectiveLegendLevel(antonidas, 8));
    AddObjective(new ObjectiveLegendLevel(jaina, 8));
    ResearchId = UPGRADE_R09F_QUEST_COMPLETED_RETURN_FROM_EXILE;
  }

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Aegwynn will also be trainable at the altar.";
}
