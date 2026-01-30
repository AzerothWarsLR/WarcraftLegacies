using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.QuestSystem;


namespace WarcraftLegacies.Source.Quests.Naga;

public sealed class QuestTheWaywardWell : QuestData
{
  public QuestTheWaywardWell(Capital sunwell, LegendaryHero illidan, QuestData burningCrusade)
    : base(
      "The Wayward Well",
      "Illidan stole three vials from the Well of Eternity. He used one to create a new Well beneath Nordrassil, and kept the other two hidden - but one went missing.",
      @"ReplaceableTextures\CommandButtons\BTNPoTN_Sanctity_Potion.blp")
  {
    Knowledge = 15;
    Progress = QuestProgress.Undiscovered;

    AddObjective(new ObjectiveQuestComplete(burningCrusade)
    {
      ShowsInPopups = false,
      ShowsInQuestLog = false
    });

    AddObjective(new ObjectiveControlCapital(sunwell, false));
    AddObjective(new ObjectiveLegendInRect(illidan, Regions.Sunwell, "the Sunwell"));
  }

  public override string RewardFlavour =>
    "The missing vial of Eternity, it seems, was used to create yet another Well of arcane energy that has since become the center of High Elven civilization.";
}
