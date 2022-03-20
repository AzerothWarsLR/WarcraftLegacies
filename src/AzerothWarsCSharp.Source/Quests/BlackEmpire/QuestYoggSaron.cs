using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public class QuestYoggSaron : QuestData{

  
    private const int RESEARCH_ID = FourCC(R07R);
  


    protected override string CompletionPopup => 
      return "Yogg-Saron has been awoken";
    }

    protected override string CompletionDescription => 
      return "The old god Yogg-Saron will join the Black Empire && enable to train Forgotten ones";
    }

    protected override void OnComplete(){
      GeneralHelpers.UnitRescue(gg_unit_U02C_2829, this.Holder.Player)  ;//Yogg
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Fiend of a Thousand Faces", "Yogg-Saron was imprisoned beneath Northrend by the Titans countless millenia ago. ", "ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n053))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n00I))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n02S))));
      this.ResearchId = RESEARCH_ID;
      ;;
    }


  }
}
