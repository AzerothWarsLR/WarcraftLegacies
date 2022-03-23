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
          UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    protected override void OnFail( ){
      GrantGoldshire(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantGoldshire(Holder.Player);
    }


    public  QuestGoldshire ( ){
      thistype this = thistype.allocate("The Scourge of Elwynn", "Hogger && his pack have taken over Goldshire, clear them out!", "ReplaceableTextures\\CommandButtons\\BTNGnoll.blp");
      AddQuestItem(QuestItemKillUnit.create(gg_unit_n021_2624)) ;//Hogger
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n00Z"))));
      AddQuestItem(new QuestItemExpire(1335));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
