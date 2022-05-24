using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Naga
{
  public sealed class QuestIllidanChapterTwo : QuestData
  {
    private readonly QuestData _questToDiscover;

    public QuestIllidanChapterTwo(QuestData questToDiscover) : base("Chapter Two: The Skull of Gul'dan",
      "The mages of Dalaran are hiding a powerful artifact that will grant Illidan unlimited power: the Skull of Gul'dan.",
      "ReplaceableTextures\\CommandButtons\\BTNGuldanSkull.blp")
    {
      AddQuestItem(new ObjectiveLegendReachRect(LegendNaga.LegendIllidan, Regions.IllidanBoat1,
        "the escape boat"));
      AddQuestItem(new ObjectiveLegendReachRect(LegendNaga.LegendIllidan, Regions.SkullOfGuldan,
        "the dungeons of Dalaran"));
      AddQuestItem(new ObjectiveLegendHasArtifact(LegendNaga.LegendIllidan, ArtifactSetup.ArtifactSkullofguldan));
      _questToDiscover = questToDiscover;
    }

    protected override string CompletionPopup =>
      "Illidan has learned of the existence of the Skull of GulFourCC(dan, hidden in Dalaran";

    protected override string RewardDescription => "Chapter Three: Dwellers from the Deep";

    protected override void OnComplete(Faction completingFaction)
    {
      LegendNaga.LegendIllidan.UnitType = FourCC("Eevi");
      _questToDiscover.Progress = QuestProgress.Incomplete;
    }
  }
}