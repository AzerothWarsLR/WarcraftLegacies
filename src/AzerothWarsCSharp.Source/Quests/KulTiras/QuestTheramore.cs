using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.QuestSystem;
using AzerothWarsCSharp.MacroTools.QuestSystem.UtilityStructs;
using AzerothWarsCSharp.Source.Libraries;

namespace AzerothWarsCSharp.Source.Quests.KulTiras
{
  public sealed class QuestTheramore : QuestData{

  
    private const int RESEARCH_ID = FourCC("R06K");
  


    private static group theramoreUnits = CreateGroup();

    protected override string CompletionPopup => "A sizeable isle off the coast of Dustwallow Marsh has been colonized && dubbed Theramore, marking the first human settlement to be established on Kalimdor.";

    protected override string CompletionDescription => "Control of all units at Theramore";

    private static void GrantToPlayer(player whichPlayer ){
      unit u;
      while(true){
        u = FirstOfGroup(theramoreUnits);
        if ( u == null){ break; }
        UnitRescue(u, whichPlayer);
        GroupRemoveUnit(theramoreUnits, u);
      }
      DestroyGroup(theramoreUnits);
      u = null;
      theramoreUnits = null;
    }

    private void OnFail( ){
      thistype.GrantToPlayer(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      Holder.ModObjectLimit(RESEARCH_ID, -UNLIMITED);
    }

    protected override void OnComplete(){
      thistype.GrantToPlayer(Holder.Player);
      Holder.ModObjectLimit(RESEARCH_ID, -UNLIMITED);
    }

    private void OnAdd( ){
      Holder.ModObjectLimit(RESEARCH_ID, UNLIMITED);
    }

    public  thistype ( ){
      thistype this = thistype.allocate("Theramore", "The distant lands of Kalimdor remain untouched by human civilization. If the Third War proceeds poorly, it may become necessary to establish a forward base there.", "ReplaceableTextures\\CommandButtons\\BTNHumanArcaneTower.blp");
      AddQuestItem(new QuestItemResearch(RESEARCH_ID, FourCC("h076")));
      AddQuestItem(new QuestItemSelfExists());
      ;;
    }

    private static void onInit( ){
      group tempGroup;
      unit u;
      tempGroup = CreateGroup();
      theramoreUnits = CreateGroup();
      GroupEnumUnitsInRect(tempGroup, Regions.Theramore.Rect, null);
      while(true){
        u = FirstOfGroup(tempGroup);
        if ( u == null){ break; }
        SetUnitInvulnerable(u, true);
        SetUnitOwner(u, Player(PLAYER_NEUTRAL_PASSIVE), true);
        GroupAddUnit(theramoreUnits, u);
        GroupRemoveUnit(tempGroup, u);
      }
      DestroyGroup(tempGroup);
    }


  }
}
