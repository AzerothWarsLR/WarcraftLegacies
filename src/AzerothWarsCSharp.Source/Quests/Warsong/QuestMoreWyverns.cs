using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Libraries;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestMoreWyverns : QuestData
  {
    private const int LIMIT_CHANGE = 2;


    private static readonly int UnittypeId = FourCC("owyv");

    public QuestMoreWyverns() : base("Perfect Warriors",
      "The prowess and savagery of the Sentinels is to be respected - and feared. They must be eliminated.",
      "ReplaceableTextures\\CommandButtons\\BTNArcher.blp")
    {
      AddQuestItem(new ObjectiveLegendDead(LegendSentinels.legendFeathermoon));
      AddQuestItem(new ObjectiveLegendDead(LegendSentinels.legendAuberdine));
    }


    protected override string CompletionPopup =>
      "The Sentinels have been eliminated. Warchief Thrall breathes a sigh of relief, knowing that his people are safe - for now.";

    protected override string RewardDescription =>
      "Learn to train " + I2S(LIMIT_CHANGE) + " additional " + GetObjectName(UnittypeId) + "s";

    protected override void OnComplete()
    {
      Holder.ModObjectLimit(UnittypeId, LIMIT_CHANGE);
      Display.DisplayUnitLimit(Holder, UnittypeId);
    }
  }
}