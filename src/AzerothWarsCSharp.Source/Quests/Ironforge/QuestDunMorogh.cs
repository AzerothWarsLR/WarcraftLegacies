using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Ironforge
{
  public sealed class QuestDunMorogh : QuestData{


    protected override string CompletionPopup => "The Trolls have been defeated, Dun Morogh will join your cause.";

    protected override string CompletionDescription => "Control of all units in Dun Morogh";

    private void GrantDunMorogh(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in DunMorogh
      GroupEnumUnitsInRect(tempGroup, Regions.DunmoroghAmbient2.Rect, null);
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
      GrantDunMorogh(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantDunMorogh(Holder.Player);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Mountain Village", "A small troll skirmish is attacking Dun Morogh. Push them back!", "ReplaceableTextures\\CommandButtons\\BTNIceTrollShadowPriest.blp");
      AddQuestItem(QuestItemKillUnit.create(gg_unit_nith_1625)) ;//Troll
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n014"))));
      AddQuestItem(new QuestItemExpire(1435));
      AddQuestItem(new QuestItemSelfExists());
      
    }


  }
}
