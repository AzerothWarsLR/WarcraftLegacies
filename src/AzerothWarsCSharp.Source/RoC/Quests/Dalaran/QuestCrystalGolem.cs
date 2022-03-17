using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Dalaran
{
  public class QuestCrystalGolem{

  
    private const int RESEARCH_ID = FourCC(R045);
  


    private string operator CompletionPopup( ){
      ;.Holder.Name + "FourCC(s Earth Golems have been infused with living crystal.";
    }

    private string operator CompletionDescription( ){
      return "Transform your Earth Golems into Crystal Golems";
    }

    private void OnComplete( ){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayResearchAcquired(Holder.Player, RESEARCH_ID, 1);
      Holder.ModObjectLimit(FourCC(n096), -6);
      Holder.ModObjectLimit(FourCC(n0AD), 6);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){

      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n02R))));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_DRAKTHARONKEEP, false));
      ;;
    }


  }
}
