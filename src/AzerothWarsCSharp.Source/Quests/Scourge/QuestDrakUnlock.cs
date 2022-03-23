using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public sealed class QuestDrakUnlock : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R08J");
  



    protected override string CompletionPopup => "DrakFourCC(taron Keep is now under the control of the Scourge.";

    protected override string CompletionDescription => "Control of all buildings in DrakFourCC("taron Keep")";

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.DrakUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.DrakUnlock.Rect, this.Holder.Player);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("DrakFourCC("taron Keep", "Drak")taron)s Keep will be the place for an outpost by the sea.", "ReplaceableTextures\\CommandButtons\\BTNUndeadShipyard.blp");
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n030"))));
      this.AddQuestItem(new QuestItemControlLegend(LEGEND_DRAKTHARONKEEP, false));
      this.AddQuestItem(new QuestItemExpire(1140));
      this.AddQuestItem(new QuestItemSelfExists());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
