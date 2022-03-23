using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Dalaran
{
  public sealed class QuestSouthshore : QuestData{


    protected override string CompletionPopup => "The Murlocs have been defeated, Southshore is safe.";

    protected override string CompletionDescription => "Control of all units in Southshore";

    private void GrantSouthshore(player whichPlayer ){
      group tempGroup = CreateGroup();
      unit u;

      //Transfer all Neutral Passive units in Southshore
      GroupEnumUnitsInRect(tempGroup, Regions.SouthshoreUnlock.Rect, null);
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
      GrantSouthshore(Player(PLAYER_NEUTRAL_AGGRESSIVE));
    }

    protected override void OnComplete(){
      GrantSouthshore(Holder.Player);
    }


    public  thistype ( ){
      thistype this = thistype.allocate("Murloc Troubles", "A small murloc skirmish is attacking Southshore, push them back", "ReplaceableTextures\\CommandButtons\\BTNMurloc.blp");
      AddQuestItem(QuestItemKillUnit.create(gg_unit_nmrm_0204)) ;//Murloc
      AddQuestItem(new QuestItemControlPoint(ControlPoint.GetFromUnitType(FourCC("n08M"))));
      AddQuestItem(new QuestItemExpire(1135));
      AddQuestItem(new QuestItemSelfExists());
      
    }


  }
}
