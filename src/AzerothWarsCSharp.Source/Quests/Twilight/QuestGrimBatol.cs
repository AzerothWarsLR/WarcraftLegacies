using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Twilight
{
  public sealed class QuestGrimBatol : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R06Y")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "Grim Batol is now under our control, && its military is now free to assist the " + Holder.Team.Name + ".";

    protected override string CompletionDescription => "Control of all units in Grim Batol && able to train Orcish Death Knights";

    protected override void OnFail( ){
      RescueNeutralUnitsInRect(Regions.GrimBatol.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      SetUnitOwner(gg_unit_h01Z_0618, Holder.Player, true);
      WaygateActivateBJ( true, gg_unit_n08R_2209 );
      WaygateActivateBJ( true, gg_unit_n08R_2214 );
      RescueNeutralUnitsInRect(Regions.GrimBatol.Rect, Holder.Player);
    }

    protected override void OnAdd( ){
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Cursed Fortress", "The mountain fortress of Grim Batol will be the perfect stronghold for the Twilight hammer clan. It has served well in the past && will do so again.", "ReplaceableTextures\\CommandButtons\\BTNFortressWC2blp");
      AddQuestItem(new QuestItemLegendDead(LEGEND_VAELASTRASZ));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n03X"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n04V"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n09F"))));
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n08T"))));
      AddQuestItem(new QuestItemExpire(1428));
      AddQuestItem(new QuestItemSelfExists());
      ResearchId = QUEST_RESEARCH_ID;
      
    }


  }
}
