using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestKingdomOfManLordaeron : QuestData{

  
    private static readonly int ResearchId = FourCC("R01N");
  


    private bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => "The people of the Eastern Kingdoms have been united under the banner of Lordaeron. Long live High King Arthas Menethil!";

    protected override string CompletionDescription => "You gain a research improving all of your units, the Crowns of Lordaeron && Stormwind are merged, && Arthas becomes High King";

    protected override void OnComplete(){
      //Artifact
      unit crownHolder = ARTIFACT_CROWNSTORMWIND.OwningUnit;
      RemoveItem(ARTIFACT_CROWNLORDAERON.item);
      RemoveItem(ARTIFACT_CROWNSTORMWIND.item);
      UnitAddItemSafe(crownHolder, ARTIFACT_CROWNEASTERNKINGDOMS.item);
      ARTIFACT_CROWNLORDAERON.setStatus(ARTIFACT_STATUS_HIDDEN);
      ARTIFACT_CROWNLORDAERON.setDescription("Melted down");
      ARTIFACT_CROWNSTORMWIND.setStatus(ARTIFACT_STATUS_HIDDEN);
      ARTIFACT_CROWNSTORMWIND.setDescription("Melted down");
      //Research
      SetPlayerTechResearched(Holder.Player, ResearchId, 1);
      DisplayResearchAcquired(Holder.Player, ResearchId, 1);
      //High King Arthas
      LEGEND_ARTHAS.UnitType = FourCC("Harf");
      LEGEND_ARTHAS.ClearUnitDependencies();
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(ResearchId, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Kingdom of Man", "Before the First War, all of humanity was united under the banner of the Arathorian Empire. Reclaim its greatness by uniting mankind once again.", "ReplaceableTextures\\CommandButtons\\BTNFireKingCrown.blp");
      AddQuestItem(new QuestItemControlLegend(LEGEND_ARTHAS, true));
      AddQuestItem(new QuestItemAcquireArtifact(ARTIFACT_CROWNLORDAERON));
      AddQuestItem(new QuestItemAcquireArtifact(ARTIFACT_CROWNSTORMWIND));
      AddQuestItem(new QuestItemLegendDead(LEGEND_LICHKING));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n010"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01G"))));
      ;;
    }


  }
}
