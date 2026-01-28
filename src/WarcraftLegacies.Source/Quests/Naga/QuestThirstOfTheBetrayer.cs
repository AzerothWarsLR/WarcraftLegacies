using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Scourge;

namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestThirstOfTheBetrayer : QuestData
{
  public QuestThirstOfTheBetrayer(Capital sunwell, LegendaryHero illidan, Faction scourge, QuestData burningCrusade)
    : base(
      "The Wayward Well",
      "Illidan seeks to seize the Sunwell and claim its arcane power for the Illidari.",
      @"ReplaceableTextures\CommandButtons\BTNPoTN_Sanctity_Potion.blp")
  {
    Progress = QuestProgress.Undiscovered;

    AddObjective(new ObjectiveQuestComplete(burningCrusade)
    {
      ShowsInPopups = false,
      ShowsInQuestLog = false
    });

    AddObjective(new ObjectiveControlCapital(sunwell, false));
    AddObjective(new ObjectiveLegendInRect(illidan, Regions.Sunwell, "the Sunwell"));

    AddObjective(new ObjectiveFactionQuestNotComplete(
      scourge.GetQuestByType<QuestKelthuzadLich>(),
      scourge)
    {
      ShowsInPopups = false,
      ShowsInQuestLog = false
    });

    Knowledge = 25;
  }

  public override string RewardFlavour =>
    "Illidan has seized control of the Sunwell, reclaiming its waters to fuel the Illidari cause.";
}
