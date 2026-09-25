using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Druids.Quests;

public sealed class QuestWrathOfTheWild : QuestData
{
  private const int HeroXpReward = 2000;
  private const int GoldReward = 500;

  public QuestWrathOfTheWild() : base(
    "Wrath of the Wild",
    "The orcs' axes have bitten deep into Ashenvale to feed the forges of Orgrimmar. Let the wild answer: bring the city down and the forest may yet heal.",
    @"ReplaceableTextures\CommandButtons\BTNEntanglingRoots.blp")
  {
    AddObjective(new ObjectiveCapitalDead(AllLegends.Warsong.Orgrimmar));
    AddObjective(new ObjectiveSelfExists());
  }

  public override string RewardFlavour =>
    "Roots and thorns swallow the ruins of Orgrimmar. Malfurion Stormrage feels the forest breathe easier, and his power grows with it.";

  protected override string RewardDescription =>
    "Malfurion gains 2000 experience, 5 Strength, 5 Agility, and 5 Intelligence, and you gain 500 gold";

  protected override void OnComplete(Faction completingFaction)
  {
    var hero = AllLegends.Druids.Malfurion.Unit;
    if (hero != null)
    {
      hero.AddHeroAttributes(5, 5, 5);
      AddHeroXP(hero, HeroXpReward, true);
    }

    if (completingFaction.Player != null)
    {
      completingFaction.Player.Gold += GoldReward;
    }
  }
}
