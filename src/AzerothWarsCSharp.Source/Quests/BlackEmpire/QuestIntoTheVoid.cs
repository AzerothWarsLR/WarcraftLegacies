using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public sealed class QuestIntoTheVoid : QuestData
  {
    private static readonly int QuestResearchId = FourCC("R084"); //This research is given when the quest is completed

    public QuestIntoTheVoid() : base("The Tomb of Tyr",
      "Long ago, Zakajz the Corruptor was killed by the Keeper Tyr and entombed with him. Only Xal'atath, the Black Blade, is powerful enough to summon him.",
      "ReplaceableTextures\\CommandButtons\\BTNGeneralVezax.blp")
    {
      AddQuestItem(new QuestItemAcquireArtifact(ArtifactSetup.ArtifactXalatath));
      AddQuestItem(new QuestItemArtifactInRect(ArtifactSetup.ArtifactXalatath, Regions.TyrsFall.Rect, "Tyr's Fall"));
      AddQuestItem(new QuestItemChannelRect(Regions.TyrsFall.Rect, "The Tomb of Tyr", LegendBlackEmpire.legendVolazj,
        120,
        170));
      ResearchId = QuestResearchId;
      Global = true;
    }


    protected override string CompletionPopup =>
      "Zakajz the Corruptor has been awakened from the Tomb of Tyr and has rejoined his master Yogg'saron.";

    protected override string RewardDescription => "Gain the hero Zakajz the Corruptor";
  }
}