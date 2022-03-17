using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.RoC.Mechanics.BlackEmpire;

namespace AzerothWarsCSharp.Source.RoC.Quests.BlackEmpire
{
  public class QuestFirstObelisk{


    private string operator CompletionPopup( ){
      return "The first Obelisk has been summoned, but NyFourCC(alotha)s connection to Azeroth is !yet stable. More Obelisks must be erected.";
    }

    private string operator CompletionDescription( ){
      return "Unlock the northern zone of NyaFourCC(lotha, && the next Herald you train will open a temporary portal to Uldum.";
    }

    private void OnComplete( ){
      RescueUnitsInGroup(udg_NyalothaGroup1, this.Holder.Player);


      RemoveUnit(Herald.Instance.unit);
      BlackEmpirePortal.GoToNext();
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The First Obelisk", "The twisted floatity of NyFourCC(alotha is a mere shadow of Azeroth, but that will soon change. The first step in merging the two floatities is to establish an Obelisk in Northrend.", "ReplaceableTextures\\CommandButtons\\BTNIceCrownObelisk.blp");
      this.AddQuestItem(QuestItemObelisk.create(ControlPoint.ByUnitType(FourCC(n02S))));
      ;;
    }


  }
}
