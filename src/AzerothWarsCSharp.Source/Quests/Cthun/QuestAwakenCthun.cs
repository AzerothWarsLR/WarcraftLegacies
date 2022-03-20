using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;

namespace AzerothWarsCSharp.Source.Quests.Cthun
{
  public sealed class QuestAwakenCthun : QuestData
  {
    private readonly unit _cthun;
    
    protected override string CompletionPopup =>
      "C'thun, Old God of madness && chaos, has awakened from his slumber. Azeroth itself shrinks back in fear as this unfathomably evil entity unleashes its singular gaze for the first time in millenia.";
    
    protected override string CompletionDescription =>
      "Gain control of C'thun and the ability to train Wasps"; //Todo: from where?

    protected override void OnComplete()
    {
      SetUnitInvulnerable(_cthun, false);
      PauseUnit(_cthun, false);
    }
    
    public QuestAwakenCthun(unit cthun) : base("The Awakening of C'thun",
      "The Old God C'thun slumbers beneath the ruins of Ahn'qiraj. Skeram will need to awaken him with an unholy ritual.",
      "ReplaceableTextures\\CommandButtons\\BTNCthunIcon.blp")
    {
      _cthun = cthun;
      AddQuestItem(new QuestItemChannelRect(Regions.CthunSummon.Rect, "C'thun", LegendCthun.LEGEND_SKERAM, 420, 270));
      ResearchId = FourCC("R06A");
    }
  }
}