using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.RoC.Mechanics.BlackEmpire;

namespace AzerothWarsCSharp.Source.RoC.Quests.BlackEmpire
{
  public class QuestSecondObelisk{


    private string operator CompletionPopup( ){
      return "The second Obelisk has been set. NyFourCC(alotha)s connection to Azeroth grows stronger.";
    }

    private string operator CompletionDescription( ){
      return "Unlock the southern zone of NyaFourCC(lotha, && the next Herald you train will open a temporary portal to the Twilight Highlands.";
    }

    private void OnComplete( ){
      RescueUnitsInGroup(udg_NyalothaGroup2, this.Holder.Player);
      RescueUnitsInGroup(udg_NyalothaGroup3, this.Holder.Player);


      RemoveUnit(Herald.Instance.unit);
      BlackEmpirePortal.GoToNext();
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Second Obelisk", "The convergence of floatities grows ever closer. An Obelisk must be established in Uldum.", "ReplaceableTextures\\CommandButtons\\BTNIceCrownObelisk.blp");
      this.AddQuestItem(QuestItemObelisk.create(ControlPoint.ByUnitType(FourCC(n0BD))));
      ;;
    }


  }
}
