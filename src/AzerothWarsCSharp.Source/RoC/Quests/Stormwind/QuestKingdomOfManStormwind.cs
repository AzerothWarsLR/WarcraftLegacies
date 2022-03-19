using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Stormwind
{
  public class QuestKingdomOfManStormwind{

  
    private const int RESEARCH_ID = FourCC(R01N);
    private const int EXPERIENCE_REWARD = 6000;
  


    private boolean operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "The people of the Eastern Kingdoms have been united under the banner of Stormwind. Long live High King Varian Wrynn!";
    }

    protected override string CompletionDescription => 
      return "You gain a research improving all of your units, the Crowns of Lordaeron && Stormwind are merged, && Varian gains " + I2S(EXPERIENCE_REWARD) + ".";
    }

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
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayResearchAcquired(Holder.Player, RESEARCH_ID, 1);
      //High King Arthas
      BlzSetUnitName(LEGEND_VARIAN.Unit, "High King");
      AddHeroXP(LEGEND_VARIAN.Unit, EXPERIENCE_REWARD, true);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Kingdom of Man", "Before the First War, all of humanity was united under the banner of the Arathorian Empire. Reclaim its greatness by uniting mankind once again.", "ReplaceableTextures\\CommandButtons\\BTNFireKingCrown.blp");
      this.AddQuestItem(QuestItemLegendNotPermanentlyDead.create(LEGEND_VARIAN));
      this.AddQuestItem(QuestItemAcquireArtifact.create(ARTIFACT_CROWNLORDAERON));
      this.AddQuestItem(QuestItemAcquireArtifact.create(ARTIFACT_CROWNSTORMWIND));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_BLACKTEMPLE, false));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n010))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n01G))));
      ;;
    }


  }
}
