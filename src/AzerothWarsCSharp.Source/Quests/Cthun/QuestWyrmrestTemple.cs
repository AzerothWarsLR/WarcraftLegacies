using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Setup;
using AzerothWarsCSharp.Source.Setup.Legends;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Quests.Cthun
{
  public sealed class QuestWyrmrestTemple : QuestData
  {
    public QuestWyrmrestTemple() : base("The Siege of Wyrmrest Temple",
      "Yor'sahj the Unsleeping)s mission is to destroy the Wyrmrest temple, assist him and he will join the Black Empire",
      "ReplaceableTextures\\CommandButtons\\BTNHeroMastermind.blp")
    {
      AddObjective(new ObjectiveAcquireArtifact(ArtifactSetup.ArtifactDemonsoul));
      AddObjective(new ObjectiveArtifactInRect(ArtifactSetup.ArtifactDemonsoul, Regions.WyrmrestTemple,
        "Wyrmrest Temple"));
      AddObjective(new ObjectiveLegendDead(LegendNeutral.LegendSaragosa));
      AddObjective(new ObjectiveLegendDead(LegendNeutral.LegendVaelastrasz));
      AddObjective(new ObjectiveLegendDead(LegendNeutral.LegendOcculus));
      ResearchId = FourCC("R07S");
    }

    protected override string CompletionPopup => "Yor'sahj can now be trained at the altar";

    protected override string RewardDescription => "The hero Yor'sahj will join Ahn'Qiraj";
  }
}