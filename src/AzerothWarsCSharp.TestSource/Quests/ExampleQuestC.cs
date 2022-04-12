using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

public sealed class ExampleQuestC : QuestData
{
  public ExampleQuestC(QuestData otherQuest) : base("Free Zergling", "We really need a free Zergling.",
    "ReplaceableTextures\\CommandButtons\\BTNZergling.blp")
  {
    AddQuestItem(new QuestItemCompleteQuest(otherQuest));
  }

  protected override string RewardDescription => "A free Zergling";
  protected override string CompletionPopup => "Congratulations on your free Zergling!";

  protected override void OnComplete()
  {
    CreateUnit(Holder.Player, FourCC("zzrg"), 0, 0, 0);
  }
}