using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Mechanics.BlackEmpire;

namespace AzerothWarsCSharp.Source.Quests.BlackEmpire
{
  public sealed class QuestSecondObelisk : QuestData{


    protected override string CompletionPopup => "The second Obelisk has been set. NyFourCC("alotha")s connection to Azeroth grows stronger.";

    protected override string CompletionDescription => "Unlock the southern zone of NyaFourCC(lotha, && the next Herald you train will open a temporary portal to the Twilight Highlands.";

    protected override void OnComplete(){
      RescueUnitsInGroup(udg_NyalothaGroup2, Holder.Player);
      RescueUnitsInGroup(udg_NyalothaGroup3, Holder.Player);


      RemoveUnit(Herald.Instance.unit);
      BlackEmpirePortal.GoToNext();
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Second Obelisk", "The convergence of floatities grows ever closer. An Obelisk must be established in Uldum.", "ReplaceableTextures\\CommandButtons\\BTNIceCrownObelisk.blp");
      AddQuestItem(new QuestItemObelisk(ControlPoint.GetFromUnitType(FourCC("n0BD"))));
      
    }


  }
}
