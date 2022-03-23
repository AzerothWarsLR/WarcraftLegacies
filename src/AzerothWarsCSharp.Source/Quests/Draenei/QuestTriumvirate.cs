using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Draenei
{
  public sealed class QuestTriumvirate : QuestData{


    private bool operator Global( ){
      return true;
    }

    protected override string CompletionPopup => 
      return "Velen has liberated Argus && re-assembled the Crown of Triumvirate";
    }

    protected override string CompletionDescription => 
      return "You gain the powerful item, the Crown of the Triumvirate";
    }

    protected override void OnComplete(){
      GeneralHelpers.UnitAddItemSafe(LEGEND_VELEN.Unit, ARTIFACT_CROWNTRIUMVIRATE.item);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Crown of the Triumvirate", "Eons ago, the council that led the Eredar was the Triumvirate. If Velen could reconquer Argus, he could reform the Crown of the Triumvirate", "ReplaceableTextures\\CommandButtons\\BTNNeverMeltingCrown.blp");
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0BH"))));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n0BL"))));
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n09X"))));
      this.AddQuestItem(new QuestItemLegendNotPermanentlyDead(LEGEND_VELEN));
      ;;
    }


  }
}
