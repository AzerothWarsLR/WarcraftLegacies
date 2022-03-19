using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Forsaken
{
  public class QuestThePlaguelands{


    protected override string CompletionPopup => 
      return "The ravaged lands of Lordaeron are now under the control of the Forsaken && able to train up to 4 ValFourCC(kyr join their ranks. 500 gold was plundered.";
    }

    protected override string CompletionDescription => 
      return "Enable 4 ValFourCC(kyr to be raised && grants 500 gold";
    }

    protected override void OnComplete(){
      FACTION_FORSAKEN.ModObjectLimit(FourCC(u01V), 2)           ;//Valyr
      AdjustPlayerStateBJ( 500, this.Holder.Player, PLAYER_STATE_RESOURCE_GOLD );
    }


    public  thistype ( ){
      thistype this = thistype.allocate("The Plaguelands", "The ravaged lands of Lordaeron must be conquered by the Forsaken, their survival depends on it", "ReplaceableTextures\\CommandButtons\\BTNNathanosBlightcaller.blp");
      this.AddQuestItem(QuestItemControlLegend.create(LEGEND_NATHANOS, false));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n01F))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n044))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n01H))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n03P))));
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n01M))));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
