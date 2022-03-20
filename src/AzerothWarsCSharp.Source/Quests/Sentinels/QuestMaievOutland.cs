using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public class QuestMaievOutland{



    protected override string CompletionPopup => 

    }

    protected override string CompletionDescription => 
      return "Control of MaievFourCC(s Outland outpost && moves Maiev to Outland";
    }

    protected override void OnComplete(){
      SetUnitPosition(LEGEND_MAIEV.Unit, -5252, -27597);
      UnitRemoveAbilityBJ( FourCC(A0J5), LEGEND_MAIEV.Unit);
      GeneralHelpers.RescueUnitsInGroup(udg_MaievUnlockOutland, this.Holder.Player);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Driven by Vengeance", "Maiev drive for vengeance leads her to chase Illidan all the way to other worlds.", "ReplaceableTextures\\CommandButtons\\BTNMaievArmor.blp");
      this.AddQuestItem(QuestItemCastSpell.create(FourCC(A0J5), true));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_MAIEV, true));
      ;;
    }


  }
}
