using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Cthun
{
  public sealed class QuestAwakenCthun : QuestData
  {
    public QuestAwakenCthun() : base("The Awakening of C'thun",
      "The Old God C'thun slumbers beneath the ruins of Ahn'qiraj. Skeram will need to awaken him with an unholy ritual.",
      "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp")
    {
      AddQuestItem(new ObjectiveChannelRect(Regions.CthunSummon, "C'thun", LegendCthun.legendSkeram, 420, 270));
      ResearchId = Constants.UPGRADE_R06A_QUEST_COMPLETED_C_THUN_AWAKENING;
      SetUnitInvulnerable(LegendCthun.legendCthun.Unit, true);
      PauseUnit(LegendCthun.legendCthun.Unit, true);
    }

    protected override string CompletionPopup =>
      "C'thun, Old God of madness and chaos, has awakened from his slumber. Azeroth itself shrinks back in fear as this unfathomably evil entity unleashes its singular gaze for the first time in millenia.";

    protected override string RewardDescription =>
      "Gain control of C'thun and the ability to train Wasps"; //Todo: from where?

    protected override void OnComplete(Faction completingFaction)
    {
      LegendCthun.legendCthun.Unit.Rescue(completingFaction.Player);
    }
  }
}