using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public class QuestGrimBatol{

  
    private const int QUEST_RESEARCH_ID = FourCC(R06Y)   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => 
      return "Grim Batol is now under our control, && its military is now free to assist the " + this.Holder.Team.Name + ".";
    }

    protected override string CompletionDescription => 
      return "Control of all units in Grim Batol && able to train Orcish Death Knights";
    }

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_Grim_Batol, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      SetUnitOwner(gg_unit_h01Z_0618, this.Holder.Player, true);
      WaygateActivateBJ( true, gg_unit_n08R_2209 );
      WaygateActivateBJ( true, gg_unit_n08R_2214 );
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_Grim_Batol, this.Holder.Player);
    }

    private void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Cursed Fortress", "The mountain fortress of Grim Batol will be the perfect stronghold for the Twilight hammer clan. It has served well in the past && will do so again.", "ReplaceableTextures\\CommandButtons\\BTNFortressWC2blp");
      this.AddQuestItem(QuestItemLegendDead.create(LEGEND_VAELASTRASZ));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n03X))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n04V))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n09F))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n08T))));
      this.AddQuestItem(QuestItemExpire.create(1428));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
