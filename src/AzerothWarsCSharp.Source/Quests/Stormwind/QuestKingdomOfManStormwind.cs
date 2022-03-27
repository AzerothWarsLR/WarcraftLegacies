using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestKingdomOfManStormwind : QuestData
  {
    private const int EXPERIENCE_REWARD = 6000;


    private static readonly int ResearchId = FourCC("R01N");

    private Global()
    {
      return true;
    }

    public QuestKingdomOfManStormwind() : base("Kingdom of Man",
      "Before the First War, all of humanity was united under the banner of the Arathorian Empire. Reclaim its greatness by uniting mankind once again.",
      "ReplaceableTextures\\CommandButtons\\BTNFireKingCrown.blp")
    {
      this.AddQuestItem(new QuestItemLegendNotPermanentlyDead(LEGEND_VARIAN));
      AddQuestItem(new QuestItemAcquireArtifact(ArtifactSetup.ArtifactCrownlordaeron));
      AddQuestItem(new QuestItemAcquireArtifact(ArtifactSetup.ArtifactCrownstormwind));
      AddQuestItem(new QuestItemControlLegend(LegendFelHorde.LegendBlacktemple, false));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n010"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01G"))));
      ;
      ;
    }

    protected override string CompletionPopup =>
      "The people of the Eastern Kingdoms have been united under the banner of Stormwind. Long live High King Varian Wrynn!";

    protected override string CompletionDescription =>
      "You gain a research improving all of your units, the Crowns of Lordaeron && Stormwind are merged, && Varian gains " +
      I2S(EXPERIENCE_REWARD) + ".";


    private bool operator

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
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
      DisplayResearchAcquired(Holder.Player, ResearchId, 1);
      //High King Arthas
      BlzSetUnitName(LEGEND_VARIAN.Unit, "High King");
      AddHeroXP(LEGEND_VARIAN.Unit, EXPERIENCE_REWARD, true);
    }

    protected override void OnAdd()
    {
      Holder.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}