using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Fel_Horde
{
  public class QuestFelHordeKillStormwind{

  
    private const int RESEARCH_ID = FourCC(R05Z);
    private const int UNITTYPE_ID = FourCC(n086);
    private const int BUILDING_ID = FourCC(o030);
    private const int UNIT_LIMIT = 6;
  


    private string operator CompletionPopup( ){
      return "StormwindFourCC(s annihilation has left behind the corpses of thousands of elite knights. As occurred during the Second War, these corpses have been filled with the souls of slain Shadow Council members, recreating the indominatable order of Death Knights.";
    }

    private string operator CompletionDescription( ){
      return "Teron Gorefiend can be trained at the altar && learn to train " + I2S(UNIT_LIMIT) + " " + GetObjectName(UNITTYPE_ID) + "s from the " + GetObjectName(BUILDING_ID);
    }

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
      Holder.ModObjectLimit(UNITTYPE_ID, UNIT_LIMIT);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Those Who Came Before", "During the Second War, the souls of slain Shadow Council members were infused into the corpses of Stormwind knights to create the Death Knights. If Stormwind were to fall again, the unholy order could return.", "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_STORMWINDKEEP));
      ;;
    }


  }
}
