using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Lordaeron
{
  public sealed class QuestStrahnbrad : QuestData{



    protected override string CompletionPopup => "Strahnbrad has been liberated.";

    protected override string CompletionDescription => "Control of all buildings in Strahnbrad";

    private void OnFail( ){
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.StrahnbradUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GeneralHelpers.RescueNeutralUnitsInRect(Regions.StrahnbradUnlock.Rect, this.Holder.Player);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("The Defense of Strahnbrad", "The Strahnbrad is under attack by some brigands, clear them out", "ReplaceableTextures\\CommandButtons\\BTNFarm.blp");
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01C"))));
      this.AddQuestItem(new QuestItemExpire(1170));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
