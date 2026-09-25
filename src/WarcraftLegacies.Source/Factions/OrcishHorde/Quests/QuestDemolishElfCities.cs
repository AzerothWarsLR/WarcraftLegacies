using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.OrcishHorde.Quests;

public sealed class QuestDemolishElfCities : QuestData
{
  private const int GromXpReward = 2000;
  private const int GoldReward = 500;

  public QuestDemolishElfCities(QuestData previousQuest) : base(
    "Kalimdor Ablaze",
    "The Night Elves' cities stand as the last bastions of resistance against the Horde. Nordrassil itself, the World Tree where the druids first stirred, must burn along with the rest.",
    @"ReplaceableTextures\CommandButtons\BTNTreeOfAges.blp")
  {
    AddObjective(new ObjectiveCapitalDead(AllLegends.Druids.Nordrassil));
    AddObjective(new ObjectiveCapitalDead(AllLegends.Sentinels.Auberdine));
    AddObjective(new ObjectiveQuestComplete(previousQuest)
    {
      Progress = QuestProgress.Undiscovered,
      ShowsInQuestLog = false,
      ShowsInPopups = false
    });
  }

  public override string RewardFlavour =>
    "Nordrassil burns, and with it the Night Elves' last hope of standing united against the Horde. Grom Hellscream leads the charge, his warband growing richer and more battle-hardened with every city razed.";

  protected override string RewardDescription =>
    "Grom Hellscream gains 2000 experience, 5 Strength, 5 Agility, and 5 Intelligence, and you gain 500 gold";

  protected override void OnComplete(Faction completingFaction)
  {
    var grom = AllLegends.Orc.GromHellscream.Unit;
    if (grom != null)
    {
      grom.AddHeroAttributes(5, 5, 5);
      AddHeroXP(grom, GromXpReward, true);
    }

    if (completingFaction.Player != null)
    {
      completingFaction.Player.Gold += GoldReward;
    }
  }
}
