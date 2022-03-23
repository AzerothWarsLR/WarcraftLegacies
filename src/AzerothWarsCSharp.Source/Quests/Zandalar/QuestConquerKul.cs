using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.Zandalar
{
  public sealed class QuestConquerKul : QuestData{

  
    private const int QUEST_RESEARCH_ID = FourCC("R08D")   ;//This research is given when the quest is completed
  


    protected override string CompletionPopup => "Before setting sails we need to conquer KulFourCC(tiras";

    protected override string CompletionDescription => "Unlock shipyards";

    private string operator FailurePopup( ){
      return "Zandalar has fallen";
    }

    private string operator FailureDescription( ){
      return "You can no longer build shipyards, but you unlock Zulfarrak";
    }

    protected override void OnFail( ){
      unit u;
      group tempGroup;
      tempGroup = CreateGroup();
      GroupEnumUnitsInRect(tempGroup, Regions.Zulfarrak.Rect, null);
      u = FirstOfGroup(tempGroup);
      while(true){
        if ( u == null){ break; }
        if (GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_PASSIVE) || GetOwningPlayer(u) == Player(PLAYER_NEUTRAL_AGGRESSIVE)){
          if (IsUnitType(u, UNIT_TYPE_HERO)){
            KillUnit(u);
          }else {
            UnitRescue(u, Holder.Player);
          }
        }
        GroupRemoveUnit(tempGroup, u);
        u = FirstOfGroup(tempGroup);
      }
      DestroyGroup(tempGroup);
    }

    public  QuestConquerKul ( ){
      thistype this = thistype.allocate("Conquer Boralus", "The KulFourCC("tiran people && their fleet have been a threat to the Zandalari Empire for ages, it is time to put them to rest. ", "ReplaceableTextures\\CommandButtons\\BTNGalleonIcon.blp"");
      AddQuestItem(new QuestItemControlLegend(LEGEND_DAZARALOR, true));
      AddQuestItem(new QuestItemLegendDead(LEGEND_BORALUS));
      ResearchId = QUEST_RESEARCH_ID;
      ;;
    }


  }
}
