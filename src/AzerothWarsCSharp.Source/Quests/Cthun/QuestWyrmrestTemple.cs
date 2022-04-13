using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Cthun
{
  public sealed class QuestWyrmrestTemple : QuestData
  {
    public QuestWyrmrestTemple() : base("The Siege of Wyrmrest Temple",
      "Yor'sahj the Unsleeping)s mission is to destroy the Wyrmrest temple, assist him && he will join the Black Empire",
      "ReplaceableTextures\\CommandButtons\\BTNHeroMastermind.blp")
    {
      AddQuestItem(new QuestItemAcquireArtifact(ArtifactSetup.ArtifactDemonsoul));
      AddQuestItem(new QuestItemArtifactInRect(ArtifactSetup.ArtifactDemonsoul, Regions.WyrmrestTemple,
        "Wyrmrest Temple"));
      AddQuestItem(new QuestItemLegendDead(LegendNeutral.LegendSaragosa));
      AddQuestItem(new QuestItemLegendDead(LegendNeutral.LegendVaelastrasz));
      AddQuestItem(new QuestItemLegendDead(LegendNeutral.LegendOcculus));
      ResearchId = FourCC("R07S");
    }

    protected override string CompletionPopup => "Yor'sahj can now be trained at the altar";

    protected override string RewardDescription => "The hero Yor'sahj will join Ahn'Qiraj";
  }
}