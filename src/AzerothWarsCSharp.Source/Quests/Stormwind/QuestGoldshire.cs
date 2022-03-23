using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Stormwind
{
  public sealed class QuestGoldshire : QuestData{


    protected override string CompletionPopup => "The Gnolls have been defeated, Goldshire is safe.";

    protected override string CompletionDescription => "Control of all units in Goldshire";

    private void GrantGoldshire(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Goldshire
      GroupEnumUnitsInRect(tempGroup, Regions.ElwinForestAmbient.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE)){
          GeneralHelpers.UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void OnFail( ){
      GrantGoldshire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantGoldshire(this.Holder.Player);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("The Scourge of Elwynn", "Hogger && his pack have taken over Goldshire, clear them out!", "ReplaceableTextures\\CommandButtons\\BTNGnoll.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_n021_2624)) ;//Hogger
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00Z"))));
      this.AddQuestItem(new QuestItemExpire(1335));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
