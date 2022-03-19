using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Druids
{
  public class QuestDruidsKillFrostwolf{

  
    private const int RESEARCH_ID = FourCC(R044);
    private const int ELEMENTAL_GUARDIAN_ID = FourCC(e00X);
  


    protected override string CompletionPopup => 
      return "The Frostwolves have been driven from Kalimdor. Their departure reveals the existence of a powerful nature spirit that now heeds the of the Druids.";
    }

    protected override string CompletionDescription => 
      return "The demihero " + GetObjectName(ELEMENTAL_GUARDIAN_ID);
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(this.Holder.Player, RESEARCH_ID, 1);
      DisplayUnitTypeAcquired(this.Holder.Player, ELEMENTAL_GUARDIAN_ID, "You can now train the Elemental Guardian from the Altar of Elders.");
    }

    private void OnAdd( ){
      this.Holder.ModObjectLimit(ELEMENTAL_GUARDIAN_ID, 1);
      this.Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Natural Contest", "The Frostwolf Clan has arrived on the shores of Kalimdor. Though their respect of the wild spirits is to be admired, their presence can!be tolerated.", "ReplaceableTextures\\CommandButtons\\BTNHeroTaurenChieftain.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_THUNDERBLUFF));
      ;;
    }


  }
}
