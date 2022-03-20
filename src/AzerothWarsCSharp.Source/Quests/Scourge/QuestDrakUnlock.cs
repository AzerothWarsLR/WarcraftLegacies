using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using AzerothWarsCSharp.Source.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.Quests.Scourge
{
  public class QuestDrakUnlock{

  
    private const int QUEST_RESEARCH_ID = FourCC(R08J);
  



    protected override string CompletionPopup => 
      return "DrakFourCC(taron Keep is now under the control of the Scourge.";
    }

    protected override string CompletionDescription => 
      return "Control of all buildings in DrakFourCC(taron Keep)";
    }

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_DrakUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_DrakUnlock, this.Holder.Player);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("DrakFourCC(taron Keep", "Drak)taron)s Keep will be the place for an outpost by the sea.", "ReplaceableTextures\\CommandButtons\\BTNUndeadShipyard.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n030))));
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_DRAKTHARONKEEP, false));
      this.AddQuestItem(QuestItemExpire.create(1140));
      this.AddQuestItem(QuestItemSelfExists.create());
      this.ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
