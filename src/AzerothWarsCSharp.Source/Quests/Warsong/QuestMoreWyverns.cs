using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Warsong
{
  public sealed class QuestMoreWyverns : QuestData
  {
    private const int LIMIT_CHANGE = 2;


    private static readonly int UnittypeId = FourCC("owyv");

    public QuestMoreWyverns() : base("Perfect Warriors",
      "The prowess && savagery of the Sentinels is to be respected - && feared. They must be eliminated.",
      "ReplaceableTextures\\CommandButtons\\BTNArcher.blp")
    {
      AddQuestItem(new QuestItemLegendDead(LEGEND_FEATHERMOON));
      AddQuestItem(new QuestItemLegendDead(LEGEND_AUBERDINE));
      ;
      ;
    }


    protected override string CompletionPopup =>
      "The Sentinels have been eliminated. Warchief Thrall breathes a sigh of relief, knowing that his people are safe - for now.";

    protected override string CompletionDescription =>
      "Learn to train " + I2S(LIMIT_CHANGE) + " additional " + GetObjectName(UnittypeId) + "s";

    protected override void OnComplete()
    {
      Holder.ModObjectLimit(UnittypeId, LIMIT_CHANGE);
      DisplayUnitLimit(Holder, UnittypeId);
    }
  }
}