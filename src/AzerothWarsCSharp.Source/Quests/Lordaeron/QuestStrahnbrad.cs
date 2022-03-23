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

    protected override void OnFail( ){
      RescueNeutralUnitsInRect(Regions.StrahnbradUnlock.Rect, Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      RescueNeutralUnitsInRect(Regions.StrahnbradUnlock.Rect, Holder.Player);
    }

    public  QuestStrahnbrad ( ){
      thistype this = thistype.allocate("The Defense of Strahnbrad", "The Strahnbrad is under attack by some brigands, clear them out", "ReplaceableTextures\\CommandButtons\\BTNFarm.blp");
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n01C"))));
      AddQuestItem(new QuestItemExpire(1170));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
