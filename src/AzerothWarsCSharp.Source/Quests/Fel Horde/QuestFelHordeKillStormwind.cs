using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Fel_Horde
{
  public sealed class QuestFelHordeKillStormwind : QuestData{

  
    private static readonly int ResearchId = FourCC("R05Z");
    private static readonly int UnittypeId = FourCC("n086");
    private static readonly int BuildingId = FourCC("o030");
    private const int UNIT_LIMIT = 6;
  


    protected override string CompletionPopup => "StormwindFourCC(s annihilation has left behind the corpses of thousands of elite knights. As occurred during the Second War, these corpses have been filled with the souls of slain Shadow Council members, recreating the indominatable order of Death Knights.";

    protected override string CompletionDescription => 
      return "Teron Gorefiend can be trained at the altar && learn to train " + I2S(UNIT_LIMIT) + " " + GetObjectName(UNITTYPE_ID) + "s from the " + GetObjectName(BUILDING_ID);
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
      Holder.ModObjectLimit(UNITTYPE_ID, UNIT_LIMIT);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Those Who Came Before", "During the Second War, the souls of slain Shadow Council members were infused into the corpses of Stormwind knights to create the Death Knights. If Stormwind were to fall again, the unholy order could return.", "ReplaceableTextures\\CommandButtons\\BTNAcolyte.blp");
      this.AddQuestItem(new QuestItemLegendDead(LEGEND_STORMWINDKEEP));
      ;;
    }


  }
}
