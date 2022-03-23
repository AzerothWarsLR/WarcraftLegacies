using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public sealed class QuestIntoTheVoid : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R084"); //This research is given when the quest is completed


    protected override string CompletionPopup =>
      "Zakajz the Corruptor has been awakened from the Tomb of Tyr && has rejoined his master Yogg'saron";

    protected override string CompletionDescription => "Gain the hero Zakajz the Corruptor";

    public QuestIntoTheVoid() : base("The Tomb of Tyr",
      "Long ago, Zakajz the Corruptor was killed by the Keeper Tyr && entombed with him. Only Xal'atath, the Black Blade, is powerful enough to summon him.",
      "ReplaceableTextures\\CommandButtons\\BTNGeneralVezax.blp")
    {
      AddQuestItem(new QuestItemAcquireArtifact(ARTIFACT_XALATATH));
      AddQuestItem(new QuestItemArtifactInRect(ARTIFACT_XALATATH, Regions.TyrsFall.Rect, "Tyr's Fall"));
      AddQuestItem(new QuestItemChannelRect(Regions.TyrsFall, "The Tomb of Tyr", LEGEND_VOLAZJ, 120, 170));
      ResearchId = QuestResearchId;
      Global = true;
    }
  }
}