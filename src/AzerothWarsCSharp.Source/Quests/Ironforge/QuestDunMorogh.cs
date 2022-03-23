using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestDunMorogh : QuestData{


    protected override string CompletionPopup => 
      return "The Trolls have been defeated, Dun Morogh will join your cause.";
    }

    protected override string CompletionDescription => 
      return "Control of all units in Dun Morogh";
    }

    private void GrantDunMorogh(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in DunMorogh
      GroupEnumUnitsInRect(tempGroup, gg_rct_DunmoroghAmbient2, null);
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
      GrantDunMorogh(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantDunMorogh(this.Holder.Player);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Mountain Village", "A small troll skirmish is attacking Dun Morogh. Push them back!", "ReplaceableTextures\\CommandButtons\\BTNIceTrollShadowPriest.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nith_1625)) ;//Troll
      this.AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n014"))));
      this.AddQuestItem(new QuestItemExpire(1435));
      this.AddQuestItem(new QuestItemSelfExists());
      ;;
    }


  }
}
