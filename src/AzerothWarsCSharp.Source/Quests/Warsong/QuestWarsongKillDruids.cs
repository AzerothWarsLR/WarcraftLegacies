using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestWarsongKillDruids : QuestData
  {
    private const int EXPERIENCE_REWARD = 10000;

    protected override string CompletionPopup => "Nordrassil has been captured. The Warsong is supreme!";

    protected override string RewardDescription =>
      "Grom Hellscream gains " + I2S(EXPERIENCE_REWARD) + " experience";

    protected override void OnComplete()
    {
      AddHeroXP(LegendWarsong.LegendGrom.Unit, EXPERIENCE_REWARD, true);
    }

    public QuestWarsongKillDruids() : base("Tear It Down",
      "The World Tree, Nordrassil, is the Night Elves' source of immortality. Capture it to cripple them permanently.",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendDruids.LegendNordrassil, false));
      AddQuestItem(new QuestItemLegendNotPermanentlyDead(LegendWarsong.LegendGrom));
    }
  }
}