using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Sentinels.Quests;

public sealed class QuestBreakTheBluff : QuestData
{
  private const int HeroXpReward = 2000;
  private const int GoldReward = 500;

  public QuestBreakTheBluff() : base(
    "Break the Bluff",
    "The Tauren have raised their great city atop the mesas of Mulgore and marched with the Horde against the forests of Kalimdor. Tear down Thunder Bluff and end their threat to the Sentinels.",
    @"ReplaceableTextures\CommandButtons\BTNHeroTaurenChieftain.blp")
  {
    AddObjective(new ObjectiveCapitalDead(AllLegends.Frostwolf.ThunderBluff));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R052_QUEST_COMPLETED_BREAK_THE_BLUFF_SENTINELS;
  }

  public override string RewardFlavour =>
    "Thunder Bluff has fallen, and the Tauren are driven from their mesas. Tyrande Whisperwind leads the Sentinels onward, emboldened by the victory.";

  protected override string RewardDescription =>
    "Tyrande Whisperwind gains 2000 experience, 5 Strength, 5 Agility, and 5 Intelligence, you gain 500 gold, you can train Moon Riders from Roosts, and you can research Upgrade Moon Glaive from the War Academy";

  protected override void OnComplete(Faction completingFaction)
  {
    var hero = AllLegends.Sentinels.Tyrande.Unit;
    if (hero != null)
    {
      hero.AddHeroAttributes(5, 5, 5);
      AddHeroXP(hero, HeroXpReward, true);
    }

    if (completingFaction.Player != null)
    {
      completingFaction.Player.Gold += GoldReward;
      completingFaction.Player.DisplayUnitTypeAcquired(UNIT_E022_MOON_RIDER_SENTINELS,
        "You can now train Moon Riders from Roosts.");
    }
  }
}
