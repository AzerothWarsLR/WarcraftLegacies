using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public class QuestCrystalGolem{

  
    private const int RESEARCH_ID = FourCC(R045);
  


    protected override string CompletionPopup => 
      ;.Holder.Name + "FourCC(s Earth Golems have been infused with living crystal.";
    }

    protected override string CompletionDescription => 
      return "Transform your Earth Golems into Crystal Golems";
    }

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayResearchAcquired(Holder.Player, RESEARCH_ID, 1);
      Holder.ModObjectLimit(FourCC(n096), -6);
      Holder.ModObjectLimit(FourCC(n0AD), 6);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){

      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n02R))));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_DRAKTHARONKEEP, false));
      ;;
    }


  }
}
