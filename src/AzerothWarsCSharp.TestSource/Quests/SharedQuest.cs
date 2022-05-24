using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using static War3Api.Common;

namespace AzerothWarsCSharp.TestSource.Quests
{
  public sealed class SharedQuest : QuestData
  {
    public SharedQuest() : base("Tomb of Sargeras",
      "When the Guardian Aegwynn defeated the fallen Titan Sargeras, she sealed his corpse within the temple that would come to be known as the Tomb of Sargeras. It lies still there, tempting those with the ambition to seize the power that remains within.",
      @"ReplaceableTextures\CommandButtons\BTNUnholyFrenzy.blp")
    {
      AddQuestItem(new ObjectiveTime(35));
      AddQuestItem(new ObjectiveKillXUnit(FourCC("hfoo"), 4));
    }
    
    protected override string RewardDescription => "The Tomb of Sargeras has been opened.";

    protected override string CompletionPopup => "The Tomb of Sargeras has been opened.";
  }
}