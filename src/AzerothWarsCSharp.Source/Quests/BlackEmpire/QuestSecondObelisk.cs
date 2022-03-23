using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Mechanics.BlackEmpire;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public class QuestSecondObelisk : QuestData{


    protected override string CompletionPopup => 
      return "The second Obelisk has been set. NyFourCC("alotha")s connection to Azeroth grows stronger.";
    }

    protected override string CompletionDescription => 
      return "Unlock the southern zone of NyaFourCC(lotha, && the next Herald you train will open a temporary portal to the Twilight Highlands.";
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueUnitsInGroup(udg_NyalothaGroup2, this.Holder.Player);
      GeneralHelpers.RescueUnitsInGroup(udg_NyalothaGroup3, this.Holder.Player);


      RemoveUnit(Herald.Instance.unit);
      BlackEmpirePortal.GoToNext();
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Second Obelisk", "The convergence of floatities grows ever closer. An Obelisk must be established in Uldum.", "ReplaceableTextures\\CommandButtons\\BTNIceCrownObelisk.blp");
      this.AddQuestItem(QuestItemObelisk.create(ControlPoint.GetFromUnitType(FourCC("n0BD"))));
      ;;
    }


  }
}
