using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestCrystalGolem : QuestData{

  
    private static readonly int ResearchId = FourCC("R045");
  


    protected override string CompletionPopup => 
      ;.Holder.Name + "FourCC(s Earth Golems have been infused with living crystal.";
    }

    protected override string CompletionDescription => "Transform your Earth Golems into Crystal Golems";

    protected override void OnComplete(){
      SetPlayerTechResearched(Holder.Player, RESEARCH_ID, 1);
      DisplayResearchAcquired(Holder.Player, RESEARCH_ID, 1);
      Holder.ModObjectLimit(FourCC("n096"), -6);
      Holder.ModObjectLimit(FourCC("n0AD"), 6);
    }

    protected override void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){

      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02R"))));
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_DRAKTHARONKEEP, false));
      
    }


  }
}
