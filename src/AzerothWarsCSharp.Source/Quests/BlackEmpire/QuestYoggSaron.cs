using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public sealed class QuestYoggSaron : QuestData{

  
    private static readonly int ResearchId = FourCC("R07R");
  


    protected override CompletionPopup => Yogg-Saron Has been _awoken;

    protected override string CompletionDescription => "The old god Yogg-Saron will join the Black Empire && enable to train Forgotten ones";

    protected override void OnComplete(){
      UnitRescue(gg_unit_U02C_2829, Holder.Player)  ;//Yogg
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Fiend of a Thousand Faces", "Yogg-Saron was imprisoned beneath Northrend by the Titans countless millenia ago. ", "ReplaceableTextures\\CommandButtons\\BTNYogg-saronIcon.blp");
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n053"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00I"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n02S"))));
      base.ResearchId = ResearchId;
      
    }


  }
}
