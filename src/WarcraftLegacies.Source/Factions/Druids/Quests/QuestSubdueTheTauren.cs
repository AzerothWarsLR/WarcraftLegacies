using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Druids.Quests;

public sealed class QuestSubdueTheTauren : QuestData
{
  private const int HeroXpReward = 2000;
  private const int GoldReward = 500;

  public QuestSubdueTheTauren() : base(
    "Subdue the Tauren",
    "The Tauren once honoured the Earthmother alongside the druids, yet now they march with the Horde. Topple Thunder Bluff and humble them before the Cenarion Circle.",
    @"ReplaceableTextures\CommandButtons\BTNHeroTaurenChieftain.blp")
  {
    AddObjective(new ObjectiveCapitalDead(AllLegends.Frostwolf.ThunderBluff));
    AddObjective(new ObjectiveSelfExists());
  }

  public override string RewardFlavour =>
    "Thunder Bluff is humbled, and the Tauren are reminded who watches over the wilds of Kalimdor. Cenarius grows mightier for the victory.";

  protected override string RewardDescription =>
    "Cenarius gains 2000 experience, 5 Strength, 5 Agility, and 5 Intelligence, and you gain 500 gold";

  protected override void OnComplete(Faction completingFaction)
  {
    var hero = AllLegends.Druids.Cenarius.Unit;
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
