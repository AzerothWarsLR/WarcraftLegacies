using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestWarsongKillDruids : QuestData
  {
    private const int EXPERIENCE_REWARD = 10000;

    protected override string CompletionPopup => "Nordrassil has been captured. The Warsong is supreme!";

    protected override string RewardDescription =>
      "Grom Hellscream gains " + I2S(EXPERIENCE_REWARD) + " experience";

    protected override void OnComplete(Faction completingFaction)
    {
      AddHeroXP(LegendWarsong.LegendGrom.Unit, EXPERIENCE_REWARD, true);
    }

    public QuestWarsongKillDruids() : base("Tear It Down",
      "The World Tree, Nordrassil, is the Night Elves' source of immortality. Capture it to cripple them permanently.",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      AddQuestItem(new ObjectiveControlLegend(LegendDruids.LegendNordrassil, false));
      AddQuestItem(new ObjectiveLegendNotPermanentlyDead(LegendWarsong.LegendGrom));
    }
  }
}