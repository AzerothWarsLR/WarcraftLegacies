using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Quelthalas
{
  public class QuestQueldanil{

  
    private const int QUEST_RESEARCH_ID = FourCC(R074)   ;//This research is given when the quest is completed
  


    private string operator CompletionPopup( ){
      return "QuelFourCC(thalas has finally reunited with its lost rangers in the Hinterlands.";
    }

    private string operator CompletionDescription( ){
      return "Control of QuelFourCC(danil Lodge";
    }

    private void OnComplete( ){
      unit u;
      while(true){
        u = FirstOfGroup(udg_QuelDanilLodge);
        if ( u == null){ break; }
        UnitRescue(u, this.Holder.Player);
        GroupRemoveUnit(udg_QuelDanilLodge, u);
      }
      DestroyGroup(udg_QuelDanilLodge);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("QuelFourCC(danil Lodge", "Quel)danil Lodge is a High Elven outpost situated in the Hinterlands. It)s been some time since the rangers there have been in contact with Quel)thalas.", "ReplaceableTextures\\CommandButtons\\BTNBearDen.blp");
      this.AddQuestItem(QuestItemAnyUnitInRect.create(gg_rct_QuelDanil_Lodge, "QuelFourCC(danil Lodge", true));
      this.AddQuestItem(QuestItemTime.create(1200));
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
