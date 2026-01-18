using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestKillMaiev : QuestData
{
  /// <inheritdoc />
  public QuestKillMaiev() : base(
    "Vengeance Denied",
    "The Warden Maiev presided over Illidan's imprisonment in the barrow prisons for ten thousand years. His escape has spurred on a relentless quest for vengeance, and nothing short of death will stop her.",
    @"ReplaceableTextures\CommandButtons\BTNWarden2.blp")
  {
    AddObjective(new ObjectiveLegendaryHeroTrained(AllLegends.Sentinels.Maiev)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInPopups = false,
      ShowsInQuestLog = false
    });
    AddObjective(new ObjectiveLegendDead(AllLegends.Sentinels.Maiev)
    {
      OnlyCreditKiller = true,
      PermanentOnly = false
    });
    Knowledge = 5;
  }

  /// <inheritdoc />
  public override string RewardFlavour => "The Warden Shadowsong has been gravely wounded, stopping her pursuit of Illidan - for now.";
}
