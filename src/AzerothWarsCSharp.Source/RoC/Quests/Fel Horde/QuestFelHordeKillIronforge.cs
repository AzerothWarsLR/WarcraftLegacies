using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Fel_Horde
{
  public class QuestFelHordeKillIronforge{

  
    private const int RESEARCH_ID = FourCC(R011);
    private const int UNITTYPE_ID = FourCC(nina);
    private const int BUILDING_ID = FourCC(o030);
    private const int UNIT_LIMIT = 4;
  


    private string operator CompletionPopup( ){
      return "The Great Forge has been annihilated. The Fel HordeFourCC(s peons immediately salvage its intact refineries && put them to purpose in the creation of Felsteel.";
    }

    private string operator CompletionDescription( ){
      return "Learn to train " + I2S(UNIT_LIMIT) + " " + GetObjectName(UNITTYPE_ID) + "s from the " + GetObjectName(BUILDING_ID) + " && acquire Felsteel Plating";
    }

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
      Holder.ModObjectLimit(UNITTYPE_ID, UNIT_LIMIT);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Felsteel Refining", "The smiths of Ironforge have long been put to use crafting goods && war machinery. In the hands of the Fel Horde, they could be used to smelt && refine the ultimate metal: Felsteel.", "ReplaceableTextures\\CommandButtons\\BTNInfernalFlameCannon.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_GREATFORGE));
      ;;
    }


  }
}
