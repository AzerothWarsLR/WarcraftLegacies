using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.RoC.Legends;
using AzerothWarsCSharp.Source.RoC.Setup;

namespace AzerothWarsCSharp.Source.RoC.Quests.Cthun
{
  public sealed class QuestWyrmrestTemple : QuestData
  {
    protected override string CompletionPopup => "Yor'sahj can now be trained at the altar";

    protected override string CompletionDescription => "The hero Yor'sahj will join Ahn'Qiraj";
    
    public QuestWyrmrestTemple() : base("The Siege of Wyrmrest Temple",
      "Yor'sahj the Unsleeping)s mission is to destroy the Wyrmrest temple, assist him && he will join the Black Empire",
      "ReplaceableTextures\\CommandButtons\\BTNHeroMastermind.blp")
    {
      AddQuestItem(new QuestItemAcquireArtifact(ArtifactSetup.artifactDemonsoul));
      AddQuestItem(new QuestItemArtifactInRect(ArtifactSetup.artifactDemonsoul, Regions.WyrmrestTemple.Rect, "Wyrmrest Temple"));
      AddQuestItem(new QuestItemLegendDead(LegendNeutral.LEGEND_SARAGOSA));
      AddQuestItem(new QuestItemLegendDead(LegendNeutral.LEGEND_VAELASTRASZ));
      AddQuestItem(new QuestItemLegendDead(LegendNeutral.LEGEND_OCCULUS));
      ResearchId = FourCC("R07S");
    }
  }
}