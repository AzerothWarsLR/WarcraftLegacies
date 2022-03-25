using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestKingdomOfManLordaeron : QuestData
  {
    private static readonly int RewardResearchId = FourCC("R01N");

    public QuestKingdomOfManLordaeron() : base("Kingdom of Man",
      "Before the First War, all of humanity was united under the banner of the Arathorian Empire. Reclaim its greatness by uniting mankind once again.",
      "ReplaceableTextures\\CommandButtons\\BTNFireKingCrown.blp")
    {
      AddQuestItem(new QuestItemControlLegend(LegendLordaeron.LegendArthas, true));
      AddQuestItem(new QuestItemAcquireArtifact(ArtifactSetup.ArtifactCrownlordaeron));
      AddQuestItem(new QuestItemAcquireArtifact(ArtifactSetup.ArtifactCrownstormwind));
      AddQuestItem(new QuestItemLegendDead(LegendScourge.LegendLichking));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n010"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01G"))));
      Global = true;
    }

    protected override string CompletionPopup =>
      "The people of the Eastern Kingdoms have been united under the banner of Lordaeron. Long live High King Arthas Menethil!";

    protected override string CompletionDescription =>
      "You gain a research improving all of your units, the Crowns of Lordaeron and Stormwind are merged, and Arthas becomes High King";


    protected override void OnComplete()
    {
      //Artifact
      unit crownHolder = ArtifactSetup.ArtifactCrownstormwind.OwningUnit;
      RemoveItem(ArtifactSetup.ArtifactCrownlordaeron.Item);
      RemoveItem(ArtifactSetup.ArtifactCrownstormwind.Item);
      UnitAddItemSafe(crownHolder, ArtifactSetup.ArtifactCrowneasternkingdoms.Item);
      ArtifactSetup.ArtifactCrownlordaeron.Status = ArtifactStatus.Hidden;
      ArtifactSetup.ArtifactCrownlordaeron.Description = "Melted down";
      ArtifactSetup.ArtifactCrownstormwind.Status = ArtifactStatus.Hidden;
      ArtifactSetup.ArtifactCrownstormwind.Description = "Melted down";
      //Research
      SetPlayerTechResearched(Holder.Player, RewardResearchId, 1);
      Display.DisplayResearchAcquired(Holder.Player, RewardResearchId, 1);
      //High King Arthas
      LegendLordaeron.LegendArthas.UnitType = FourCC("Harf");
      LegendLordaeron.LegendArthas.ClearUnitDependencies();
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(RewardResearchId, Faction.UNLIMITED);
    }
  }
}