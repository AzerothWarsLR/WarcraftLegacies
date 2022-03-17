using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.Main.Libraries.QuestSystem.UtilityStructs;

namespace AzerothWarsCSharp.Source.RoC.Quests.Ironforge
{
  public class QuestDunMorogh{


    private string operator CompletionPopup( ){
      return "The Trolls have been defeated, Dun Morogh will join your cause.";
    }

    private string operator CompletionDescription( ){
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
          UnitRescue(u, whichPlayer);
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
      tempGroup = null;
    }

    private void OnFail( ){
      this.GrantDunMorogh(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    private void OnComplete( ){
      this.GrantDunMorogh(this.Holder.Player);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Mountain Village", "A small troll skirmish is attacking Dun Morogh. Push them back!", "ReplaceableTextures\\CommandButtons\\BTNIceTrollShadowPriest.blp");
      this.AddQuestItem(QuestItemKillUnit.create(gg_unit_nith_1625)) ;//Troll
      this.AddQuestItem(QuestItemControlPoint.create(ControlPoint.ByUnitType(FourCC(n014))));
      this.AddQuestItem(QuestItemExpire.create(1435));
      this.AddQuestItem(QuestItemSelfExists.create());
      ;;
    }


  }
}
