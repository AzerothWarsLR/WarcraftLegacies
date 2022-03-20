using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public class QuestStrahnbrad{



    protected override string CompletionPopup => 
      return "Strahnbrad has been liberated.";
    }

    protected override string CompletionDescription => 
      return "Control of all buildings in Strahnbrad";
    }

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_StrahnbradUnlock, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(gg_rct_StrahnbradUnlock, this.Holder.Player);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Defense of Strahnbrad", "The Strahnbrad is under attack by some brigands, clear them out", "ReplaceableTextures\\CommandButtons\\BTNFarm.blp");
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.GetFromUnitType(FourCC(n01C))));
      this.AddQuestItem(QuestItemExpire.create(1170));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
