using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Sentinels.Quests;

public sealed class QuestRazeOrgrimmar : QuestData
{
  private const int HeroXpReward = 2000;
  private const int GoldReward = 500;

  public QuestRazeOrgrimmar() : base(
    "Raze Orgrimmar",
    "The orcs have carved a city out of the red rock of Durotar, and from it their warbands strike deep into Ashenvale. Raze Orgrimmar and the Horde's grip on Kalimdor will break.",
    @"ReplaceableTextures\CommandButtons\BTNFortress.blp")
  {
    AddObjective(new ObjectiveCapitalDead(AllLegends.Warsong.Orgrimmar));
    AddObjective(new ObjectiveSelfExists());
  }

  public override string RewardFlavour =>
    "Orgrimmar lies in ruins, and the Horde's warbands scatter across Durotar. Shandris Feathermoon's huntresses return from the assault hardened and rich with plunder.";

  protected override string RewardDescription =>
    "Shandris Feathermoon gains 2000 experience, 5 Strength, 5 Agility, and 5 Intelligence, and you gain 500 gold";

  protected override void OnComplete(Faction completingFaction)
  {
    var hero = AllLegends.Sentinels.Shandris.Unit;
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
