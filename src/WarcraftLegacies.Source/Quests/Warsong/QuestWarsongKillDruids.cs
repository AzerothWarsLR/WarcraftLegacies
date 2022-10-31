using WarcraftLegacies.MacroTools.FactionSystem;
using WarcraftLegacies.MacroTools.QuestSystem;
using WarcraftLegacies.MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  public sealed class QuestWarsongKillDruids : QuestData
  {
    private const int EXPERIENCE_REWARD = 10000;

    protected override string CompletionPopup => "Nordrassil has been captured. The Warsong is supreme!";

    protected override string RewardDescription =>
      "Grom Hellscream gains " + I2S(EXPERIENCE_REWARD) + " experience";

    protected override void OnComplete(Faction completingFaction)
    {
      AddHeroXP(LegendWarsong.GromHellscream.Unit, EXPERIENCE_REWARD, true);
    }

    public QuestWarsongKillDruids() : base("Tear It Down",
      "The World Tree, Nordrassil, is the Night Elves' source of immortality. Capture it to cripple them permanently.",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      AddObjective(new ObjectiveControlLegend(LegendDruids.LegendNordrassil, false));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendWarsong.GromHellscream));
    }
  }
}