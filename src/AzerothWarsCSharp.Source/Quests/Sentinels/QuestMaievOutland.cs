using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Sentinels
{
  public sealed class QuestMaievOutland : QuestData{



    protected override string CompletionPopup => 

    }

    protected override string CompletionDescription => "Control of MaievFourCC(s Outland outpost && moves Maiev to Outland";

    protected override void OnComplete(){
      SetUnitPosition(LEGEND_MAIEV.Unit, -5252, -27597);
      UnitRemoveAbilityBJ( FourCC("A0J5"), LEGEND_MAIEV.Unit);
      GeneralHelpers.RescueUnitsInGroup(udg_MaievUnlockOutland, this.Holder.Player);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Driven by Vengeance", "Maiev drive for vengeance leads her to chase Illidan all the way to other worlds.", "ReplaceableTextures\\CommandButtons\\BTNMaievArmor.blp");
      this.AddQuestItem(new QuestItemCastSpell(FourCC("A0J5"), true));
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_MAIEV, true));
      
    }


  }
}
